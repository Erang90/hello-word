using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace schoolProjectMVC.Models
{
    public class Assistant
    {
        [Required]
        public string AFirstName { get; set; }

        [Required]
        public string ALastName { get; set; }

        [Required]
        [Key]
        public string AIDNumber { get; set; }
  
        [Required]
        public string AEmployeeNumber { get; set; }

        [Required]
        public string IdStudent { get; set; }

        [Required]
        public string AEmail { get; set; }
        [Required(ErrorMessage = "Password is required felid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password must be 2-50 characters ")]
        public string APassword { get; set; }

    }
}