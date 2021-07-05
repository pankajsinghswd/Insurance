using Insurance.DAL;
using Insurance.Models;
using Insurance.Utils;
using Insurance.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Insurance.Interface
{
    public class UIRepository
    {
        DataSet ds;
        public static string connectionString;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool IsEnglish { get; set; }
        private Mailer _mailer;
        public UIRepository()
        {
            ds = new DataSet();
            connectionString = SqlHelper.GetConnectionString();
            _mailer = new Mailer();
            IsEnglish = SessionHelper.IsEnglish();
        }

        #region Insurance Quote Form
        public List<SelectListItem> GetPolicyTypeList()
        {
            List<SelectListItem> model = new List<SelectListItem>();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetPolicyTypeList);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            SelectListItem viewModel = new SelectListItem();
                            viewModel.Value = Convert.ToString(dr["Id"]);
                            viewModel.Text = (IsEnglish) ? Convert.ToString(dr["Name_en"]) : Convert.ToString(dr["Name_local"]);
                            model.Add(viewModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Class Name:{0},Methode Name: {1}, Error {2}", "DropdownList", "GetPolicyTypeList", ex.Message.ToString()));

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public List<SelectListItem> GetAgeList()
        {
            List<SelectListItem> model = new List<SelectListItem>();
            try
            {
                int age = 5;
                for (int index = 0; index <= 11; index++)
                {
                    if (index == 0)
                    {
                        SelectListItem viewModel = new SelectListItem();
                        viewModel.Value = Convert.ToString(age);
                        viewModel.Text = Convert.ToString(age);
                        model.Add(viewModel);
                    }
                    else
                    {
                        age = age + 5;
                        SelectListItem viewModel = new SelectListItem();
                        viewModel.Value = Convert.ToString(age);
                        viewModel.Text = Convert.ToString(age);
                        model.Add(viewModel);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Class Name:{0},Methode Name: {1}, Error {2}", "DropdownList", "GetPolicyTypeList", ex.Message.ToString()));

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }

        public int SaveInsuranceQuote(InsuranceQuoteModel model)
        {
            int count = 0;
            IDictionary<string, object> sqlParams = null;
            try
            {

                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeFrontendUI.SaveInsuranceQuote);
                sqlParams.Add("@PurposeofInsurance", model.PurposeofInsurance);
                sqlParams.Add("@FirstName_en", (IsEnglish) ? model.FirstName : "");
                sqlParams.Add("@FirstName_local", !(IsEnglish) ? model.FirstName : "");
                sqlParams.Add("@LastName_en", (IsEnglish) ? model.LastName : "");
                sqlParams.Add("@LastName_local", !(IsEnglish) ? model.LastName : "");
                sqlParams.Add("@Email", model.EmailAddress);
                sqlParams.Add("@PhoneNumber", model.PhoneNumber);
                sqlParams.Add("@Age", model.Age);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsFrontendUI, sqlParams);
                count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                //sent email
                _mailer.SendEmailInsuracneQuote(model, IsEnglish);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return count;
        }
        #endregion

        #region Contact Us Form
        public int SaveContactUsSendEmail(ContactUsViewModels model)
        {
            int count = 0;
            try
            {
                //sent email
                _mailer.SendEmailContactUs(model, IsEnglish);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            return count;
        }
        #endregion

        #region 
        public void CreateUserProfile(UserRegisterViewModel viewModel,string AspnetUserId)
        {
            CreateProfileViewModel model = new CreateProfileViewModel();
            model.FullName_en = (IsEnglish) ? viewModel.FullName : "";
            model.FullName_local = (!IsEnglish) ? viewModel.FullName : "";
            model.Password = (IsEnglish) ? viewModel.Password : "";
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.CreateUsers);
                sqlParams.Add("@AspNetUserId", AspnetUserId);
                sqlParams.Add("@FullName_en", model.FullName_en);
                sqlParams.Add("@FullName_local", model.FullName_local);
                sqlParams.Add("@Password", model.Password);
                sqlParams.Add("@InsuraceTypeId", model.InsuranceTypeId);
                sqlParams.Add("@Interest_en", model.Interest_en);
                sqlParams.Add("@Interest_local", model.Interest_local);
                sqlParams.Add("@Gender", model.Gender);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
        }
        public bool UserForgotPasswordEmail(string Email, string EmailLink, bool IsEnglish)
        {
            try
            {
               return _mailer.UserForgotPasswordEmail(Email,EmailLink,IsEnglish);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
        }
        #endregion
    }
}