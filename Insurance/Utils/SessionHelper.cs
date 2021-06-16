using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Insurance.Models;
using Microsoft.AspNet.Identity;
using System.Net;
using log4net;
using Insurance.Utils;
using Insurance.Interface;

namespace Insurance.Utils
{
    public static class SessionHelper
    {
        readonly static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static bool IsAdmin()
        {
            return HttpContext.Current.User.IsInRole(AppConstants.ADMIN);
        }
        public static bool IsUser()
        {
            return HttpContext.Current.User.IsInRole(AppConstants.THERAPIST);
        }
        public static int CurrentUserId()
        {
            int userid = 0;
            if (HttpContext.Current.User.IsInRole(AppConstants.ADMIN))
            {
                string strguid = HttpContext.Current.User.Identity.GetUserId();
            }
            return userid;
        }

        public static string AspnetUserId()
        {
            string strguid = HttpContext.Current.User.Identity.GetUserId();
            return strguid;
        }

        public static bool IsEnglish()
        {
            string strlan = "";
            bool IsEnglish = false;
            HttpCookie cultureCookie = System.Web.HttpContext.Current.Request.Cookies["_culture"];
            if (cultureCookie != null)
                strlan = cultureCookie.Value;
            if (strlan.ToLower().Contains("ar"))
                IsEnglish = false;
            else
                IsEnglish = true;
            return IsEnglish;
        }

        public static int GetCountryId()
        {
            int CountryId = 0;
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("cookieLocation");
            if (cookie != null)
            {
                CountryId = Int32.Parse(cookie["CountryId"].ToString());
            }
            return CountryId;
        }
        public static int GetCityId()
        {
            int CityId = -1;
            HttpCookie cookie = HttpContext.Current.Request.Cookies.Get("cookieLocation");
            if (cookie != null)
            {
                CityId = Int32.Parse(cookie["CityId"].ToString());
            }
            return CityId;
        }
    }
}