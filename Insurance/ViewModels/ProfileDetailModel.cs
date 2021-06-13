using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class ProfileDetailModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Timing { get; set; }
        public string ConsultationFee { get; set; }
        public string About { get; set; }
        public string ProfilePath { get; set; }
        public string SpecialistType { get; set; }
    }

    public class UserProfileDetailModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Interest { get; set; }
        public string Gender { get; set; }
        public string ProfilePath { get; set; }
        public string InsuranceType { get; set; }
    }
}