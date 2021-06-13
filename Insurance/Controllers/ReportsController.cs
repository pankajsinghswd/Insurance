using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Insurance.Interface;
using Insurance.Utils;

namespace Insurance.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ReportsController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AdminRepository adminRepository;
        public ReportsController()
        {
            adminRepository = new AdminRepository();
        }
        public ActionResult Index()
        {
            var result = adminRepository.GetUsers();
            return View(result);
        }
    }
}