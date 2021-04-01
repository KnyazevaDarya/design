using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ModularHouse.Models
{
    public class House
    {
        public int Id { get; set; }

        [DisplayName("Название дома")]
        public string Name { get; set; }

        [DisplayName("Изображение 1")]
        public byte[] Image1 { get; set; }

        [DisplayName("Изображение 2")]
        public byte[] Image2 { get; set; }

        [DisplayName("Изображение 3")]
        public byte[] Image3 { get; set; }

        [DisplayName("Изображение 4")]
        public byte[] Image4 { get; set; }

        [DisplayName("Изображение 5")]
        public byte[] Image5 { get; set; }

        [DisplayName("Жилая площадь дома")]
        public float ResidentialSquare { get; set; }

        [DisplayName("Общая площадь дома")]
        public float TotalSquare { get; set; }

        [DisplayName("Длина главного фасада")]
        public float MainFacadeLength { get; set; }

        [DisplayName("Длина бокового фасада")]
        public float SideFacadeLength { get; set; }

        [DisplayName("Этажность")]
        public int NumberOfStoreys { get; set; }

        [DisplayName("Количество Комнат")]
        public int Rooms { get; set; }

        [DisplayName("Количество Санузлов")]
        public int Bathrooms { get; set; }

        [DisplayName("Стоимость эконом комплектации")]
        public int EconomyConfigurationCost { get; set; }

        [DisplayName("Стоимость базовой комплектации ")]
        public int BasicConfigurationCost { get; set; }

        [DisplayName("Стоимость средней комплектации")]
        public int AverageConfigurationCost { get; set; }

        [DisplayName("Стоимость люкс комплектации")]
        public int LuxuryConfigurationCost { get; set; }
    }
}