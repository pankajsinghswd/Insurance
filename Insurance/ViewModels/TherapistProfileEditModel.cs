using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class TherapistProfileEditModel : BindDropdownList
    {
        public string Id { get; set; }
        [Display(Name = "Full Name")]
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Display(Name = "Mail Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must provide a mobile number")]
        [Display(Name = "Mobile")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Speciality")]
        [Required]
        public string SpecialityIDs { get; set; }
        [Required]
        [Display(Name = "Educational Qualification")]
        public string EducationId { get; set; }
        [Display(Name = "Registration Council")]
        public string RegistrationCouncil { get; set; }
        [Display(Name = "Registration Number")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Registration Year")]
        public string RegistrationYear { get; set; }
        [Required]
        [Display(Name = "Experience (in years)")]
        public string ExperienceInYear { get; set; }
        public string ExistingPhotoPath { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }
}