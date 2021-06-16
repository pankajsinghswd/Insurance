using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class UserEditModel : BindDropdownList
    {
        public string Id { get; set; }
        [Display(Name = "Full Name_en")]
        [Required]
        public string FullName_en { get; set; }
        [Display(Name = "Full Name_local")]
        [Required]
        public string FullName_local { get; set; }
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
        public string Interest_en { get; set; }
        public string Interest_local { get; set; }
        public string ExistingPhotoPath { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }
}