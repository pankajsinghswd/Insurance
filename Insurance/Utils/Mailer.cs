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

        public bool SendEmailInsuracneQuote(InsuranceQuoteModel model, bool IsEnglish)
        {
            try
            {
                if (model != null)
                {

                    if (model.PurposeofInsurance == "New Insurance" && IsEnglish == false)
                    {
                        model.PurposeofInsurance = "تأمين جديد";
                    }
                    if (model.PurposeofInsurance == "Transfer of ownership" && IsEnglish == false)
                    {
                        model.PurposeofInsurance = "نقل ملكية";
                    }
                    Dictionary<string, string> mailParam = new Dictionary<string, string>();
                    mailParam.Add("%PurposeofInsurance%", model.PurposeofInsurance);
                    mailParam.Add("%InsuranceType%", model.SelectedInsurance);
                    mailParam.Add("%FirstName%", model.FirstName);
                    mailParam.Add("%LastName%", model.LastName);
                    mailParam.Add("%Email%", model.EmailAddress);
                    mailParam.Add("%PhoneNumber%", model.PhoneNumber);
                    mailParam.Add("%Age%", model.Age);

                    string body = PrepareMailBodyForSync(IsEnglish ? "InsuranceQuote_en.html" : "InsuranceQuote_ar.html", mailParam);

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