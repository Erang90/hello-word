using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolProjectMVC.Controllers;
using Microsoft.CSharp.RuntimeBinder;

namespace SchoolProjectTest
{
    [TestClass]
    public class AssistantControllerTest
    {
        [TestMethod]
        public void Login()
        {
            AssistantController controller = new AssistantController();


            ViewResult result = controller.Login() as ViewResult;

            //var controller = new AssistantController();
            //var result = controller.Login() as ViewResult;
            Assert.AreEqual("NOT", result.ViewBag.Message);
        }
    }
}
