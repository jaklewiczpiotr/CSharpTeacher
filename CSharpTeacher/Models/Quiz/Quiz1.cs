using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CSharpTeacher.Models.Quiz
{
    public class Quiz1
    {
        public int Id { get; set; }
        private IList<Quiz1Question> _questions = new List<Quiz1Question>();
        public string Name { get; set; }

        public IList<Quiz1Question> Questions
        {
            get { return _questions; }
            set { _questions = value; }
        }

        public void AddQuestion(IList<Quiz1Question> questions)
        {
            foreach (var question in questions)
            {
                AddQuestion(question);
            }
        }

        public void AddQuestion(Quiz1Question question)
        {
            _questions.Add(question);
        }

        public double TotalPoints
        {
            get
            {
                return (from q in _questions
                        select q.Point).Sum();
            }
        }
    }
}