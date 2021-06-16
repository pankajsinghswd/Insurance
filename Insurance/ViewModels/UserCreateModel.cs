using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class UserCreateModel : BindDropdownList
    {
        [Required]
        [Display(Name = "Full Name_en")]
        public string FullName_en { get; set; }
        [Required]
        [Display(Name = "Full Name_local")]
        public string FullName_local { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        //[RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string InsuranceTypeId { get; set; }
        [Required]
        public string Interest_en { get; set; }
        public string Interest_local { get; set; }
    }
}