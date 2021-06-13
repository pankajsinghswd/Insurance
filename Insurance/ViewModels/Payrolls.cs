using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class Payrolls
    {
        public string TherapistId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Speciality { get; set; }
        public double TotalEarnedUnit { get; set; }
        public double RoundEarnedUnit { get; set; }
        public double Hours { get; set; }
        public double Minutes { get; set; }
    }
}