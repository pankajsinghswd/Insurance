using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class ConsumedUnitHistory
    {
        public string PatientId { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientMobile { get; set; }
        public string ConsultationType { get; set; }
        public double UnitConsumed { get; set; }
        public string Duration { get; set; }
        public string Timing { get; set; }
        public string TherapistId { get; set; }
        public string TherapistName { get; set; }
        public string ProfilePath { get; set; }
    }
}