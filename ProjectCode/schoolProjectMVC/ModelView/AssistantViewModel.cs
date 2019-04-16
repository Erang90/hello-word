using schoolProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.ModelView
{
    public class AssistantViewModel
    {
        public Assistant assistant { get; set; }

        public List<Assistant> assistants { get; set; }
    }
}