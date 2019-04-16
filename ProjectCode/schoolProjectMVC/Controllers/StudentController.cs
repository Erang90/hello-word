using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using schoolProjectMVC.Dal;
using schoolProjectMVC.Models;
using schoolProjectMVC.ModelView;

namespace schoolProjectMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Load()
        {
            Student myStudent = new Student
            {
                SFirstName = "Gena",
                SLastName = "Kogan",
                SIdNumber = "328956537"
             
            };
            return View("Student",myStudent);
        }
        public ActionResult ShowSearch()
        {
            StudentViewModel std = new StudentViewModel();
            std.students = new List<Student>();
            return View("SearchStudent", std);
        }

        public ActionResult SearchStudent()
        {
            StudentDal dal = new StudentDal();
            string searchValue = Request.Form["SFirstName"];
            List<Student> objStudent =
                (from x in dal.students
                 where x.SFirstName.Contains(searchValue)
                 select x).ToList<Student>();
            StudentViewModel std = new StudentViewModel();
            std.students = objStudent;
            return View(std);
        }





        public ActionResult StudentEnter()
        {
            StudentDal dal = new StudentDal();
            List<Student> objStudent = dal.students.ToList<Student>();
            StudentViewModel std = new StudentViewModel();
            std.student = new Student();
            std.students = objStudent;

            //StudentViewModel std = new StudentViewModel();
            //std.student = new Student();
            //std.students = new List<Student>();
            return View(std);
        }
        public ActionResult Submit()
        {

            StudentViewModel std = new StudentViewModel();
            Student objStudent = new Student();
            objStudent.SFirstName = Request.Form["student.SFirstName"].ToString();
            objStudent.SLastName = Request.Form["student.SLastName"].ToString();
            objStudent.SIdNumber = Request.Form["student.SIdNumber"].ToString();
            objStudent.SAssistantEmployeeNumber = Request.Form["student.SAssistantEmployeeNumber"].ToString();
            objStudent.SIDNumberOfParent = Request.Form["student.SIDNumberOfParent"].ToString();
            StudentDal dal = new StudentDal();

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
                dal.students.Add(objStudent);// in memory adding
                dal.SaveChanges();
                std.student = new Student();
            }
            //else
            //    return View("Enter", myAssistant);
            else
                std.student = objStudent;
            std.students = dal.students.ToList<Student>();
            return View("StudentEnter", std);

        }

    }
}