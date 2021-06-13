using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class EducationViewModel
    {
        public int Id { get; set; }
        public string CollegeName { get; set; }
        public string Course { get; set; }
        public string Specialization { get; set; }
        public string PassingYear { get; set; }
        public string Date { get; set; }
    }
}