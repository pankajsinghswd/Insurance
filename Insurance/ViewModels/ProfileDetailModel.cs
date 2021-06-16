using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class UserProfileDetailModel
    {
        public string Id { get; set; }
        public string FullName_en { get; set; }
        public string FullName_local { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Interest_en { get; set; }
        public string Interest_local { get; set; }
        public string Gender { get; set; }
        public string ProfilePath { get; set; }
        public string InsuranceType_en { get; set; }
        public string InsuranceType_local { get; set; }
    }
}