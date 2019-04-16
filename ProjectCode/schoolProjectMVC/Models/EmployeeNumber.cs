using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace schoolProjectMVC.Models
{
    public class EmployeeNumber
    {
        [Required (ErrorMessage = "EmployeeNumber is required felid")]
        [RegularExpression ("^[0-9]{9}$", ErrorMessage = "Employee Number Must be 9 digits")]
        public string number { get; set; }
    }
    
} 