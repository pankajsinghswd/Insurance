using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class BindDropdownList
    {
        public List<SelectListItem> Speciality { get; set; }
        public List<SelectListItem> Education { get; set; }
        public List<SelectListItem> Year { get; set; }
        public List<SelectListItem> Days { get; set; }

        //Working
        public List<SelectListItem> InsuranceType { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        //end
        
    }
}