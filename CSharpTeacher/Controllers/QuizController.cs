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
                var exam = new Quiz1() { Id = 100, Name = "Quiz sprawdzający zdobytą wiedzę z pierwszej serii zadań !" };
                exam.AddQuestion(GetQuestions());

                return exam;
            }

            private IList<Quiz1Question> GetQuestions()
            {
                var questions = new List<Quiz1Question>()
                {
                    new Quiz1Question() { Text = "Co to jest klasa ?", Point = 1, Id = 1, OrderNumber = 0},
                    new Quiz1Question() { Text = "Co to jest obiekt ?", Point = 1, Id =2, OrderNumber = 1},
                    new Quiz1Question() { Text="Zaznacz poprawną deklarację stworzenia instancji klasy", Point =1, Id=3, OrderNumber = 2},
                    new Quiz1Question() { Text="Co to jest metoda ?", Point =1, Id=4, OrderNumber = 3},
                    new Quiz1Question() { Text="Która z podanych wartości może być przechowywana jako typ int ?", Point =1, Id=5, OrderNumber = 4},
                    new Quiz1Question() { Text="Która z podanych wartości może być przechowywana jako typ bool ?", Point =1, Id=6, OrderNumber = 5},
                    new Quiz1Question() { Text="Która z podanych wartości może być przechowywana jako typ string ?", Point =1, Id=7, OrderNumber = 6},
                    new Quiz1Question() { Text="Do czego służy słowo kluczowe \"return\" znajdujące się wewnątrz metody ?", Point =1, Id=8, OrderNumber = 7},
                };

                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to instancja jakiegoś obiektu.", Id = 1 });
                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to liczba zapisana w systemie szesnastkowym.", Id = 2 });
                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = true, Text =  "Jest to wzorzec na podstawie którego można tworzyć obiekty.", Id = 3 });
                questions[0].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to inna nazwa języka programowania c#.", Id = 4 });

                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to inna nazwa metody.", Id = 5 });
                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "jest to inna nazwa typu int.", Id = 6 });
                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to liczba zapisana w systemie binarnym.", Id = 7 });
                questions[1].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "Jest to instancja jakiejś klasy.", Id = 8 });

                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "Klasa nazwa_obiektu = new Klasa();", Id = 9 });
                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "int Klasa = \"Klasa;\"", Id = 10 });
                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "bool Klasa = true;", Id = 11});
                questions[2].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "return Klasa;", Id = 12 });

                questions[3].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "Jest to funkcja znajdująca się wewnątrz klasy.", Id = 13 });
                questions[3].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to instancja klasy.", Id = 14 });
                questions[3].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to jeden z modyfikatorów dostępu", Id = 15 });
                questions[3].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Jest to jeden z typów podstawowych.", Id = 16 });

                questions[4].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "false", Id = 17 });
                questions[4].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "true", Id = 18 });
                questions[4].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "lalalala", Id = 19 });
                questions[4].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "20934", Id = 20 });

                questions[5].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "true", Id = 21 });
                questions[5].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "0x56", Id = 22 });
                questions[5].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Andrzej", Id = 23 });
                questions[5].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "-345", Id = 24 });

                questions[6].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "456723", Id = 25 });
                questions[6].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "0", Id = 26 });
                questions[6].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "Janusz Kowalski", Id = 27 });
                questions[6].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "false", Id = 28 });

                questions[7].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Do tworzenia instancji klasy", Id = 29 });
                questions[7].AddChoice(new Quiz1Choice() { IsAnswer = true, Text = "Do zwracania wartości", Id = 30 });
                questions[7].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Do dodawania dwóch liczb całkowitych", Id = 31 });
                questions[7].AddChoice(new Quiz1Choice() { IsAnswer = false, Text = "Do deklaracji jakiegoś konkretnego typu", Id = 32 });

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