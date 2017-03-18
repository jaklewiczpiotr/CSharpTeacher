using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharpTeacher;
using CSharpTeacher.Controllers;
using CSharpTeacher.Models;

namespace CSharpTeacher.Tests.Controllers
{
    class CourseControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            CourseController controller = new CourseController();

            Exercise1ViewModel model = new Exercise1ViewModel();
            model.expression = "aa";


            controller.Exercise1(model, 0);
            // Act
            Assert.AreEqual(model.result is String, model.result);
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }
    }
}
