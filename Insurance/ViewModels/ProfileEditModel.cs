﻿using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class ProfileEditModel : BindDropdownList
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
        [Required]
        public string FromDay { get; set; }
        [Required]
        public string ToDay { get; set; }
        [Required]
        public string FromTime { get; set; }
        [Required]
        public string ToTime { get; set; }
        [Required]
        public string ConsultationFee { get; set; }
        [Required]
        public string AboutDoctor { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }

    public class UserEditModel : BindDropdownList
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
        [Required]
        public string InsuranceTypeId { get; set; }
        [Required]
        public string Interest { get; set; }
        public string ExistingPhotoPath { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }
}