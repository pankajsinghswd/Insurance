using Insurance.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "Email", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "PasswordRequired", ErrorMessage = null)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
    public class UserRegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ContactUsNameRequired", ErrorMessage = null)]
        public string FullName { get; set; }

        //[Required(ErrorMessage = "You must provide a phone number")]
        //[Display(Name = "Phone number")]
        //[DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        //public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "Email", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "PasswordRequired", ErrorMessage = null)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$)")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "PasswordRequired", ErrorMessage = null)]
        public string ConfirmPassword { get; set; }
    }
    public class UserResetPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "Email", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "PasswordRequired", ErrorMessage = null)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d).+$)")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "PasswordRequired", ErrorMessage = null)]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class UserForgotPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "Email", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        public string Email { get; set; }
    }
}