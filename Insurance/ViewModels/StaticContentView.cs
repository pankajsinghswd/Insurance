using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class StaticContentView
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageTitle_en { get; set; }
        public string PageTitle_local { get; set; }
        public string LastModified { get; set; }
        public string ModifiedBy { get; set; }
    }
}