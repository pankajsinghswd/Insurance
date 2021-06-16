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
    public class ManageUserController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private AdminRepository adminRepository;
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
        public ManageUserController()
        {
            adminRepository = new AdminRepository();
        }

        // GET: Get all users
        public ActionResult Index()
        {
            var result = adminRepository.GetUsers();
            return View(result);
        }
        
        //Create user
        public ActionResult CreateAsync()
        {
            UserCreateModel model = new UserCreateModel
            {
                InsuranceType = adminRepository.GetMasterData(QueryType.InsuranceType),
                GenderList = adminRepository.GetMasterData(QueryType.GetGender),
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(UserCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email, PhoneNumber = model.Phone };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await UserManager.AddToRoleAsync(user.Id, RoleName.User);
                    if (result.Succeeded)
                    {
                        CreateProfileViewModel create = new CreateProfileViewModel
                        {
                            Id = user.Id,
                            FullName_en = model.FullName_en,
                            FullName_local = model.FullName_local,
                            Gender = model.Gender,
                            InsuranceTypeId = model.InsuranceTypeId,
                            Interest_en = model.Interest_en,
                            Interest_local = model.Interest_local,
                            Password = model.ConfirmPassword
                        };
                        adminRepository.CreateProfile(create);
                        logger.Info("User Profile has been created.");
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "User email is already exists.");
                    return View();
                }
            }
            else
            {
                model.GenderList = adminRepository.GetMasterData(QueryType.GetGender);
                model.InsuranceType = adminRepository.GetMasterData(QueryType.InsuranceType);
            }
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var result = adminRepository.GetProfileById(id);
            result.InsuranceType = adminRepository.GetMasterData(QueryType.InsuranceType);
            result.GenderList = adminRepository.GetMasterData(QueryType.GetGender);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(UserEditModel model, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                model.ExistingPhotoPath = ProcessFile(model.ExistingPhotoPath, file);
                var result = adminRepository.UpdateProfile(model);

                return RedirectToAction("Index");
            }
            else
            {
                model.InsuranceType = adminRepository.GetMasterData(QueryType.InsuranceType);
                model.GenderList = adminRepository.GetMasterData(QueryType.GetGender);
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
        public JsonResult UserProfile(string id)
        {
            var result = adminRepository.ViewProfile(id);
            return Json(result);
        }
        [HttpPost]
        public JsonResult DeleteUser(string id)
        {
            var result = adminRepository.DeleteTherapist(id);
            return Json(result);
        }
        [HttpPost]
        public JsonResult BlockToUser(string id)
        {
            var result = adminRepository.BlockToTherapist(id);
            return Json(result);
        }
    }
}