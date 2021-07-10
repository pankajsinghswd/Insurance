using Insurance.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Models
{
    public class VehicleInsuranceModels
    {
        public string AspnetUserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string ID { get; set; }

        public string PurposeOfInsurance { get; set; }

        public string RegistrationType { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string RegistrationTypeNo { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; }

        [CheckBoxRequired(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "AgreeCheckBox", ErrorMessage = null)]
        public bool TermsCondition { get; set; }
        public string CaptchaImage { get; set; }
        public string SelectedInsurance { get; set; }
        public string SelectedDate { get; set; }
    }
}