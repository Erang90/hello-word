using schoolProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.ModelView
{
    public class StudentViewModel
    {
        public Student student { get; set; }
        public List<Student> students { get; set; } 
    }
}