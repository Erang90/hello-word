using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.Models
{
    public class Parent
    {
        [Required(ErrorMessage = "First name is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "First name must to contain 2-50 letters")]
        public string PFirstName { get; set; }

        [Required(ErrorMessage = "Last name is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last name must to contain 2-50 letters")]
        public string PLastName { get; set; }

        [Key]
        [Required(ErrorMessage = "ID is required felid")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "ID Number Must be 9 digits")]
        public string PIdNumber { get; set; }

        [Required(ErrorMessage = "Email is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Email adress must be 2-50 characters ")]
        public string PEmail { get; set; }

        [Required(ErrorMessage = "Password is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Password must be 2-50 characters ")]
        public string PPassword { get; set; }

        [Required(ErrorMessage = "Student number is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Password must be 2-50 characters ")]
        public string PStudentIdNumber { get; set; }

        [Required(ErrorMessage = "Assistant employee number is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Password must be 2-50 characters ")]
        public string PAssistantEmployeeNumber { get; set; }

    }
}