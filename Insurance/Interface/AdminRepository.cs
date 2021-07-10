using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Insurance.DAL;
using Insurance.Models;
using Insurance.Models.APIModels;
using Insurance.Utils;
using Insurance.ViewModels;

namespace Insurance.Interface
{
    public class AdminRepository
    {
        DataSet ds;
        public static string connectionString;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public AdminRepository()
        {
            ds = new DataSet();
            connectionString = SqlHelper.GetConnectionString();
        }

        #region Manage Users methods
        public DashboardModel GetDashboardData()
        {
            DashboardModel generalModels = new DashboardModel();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetDashboardData);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            generalModels.NumberofInsuranceType = Convert.ToInt32(dr["NumberofInsuranceType"]);
                            generalModels.NumberofUsers = Convert.ToInt32(dr["NumberofUserRegistered"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return generalModels;
        }
        public List<UsersViewModel> GetUsers()
        {
            List<UsersViewModel> model = new List<UsersViewModel>();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetUsers);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            UsersViewModel viewModel = new UsersViewModel();
                            viewModel.Id = Convert.ToString(dr["Id"]);
                            viewModel.Email = Convert.ToString(dr["Email"]);
                            viewModel.FullName_en = Convert.ToString(dr["FullName_en"]);
                            viewModel.FullName_local = Convert.ToString(dr["FullName_local"]);
                            viewModel.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            viewModel.Interest_en = Convert.ToString(dr["Interest_en"]);
                            viewModel.Interest_local = Convert.ToString(dr["Interest_local"]);
                            viewModel.IsBlocked = Convert.ToString(dr["IsBlocked"]);
                            viewModel.IsDeleted = Convert.ToString(dr["IsDeleted"]);
                            viewModel.RegisteredOn = Convert.ToString(dr["RegisteredOn"]);
                            model.Add(viewModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Class Name:{0},Methode Name: {1}, Error {2}", "ManageUsers", "GetUsers", ex.Message.ToString()));

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public void CreateProfile(CreateProfileViewModel model)
        {
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.CreateUsers);
                sqlParams.Add("@AspNetUserId", model.Id);
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
        public UserEditModel GetProfileById(string Id)
        {
            UserEditModel model = new UserEditModel();
            IDictionary<string, object> sqlParams = null;
            var context = HttpContext.Current;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetUpdateData);
                sqlParams.Add("@AspNetUserId", Id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model.Id = Convert.ToString(dr["Id"]);
                            model.FullName_en = Convert.ToString(dr["FullName_en"]);
                            model.FullName_local = Convert.ToString(dr["FullName_local"]);
                            model.Email = Convert.ToString(dr["Email"]);
                            model.Gender = Convert.ToString(dr["Gender"]);
                            model.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            model.InsuranceTypeId = Convert.ToString(dr["InsuranceTypeId"]);
                            model.Interest_en = Convert.ToString(dr["Interest_en"]);
                            model.Interest_local = Convert.ToString(dr["Interest_local"]);
                            model.ExistingPhotoPath = Convert.ToString(dr["Image"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public string UpdateProfile(UserEditModel editModel)
        {
            string model = string.Empty;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.UpdateProfile);
                sqlParams.Add("@AspNetUserId", editModel.Id);
                sqlParams.Add("@Email", editModel.Email);
                sqlParams.Add("@FullName_en", editModel.FullName_en);
                sqlParams.Add("@FullName_local", editModel.FullName_local);
                sqlParams.Add("@Gender", editModel.Gender);
                sqlParams.Add("@Phone", editModel.PhoneNumber);
                sqlParams.Add("@InsuraceTypeId", editModel.InsuranceTypeId);
                sqlParams.Add("@Interest_en", editModel.Interest_en);
                sqlParams.Add("@Interest_local", editModel.Interest_local);
                sqlParams.Add("@ExistingPhotoPath", editModel.ExistingPhotoPath);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model = Convert.ToString(dr["Status"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public UserProfileDetailModel ViewProfile(string Id)
        {
            UserProfileDetailModel model = new UserProfileDetailModel();
            IDictionary<string, object> sqlParams = null;
            var context = HttpContext.Current;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetProfile);
                sqlParams.Add("@AspNetUserId", Id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model.Id = Convert.ToString(dr["Id"]);
                            model.FullName_en = Convert.ToString(dr["FullName_en"]);
                            model.FullName_local = Convert.ToString(dr["FullName_local"]);
                            model.Email = Convert.ToString(dr["Email"]);
                            model.Mobile = Convert.ToString(dr["PhoneNumber"]);
                            model.Interest_en = Convert.ToString(dr["Interest_en"]);
                            model.Interest_local = Convert.ToString(dr["Interest_local"]);
                            model.InsuranceType_en = Convert.ToString(dr["InsuranceName_en"]);
                            model.InsuranceType_local = Convert.ToString(dr["InsuranceName_local"]);
                            if (Convert.ToString(dr["ProfilePath"]) != "avtar.png")
                            {
                                model.ProfilePath = GetBaseUrl() + "Content/userProfile/" + Convert.ToString(dr["ProfilePath"]);
                            }
                            else
                            {
                                model.ProfilePath = GetBaseUrl() + "Content/images/" + Convert.ToString(dr["ProfilePath"]);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public int DeleteTherapist(string Id)
        {
            int model = 0;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.DeleteUser);
                sqlParams.Add("@AspNetUserId", Id);

                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public int BlockToTherapist(string Id)
        {
            int model = 0;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.BlockUser);
                sqlParams.Add("@AspNetUserId", Id);

                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        #endregion

        #region Manage Policy type
        public List<ManagePolicyTypeModels> GetPolicyTypeList()
        {
            List<ManagePolicyTypeModels> model = new List<ManagePolicyTypeModels>();
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
                            ManagePolicyTypeModels viewModel = new ManagePolicyTypeModels();
                            viewModel.Id = Convert.ToString(dr["Id"]);
                            viewModel.Name_en = Convert.ToString(dr["Name_en"]);
                            viewModel.Name_local = Convert.ToString(dr["Name_local"]);
                            viewModel.Image = !string.IsNullOrEmpty(Convert.ToString(dr["Image"])) ? Convert.ToString(dr["Image"]) : "avtar.png";
                            model.Add(viewModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("Class Name:{0},Methode Name: {1}, Error {2}", "ManageUsers", "GetUsers", ex.Message.ToString()));

            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public void CreatePolicyType(ManagePolicyTypeModels model)
        {
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.AddPolicyType);
                sqlParams.Add("@Id", model.Id);
                sqlParams.Add("@Name_en", model.Name_en);
                sqlParams.Add("@Name_local", model.Name_local);
                sqlParams.Add("@ExistingPhotoPath", model.Image);
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
        public ManagePolicyTypeModels GetPolicyTypeById(string Id)
        {
            ManagePolicyTypeModels model = new ManagePolicyTypeModels();
            IDictionary<string, object> sqlParams = null;
            var context = HttpContext.Current;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetPolicyTypeById);
                sqlParams.Add("@Id", Id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model.Id = Convert.ToString(dr["Id"]);
                            model.Name_en = Convert.ToString(dr["Name_en"]);
                            model.Name_local = Convert.ToString(dr["Name_local"]);
                            model.Image = Convert.ToString(dr["Image"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public string UpdatePolicyType(ManagePolicyTypeModels editModel)
        {
            string model = string.Empty;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.UpdatePolicyType);
                sqlParams.Add("@Id", editModel.Id);
                sqlParams.Add("@Name_en", editModel.Name_en);
                sqlParams.Add("@Name_local", editModel.Name_local);
                sqlParams.Add("@ExistingPhotoPath", editModel.Image);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model = Convert.ToString(ds.Tables[0].Rows[0][0]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public int DeletePolicyType(string Id)
        {
            int model = 0;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.DeletePolicyType);
                sqlParams.Add("@Id", Id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    model = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }

        #endregion

        #region Static Contents methods
        public List<StaticContentView> GetStaticPageContent()
        {
            List<StaticContentView> model = new List<StaticContentView>();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetStaticContent);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            StaticContentView model1 = new StaticContentView();
                            model1.Id = Convert.ToInt32(dr["Id"]);
                            model1.PageName = Convert.ToString(dr["PageName"]);
                            model1.PageTitle_en = Convert.ToString(dr["PageTitle_en"]);
                            model1.PageTitle_local = Convert.ToString(dr["PageTitle_local"]);
                            model1.LastModified = Convert.ToString(dr["LastModifiedOn"]);
                            model1.ModifiedBy = Convert.ToString(dr["ModifiedBy"]);

                            model.Add(model1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        public int AddUpdateContent(StaticContentUpdate model)
        {
            int identity = 0;
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.AddUpdateStaticPageContent);
                sqlParams.Add("@AspNetUserId", model.AspNetUserId);
                sqlParams.Add("@Id", model.Id);
                sqlParams.Add("@Title_en", model.PageTitle_en);
                sqlParams.Add("@Title_local", model.PageTitle_local);
                sqlParams.Add("@Content_en", model.PageContent_en);
                sqlParams.Add("@Content_local", model.PageContent_local);
                sqlParams.Add("@PageId", model.PageName);

                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    identity = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return identity;
        }
        public StaticContentUpdate GetPageContentById(int id)
        {
            StaticContentUpdate model = new StaticContentUpdate();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetStaticContentById);
                sqlParams.Add("@Id", id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            model.Id = Convert.ToInt32(dr["Id"]);
                            model.PageName = Convert.ToInt32(dr["PageTypeId"]);
                            model.PageTitle_en = Convert.ToString(dr["PageTitle_en"]);
                            model.PageTitle_local = Convert.ToString(dr["PageTitle_local"]);
                            model.PageContent_en = Convert.ToString(dr["PageContent_en"]);
                            model.PageContent_local = Convert.ToString(dr["PageContent_local"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());
            }
            finally
            {
                ds.Dispose();
            }
            return model;
        }
        #endregion

        #region Report methods
        public UserDetailHistoryModel UserDetailHisotry(string Id)
        {
            UserDetailHistoryModel objmodel = new UserDetailHistoryModel();
            IDictionary<string, object> sqlParams = null;
            var context = HttpContext.Current;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryTypeAdmin.GetProfile);
                sqlParams.Add("@AspNetUserId", Id);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spInsAdmin, sqlParams);
                if (ds != null && ds.Tables.Count > 0)
                {

                    //User detail model
                    UserProfileDetailModel userProfile = new UserProfileDetailModel();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            userProfile.Id = Convert.ToString(dr["Id"]);
                            userProfile.FullName_en = Convert.ToString(dr["FullName_en"]);
                            userProfile.FullName_local = Convert.ToString(dr["FullName_local"]);
                            userProfile.Email = Convert.ToString(dr["Email"]);
                            userProfile.Mobile = Convert.ToString(dr["PhoneNumber"]);
                            userProfile.Interest_en = Convert.ToString(dr["Interest_en"]);
                            userProfile.Interest_local = Convert.ToString(dr["Interest_local"]);
                            userProfile.InsuranceType_en = Convert.ToString(dr["InsuranceName_en"]);
                            userProfile.InsuranceType_local = Convert.ToString(dr["InsuranceName_local"]);
                            if (Convert.ToString(dr["ProfilePath"]) != "avtar.png")
                            {
                                userProfile.ProfilePath = GetBaseUrl() + "Content/userProfile/" + Convert.ToString(dr["ProfilePath"]);
                            }
                            else
                            {
                                userProfile.ProfilePath = GetBaseUrl() + "Content/images/" + Convert.ToString(dr["ProfilePath"]);
                            }

                        }
                    objmodel.userProfileDetail = userProfile;
                    //Vehicle Insurance model model
                    objmodel.listvehicleInsurance = CommonFunctions.ConvertDataTable<VehicleInsurance>(ds.Tables[1]);
                    //Medical Insurance model model
                    objmodel.listmedicalInsurance = CommonFunctions.ConvertDataTable<MedicalInsurance>(ds.Tables[2]);
                    //MedicalMalpracticeInsurance
                    objmodel.listmedicalMalpracticeInsurance = CommonFunctions.ConvertDataTable<MedicalMalpracticeInsurance>(ds.Tables[3]);
                    //TravelInsurance
                    objmodel.listtravelInsurance = CommonFunctions.ConvertDataTable<TravelInsurance>(ds.Tables[4]);
                    //LIfe & Sagings
                    objmodel.listlifeSavingsInsurance = CommonFunctions.ConvertDataTable<LifeSavingInsurance>(ds.Tables[5]);
                    //HouseHoldInsurance
                    objmodel.listHouseHoldInsurance = CommonFunctions.ConvertDataTable<HouseHoldInsurance>(ds.Tables[6]);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return objmodel;
        }

        #endregion

        #region Bind dropdownlist
        public List<SelectListItem> GetMasterData(int QueryType)
        {
            List<SelectListItem> category = new List<SelectListItem>();
            IDictionary<string, object> sqlParams = null;
            try
            {
                sqlParams = new Dictionary<string, object>();
                sqlParams.Add("@Qtype", QueryType);
                ds = SqlHelper.ExecuteProcedure(connectionString, storeProcedureName.spBindDropDownlist, sqlParams);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in ds.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            category.Add(new SelectListItem
                            {
                                Value = Convert.ToString(dr["Id"]),
                                Text = Convert.ToString(dr["Name_en"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message.ToString());

            }
            finally
            {
                ds.Dispose();
            }
            return category;
        }
        #endregion

        #region Common methods
        public string GetBaseUrl()
        {
            var request = HttpContext.Current.Request;
            var appUrl = HttpRuntime.AppDomainAppVirtualPath;

            if (appUrl != "/")
                appUrl = "/" + appUrl;

            var baseUrl = string.Format("{0}://{1}{2}", request.Url.Scheme, request.Url.Authority, appUrl);

            return baseUrl;
        }
        #endregion
    }
}