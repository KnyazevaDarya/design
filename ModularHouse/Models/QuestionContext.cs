using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ModularHouse.Models
{
    public class QuestionContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
    }
}