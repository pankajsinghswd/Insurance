using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class PatientBilling
    {
        public string PatientId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ConsultationType { get; set; }
        public double TotalConsumedUnit { get; set; }
    }
}