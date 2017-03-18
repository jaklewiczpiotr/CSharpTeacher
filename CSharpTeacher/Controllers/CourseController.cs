using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpTeacher.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Threading.Tasks;

namespace CSharpTeacher.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Exercise1(Exercise1ViewModel model, int? a)
        {
            //model.expression = "public class YourName { public string Name {get; set;} public YourName() { Name = \" \"; } } static void Main(string[] args) { new YourName().Name }";
            model.expression = "public class YourName {public string name;}\nstatic void Main(string[] args){\n\nYourName yourName = new YourName();\nyourName.name = \" \";\n\nstring returnName(YourName name)\n{\nreturn name.name;\n}\nreturnName(yourName)\n}";
            return View(model);
        }

        private bool isString(object obj)
        {
            return obj is string;
        }

        private void prepareExercise(Exercise1ViewModel model)
        {
            if (model.expression == null)
            {
                model.expression = " ";
                model.sysAnswer = "Błąd kompilacji, został wpisany niepoprawny kod, spróbuj jeszcze raz.";
            }
            else
            {
                //można jeszcze dopisać Replace Console.WriteLine
                string exp1 = model.expression.Replace("static void Main(string[] args){", " ").Replace("static void Main(string[] args) {", " ");
                exp1 = exp1.TrimEnd('}');
                model.expression = exp1;
                if (model.expression.EndsWith(";")) //poprawić, bo jeśli sie konczy spacja lub /n to nie dziala
                {
                    string exp = model.expression.Remove(model.expression.Length - 1);
                    model.expression = exp;
                    //dalsze rozw if endswith ) zle
                }
            }
        }

        [HttpPost]
        public ActionResult Exercise1(Exercise1ViewModel model)
        {
            prepareExercise(model);
            CsharpResult(model);

            //Do osobnej metody


            if (isString(model.result) && !string.IsNullOrWhiteSpace((string)model.result))
            {
                model.sysAnswer = "Gratulacje !";
                model.isExerciseDone = true;
            }
            //

            return View(model);
        }

        [HttpGet]
        public ActionResult Exercise2(Exercise1ViewModel model, int? a)
        {
            model.expression = "public class PlayWithVariables {public string name;\npublic int age;\npublic bool isSmart;}\nstatic void Main(string[] args){\n\nPlayWithVariables yourData = new PlayWithVariables();\nyourData.name = \" \";\nyourData.age = ;\nyourData.isSmart = ;\n\nobject returnData(PlayWithVariables variables)\n{\nreturn variables.name + \" \" + variables.age + \" \" + variables.isSmart;\n}\nreturnData(yourData)\n}";
            return View(model);
        }

        [HttpPost]
        public ActionResult Exercise2(Exercise1ViewModel model)
        {
            prepareExercise(model);

            CsharpResult(model);

            //Do osobnej metody
            if (model.result != null)
            {
                model.sysAnswer = "Gratulacje !";
                model.isExerciseDone = true;
            }

            else { model.sysAnswer = "Źle !"; }
            //

            return View(model);
        }

        [HttpGet]
        public ActionResult Exercise3(Exercise1ViewModel model, int? a)
        {
            model.expression = "public class PlayWithVariables {public string name;\npublic int age;\npublic bool isMarried;}\nstatic void Main(string[] args){\n\nPlayWithVariables yourData = new PlayWithVariables();\nyourData.name = \" \";\nyourData.age = ;\nyourData.isMarried = ;\n\nobject returnData(PlayWithVariables variables)\n{\nreturn variables.name + \" \" + variables.age + \" \" + variables.isMarried;\n}\nreturnData(yourData)\n}";
            return View(model);
        }

        [HttpPost]
        public ActionResult Exercise3(Exercise1ViewModel model)
        {
            prepareExercise(model);

            CsharpResult(model);

            //Do osobnej metody
            if (model.result != null)
            {
                model.sysAnswer = "Gratulacje !";
                model.isExerciseDone = true;
            }

            else { model.sysAnswer = "Źle !"; }
            //

            return View(model);
        }

        private async Task CsharpResult(Exercise1ViewModel model)
        {
            model.result = CSharpScript.EvaluateAsync(model.expression).Result;
        }

        private async Task CsharpResultV2(Exercise1ViewModel model)
        {
            model.result = CSharpScript.EvaluateAsync(model.expression);
        }
    }
}