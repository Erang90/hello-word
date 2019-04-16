using schoolProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolProjectMVC.ModelBinders;
using schoolProjectMVC.Dal;
using System.Net.Mail;

namespace schoolProjectMVC.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Load()
        {
            Teacher myTeacher = new Teacher
            {
                FirstName = "Gena",
                LastName = "Kogan",
                TeacherId = "328956537"
            };

            return View("Teacher", myTeacher);
        }

        public ActionResult Login()
        {
            return View();
        }
        //SubmitLogin
        public ActionResult SubmitLogin(Teacher t)
        {
            if (ModelState.IsValid)
            {
                Dal.Dal dal = new Dal.Dal();
                string name = t.FirstName.ToString();
                string id = t.TeacherId.ToString();
                Session["IDValue"] = t.FirstName.ToString();
                Session["PassValue"] = t.TeacherId.ToString();
                List<Teacher> tid = (from x in dal.Teacher where x.TeacherId == id select x).ToList();
                List<Teacher> tname = (from x in dal.Teacher where x.FirstName == name select x).ToList();

                if (tid.Count == 0 || tname.Count == 0)
                {
                    ViewData["errormessage"] = "The Name or TeacherId is not valid";
                    return View("Login", t);
                }
                if (tid[0].TeacherId == id && tname[0].FirstName == name)
                {
                    return View("viewTeacher");
                }
                else
                {
                    ViewData["errormessage"] = "The Name or IDNumber is not valid";
                    return View("Login", t);
                    //return View("Index");
                }
            }
            else
            {
                return View("Index");
            }


        }

        public ActionResult Enter()
        {
            return View(new Teacher());
        }
        [HttpPost]

        //public ActionResult Submit([ModelBinder(typeof(TeacherBinder))] Teacher myTeacher)
        public ActionResult Submit(Teacher myTeacher)
        {
            //Teacher myTeacher = new Teacher();
            //myTeacher.FirstName = Request.Form["FirstName"];
            //myTeacher.LastName = Request.Form["LastName"];
            //myTeacher.TeacherId = Request.Form["TeacherId"];

            if (ModelState.IsValid)
            {
                TeacherDal dal = new TeacherDal();
                dal.Teachers.Add(myTeacher);// in memory adding
                dal.SaveChanges();
                return View("Teacher", myTeacher);
            }
            else
                return View("Enter", myTeacher);

        }
        public ActionResult ForgetPassword()
        {
            return View(new EmployeeNumber());
        }
        public ActionResult ChangePassword(Teacher t)
        {
            if (ModelState.IsValid)
            {
                TeacherDal dal = new TeacherDal();
                t.Password = Request.Form["Password"].ToString();
                dal.SaveChanges();
                return View("SendPassword", t);
            }
            return View(t);

        }
        [HttpPost]
        public ActionResult SendPassword(Teacher t)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("goyeee90@gmail.com");
            mail.To.Add(t.Email);
            mail.Subject = "New Password";
            mail.Body = "Your Password is: " + t.Password;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("goyeee90", "A11223344a");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return View(t);
        }
        [HttpPost]
        public ActionResult Submit2(EmployeeNumber num)
        {
            if (ModelState.IsValid)
            {
                TeacherDal dal = new TeacherDal();
                List<Teacher> l =
                                        (from x in dal.Teachers
                                         where x.TeacherId == num.number
                                         select x).ToList<Teacher>();

                /*Assistant assis = list[0];
                list[0].LastName = "nahmani";
                assdal.SaveChanges();*/
                return View("ChangePassword", l[0]);
            }
            return View("ForgetPassword", new EmployeeNumber());


        }


    }
}