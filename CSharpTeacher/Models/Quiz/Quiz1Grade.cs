using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpTeacher.Models.Quiz
{
    public class Quiz1Grade
    {
        public double TotalPoints { get; set; }
        public double Score { get; set; }
        public Quiz1 Quiz1 { get; set; }
    }
}