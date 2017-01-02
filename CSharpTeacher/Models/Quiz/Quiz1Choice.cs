using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpTeacher.Models.Quiz
{
    public class Quiz1Choice
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsAnswer { get; set; }
        private Quiz1Question _question = new Quiz1Question();
        public bool IsSelected { get; set; }

        public Quiz1Question Question
        {
            get { return _question; }
            set { _question = value; }
        }

    }
}