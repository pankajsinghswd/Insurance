using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insurance.Models;
namespace Insurance.ViewModels
{
    public class UserDetailHistoryModel
    {
        public UserProfileDetailModel userProfileDetail { get; set; }
        public List<VehicleInsurance> listvehicleInsurance { get; set; }
        public List<MedicalInsurance> listmedicalInsurance { get; set; }
        public List<MedicalMalpracticeInsurance> listmedicalMalpracticeInsurance { get; set; }
        public List<TravelInsurance> listtravelInsurance { get; set; }
        public List<LifeSavingInsurance> listlifeSavingsInsurance { get; set; }
        public List<HouseHoldInsurance> listHouseHoldInsurance { get; set; }
    }

    public class VehicleInsurance
    {
        public string PurposeOfInsurance { get; set; }
        public string IdNumber { get; set; }
        public string RegistrationType { get; set; }
        public string RegistrationTypeNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class MedicalInsurance
    {
        public string IdNumber { get; set; }
        public string TypeInsuranceCoverage { get; set; }
        public DateTime StartDateofInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class MedicalMalpracticeInsurance
    {
        public string IdNumber { get; set; }
        public string Speciality { get; set; }
        public string LimitofLiability { get; set; }
        public DateTime StartDateInsurance { get;set;}
        public DateTime CreatedOn { get; set; }
    }
    public class TravelInsurance
    {
        public string IdNumber { get; set; }
        public string Duration { get; set; }
        public string PassportNumber{ get; set; }
        public string Destination { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class LifeSavingInsurance
    {
        public string IdNumber { get; set; }
        public string LimitCoverage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class HouseHoldInsurance
    {
        public string IdNumber { get; set; }
        public string SumInsurred { get; set; }
        public string Location { get; set; }
        public string TypeofCoverage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}