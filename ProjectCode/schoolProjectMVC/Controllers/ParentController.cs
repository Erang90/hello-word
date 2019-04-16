using schoolProjectMVC.Dal;
using schoolProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using schoolProjectMVC.ModelView;

namespace schoolProjectMVC.Controllers
{
    public class ParentController : Controller
    {
        // GET: Parent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ShowSearch()
        {
            ParentViewModel par = new ParentViewModel();
            par.parents = new List<Parent>();
            return View("SearchParents", par);
        }

        public ActionResult SearchParents()
        {
            ParentDal dal = new ParentDal();
            string searchValue = Request.Form["PFirstName"];
            List<Parent> objParent =
                (from x in dal.parents
                 where x.PFirstName.Contains(searchValue)
                 select x).ToList<Parent>();
            ParentViewModel par = new ParentViewModel();
            par.parents = objParent;
            return View(par);
        }



        //public ActionResult ParentEnter()
        //{
        //    ParentViewModel prn = new ParentViewModel();
        //    prn.parent = new Parent();
        //    prn.parents = new List<Parent>();
        //    return View(prn);
        //}
        public ActionResult Submit()
        {

            ParentViewModel par = new ParentViewModel();
            Parent objParent = new Parent();
            objParent.PFirstName = Request.Form["parent.PFirstName"].ToString();
            objParent.PLastName = Request.Form["parent.PLastName"].ToString();
            objParent.PIdNumber = Request.Form["parent.PIdNumber"].ToString();
            objParent.PEmail = Request.Form["parent.PEmail"].ToString();
            objParent.PPassword = Request.Form["parent.PPassword"].ToString();
            objParent.PStudentIdNumber = Request.Form["parent.PStudentIdNumber"].ToString();
            objParent.PAssistantEmployeeNumber = Request.Form["parent.PAssistantEmployeeNumber"].ToString();
            ParentDal dal = new ParentDal();

            //if (ModelState.IsValid)
            //    return View("Student", stud);
            //else
            //    return View("StudentEnter", stud);

            if (ModelState.IsValid)
            {
                //AssistantDal dal = new AssistantDal();
                //dal.Assistants.Add(myAssistant);// in memory adding
                //dal.SaveChanges();
                //return View("Assistant", myAssistant);
                dal.parents.Add(objParent);// in memory adding
                dal.SaveChanges();
                par.parent = new Parent();
            }
            //else
            //    return View("Enter", myAssistant);
            else
                par.parent = objParent;
            par.parents = dal.parents.ToList<Parent>();
            return View("ParentEnter", par);


        }

        public ActionResult ParentEnter()
        {

            ParentDal dal = new ParentDal();
            List<Parent> objParent = dal.parents.ToList<Parent>();
            ParentViewModel std = new ParentViewModel();
            std.parent = new Parent();
            std.parents = objParent;
            return View(std);
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ForgetPassword()
        {
            return View(new EmployeeNumber());
        }
        public ActionResult ChangePassword(Parent p)
        {
            if (ModelState.IsValid)
            {
                ParentDal dal = new ParentDal();
                p.PPassword = Request.Form["Password"].ToString();
                dal.SaveChanges();
                return View("SendPassword", p);
            }
            return View(p);

        }
        [HttpPost]
        public ActionResult SendPassword(Parent p)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("goyeee90@gmail.com");
            mail.To.Add(p.PEmail);
            mail.Subject = "New Password";
            mail.Body = "Your Password is: " + p.PPassword;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("goyeee90", "A11223344a");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return View(p);
        }
        [HttpPost]
        public ActionResult Submit2(EmployeeNumber num)
        {
            if (ModelState.IsValid)
            {
                ParentDal dal = new ParentDal();
                List<Parent> l =
                                        (from x in dal.parents
                                         where x.PIdNumber == num.number
                                         select x).ToList<Parent>();

                /*Assistant assis = list[0];
                list[0].LastName = "nahmani";
                assdal.SaveChanges();*/
                return View("ChangePassword", l[0]);
            }
            return View("ForgetPassword", new EmployeeNumber());


        }

    }
}