using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class StaticContentInsert
    {
        [Required]
        [Display(Name = "Page Name")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Page Name")]
        public int PageName { get; set; }
        [Required]
        [Display(Name = "Page Title_en")]
        public string PageTitle_en { get; set; }
        [Required]
        [Display(Name = "Page Title_local")]
        public string PageTitle_local { get; set; }
        [AllowHtml]
        [Required]
        [Display(Name = "PageContent_en")]
        public string PageContent_en { get; set; }
        [AllowHtml]
        [Required]
        [Display(Name = "PageContent_local")]
        public string PageContent_local { get; set; }
        public string AspNetUserId { get; set; }
    }
}