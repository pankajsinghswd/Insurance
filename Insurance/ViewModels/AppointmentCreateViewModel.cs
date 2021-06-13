using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class AppointmentCreateViewModel
    {
        [Display(Name = "First Name"), Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string DOB { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [Display(Name = "Type Of Therapist")]
        public string TypeOfTherapist { get; set; }
        [Required]
        public string Date { get; set; }
        public string MotherName { get; set; }
        [Required]
        public string FatherName { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        public string Mobile { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }
        [Required]
        [Display(Name = "Type Of Cunsultation")]
        public string TypeOfCunsultation { get; set; }
        [Display(Name = "Therapist"), Required]
        public string Therapist { get; set; }
        public List<SelectListItem> TherapistList { get; set; }

    }
}