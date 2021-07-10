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
        public string VehicleRegistrationNumber { get; set; }
        public string VehicleBrand { get; set; }
        public string VehicleModel { get; set; }
        public string InsuranceType { get; set; }
        public string EmailId { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class MedicalInsurance
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string InsuranceType { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class MedicalMalpracticeInsurance
    {
        public string NeedInsuranceFor { get; set; }
        public string EmailId { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class TravelInsurance
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string DestinationCountry { get; set; }
        public string Age { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string EmailId { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
    public class LifeSavingInsurance
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string AnnualIncome { get; set; }
        public string TobbacoNicotine { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class HouseHoldInsurance
    {
        public string TellAboutHome { get; set; }
        public string Address { get; set; }
        public string InsuranceType { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsInsurance { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}