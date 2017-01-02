using CSharpTeacher.Models;
using CSharpTeacher.Models.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CSharpTeacher.Controllers
{
    public class QuizController : Controller
    {
        private ExamService _examService;

        public QuizController()
        {
            _examService = new ExamService();
        }
        // GET: Quiz
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Quiz1()
        {
            var exam = _examService.GetExam();
            return View(exam);
        }

        public ActionResult Grade(Quiz1 exam)
        {
            var grade = _examService.Grade(exam);
            return View(grade);
        }

        public class ExamService
        {
            public Quiz1 GetExam()
            {
                var exam = new Quiz1() { Id = 100, Name = "MATH EXAM 1" };
                exam.AddQuestion(GetQuestions());

                return exam;
            }

            private IList<Quiz1Question> GetQuestions()
            {
                var questions = new List<Quiz1Question>()
                {
                    new Quiz1Question() { Text = "What is 2+2", Point = 10, Id = 1, OrderNumber = 0},
                    new Quiz1Question() { Text = "What is 5+2", Point = 10, Id =2, OrderNumber = 1},
                    new Quiz1Question() { Text="What is 10+2", Point =5, Id=3, OrderNumber = 2}
                };

                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "2", Id = 1 });
                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "4", Id = 2 });

                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "12", Id = 3 });
                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "7", Id = 4 });

                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "12", Id = 5 });
                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "15", Id = 6 });


                return questions;
            }

            public Quiz1Grade Grade(Quiz1 toBeGradedExam)
            {
                var persistedExam = GetExam();
                var grade = new Quiz1Grade() { Quiz1 = persistedExam };

                foreach (var question in toBeGradedExam.Questions)
                {
                    var persistedQuestion = (from q in persistedExam.Questions
                                             where q.Id == question.Id
                                             select q).SingleOrDefault();

                    if (persistedQuestion != null)
                    {
                        foreach (var choice in question.Choices)
                        {
                            var persistedChoice = (from c in persistedQuestion.Choices
                                                   where c.Id == choice.Id
                                                   select c).SingleOrDefault();

                            // sets the user choice in the actual exam fetched from database! 
                            persistedChoice.IsSelected = true;

                            if (persistedChoice.IsAnswer)
                            {
                                grade.Score += persistedQuestion.Point;
                            }
                        }
                    }
                }

                return grade;
            }
        }
    }
}