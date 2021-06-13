using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;

namespace Insurance.Utils
{
    public class ResponseBuilder
    {
        readonly static log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static HttpResponseMessage GetResponse(dynamic dyRes, HttpStatusCode code)
        {
            string content = JsonConvert.SerializeObject(dyRes);
            StringContent sc = new StringContent(content);
            HttpResponseMessage rm = new HttpResponseMessage(code);
            rm.Content = sc;
            return rm;
        }
        public static HttpResponseMessage getErrorResponse(ErrorDetails errorDetails)
        {
            dynamic res = new ExpandoObject();
            try
            {
                //logger.Info("Setting Error Response");
                ResponseStatus responseStatus = new ResponseStatus();
                responseStatus.message = errorDetails.getMessage();
                responseStatus.statusCode = errorDetails.getErrorCode();
                responseStatus.errorTypeCode = errorDetails.getErrorTypeCode();
                responseStatus.errorType = errorDetails.getErrorType();
                res.responseStatus = responseStatus;
                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
                };
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject("Error while parsing error response " + errorDetails.ToString()))
                };
            }

        }

        public static HttpResponseMessage getSuccessResponse()
        {
            return getSuccessResponse(null);
        }

        public static HttpResponseMessage getSuccessResponse(Object obj)
        {
            //logger.Info("Setting Success Response");
            HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
            dynamic res = new ExpandoObject();
            ResponseStatus responseStatus = new ResponseStatus();
            responseStatus.statusCode = 200;
            res.responseStatus = responseStatus;
            if (obj != null)
            {
                res.responseData = obj;
            }
            else
            {
                res.responseData = new List<object>();
            }
            //logger.Info(Newtonsoft.Json.JsonConvert.SerializeObject(res));
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
            };
        }

        public static HttpResponseMessage getSuccessResponse(Object obj, ResponseStatus response)
        {
            dynamic res = new ExpandoObject();
            ResponseStatus responseStatus = new ResponseStatus();
            responseStatus.message = response.message;
            responseStatus.statusCode = response.statusCode;
            responseStatus.errorTypeCode = response.errorTypeCode;
            responseStatus.errorType = response.errorType;
            //res.data = new List<object>();
            res.responseStatus = responseStatus;
            res.responseData = null;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
            };

        }
        public static HttpResponseMessage getSuccessResponse(Object obj, ResponseStatusCode response)
        {
            dynamic res = new ExpandoObject();
            ResponseStatus responseStatus = new ResponseStatus();
            responseStatus.message = response.getMessage();
            responseStatus.statusCode = response.getStatusCode();
            responseStatus.errorTypeCode = response.getErrorTypeCode();
            responseStatus.errorType = response.getErrorType();
            //res.data = new List<object>();
            res.responseStatus = responseStatus;
            res.responseData = null;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
            };

        }

        public static HttpResponseMessage getInvalidResponse(Object obj)
        {
            dynamic res = new ExpandoObject();
            ResponseStatus responseStatus = new ResponseStatus();
            responseStatus.message = APIConstant.LoginFail;
            responseStatus.statusCode = APIConstant.BadRequest;
            responseStatus.errorTypeCode = 404;
            responseStatus.errorType = APIConstant.ModelState;
            //res.data = new List<object>();
            res.responseStatus = responseStatus;
            res.responseData = null;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
            };
        }

        public static HttpResponseMessage getInvalidTokenResponse()
        {
            dynamic res = new ExpandoObject();
            ResponseStatus responseStatus = new ResponseStatus();
            responseStatus.message = "Invalid token";
            responseStatus.statusCode = 404;
            responseStatus.errorTypeCode = 404;
            responseStatus.errorType = "Error";
            //res.data = new List<object>();
            res.responseStatus = responseStatus;
            res.responseData = null;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(res))
            };
        }
    }
}