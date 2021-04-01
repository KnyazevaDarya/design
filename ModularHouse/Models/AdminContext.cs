using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModularHouse.Models
{
    public class AdminContext: DbContext
    {
        public AdminContext() :
            base("DefaultConnetions")
        { }

        public DbSet<Admin> Admins { get; set; }
    }
}