using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Interface;
using Insurance.Utils;
using Insurance.ViewModels;

namespace Insurance.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class DashboardController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AdminRepository adminRepository;
        public DashboardController()
        {
            adminRepository = new AdminRepository();
        }
        public ActionResult Index()
        {
            return View();
        }
        // GET: Dashboard
        public JsonResult GetDashboardData()
        {
            DashboardModel result=new DashboardModel();
            try
            {
                result = adminRepository.GetDashboardData();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}