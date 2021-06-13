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
        [Display(Name = "Page Title")]
        public string PageTitle { get; set; }
        [AllowHtml]
        [Required]
        [Display(Name = "Page Content")]
        public string PageContent { get; set; }
        public string AspNetUserId { get; set; }
    }
}