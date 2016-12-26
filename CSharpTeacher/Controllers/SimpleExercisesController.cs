using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CSharpTeacher.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading.Tasks;

namespace CSharpTeacher.Controllers
{
    public class SimpleExercisesController : Controller
    {
        // GET: SimpleExercises
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Exercise1(Exercise1ViewModel model, int? a)
        {
            model.expression = "string metoda(****** napis) { ****** napis; } metoda(\"hehe\")";
            //model.expression = "using System;                                                    namespace ConsoleApplication {                                    class Program {                                                     string metoda(****** napis;) { ****** napis; }           static void Main(string[] args){                                                          metoda(\"hehe\") } } }";
            return View(model);
        }

        [HttpPost]
        public ActionResult Exercise1(Exercise1ViewModel model)
        {
            CsharpResult(model);

            //Do osobnej metody

            //model.result.ToString().Replace("using System;                                                    namespace ConsoleApplication {                                    class Program {                                                     ", "").Replace("           static void Main(string[] args){                                                          ", "").Replace(" } } }", "");
            
            if (string.Equals(model.result, "hehe"))
            {
                model.sysAnswer = "Gratulacje !";
                model.isExerciseDone = true;
            }

            else if (!string.Equals(model.result, "hehe")) { model.sysAnswer = "Źle !"; }
            //

            return View(model);
        }

        [HttpGet]
        public ActionResult Exercise2(Exercise1ViewModel model, int? a)
        {
            model.expression = "int metoda(int a, *** b) { ****** a + b; } metoda(10,40)";
            return View(model);
        }

        [HttpPost]
        public ActionResult Exercise2(Exercise1ViewModel model)
        {
            if (model.expression.EndsWith(";"))
            {
                string exp = model.expression.Remove(model.expression.Length - 1);
                model.expression = exp;
                //dalsze rozw if endswith ) zle
            }

            CsharpResult(model);

            //Do osobnej metody
            if (int.Equals(model.result, 50))
            {
                model.sysAnswer = "Gratulacje !";
                model.isExerciseDone = true;
            }

            else if (!int.Equals(model.result, 50)) { model.sysAnswer = "Źle !"; }
            //

            return View(model);
        }

        private async Task CsharpResult(Exercise1ViewModel model)
        {
            model.result = await CSharpScript.EvaluateAsync(model.expression);
        }

        //private void CsharpResult(Exercise1ViewModel model)
        //{
        //     model.result = CSharpScript.EvaluateAsync("public class ScriptedClass { public string HelloWorld {get; set;} public ScriptedClass(){ HelloWorld = \"Hello ros\"; }} new ScriptedClass().HelloWorld").Result;
        //    // CSharpScript.RunAsync("new ScriptedClass().HelloWorld");
        //}

    }
}