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

namespace Insurance.Controllers
{
    //[Authorize(Roles = RoleName.Admin + "," + RoleName.HRSTAFF)]
    [Authorize(Roles = RoleName.Admin)]
    public class HomeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public HomeController()
        {
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

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
    }
}