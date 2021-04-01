using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModularHouse.Models
{
    public class HouseContext : DbContext
    {
        public DbSet<House> Houses { get; set; }
    }
}