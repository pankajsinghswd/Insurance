using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Linq;
using System.Net.Mime;
using System.IO;
using System.Configuration;
using System.Text;
using System.Web.Hosting;
using System.Threading.Tasks;
using System.Net;
using Insurance.Models;
using Insurance.Resources;
using System.Globalization;

namespace Insurance.Utils
{
    public class Mailer
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public bool SendMailFromAdmin(string strTo, string strCC, string message, string subject, string MailTemplate = "", string Name = "User", string stringArray = "test", string Emailmsg = "Please find your link below")
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(strTo);

        //        string[] result = stringArray.Split(',');
        //        var urlLink = ConfigurationManager.AppSettings["URLLink"];
        //        var Template = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["EmailTemplate"]);
        //        var reader = new StreamReader(Template + MailTemplate);

        //        string body = reader.ReadToEnd().Replace("%TEMPLATE_TOKEN1%", Name).Replace("%TEMPLATE_TOKEN4%", Emailmsg).Replace("%TEMPLATE_TOKEN2%", result[0]); // and so on as needed...
        //        AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
        //        //string imageSource = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["Icons"] + "mailHeader.jpg");
        //        //LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
        //        // PictureRes.ContentId = "logo_headermail";
        //        mail.AlternateViews.Add(altView);
        //        mail.Body = message;
        //        mail.Subject = subject;
        //        mail.IsBodyHtml = true;
        //        mail.Priority = MailPriority.High;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.UseDefaultCredentials = false;
        //        mail.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
        //        smtp.Host = ConfigurationManager.AppSettings["Host"];
        //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        //object someObject = "some object";
        //        //smtp.SendAsync(mail, someObject);
        //        reader.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error in sending mail to " + strTo, ex);
        //        return false;
        //    }
        //}

        //public bool SendMailFromAdmin(List<string> strTo, List<string> strCC, string message, string subject, string MailTemplate = "", string Name = "User", string stringArray = "test", string Emailmsg = "Please find your link below")
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(string.Join<string>(",", strTo));
        //        string[] result = stringArray.Split(',');
        //        var urlLink = ConfigurationManager.AppSettings["URLLink"];
        //        var Template = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["EmailTemplate"]);
        //        var reader = new StreamReader(Template + MailTemplate);

        //        string body = reader.ReadToEnd().Replace("%TEMPLATE_TOKEN1%", Name).Replace("%TEMPLATE_TOKEN4%", Emailmsg).Replace("%TEMPLATE_TOKEN2%", result[0]); // and so on as needed...
        //        AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
        //        //string imageSource = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["Icons"] + "mailHeader.jpg");
        //        //LinkedResource PictureRes = new LinkedResource(imageSource, MediaTypeNames.Image.Jpeg);
        //        // PictureRes.ContentId = "logo_headermail";
        //        mail.AlternateViews.Add(altView);
        //        mail.Body = message;
        //        mail.Subject = subject;
        //        mail.IsBodyHtml = true;
        //        mail.Priority = MailPriority.High;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.UseDefaultCredentials = false;
        //        mail.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
        //        smtp.Host = ConfigurationManager.AppSettings["Host"];
        //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        //object someObject = "some object";
        //        //smtp.SendAsync(mail, someObject);
        //        reader.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error in sending mail ", ex);
        //        return false;
        //    }
        //}

        //public bool SendBulkMailFromAdmin(List<string> strTo, List<string> strCC, string message, string subject, string MailTemplate = "", string Name = "User", string stringArray = "test", string Emailmsg = "Please find your link below")
        //{
        //    try
        //    {
        //        MailMessage mail = new MailMessage();
        //        mail.To.Add(string.Join<string>(",", strTo));
        //        string[] result = stringArray.Split(',');
        //        var urlLink = ConfigurationManager.AppSettings["URLLink"];
        //        var Template = System.Web.HttpContext.Current.Server.MapPath("~" + ConfigurationManager.AppSettings["EmailTemplate"]);
        //        var reader = new StreamReader(Template + MailTemplate);

        //        string body = reader.ReadToEnd().Replace("%TEMPLATE_TOKEN1%", Name).Replace("%TEMPLATE_TOKEN4%", Emailmsg).Replace("%TEMPLATE_TOKEN2%", result[0]); // and so on as needed...
        //        AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);

        //        StringBuilder str = new StringBuilder();
        //        str.Append(message);
        //        mail.Body = str.ToString();
        //        mail.Subject = subject;
        //        mail.IsBodyHtml = true;

        //        mail.Priority = MailPriority.High;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.UseDefaultCredentials = false;
        //        mail.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
        //        smtp.Host = ConfigurationManager.AppSettings["Host"];
        //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //        //object someObject = "some object";
        //        //smtp.SendAsync(mail, someObject);
        //        reader.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error in sending mail ", ex);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// send account activation message over mail
        ///// </summary>
        ///// <param name="strTo"></param>
        ///// <param name="languageCode"></param>
        ///// <returns></returns>
        //public bool SendAccountActivationMessage(string strTo, string languageCode)
        //{
        //    try
        //    {
        //        var encryptemail = Encrypt.Encryptdata(strTo);
        //        string urlformail = ConfigurationManager.AppSettings["URLLink"] + "/home/Mailverification?token=" + encryptemail + "&lan=" + languageCode;

        //        Dictionary<string, string> mailParam = new Dictionary<string, string>();
        //        mailParam.Add("%link%", urlformail);

        //        string body = PrepareMailBody(languageCode == AppConstants.ARABIC_LANGUAGE ? "accountactivation_ar.html" : "accountactivation_en.html", mailParam);

        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.To.Add(strTo);
        //        mailMessage.Subject = languageCode == AppConstants.ARABIC_LANGUAGE ? "مرحبا بكم في Clicflyer - تفعيل وصلة" : "Welcome to ClicFlyer - Activation Link";

        //        AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
        //        mailMessage.AlternateViews.Add(altView);

        //        SendMail(mailMessage);

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error in sending mail " + strTo, ex);
        //        return false;
        //    }
        //}

        //public bool SendSyncHistoryMessage(string strTo, string syncHIstoryTable, string ErroLogTabel, string strSyncMode)
        //{
        //    try
        //    {

        //        Dictionary<string, string> mailParam = new Dictionary<string, string>();
        //        mailParam.Add("%TEMPLATE_TOKEN1%", syncHIstoryTable);
        //        mailParam.Add("%TEMPLATE_TOKEN4%", ErroLogTabel);

        //        string body = PrepareMailBodyForSync("MailSyncHistory_ErroLog.html", mailParam);

        //        MailMessage mailMessage = new MailMessage();
        //        mailMessage.To.Add(strTo);
        //        mailMessage.Subject = strSyncMode + "Syncing Details";

        //        AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
        //        mailMessage.AlternateViews.Add(altView);

        //        //SendMail(mailMessage);
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        //        smtp.UseDefaultCredentials = false;
        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);

        //        smtp.Host = ConfigurationManager.AppSettings["Host"];
        //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //        smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
        //        smtp.EnableSsl = true;
        //        string userState = Guid.NewGuid().ToString();
        //        //smtp.SendMailAsync(mailMessage);
        //        BackgroundTaskRunner.FireAndForgetTask(async () =>
        //        {
        //            await smtp.SendMailAsync(mailMessage);
        //        });
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Error("Error in sending mail " + strTo, ex);
        //        return false;
        //    }
        //}


        /// <summary>
        /// Send forgot Password Message
        /// </summary>
        /// <param name="strTo"></param>
        /// <param name="userId"></param>
        /// <param name="activationCode"></param>
        /// <param name="languageCode"></param>
        /// <returns></returns>
        public bool SendForgotPasswordMessage(string strTo, string userId, string activationCode)
        {
            try
            {


                string urlformail = ConfigurationManager.AppSettings["URLLink"] + "/Account/ResetPassword?userId=" + userId + "&code=" + activationCode;

                Dictionary<string, string> mailParam = new Dictionary<string, string>();
                mailParam.Add("%link%", urlformail);

                string body = PrepareMailBody("forgotpassword.html", mailParam);

                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(strTo);
                mailMessage.Subject = "Reset your password on Insurance";

                AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                mailMessage.AlternateViews.Add(altView);
                SendMail(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail " + strTo, ex);
                return false;
            }
        }

        /// <summary>
        /// Method to send mail as per mail message
        /// </summary>
        /// <param name="mailMessage"></param>
        /// <returns></returns>
        private bool SendMail(MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);

                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
                smtp.EnableSsl = true;
                string userState = Guid.NewGuid().ToString();
                //smtp.Send(mailMessage);
                BackgroundTaskRunner.FireAndForgetTask(async () =>
                {
                    await smtp.SendMailAsync(mailMessage);
                });
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail ", ex);
                return false;
            }
        }
        private bool SendMailForOTP(MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);

                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["MailAddress"], ConfigurationManager.AppSettings["Password"]);
                smtp.EnableSsl = true;
                string userState = Guid.NewGuid().ToString();
                //smtp.SendMailAsync(mailMessage);
                smtp.Send(mailMessage);
                //object someObject = "some object";
                //smtp.SendAsync(mailMessage, someObject);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail ", ex);
                return false;
            }
        }
        private string PrepareMailBody(string nameOfTemplate, Dictionary<string, string> mailParam)
        {
            string mailBody = "";
            string replacebody = "";
            try
            {
                //read mail body
                mailBody = ReadTemplate(nameOfTemplate);

                foreach (var param in mailParam)
                {
                    replacebody = mailBody.Replace(param.Key, param.Value);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error in preparing mail body ", ex);
            }
            return replacebody;
        }

        private string PrepareMailBodyForSync(string nameOfTemplate, Dictionary<string, string> mailParam)
        {
            string mailBody = "";
            string replacebody = "";
            try
            {
                //read mail body
                mailBody = ReadTemplate(nameOfTemplate);

                foreach (var param in mailParam)
                {
                    replacebody = mailBody.Replace(param.Key, param.Value);
                    mailBody = replacebody;
                }
            }
            catch (Exception ex)
            {
                logger.Error("Error in preparing mail body ", ex);
            }
            return replacebody;
        }

        private string ReadTemplate(string nameOfTemplate)
        {
            string templatePath, templateText;
            templatePath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/");

            var reader = new StreamReader(templatePath + nameOfTemplate);
            templateText = reader.ReadToEnd();
            reader.Close();
            return templateText;
        }

        public bool SendEmailInsuracneQuote<T>(T model, bool IsEnglish,string insuranceTye)
        {
            try
            {
                string body = string.Empty;
                if (model != null)
                {
                    //house hold
                    if (insuranceTye == InsuranceType.HouseHold) 
                    {
                        HouseHoldInsuranceModels _model = model as HouseHoldInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%",_model.SelectedInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%SumAssured%", _model.SumAssured);
                        mailParam.Add("%Location%", _model.Location);
                        mailParam.Add("%TypeOfCoverage%", _model.TypeOfCoverage);
                        mailParam.Add("%StartDate%", CommonFunctions.GetSelectedDate(_model.SelectedDate));
                        body = PrepareMailBodyForSync(IsEnglish ? "HouseHoldQuote_en.html" : "HouseHoldQuote_ar.html", mailParam);
                    }
                    //Life & Savings
                    if (insuranceTye == InsuranceType.LifeSavings)
                    {
                        LifeSavingsInsuranceModels _model = model as LifeSavingsInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%", _model.SelectedInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%LimitOfCoverage%", _model.LimitOfCoverage);
                        mailParam.Add("%StartDate%", CommonFunctions.GetSelectedDate(_model.SelectedDate));
                        body = PrepareMailBodyForSync(IsEnglish ? "LifeSavingQuote_en.html" : "LifeSavingQuote_ar.html", mailParam);
                    }
                    //Medical
                    if (insuranceTye == InsuranceType.Medical)
                    {
                        MedicalInsuranceModels _model = model as MedicalInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%", _model.SelectedInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%TypeOfCoverage%", _model.InsuranceCoverage);
                        mailParam.Add("%StartDateInsurance%", CommonFunctions.GetSelectedDate(_model.SelectedDate));
                        body = PrepareMailBodyForSync(IsEnglish ? "MedicalQuote_en.html" : "MedicalQuote_ar.html", mailParam);
                    }
                    //Medical Malpractice
                    if (insuranceTye == InsuranceType.MedicalMalpractice)
                    {
                        MedicalMalpracticeInsuranceModels _model = model as MedicalMalpracticeInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%", _model.SelectedInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%Speciality%", _model.Speciality);
                        mailParam.Add("%LimitOfLiability%", _model.LimitOfLiability);
                        mailParam.Add("%StartDateInsurance%", CommonFunctions.GetSelectedDate(_model.SelectedDate));
                        body = PrepareMailBodyForSync(IsEnglish ? "MedicalMalPracticeQuote_en.html" : "MedicalMalPracticeQuote_ar.html", mailParam);
                    }
                    //Travel
                    if (insuranceTye == InsuranceType.Travel)
                    {
                        TravelInsuranceModels _model = model as TravelInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%", _model.SelectedInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%Duration%", _model.Duration);
                        mailParam.Add("%PassportNumber%", _model.PassportNumber);
                        mailParam.Add("%Destination%", _model.Destination);
                        body = PrepareMailBodyForSync(IsEnglish ? "TravelQuote_en.html" : "TravelQuote_ar.html", mailParam);
                    }
                    //Vehicle Insurance
                    if (insuranceTye == InsuranceType.VehicleInsurance)
                    {
                        VehicleInsuranceModels _model = model as VehicleInsuranceModels;
                        Dictionary<string, string> mailParam = new Dictionary<string, string>();
                        mailParam.Add("%InsuranceType%", _model.SelectedInsurance);
                        mailParam.Add("%PurposeOfInsurance%", _model.PurposeOfInsurance);
                        mailParam.Add("%ID%", _model.ID);
                        mailParam.Add("%RegistrationType%", _model.RegistrationType);
                        mailParam.Add("%RegistrationTypeNo%", _model.RegistrationTypeNo);
                        mailParam.Add("%StartDate%", CommonFunctions.GetSelectedDate(_model.SelectedDate));
                        body = PrepareMailBodyForSync(IsEnglish ? "VehicleQuote_en.html" : "VehicleQuote_ar.html", mailParam);
                    }
                    
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(ConfigurationManager.AppSettings["contactusemail"]);
                    mailMessage.Subject = Master_en.GetaFreeInsuranceQuote;
                    AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                    mailMessage.AlternateViews.Add(altView);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
                    //send email
                    SendMail(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail ", ex);
                return false;
            }
        }

        public bool SendEmailContactUs(ContactUsViewModels model, bool IsEnglish)
        {
            try
            {
                if (model != null)
                {
                    Dictionary<string, string> mailParam = new Dictionary<string, string>();
                    mailParam.Add("%Name%", model.Name);
                    mailParam.Add("%Email%", model.EmailAddress);
                    mailParam.Add("%PhoneNumber%", model.PhoneNumber);
                    mailParam.Add("%Age%", model.Age);
                    mailParam.Add("%Comment%", model.Comment);

                    string body = PrepareMailBodyForSync(IsEnglish ? "ContactUs_en.html" : "ContactUs_ar.html", mailParam);
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.To.Add(ConfigurationManager.AppSettings["contactusemail"]);
                    mailMessage.Subject = Master_en.MenuContactUs;

                    AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                    mailMessage.AlternateViews.Add(altView);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
                    //send email
                    SendMail(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail ", ex);
                return false;
            }
        }

        public bool UserForgotPasswordEmail(string Email, string EmailLink, bool IsEnglish)
        {
            try
            {
                Dictionary<string, string> mailParam = new Dictionary<string, string>();
                mailParam.Add("%link%", EmailLink);

                string body = PrepareMailBodyForSync(IsEnglish ? "forgotpassword_en.html" : "forgotpassword_ar.html", mailParam);
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(Email);
                mailMessage.Subject = Master_en.UserLogin_ForgotPassword;

                AlternateView altView = AlternateView.CreateAlternateViewFromString(body, null, MediaTypeNames.Text.Html);
                mailMessage.AlternateViews.Add(altView);
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["SenderMailAddress"]);
                //send email
                SendMail(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                logger.Error("Error in sending mail ", ex);
                return false;
            }
        }
        public static class BackgroundTaskRunner
        {
            public static void FireAndForgetTask(Action action)
            {
                HostingEnvironment.QueueBackgroundWorkItem(cancellationToken => // .Net 4.5.2 required
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        // TODO: handle exception
                    }
                });
            }

            /// <summary>
            /// Using async
            /// </summary>
            public static void FireAndForgetTask(Func<Task> action)
            {
                HostingEnvironment.QueueBackgroundWorkItem(async cancellationToken => // .Net 4.5.2 required
                {
                    try
                    {
                        await action();
                    }
                    catch (Exception e)
                    {
                        // TODO: handle exception
                    }
                });
            }
        }
    }
}