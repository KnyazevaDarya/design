using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModularHouse.Models
{
    public class Question
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string EmailAddress { get; set; }

        public string QuestionTopic { get; set; }
    }
}