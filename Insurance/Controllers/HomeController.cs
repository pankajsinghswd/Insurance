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
using Insurance.Resources;
using System.Drawing;

namespace Insurance.Controllers
{

    public class HomeController : MasterBaseController, IDisposable
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public bool IsEnglish { get; set; }
        UIRepository uiRepository;
        public HomeController()
        {
            IsEnglish = SessionHelper.IsEnglish();
            uiRepository = new UIRepository();
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
        #region Home page code
        public ActionResult Index()
        {
            InsuranceQuoteModel quoteModel = new InsuranceQuoteModel();
            quoteModel.InsuraceList = uiRepository.GetPolicyTypeList();
            return View(quoteModel);
        }
        [HttpPost]
        public ActionResult Index(InsuranceQuoteModel model)
        {
            //ModelState.Remove("AgeList");
            //ModelState.Remove("InsuraceList");
            //if (model != null)
            //{
            //    uiRepository.SaveInsuranceQuote(model);
            //    TempData["success"] = Master_en.QuoteSuccessMessage;
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    model.InsuraceList = uiRepository.GetPolicyTypeList();
            //    model.AgeList = uiRepository.GetAgeList();
            //}
            return View(model);
        }

        public ActionResult HouseHoldPartial()
        {
            HouseHoldInsuranceModels model = new HouseHoldInsuranceModels();
            model.TypeOfCoverageList = uiRepository.GetTypeOfCoverage();
            return PartialView("_household", model);
        }
        [HttpPost]
        public ActionResult HouseHoldQuote(HouseHoldInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.HouseHold);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        public ActionResult LifeSavingPartial()
        {
            LifeSavingsInsuranceModels model = new LifeSavingsInsuranceModels();
            return PartialView("_lifesaving", model);
        }
        [HttpPost]
        public ActionResult LifeSavingQuote(LifeSavingsInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.LifeSavings);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        public ActionResult MedicalPartial()
        {
            MedicalInsuranceModels model = new MedicalInsuranceModels();
            model.InsuranceCoverageList = uiRepository.GetTypeOfInsuranceCoverage();
            return PartialView("_medicalinsurance",model);
        }
        [HttpPost]
        public ActionResult MedicalQuote(MedicalInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.Medical);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        public ActionResult MedicalMalpracticePartial()
        {
            MedicalMalpracticeInsuranceModels model = new MedicalMalpracticeInsuranceModels();
            model.SpecialityList = uiRepository.GetSpeciality();
            model.LimitOfLiabilityList = uiRepository.GetLimitLiability();
            return PartialView("_medicalmalparctice",model);
        }
        [HttpPost]
        public ActionResult MedicalMalpracticeQuote(MedicalMalpracticeInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.MedicalMalpractice);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        public ActionResult TravelPartial()
        {
            TravelInsuranceModels model = new TravelInsuranceModels();
            return PartialView("_travelinsurance",model);
        }
        [HttpPost]
        public ActionResult TravelQuote(TravelInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.Travel);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        public ActionResult VehiclePartial()
        {
            VehicleInsuranceModels model = new VehicleInsuranceModels();
            return PartialView("_vehicleInsurance",model);
        }
        [HttpPost]
        public ActionResult VehicleQuote(VehicleInsuranceModels model)
        {
            if (model != null)
            {
                uiRepository.SaveInsuranceQuote(model, InsuranceType.VehicleInsurance);
                TempData["success"] = Master_en.QuoteSuccessMessage;
            }
            return RedirectToAction("Index");
        }
        #endregion
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
            ContactUsViewModels models = new ContactUsViewModels();
            models.AgeList = uiRepository.GetAgeList();
            return View(models);
        }
        [HttpPost]
        public ActionResult Contact(ContactUsViewModels model)
        {
            try
            {
                if (model != null)
                {
                    uiRepository.SaveContactUsSendEmail(model);
                    //sent email
                    TempData["success"] = Master_en.ContactUsSuccessMessage;
                    return RedirectToAction("Contact");
                }
                else
                {
                    model.AgeList = uiRepository.GetAgeList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return View(model);
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

        #region Insurance Model
        public ActionResult VehicleInsurance()
        {
            VehicleInsuranceModels model = new VehicleInsuranceModels();
            try
            {
                model.CaptchaImage = CaptchaImage();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            return View(model);
        }
        [Authorize]
        public JsonResult AddVehicleInsurance(VehicleInsuranceModels model)
        {
            try
            {
                uiRepository.AddVehicleInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Medical()
        {
            MedicalInsuranceModels model = new MedicalInsuranceModels();
            model.InsuranceCoverageList = uiRepository.GetTypeOfInsuranceCoverage();
            model.CaptchaImage = CaptchaImage();
            return View(model);
        }
        [Authorize]
        public JsonResult AddMedicalInsurance(MedicalInsuranceModels model)
        {
            try
            {
                uiRepository.AddMedicalInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult MedicalMalpractice()
        {
            MedicalMalpracticeInsuranceModels model = new MedicalMalpracticeInsuranceModels();
            model.CaptchaImage = CaptchaImage();
            model.SpecialityList = uiRepository.GetSpeciality();
            model.LimitOfLiabilityList = uiRepository.GetLimitLiability();
            return View(model);
        }
        [Authorize]
        public JsonResult AddMedicalMalpractieInsurance(MedicalMalpracticeInsuranceModels model)
        {
            try
            {
                uiRepository.AddMedicalMalPracticeInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult Travel()
        {
            TravelInsuranceModels model = new TravelInsuranceModels();
            model.CaptchaImage = CaptchaImage();
            return View(model);
        }
        [Authorize]
        public JsonResult AddTravelInsurance(TravelInsuranceModels model)
        {
            try
            {
                uiRepository.AddTravelInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult LifeAndSavings()
        {
            LifeSavingsInsuranceModels model = new LifeSavingsInsuranceModels();
            model.CaptchaImage = CaptchaImage();
            return View(model);
        }
        [Authorize]
        public JsonResult AddLifeSavingsInsurance(LifeSavingsInsuranceModels model)
        {
            try
            {
                uiRepository.AddLifeSavingsInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult HouseHold()
        {
            HouseHoldInsuranceModels model = new HouseHoldInsuranceModels();
            model.TypeOfCoverageList = uiRepository.GetTypeOfCoverage();
            model.CaptchaImage = CaptchaImage();
            return View(model);
        }
        [Authorize]
        public JsonResult AddHouseHoldInsurance(HouseHoldInsuranceModels model)
        {
            try
            {
                uiRepository.AddHouseHoldInsuranceQuote(model);
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return Json("error", JsonRequestBehavior.AllowGet);
            }

        }

        public ActionResult LoginPage()
        {
            UserLoginViewModel model = new UserLoginViewModel();
            return PartialView("~/Views/Home/_Login.cshtml", model);
        }

        #region Cpatcha Code
        public string CaptchaImage()
        {
            string[] strArray = new string[36];
            strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random autoRand = new Random();
            string strCaptcha = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int j = Convert.ToInt32(autoRand.Next(0, 62));
                strCaptcha += strArray[j].ToString();
            }
            Session["Captcha"] = strCaptcha;
            ImageConverter converter = new ImageConverter();
            // Response.BinaryWrite((byte[])converter.ConvertTo(CaptchaGeneration(strCaptcha), typeof(byte[])));
            return Convert.ToBase64String((byte[])converter.ConvertTo(CaptchaGeneration(strCaptcha), typeof(byte[])));
        }
        public ActionResult CaptchaImageReload()
        {
            string[] strArray = new string[36];
            strArray = new string[] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

            Random autoRand = new Random();
            string strCaptcha = string.Empty;
            for (int i = 0; i < 6; i++)
            {
                int j = Convert.ToInt32(autoRand.Next(0, 62));
                strCaptcha += strArray[j].ToString();
            }
            Session["Captcha"] = strCaptcha;
            ImageConverter converter = new ImageConverter();
            // Response.BinaryWrite((byte[])converter.ConvertTo(CaptchaGeneration(strCaptcha), typeof(byte[])));
            return Json(Convert.ToBase64String((byte[])converter.ConvertTo(CaptchaGeneration(strCaptcha), typeof(byte[]))), JsonRequestBehavior.AllowGet);
        }
        public Bitmap CaptchaGeneration(string captchatxt)
        {
            Bitmap bmp = new Bitmap(133, 48);
            using (Graphics graphics = Graphics.FromImage(bmp))
            {
                Font font = new Font("Tahoma", 14);
                graphics.FillRectangle(new SolidBrush(Color.Gray), 0, 0, bmp.Width, bmp.Height);
                graphics.DrawString(captchatxt, font, new SolidBrush(Color.Gold), 25, 10);
                graphics.Flush();
                font.Dispose();
                graphics.Dispose();
            }
            return bmp;
        }
        public string ValidateCaptcha(string Code)
        {
            try
            {
                if (Session["Captcha"].ToString() == Code)
                {
                    return "1";
                }
                else
                {
                    return "0";
                }
            }
            catch { return "0"; }
        }
        #endregion

        #endregion

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