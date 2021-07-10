using Insurance.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Models
{
    public class InsuranceQuoteModel
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "InsuraceList", ErrorMessage = null)]
        public List<SelectListItem> InsuraceList { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "InsuraceList", ErrorMessage = null)]
        public string IssuranceId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "AgeList", ErrorMessage = null)]
        [CheckBoxRequired(ErrorMessageResourceType = typeof(Master_en), ErrorMessageResourceName = "TermsCondition", ErrorMessage = null)]
        //[CheckBoxRequired(ErrorMessage = "TermsCondition")]
        public bool TermsCondition { get; set; }
    }

    public class CheckBoxRequired : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            return value is bool && (bool)value;
        }
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                ValidationType = "checkboxrequired"
            };
        }
    }
}