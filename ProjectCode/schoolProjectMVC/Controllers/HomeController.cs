using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schoolProjectMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.CurrentTime1 = DateTime.Now.ToString();
            //ViewData["CurrentTime"] = DateTime.Now.ToString();
            TempData["CurrentTime"] = DateTime.Now.ToString();
            Session["CurrentTime"] = DateTime.Now.ToString();
            //return RedirectToAction("ShowHomePage", "Home");
            return View();
        }

        //LoginChoose
        public ActionResult LoginChoose()
        {
            return View();

        }

        public ActionResult ShowHomePage()
        {
            //ViewData["CurrentTime"] = DateTime.Now.ToString();

            return View();
        }
        public ActionResult KeepDataExample()
        {
            TempData["testing"] = "This is testing";
            return View();
        }
    }
}