using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class EarnedUnitHistory
    {
        public string TherapistId { get; set; }
        public string TherapistName { get; set; }
        public string TherapistEmail { get; set; }
        public string TherapistMobile { get; set; }
        public string Speciality { get; set; }
        public double UnitEarned { get; set; }
        public string Duration { get; set; }
        public string Timing { get; set; }
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string ProfilePath { get; set; }
    }
}