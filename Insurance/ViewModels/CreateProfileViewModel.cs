using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class CreateProfileViewModel
    {
        [Required]
        public string Id { get; set; }
        public string FullName_en { get; set; }
        public string FullName_local { get; set; }
        public string CreatedBy { get; set; }
        public string Password { get; set; }
        public string Interest_en { get; set; }
        public string Interest_local { get; set; }
        public string InsuranceTypeId { get; set; }
        public string Gender { get; set; }
    }

}