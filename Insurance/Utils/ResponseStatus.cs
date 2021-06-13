using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Utils
{
    public class ResponseStatus
    {
        public int statusCode { get; set; }

        public string message { get; set; }

        public int errorTypeCode { get; set; }

        public string errorType { get; set; }

        public int getStatusCode(int statuscode)
        {
            return this.statusCode;
        }
    }
    public class ResponseStatusCode
    {
        private int statusCode { get; set; }

        private string message { get; set; }

        private int errorTypeCode { get; set; }

        private string errorType { get; set; }

        public int getStatusCode()
        {
            return this.statusCode;
        }
        public void setStatusCode(int statusCode)
        {
            this.statusCode = statusCode;
        }

        public string getMessage()
        {
            return this.message;
        }
        public void setMessage(string message)
        {
            this.message = message;
        }
        public int getErrorTypeCode()
        {
            return this.errorTypeCode;
        }
        public void setErrorTypeCode(int errorTypeCode)
        {
            this.errorTypeCode = errorTypeCode;
        }

        public string getErrorType()
        {
            return this.errorType;
        }
        public void setErrorType(string errorType)
        {
            this.errorType = errorType;
        }

    }
}