using System;
using System.Linq;
using System.Web.Mvc;
using Insurance.Interface;
using Insurance.Utils;
using Insurance.ViewModels;

namespace Insurance.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class StaticContentController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AdminRepository adminRepository;
        public StaticContentController()
        {
            adminRepository = new AdminRepository();
        }
        public ActionResult Index()
        {
            var result = adminRepository.GetStaticPageContent();
            return View(result);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StaticContentInsert model)
        {
            if (ModelState.IsValid)
            {
                StaticContentUpdate data = new StaticContentUpdate
                {
                    PageName = model.PageName,
                    PageTitle_en = model.PageTitle_en,
                    PageTitle_local = model.PageTitle_local,
                    PageContent_en = model.PageContent_en,
                    PageContent_local = model.PageContent_local,
                    AspNetUserId = SessionHelper.AspnetUserId()
                };
                int result = adminRepository.AddUpdateContent(data);
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var result = adminRepository.GetPageContentById(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(StaticContentUpdate model)
        {
            if (ModelState.IsValid)
            {
                model.AspNetUserId = SessionHelper.AspnetUserId();
                int result = adminRepository.AddUpdateContent(model);
                if (result != 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}