using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class PendingAppointmentsReport
    {
        public string AppointmentId { get; set; }
        public string PatientName { get; set; }
        public string PatientAge { get; set; }
        public string PatientGender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string AppointmentDate { get; set; }
        public string Timing { get; set; }
        public string PatientAddress { get; set; }
        public string TherapistName { get; set; }
        public string ConsultationType { get; set; }
    }
}