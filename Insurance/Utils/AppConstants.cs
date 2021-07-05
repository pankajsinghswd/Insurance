using System.Web;

namespace Insurance.Utils
{
    public static class AppConstants
    {
        internal const string ADMIN = "Admin";
        internal const string USER = "User";
    }
    public class RoleName
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
    public enum PageType
    {
        None = 0,
        AboutUs = 1,
        PrivacyPolicy = 2,
        ContactUs = 3,
        Termsandconditions = 4
    }
    public class Constants
    {
        public static readonly int BUNCH_SIZE = 500;
        public static readonly string Subject = "Appointment reminder";

        //public static readonly string FCMAuthKey = "AAAAzHVHKw0:APA91bHns7VjWv197R6Ecj7ADQt4vFvd4Fg7NnbkX1SckS7fbGSEh072dz_FnwdNcG8VNd6O0yRobXXJv_HMDIS8jtRYNzOF-vkwAqOBWtKlN2j-FxnsT9JQX0957O23XBJRm7IqL2og";
        //public static readonly string FCMSenderId = "878140926733";

        public static readonly string FCMAuthKey = "AAAAejEM9zA:APA91bHFG5ekAwm0Pl4ZPhTmaP11zdJcHvZLq3z8KXgphO4XA24BSgkvbdovhUI4oE8AZFpEJ_tRcCSWz0Yq6GQtvDN3KHClezt7Sno99D0ajw08To3mRKSu1xN95WqD8LWktAxw5GHE";
        public static readonly string FCMSenderId = "524808943408";
        public static readonly string FirebaseAPI = "https://fcm.googleapis.com/fcm/send";

        public static readonly string CERTIFICATE_PATH = HttpContext.Current.Server.MapPath("~/OAuth/sanbox_push_nomination.p12");
        public static readonly string PASSWORD = "1234";
    }
    public static class APIConstant
    {
        public const int Ok = 200;
        public const int Created = 201;
        public const int Accepted = 202;
        public const int NoContent = 204;
        public const int BadRequest = 400;
        public const int UnAuthorized = 401;
        public const int InternalServerError = 500;
        public const int BadGateway = 502;

        public const string NoRecord = "Sorry! No record Found";
        public const string ModelState = "Somthing went wrong";
        public const string LoginFail = "Sorry! Email or Password is Invalid";
        public const string InActiveUser = "Sorry! Email is Inactive";
        public const string Create = "Record Added Successfully ";
        public const string Login = "Login Successfully ";
    }
    public static class storeProcedureName
    {
        public const string spInsAdmin = "spInsAdmin";
        public const string spBindDropDownlist = "spBindDropDownlist";
        public const string spInsFrontendUI = "spInsFrontendUI";

        //not in use
        public const string spAdmin = "spAdmin";
        public const string spTherapist = "spTherapist";
        public const string spHR = "spHR";
        //
    }
    
    public static class QueryTypeAdmin
    {
        //Working 
        public const int GetUsers = 1;
        public const int GetDashboardData = 2;
        public const int CreateUsers = 3;
        public const int GetUpdateData = 4;
        public const int UpdateProfile = 5;
        public const int GetProfile = 6;
        public const int DeleteUser = 7;
        public const int BlockUser = 8;
        public const int GetPolicyTypeList = 9;
        public const int AddPolicyType = 10;
        public const int UpdatePolicyType = 11;
        public const int DeletePolicyType = 12;
        public const int GetPolicyTypeById = 13;
        public const int GetStaticContent = 14;
        public const int AddUpdateStaticPageContent = 15;
        public const int GetStaticContentById = 16;
        


        //not in use
        public const int GetTherapist = 1;
        public const int GetPatient = 2;
        public const int GetPatientById = 3;
        public const int InActivePatient = 4;
        public const int GetProfilePhotoPath = 5;
        public const int DeleteTherapist = 6;
        public const int BlockTherapist = 7;
        public const int TimeMaster = 8;
        public const int GetPatientBySpecilization = 9;
        public const int addUpdateDevice = 10;
        public const int getNotification = 11;
        public const int getNotificationForDevice = 12;
        public const int UpdateReadStatus = 13;
        public const int GetBillings = 14;
        public const int GetBillingsHistoryById = 15;
        public const int GetPatientBillings = 16;
        public const int GetPatientBillingsHistoryById = 17;
        public const int GetAttendedReports = 18;
        public const int GetUnassignedReport = 19;
        public const int GetPendingReport = 20;
        //public const int GetStaticContent = 21;
        //public const int AddUpdateStaticPageContent = 22;
        //public const int GetStaticContentById = 23;
        public const int GetPayrolls = 24;
        
    }
    public static class QueryType
    {
        //Working
        public const int GetGender = 1;
        public const int InsuranceType = 2;

        //end here


        public const int ConsultationType = 1;
        public const int TherapistType = 2;
        public const int Specializations = 3;
        public const int EducationType = 4;
        public const int TimeMaster = 5;
        public const int InsertAppointment = 6;
        public const int GetAppointment = 7;
        public const int CreateProfile = 8;
        public const int GetUserDetails = 9;
        public const int GetAppointmentDetailsById = 10;
        public const int SetDurationStartTime = 11;
        public const int SetDurationEndTime = 12;
        public const int GetState = 13;
       
        public const int GetAppoinmentWothKeyword = 15;
        public const int GetProfile = 16;
        public const int GetUpdateData = 17;
        public const int UpdateProfile = 18;
        public const int GetYear = 19;
        
        public const int TherapistList = 21;
        public const int UpdateAppointment = 22;
        public const int Days = 23;
        public const int therapistList = 24;
        public const int UpdateProfileByTherapist = 25;
        
    }

    public static class QueryTypeFrontendUI
    {
        public const int SaveInsuranceQuote = 1;
    }
}