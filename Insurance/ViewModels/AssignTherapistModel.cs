using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Insurance.ViewModels
{
    public class AssignTherapistModel
    {
        [Required]
        public string AppointmentId { get; set; }
        [Required]
        public string TherapistTo { get; set; }
        [Required]
        public string AssignedDate { get; set; }
        [Required]
        public string FromTime { get; set; }
        [Required]
        public string ToTime { get; set; }
        public string UpdatedBy { get; set; }
    }
}