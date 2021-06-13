using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class SalesforceEnquiry__C
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AccountName__C { get; set; }
        [Required]
        public string Description__C { get; set; }
    }
}