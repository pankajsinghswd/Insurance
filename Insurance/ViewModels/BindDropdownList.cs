using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.ViewModels
{
    public class BindDropdownList
    {
        //Working
        public List<SelectListItem> InsuranceType { get; set; }
        public List<SelectListItem> GenderList { get; set; }
        //end
        
    }
}