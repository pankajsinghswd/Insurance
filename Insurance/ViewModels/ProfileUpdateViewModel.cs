using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class ProfileUpdateViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a mobile number")]
        [Display(Name = "Mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid mobile number")]
        public string Mobile { get; set; }
        [Required(ErrorMessage = "You must provide at least one Speciality")]
        public string SpecialityIDs { get; set; }
        [Required]
        public string EducationId { get; set; }
        [Required]
        public string CollegeName { get; set; }
        [Required]
        public string PassingYear { get; set; }
        public string RegistrationDetails { get; set; }
        [Required]
        public string ExperienceInYear { get; set; }
        [Required]
        public string IFormFile { get; set; }
        [Required]
        public string Timing { get; set; }
        public string AboutDoctor { get; set; }
        public string CreatedBy { get; set; }
    }
}