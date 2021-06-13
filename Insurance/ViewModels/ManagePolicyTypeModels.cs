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
        public string Name { get; set; }
        public string Image { get; set; }
    }

    public class EditPolicyTypeModel
    {
        public string Id { get; set; }
        [Display(Name = "Name")]
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        public string file { get; set; }
    }
}