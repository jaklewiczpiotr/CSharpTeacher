using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpTeacher.Models
{
    public class Exercise1ViewModel
    {
        public string expression { get; set; }
        public string sysAnswer { get; set; }
        public bool isExerciseDone { get; set; } = false;
        public object result { get; set; }
    }
}