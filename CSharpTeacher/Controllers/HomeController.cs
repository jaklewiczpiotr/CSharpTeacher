using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CSharpTeacher.Models;
using System.Web.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.Threading.Tasks;

namespace CSharpTeacher.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        private void CsharpResult(GlobalsViewModel model)
        {
            model.result = CSharpScript.EvaluateAsync(model.expression).Result;
        }

        [HttpPost]
        public ActionResult Contact(GlobalsViewModel model)
        {
            CsharpResult(model);
            return View(model);
        }
        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View(new GlobalsViewModel());
        }
    }
}