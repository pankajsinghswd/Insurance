using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class AppointmentDetailModel
    {
        public string AppointmentId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string ConsultationType { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string TherapistType { get; set; }
        public string AppointmentDate { get; set; }
        public string Timing { get; set; }
        public string Address { get; set; }
    }
}