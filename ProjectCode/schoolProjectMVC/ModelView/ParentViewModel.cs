using schoolProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.ModelView
{
    public class ParentViewModel
    {
        public Parent parent { get; set; }

        public List<Parent> parents { get; set; }
    }
}