using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class HRViewModel
    {
        public string Id { get; set; }
        public string AspNetUserId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string PINCode { get; set; }
        public string Password { get; set; }
        public string Experience { get; set; }
        public string Skills { get; set; }
        public string PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Date { get; set; }
        public string Email { get; set; }
    }
}