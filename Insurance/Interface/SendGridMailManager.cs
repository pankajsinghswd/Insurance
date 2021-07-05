using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Policy;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Insurance.Interface
{
    public class SendGridMailManager
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        readonly string authKey;
        readonly string emailFrom;
        readonly string displayName;
        public SendGridMailManager()
        {
            authKey = ConfigurationManager.AppSettings["AuthKey"];
            emailFrom = ConfigurationManager.AppSettings["EmailFrom"];
            displayName = ConfigurationManager.AppSettings["DisplayName"];
        }
        public Task SendEmailOTPAsync(string email, string subject, string OTP)
        {
            Dictionary<string, string> mailParam = new Dictionary<string, string>();
            mailParam.Add("%Email_OTP%", OTP);

            string body = PrepareMailBody("EmailOTP.html", mailParam);

            return Execute(subject, OTP, body, email);
        }
        public Task ForgotPasswordMessageAsync(string email, string userId, string activationCode)
        {
            string urlformail = ConfigurationManager.AppSettings["baseUrl"] + "/Account/ResetPassword?userId=" + userId + "&Code=" + activationCode;

            Dictionary<string, string> mailParam = new Dictionary<string, string>();
            mailParam.Add("%link%", urlformail);

            string body = PrepareMailBody("forgotpassword.html", mailParam);

            return Execute("User Reset Password", "", body, email);
        }
        public Task Execute(string subject, string message, string body, string toEmail)
        {
            //var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
            //var client = new SendGridClient(apiKey);
            //var from = new EmailAddress("test@example.com", "Example User");
            //var subject = "Sending with SendGrid is Fun";
            //var to = new EmailAddress("test@example.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);

            var client = new SendGridClient(authKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress(emailFrom, displayName),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = body
            };
            msg.AddTo(new EmailAddress(toEmail));
            return client.SendEmailAsync(msg);
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
        private string ReadTemplate(string nameOfTemplate)
        {
            string templatePath, templateText;
            templatePath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplate/");

            var reader = new StreamReader(templatePath + nameOfTemplate);
            templateText = reader.ReadToEnd();
            reader.Close();
            return templateText;
        }
        #region Not Use 
        public async void SendEmail(string address, string toName, string fromName, string fromAddress, string subject, string body)
        {
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom(new EmailAddress("er.ashwin93@gmail.com", fromName));
            var recipients = new List<EmailAddress>
            {
                new EmailAddress(address, toName),
            };
            msg.AddTos(recipients);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Text, body);

            await Execute(msg);
        }
        private async Task Execute(SendGridMessage msg)
        {
            try
            {
                var client = new SendGridClient(authKey);
                var response = await client.SendEmailAsync(msg);
            }
            catch (Exception Ex)
            {
                logger.Error(Ex.Message.ToString());
            }
        }
        #endregion
    }
}