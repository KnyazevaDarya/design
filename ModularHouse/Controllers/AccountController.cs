using ModularHouse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ModularHouse.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginAdmin la)
        {
            if (ModelState.IsValid)
            {
                Admin admin = null;
                using (AdminContext ac = new AdminContext())
                {
                    admin = ac.Admins.FirstOrDefault(u => u.Login == la.Login && u.Password == la.Password);
                }
                if (admin != null)
                {
                    FormsAuthentication.SetAuthCookie(la.Login, true);
                    return RedirectToAction("AddHouse", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль!");
                }
            }
            return View(la);
        }
    }
}