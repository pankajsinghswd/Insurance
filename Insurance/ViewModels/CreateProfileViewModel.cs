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
        public string FullName { get; set; }
        public string CreatedBy { get; set; }
        public string Password { get; set; }
        public string Interest { get; set; }
        public string InsuranceTypeId { get; set; }
        public string Gender { get; set; }
        public string SpecialityIDs { get; set; }
        public string EducationId { get; set; }
        public string ExperienceInYear { get; set; }
        public string FromDay { get; set; }
        public string ToDay { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        public string ConsultationFee { get; set; }
        public string AboutDoctor { get; set; }
        
    }

}