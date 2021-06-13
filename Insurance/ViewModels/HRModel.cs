using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class HRModel
    {
        public List<EducationViewModel> educationList { get; set; }
        public HRViewModel basicDetails { get; set; }
    }
}