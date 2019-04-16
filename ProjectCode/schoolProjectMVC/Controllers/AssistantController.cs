using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolProjectMVC.Models;
using schoolProjectMVC.Dal;
using schoolProjectMVC.ModelView;
using System.Net.Mail;

namespace schoolProjectMVC.Controllers
{
    public class AssistantController : Controller
    {
        public string MailCodeGenerated { get; private set; }
        public object CurrentPatient { get; private set; }
        // GET: Assistant
        public ActionResult Enter()
        {
            AssistantDal dal = new AssistantDal();
            List<Assistant> objAssistant = dal.Assistants.ToList<Assistant>();
            AssistantViewModel avm = new AssistantViewModel();
            avm.assistant = new Assistant();
            avm.assistants = objAssistant;
            //AssistantDal dal = new AssistantDal();
            
            return View(avm);
           // return View(new Assistant());
        }
        public ActionResult ShowSearch()
        {
            AssistantViewModel avm = new AssistantViewModel();
            avm.assistants = new List<Assistant>();
            return View("SearchAssistants",avm);
        }

        public ActionResult Login()
        {
            ViewBag.Message = "NOT";
            return View();
        }

        public ActionResult SubmitLogin(Assistant a)
        {
            if (ModelState.IsValid)
            {
                Dal.Dal dal = new Dal.Dal();
                string name = a.AFirstName.ToString();
                string id = a.AIDNumber.ToString();
                Session["AFirstName"] = a.AFirstName.ToString();
                Session["AIDNumber"] = a.AIDNumber.ToString();
                List<Assistant> tid = (from x in dal.Assistant where x.AIDNumber == id select x).ToList();
                List<Assistant> tname = (from x in dal.Assistant where x.AFirstName == name select x).ToList();

                if (tid.Count == 0 || tname.Count == 0)
                {
                    ViewData["errormessage"] = "The Name or IDNumber is not valid";
                    return View("Login", a);
                }
                if (tid[0].AIDNumber == id && tname[0].AFirstName == name)
                {
                    return View("viewAssistant");
                }
                else
                {
                    ViewData["errormessage"] = "The Name or IDNumber is not valid";
                    return View("Login", a);
                    //return View("Index");
                }
            }
            else
            {
                return View("Index");
            }


        }

        public ActionResult SearchAssistants()
        {
            AssistantDal dal = new AssistantDal();
            string searchValue = Request.Form["txtFirstName"];
            List<Assistant> objAssistant =
                (from x in dal.Assistants
                 where x.AFirstName.Contains(searchValue)
                 select x).ToList<Assistant>();
            AssistantViewModel avm = new AssistantViewModel();
            avm.assistants = objAssistant;
            return View(avm);
        }
        [HttpPost]
           
        public ActionResult Submit()
        {
            AssistantViewModel avm = new AssistantViewModel();
            Assistant objAssistant = new Assistant();
            objAssistant.AFirstName = Request.Form["assistant.AFirstName"].ToString();
            objAssistant.ALastName = Request.Form["assistant.ALastName"].ToString();
            objAssistant.AIDNumber = Request.Form["assistant.AIDNumber"].ToString();
            objAssistant.AEmployeeNumber = Request.Form["assistant.AEmployeeNumber"].ToString();
            objAssistant.IdStudent = Request.Form["assistant.IdStudent"].ToString();
            objAssistant.AEmail = Request.Form["assistant.AEmail"].ToString();
            objAssistant.APassword = Request.Form["assistant.APassword"].ToString();
            AssistantDal dal = new AssistantDal();



            if (ModelState.IsValid)
            {
                //AssistantDal dal = new AssistantDal();
                //dal.Assistants.Add(myAssistant);// in memory adding
                //dal.SaveChanges();
                //return View("Assistant", myAssistant);
                dal.Assistants.Add(objAssistant);// in memory adding
                dal.SaveChanges();
                avm.assistant = new Assistant();
            }
            //else
            //    return View("Enter", myAssistant);
            else
                avm.assistant = objAssistant;
            avm.assistants = dal.Assistants.ToList<Assistant>();
            return View("Enter", avm);
        }
        public ActionResult ForgetPassword()
        {
            return View(new EmployeeNumber());
        }
        public ActionResult ChangePassword(Assistant a)
        {
            if (ModelState.IsValid)
            {
                AssistantDal dal = new AssistantDal();
                a.APassword = Request.Form["Password"].ToString();
                dal.SaveChanges();
                return View("SendPassword", a);
            }
            return View(a);

        }
        [HttpPost]
        public ActionResult SendPassword(Assistant a)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("goyeee90@gmail.com");
            mail.To.Add(a.AEmail);
            mail.Subject = "New Password";
            mail.Body = "Your Password is: " + a.APassword;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("goyeee90", "A11223344a");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return View(a);
        }
        [HttpPost]
        public ActionResult Submit2(EmployeeNumber num)
        {
            if (ModelState.IsValid)
            {
                AssistantDal assdal = new AssistantDal();
                List<Assistant> l =
                                        (from x in assdal.Assistants
                                         where x.AEmployeeNumber == num.number
                                         select x).ToList<Assistant>();

                /*Assistant assis = list[0];
                list[0].LastName = "nahmani";
                assdal.SaveChanges();*/
                return View("ChangePassword", l[0]);
            }
            return View("ForgetPassword", new EmployeeNumber());


        }


    }

}