using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpTeacher.Models.Quiz
{
    public class Quiz1Question
    {
        public int Id { get; set; }
        private IList<Quiz1Choice> _choices = new List<Quiz1Choice>();
        public string Text { get; set; }
        public double Point { get; set; }
        public int OrderNumber { get; set; }

        public IList<Quiz1Choice> Choices
        {
            get { return _choices; }
            set { _choices = value; }
        }

        public void AddChoice(Quiz1Choice choice)
        {
            _choices.Add(choice);
            choice.Question = this;

        }
    }
}