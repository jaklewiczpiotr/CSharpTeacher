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
    public class InterpretController : Controller
    {
        // GET: Interpret
        public ActionResult Index()
        {
            return View(new GlobalsViewModel());
        }

        private async void CsharpResult(GlobalsViewModel model)
        {
            model.result = await CSharpScript.EvaluateAsync(model.expression);
        }

        [HttpPost]
        public ActionResult Index(GlobalsViewModel model)
        {
            CsharpResult(model);
            return View(model);
        }
    }
}