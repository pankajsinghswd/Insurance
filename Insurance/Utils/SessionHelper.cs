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
    }
}