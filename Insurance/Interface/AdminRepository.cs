﻿using System;
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
                            viewModel.FullName = Convert.ToString(dr["FullName"]);
                            viewModel.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            viewModel.Interest = Convert.ToString(dr["Interest"]);
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
                sqlParams.Add("@FullName", model.FullName);
                sqlParams.Add("@Password", model.Password);

                sqlParams.Add("@InsuraceTypeId", model.InsuranceTypeId);
                sqlParams.Add("@Interest", model.Interest);
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
                            model.FullName = Convert.ToString(dr["FullName"]);
                            model.Email = Convert.ToString(dr["Email"]);
                            model.Gender = Convert.ToString(dr["Gender"]);
                            model.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                            model.InsuranceTypeId = Convert.ToString(dr["InsuranceTypeId"]);
                            model.Interest = Convert.ToString(dr["Interest"]);
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
                sqlParams.Add("@FullName", editModel.FullName);
                sqlParams.Add("@Gender", editModel.Gender);
                sqlParams.Add("@Phone", editModel.PhoneNumber);
                sqlParams.Add("@InsuraceTypeId", editModel.InsuranceTypeId);
                sqlParams.Add("@Interest", editModel.Interest);
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
                            model.FullName = Convert.ToString(dr["FullName"]);
                            model.Email = Convert.ToString(dr["Email"]);
                            model.Mobile = Convert.ToString(dr["PhoneNumber"]);
                            model.Interest = Convert.ToString(dr["Interest"]);
                            model.InsuranceType = Convert.ToString(dr["InsuranceName"]);
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
                            viewModel.Name = Convert.ToString(dr["Name"]);
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
                sqlParams.Add("@FullName", model.Name);
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
                            model.Name = Convert.ToString(dr["Name"]);
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
                sqlParams.Add("@FullName", editModel.Name);
                sqlParams.Add("@ExistingPhotoPath", editModel.Image);
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
                            model1.PageTitle = Convert.ToString(dr["PageTitle"]);
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
                sqlParams.Add("@Title", model.PageTitle);
                sqlParams.Add("@Content", model.PageContent);
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
                            model.PageTitle = Convert.ToString(dr["PageTitle"]);
                            model.PageContent = Convert.ToString(dr["PageContent"]);
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
                                Text = Convert.ToString(dr["Name"])
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