using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Therapist.Interface;
using Therapist.Utils;

namespace Therapist.Controllers.API
{
    [RoutePrefix("api/therapist")]
    public class PushNotificationAPIController : ApiController
    {
        private readonly string authKey = ConfigurationManager.AppSettings["authkey"].ToString();
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ITherapist therapist;

        public PushNotificationAPIController(ITherapist therapist)
        {
            this.therapist = therapist;
        }
        // GET api/<controller>
        [Route("sendCronJobPushNotification/{authkey}")]
        [HttpGet]
        public HttpResponseMessage senPushNotification(string authkey)
        {
            HttpResponseMessage responseMessage = new HttpResponseMessage();
            try
            {
                if (authKey == authkey)
                {
                    ResponseStatusCode responseStatus = _pushNotificationHelperService.sendPushNotificationByCronJob();

                    responseMessage = ResponseBuilder.getSuccessResponse(responseStatus);
                }
                else
                {
                    responseMessage = ResponseBuilder.getInvalidTokenResponse();
                }
            }
            catch (Exception Ex)
            {
                logger.Error("Failed to excute Service " + Ex.Message.ToString() + "");
            }
            return responseMessage;
        }
    }
}