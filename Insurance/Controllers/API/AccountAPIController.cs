using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using Insurance.Interface;
using Insurance.Models;
using Insurance.Models.APIModels;
using Insurance.Utils;
using Insurance.ViewModels;

namespace Insurance.Controllers.API
{
    [Authorize]
    [RoutePrefix("api/insurance")]
    public class AccountAPIController : ApiController
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IAdmin admin;
        public AccountAPIController(IAdmin _admin)
        {
            this.admin = _admin;
        }

        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        /// <summary>
        /// This is the Login API  to login for existing users.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<HttpResponseMessage> Login(LoginViewModel model)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            dynamic dyRes = new ExpandoObject();
            if (!ModelState.IsValid)
            {
                return responseMessage = ResponseBuilder.getInvalidResponse(model);
            }
            else
            {
                try
                {
                    var request = HttpContext.Current.Request;
                    string tokenServiceUrl = ConfigurationManager.AppSettings["baseUrlOAuth"];

                    using (var client = new HttpClient())
                    {
                        var requestParams = new List<KeyValuePair<string, string>>
                        {
                            new KeyValuePair<string, string>("grant_type", "password"),
                            new KeyValuePair<string, string>("username", model.Email),
                            new KeyValuePair<string, string>("password", model.Password)
                        };

                        var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                        var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                        var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                        var responseCode = tokenServiceResponse.StatusCode;
                        if (responseCode == HttpStatusCode.OK)
                        {
                            dyRes.code = responseCode;
                            dyRes.message = responseString;
                            var js = new JavaScriptSerializer();
                            var loginUser = UserManager.FindByEmail(model.Email);

                            if (loginUser != null)
                            {
                                var role = loginUser.Roles.FirstOrDefault().RoleId;
                                //UserDetailsModels userDetails = admin.GetUserByAspId(loginUser.Id);
                                UserDetailsModels userDetails=new UserDetailsModels();
                                JObject json = JObject.Parse(responseString);
                                dyRes.code = APIConstant.Ok;
                                dyRes.message = APIConstant.Login;
                                dyRes.access_token = json.First.First.ToString();
                                dyRes.token_type = Convert.ToString(((JProperty)json.First.Next).Value);
                                dyRes.expires_in = Convert.ToString(((JProperty)json.First.Next.Next).Value);
                                if (userDetails != null)
                                {
                                    dyRes.data = userDetails;
                                }
                                else
                                {
                                    dyRes.data = new List<object>();
                                }

                                #region Add device info of logged in user
                                //DeviceInfoForPushNotification device = new DeviceInfoForPushNotification
                                //{
                                //    TherapistId = loginUser.Id,
                                //    DeviceId = model.DeviceId,
                                //    DeviceName = model.DeviceName
                                //};
                                //admin.addUpdateDeviceInfo(device);
                                #endregion

                                return ResponseBuilder.getSuccessResponse(dyRes);
                            }
                            else
                            {
                                dyRes.message = APIConstant.LoginFail;
                                dyRes.code = APIConstant.BadRequest;
                                JObject json = JObject.Parse(responseString);
                                dyRes.message = json.First.Next.First.ToString();
                                return ResponseBuilder.getInvalidResponse(dyRes);
                            }
                        }
                        else
                        {
                            dyRes.message = APIConstant.LoginFail;
                            dyRes.code = APIConstant.BadRequest;
                            JObject json = JObject.Parse(responseString);
                            dyRes.message = json.First.Next.First.ToString();
                            return ResponseBuilder.getInvalidResponse(dyRes);
                        }
                    }
                }
                catch (InsuranceErrorService ex)
                {
                    dyRes.code = APIConstant.InternalServerError;
                    dyRes.message = ex.Message;
                    logger.Error(ex);
                    return ResponseBuilder.getErrorResponse(ex.getErrorDetails());
                }
            }
        }

        /// <summary>
        /// This is used for TokenGeneration for AddUser API
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="Password"></param>
        /// <param name="dyRes"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private async Task<HttpResponseMessage> TokenGeneration(string Email, string Password, dynamic dyRes, LoginViewModel obj)
        {
            string tokenServiceUrl = ConfigurationManager.AppSettings["baseUrlOAuth"];
            using (var client = new HttpClient())
            {
                var requestParams = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("username", Email),
                    new KeyValuePair<string, string>("password", Password)
                };

                var requestParamsFormUrlEncoded = new FormUrlEncodedContent(requestParams);
                var tokenServiceResponse = await client.PostAsync(tokenServiceUrl, requestParamsFormUrlEncoded);
                var responseString = await tokenServiceResponse.Content.ReadAsStringAsync();
                var responseCode = tokenServiceResponse.StatusCode;
                dyRes.code = responseCode;
                dyRes.message = responseString;
                var js = new JavaScriptSerializer();

                if (responseCode == HttpStatusCode.BadRequest)
                {
                    JObject json = JObject.Parse(responseString);
                    dyRes.code = -1;
                    dyRes.message = json.First.Next.First.ToString();
                    return ResponseBuilder.GetResponse(dyRes, HttpStatusCode.OK);
                }
                else
                {
                    JObject json = JObject.Parse(responseString);
                    dyRes.code = APIConstant.Ok;
                    dyRes.message = APIConstant.Create;
                    dyRes.access_token = json.First.First.ToString();
                    dyRes.token_type = ((JProperty)json.First.Next).Value.ToString();
                    dyRes.expires_in = ((JProperty)json.First.Next.Next).Value.ToString();
                    dyRes.data = obj;
                    return ResponseBuilder.GetResponse(dyRes, HttpStatusCode.OK);
                }
            }
        }

        //[Route("Register")]
        //[HttpPost]
        //public async Task<HttpResponseMessage> Register([FromBody] RegisterViewModel model)
        //{
        //    HttpResponseMessage responseMessage = new HttpResponseMessage();
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.PhoneNumber };
        //            var result = await UserManager.CreateAsync(user, model.Password);
        //            if (result.Succeeded)
        //            {
        //                result = await UserManager.AddToRoleAsync(user.Id, model.Stakeholder);
        //                if (result.Succeeded)
        //                {
        //                    CreateProfileViewModel create = new CreateProfileViewModel
        //                    {
        //                        Id = user.Id,
        //                        FullName = model.FullName,
        //                        CreatedBy = "ashwini.yadav@wildnettechnologies.com"
        //                    };
        //                    admin.CreateProfile(create);
        //                    logger.Info("User created a new account with password via API.");

        //                    return ResponseBuilder.getSuccessResponse(user);
        //                }
        //            }
        //            else
        //            {
        //                return ResponseBuilder.getSuccessResponse(result);
        //            }
        //        }
        //        else
        //        {
        //            var errors = new List<string>();
        //            foreach (var modelState in ModelState)
        //            {
        //                foreach (var error in modelState.Value.Errors)
        //                {
        //                    errors.Add(!string.IsNullOrEmpty(error.ErrorMessage) ? error.ErrorMessage : "Not valid data");
        //                }
        //            }
        //            return ResponseBuilder.getSuccessResponse(errors);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ResponseBuilder.getSuccessResponse(ex);
        //    }
        //    return ResponseBuilder.getSuccessResponse(responseMessage);
        //}
    }
}
