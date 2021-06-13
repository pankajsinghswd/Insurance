using Microsoft.AspNet.Identity.Owin;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Insurance.Interface;
using Insurance.Models;
using Insurance.Utils;
using Insurance.ViewModels;

namespace Insurance.Controllers
{
    [Authorize(Roles = RoleName.Admin)]
    public class ManagePolicyController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AdminRepository adminRepository;
        public ManagePolicyController()
        {
            adminRepository = new AdminRepository();
        }
        // GET: ManagePolicy
        public ActionResult Index()
        {
            var result = adminRepository.GetPolicyTypeList();
            return View(result);
        }

        //Create user
        public ActionResult CreateAsync()
        {
            ManagePolicyTypeModels model = new ManagePolicyTypeModels();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(EditPolicyTypeModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ManagePolicyTypeModels _model = new ManagePolicyTypeModels();
                _model.Name = model.Name;
                _model.Image = ProcessFile(model.Image, file);
                adminRepository.CreatePolicyType(_model);
                logger.Info("Policy type has been created.");
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Model not valid");
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var result = adminRepository.GetPolicyTypeById(id);
            EditPolicyTypeModel _model = new EditPolicyTypeModel();
            _model.Id = result.Id;
            _model.Name = result.Name;
            _model.Image = result.Image;
            return View(_model);
        }
        [HttpPost]
        public ActionResult Edit(EditPolicyTypeModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                ManagePolicyTypeModels _model = new ManagePolicyTypeModels();
                _model.Id = model.Id;
                _model.Name = model.Name;
                _model.Image = ProcessFile(model.Image, file);
                var result = adminRepository.UpdatePolicyType(_model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public string ProcessFile(string ExistingPhotoPath, HttpPostedFileBase file)
        {
            string fileName = ExistingPhotoPath;
            try
            {
                if (file != null)
                {
                    string filePath = Server.MapPath("~/Content/userProfile/");
                    if (ExistingPhotoPath != null)
                    {
                        string existingFilePath = Path.Combine(filePath, ExistingPhotoPath);
                        System.IO.File.Delete(existingFilePath);
                    }

                    fileName = Path.GetFileName(Convert.ToString(Guid.NewGuid()) + Path.GetExtension(file.FileName));
                    string path = Path.Combine(filePath, fileName);
                    file.SaveAs(path);
                }
            }
            catch (Exception Ex)
            {
                logger.Error(Ex.Message.ToString());
            }
            return fileName;
        }

        [HttpPost]
        public JsonResult DeletePolicyType(string id)
        {
            var result = adminRepository.DeletePolicyType(id);
            return Json(result);
        }
    }
}