using Insurance.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Models
{
    public class TravelInsuranceModels
    {
        public string AspnetUserId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string Age { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public List<SelectListItem> GenderList { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string Gender { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        public string DestinationCountry { get; set; }
        
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ToDate { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "ReuiredField", ErrorMessage = null)]
        [EmailAddress(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "RegEmail", ErrorMessage = null)]
        public string EmailId { get; set; }

        public bool IsInsurance { get; set; }
    }
}