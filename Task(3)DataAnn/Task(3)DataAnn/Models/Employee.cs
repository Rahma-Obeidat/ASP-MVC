using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task_3_DataAnn.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 12)]
        public string Fname { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 12)]
        public string LName { get; set; }


        [Required]
        [EmailAddress]
        public string Email { get; set; }


        //ValidationExpression="^(07)[7-9]{1}[0-9]{7}$"
        //[RegularExpression("((079)|(078)|(077)){1}[0-9]{7}" ,ErrorMessage = "Invalid Phone Number")]
        public int Phone { get; set; }


        [Range(18, 50)]
        public int Age { get; set; }


        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Job_Title { get; set; }



        [Required(ErrorMessage = "The Gender field is required.")]
        [RegularExpression("^(Male|Female)$", ErrorMessage = "Invalid Gender")]
        public string Gender { get; set; } 
    }
}