using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace schoolProjectMVC.Models
{
    public class Teacher
    {
        [Required]
        //[StringLength(50, MinimumLength = 2)]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "Please enter Name")]
        public string FirstName { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Lenght must be between 2 and 50 characters")]
        public string LastName { get; set; }
        [Key]
        [Required]
        [RegularExpression("^[0-9]{4}$", ErrorMessage = "Teacher number should contain 4 digits")]
        public string TeacherId { get; set; }
        [Required(ErrorMessage = "Password is required felid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Password must be 2-50 characters ")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required felid")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Email adress must be 2-50 characters ")]
        public string Email { get; set; }

        //public string TeacherMail { get; set; }
    }
}