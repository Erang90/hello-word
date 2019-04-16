using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace schoolProjectMVC.Models
{
    public class Student
    {
        [Required(ErrorMessage = "First name is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "First name must to contain 2-50 letters")]
        public string SFirstName { get; set; }

       [Required(ErrorMessage = "Last name is required felid")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Last name must to contain 2-50 letters")]
        public string SLastName { get; set; }

        [Key]
        [Required(ErrorMessage = "Student ID number is required felid")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Student ID number must be 4 digits")]
        public string SIdNumber { get; set; }

        [Required(ErrorMessage = "Assistant employee number is required felid")]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Assistant employee number must be 4 digits")]
        public string SAssistantEmployeeNumber { get; set; }

        [Required(ErrorMessage = "Parent ID number is required felid")]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "Parent ID number must be 9 digits")]
        public string SIDNumberOfParent { get; set; }
    }
}