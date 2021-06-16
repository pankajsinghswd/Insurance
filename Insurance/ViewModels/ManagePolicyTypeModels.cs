using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class ManagePolicyTypeModels
    {
        public string Id { get; set; }
        public string Name_en { get; set; }
        public string Name_local { get; set; }
        public string Image { get; set; }
    }

    public class EditPolicyTypeModel
    {
        public string Id { get; set; }
        [Display(Name = "Name_en")]
        [Required]
        public string Name_en { get; set; }
        [Display(Name = "Name_local")]
        [Required]
        public string Name_local { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }
}