using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class PatientViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string TherapistType { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string ConsultationType { get; set; }
    }
}