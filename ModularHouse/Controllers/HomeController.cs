using ModularHouse.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModularHouse.Controllers
{
    public class HomeController : Controller
    {
        HouseContext hc = new HouseContext();
        QuestionContext qc = new QuestionContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        #region О компании + форма с вопросом
        public ActionResult About()
        {
            return View();
        }
        public ActionResult _FormQuestion(Question question)
        {
            qc.Questions.Add(question);
            qc.SaveChanges();

            ViewBag.Message = "Ваш вопрос отправлен! Мы постараемся как можно скорее Вам ответить";

            return PartialView();
        }
        #endregion

        #region Страница с вопросами клиентов
        [Authorize]
        public ActionResult ViewQuestion()
        {
            return View(qc.Questions);
        }
        [HttpPost]
        public ActionResult _ViewQuestion(string id)
        {
            int Id = Convert.ToInt32(id);
            Question question = qc.Questions.Find(Id);
            if (question != null)
            {
                qc.Questions.Remove(question);
                qc.SaveChanges();
            }
            return PartialView(qc.Questions);
        }
        #endregion

        #region Каталог домов
        public ActionResult Catalog()
        {
            return View(hc.Houses);
        }
        public ActionResult _CatalogOfHouses(string dropdown_choice, bool? checkbox1_big, bool? checkbox2_small)
        {
            int type = Convert.ToInt32(dropdown_choice);
            if (type == 1)
            {
                if (checkbox1_big == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare > 99 && hc.Rooms > 2 && hc.Bathrooms > 1).OrderBy(hc => hc.EconomyConfigurationCost));
                else if (checkbox2_small == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare < 100).OrderBy(hc => hc.EconomyConfigurationCost));
                else return PartialView(hc.Houses.OrderBy(hc => hc.EconomyConfigurationCost));
            }
            else if (type == 2)
            {
                if (checkbox1_big == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare > 99 && hc.Rooms > 2 && hc.Bathrooms > 1).OrderByDescending(hc => hc.EconomyConfigurationCost));
                else if (checkbox2_small == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare < 100).OrderByDescending(hc => hc.EconomyConfigurationCost));
                else return PartialView(hc.Houses.OrderByDescending(hc => hc.EconomyConfigurationCost));
            }
            else
            {
                if (checkbox1_big == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare > 99 && hc.Rooms > 2 && hc.Bathrooms > 1));
                else if (checkbox2_small == true)
                    return PartialView(hc.Houses.Where(hc => hc.ResidentialSquare < 100));
                else
                {
                    return PartialView(hc.Houses);
                }

            }
        }

        // Просмотр самого дома
        [HttpGet]
        public ActionResult ViewHouse(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            House house = hc.Houses.Find(id);
            if (house != null)
            {
                return View(house);
            }
            return HttpNotFound();
        }
        #endregion

        #region Добавление дома
        [Authorize]
        public ActionResult AddHouse()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddHouse(House house, HttpPostedFileBase uI1, HttpPostedFileBase uI2, HttpPostedFileBase uI3,
            HttpPostedFileBase uI4, HttpPostedFileBase uI5)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in hc.Houses)
                {
                    if (item.Name == house.Name)
                    {
                        ViewBag.Message = "Дом с таким именем уже существует";
                        return View();
                    }
                }
            }
            if (ModelState.IsValid && uI1 != null && uI2 != null && uI3 != null && uI4 != null && uI5 != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(uI1.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI1.ContentLength);
                }
                // установка массива байтов
                house.Image1 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI2.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI2.ContentLength);
                }
                // установка массива байтов
                house.Image2 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI3.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI3.ContentLength);
                }
                // установка массива байтов
                house.Image3 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI4.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI4.ContentLength);
                }
                // установка массива байтов
                house.Image4 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI5.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI5.ContentLength);
                }
                // установка массива байтов
                house.Image5 = imageData;


                hc.Houses.Add(house);
                hc.SaveChanges();

                return RedirectToAction("AddHouse");
            }
            ViewBag.Message = "Необходимо выбрать все изображения";
            return View(house);
        }
        #endregion

        #region Удаление дома
        [Authorize]
        public ActionResult DeleteHouse()
        {
            return View(hc.Houses);
        }
        [HttpPost]
        public ActionResult _DeleteHouse(string id)
        {
            int Id = Convert.ToInt32(id);
            House house = hc.Houses.Find(Id);
            if (house != null)
            {
                hc.Houses.Remove(house);
                hc.SaveChanges();
            }
            return PartialView(hc.Houses);
        }
        #endregion

        #region Редактирование дома
        [Authorize]
        public ActionResult CatalogEditHouse()
        {
            return View(hc.Houses);
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditHouse(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            House house = hc.Houses.Find(id);
            if (house != null)
            {
                return View(house);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditHouse(House house, HttpPostedFileBase uI1, HttpPostedFileBase uI2, HttpPostedFileBase uI3,
            HttpPostedFileBase uI4, HttpPostedFileBase uI5)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in hc.Houses)
                {
                    if (item.Name == house.Name)
                    {
                        ViewBag.Message = "Дом с таким именем уже существует";
                        return View();
                    }
                }
            }
            if (ModelState.IsValid && uI1 != null && uI2 != null && uI3 != null && uI4 != null && uI5 != null)
            {
                byte[] imageData;
                using (var binaryReader = new BinaryReader(uI1.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI1.ContentLength);
                }
                // установка массива байтов
                house.Image1 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI2.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI2.ContentLength);
                }
                // установка массива байтов
                house.Image2 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI3.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI3.ContentLength);
                }
                // установка массива байтов
                house.Image3 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI4.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI4.ContentLength);
                }
                // установка массива байтов
                house.Image4 = imageData;

                imageData = null;
                using (var binaryReader = new BinaryReader(uI5.InputStream))
                {
                    imageData = binaryReader.ReadBytes(uI5.ContentLength);
                }
                // установка массива байтов
                house.Image5 = imageData;

                House _house = hc.Houses.Find(house.Id);
                hc.Houses.Remove(_house);
                hc.SaveChanges();

                hc.Houses.Add(house);
                hc.SaveChanges();

                return RedirectToAction("CatalogEditHouse");
            }
            ViewBag.Message = "Необходимо выбрать все изображения";
            return View(house);
        }
        #endregion
    }
}