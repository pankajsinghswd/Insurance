using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Insurance.Interface;
using Insurance.Models;
using Insurance.Utils;
using Insurance.ViewModels;
using System;
using Insurance.Helpers;

namespace Insurance.Controllers
{
    public class HomeController : MasterBaseController, IDisposable
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool IsEnglish { get; set; }
        public HomeController()
        {
            IsEnglish = SessionHelper.IsEnglish();
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
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult TermsCondition()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult HouseHold()
        {
            return View();
        }

        [AcceptVerbs("Get", "Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var result = await UserManager.FindByEmailAsync(email);

            if (result == null)
            {
                return (IActionResult)Json(true);
            }
            else
            {
                return (IActionResult)Json($"Email {email} is already in use.");
            }
        }

        /// <summary>
        ///Set english and arabic cuturer by param
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public ActionResult SetCulture(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            SetCityName();
            return Redirect(Request.UrlReferrer.AbsoluteUri);
        }

        /// <summary>
        /// change lunaguage by cuture param
        /// </summary>
        /// <param name="culture"></param>
        /// <returns></returns>
        public ActionResult Lang(string culture)
        {
            // Validate input
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);
            SetCityName();
            return RedirectToAction("mobapp", "home");
        }

        /// <summary>
        /// Set cityname in cookies
        /// </summary>
        public void SetCityName()
        {
            //using (ClicFlyerEntities db = new ClicFlyerEntities())
            //{
            //    HttpCookie cookieLoct = Request.Cookies.Get("cookieLocation");
            //    if (cookieLoct != null)
            //    {
            //        int cityId = SessionHelper.GetCityId();
            //        var cityrow = db.Cities.Where(x => x.Id == cityId).FirstOrDefault();
            //        string encryptCity = (SessionHelper.IsEnglish()) ? cityrow.Name_en : cityrow.Name_local;
            //        cookieLoct["CityName"] = Crypto.Encrypt(encryptCity, true);
            //        Response.Cookies.Add(cookieLoct);
            //    }
            //}

        }

        #region IDisposable Members

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    // db.Dispose();
                    Dispose();
                }
            }
            this.disposed = true;
        }

        private void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}