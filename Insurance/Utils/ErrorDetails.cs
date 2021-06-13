using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Utils
{
    public class ErrorDetails
    {
        private int errorCode;

        private int errorTypeCode;

        private String errorType;

        private String message;

        public ErrorDetails(int errorCode, int errorTypeCode, String errorType, String message) :
                base()
        {
            this.errorCode = this.errorCode;
            this.errorTypeCode = this.errorTypeCode;
            this.errorType = this.errorType;
            this.message = this.message;
        }

        public int getErrorCode()
        {
            return this.errorCode;
        }

        public void setErrorCode(int errorCode)
        {
            this.errorCode = this.errorCode;
        }

        public int getErrorTypeCode()
        {
            return this.errorTypeCode;
        }

        public void setErrorTypeCode(int errorTypeCode)
        {
            this.errorTypeCode = this.errorTypeCode;
        }

        public String getErrorType()
        {
            return this.errorType;
        }

        public void setErrorType(String errorType)
        {
            this.errorType = this.errorType;
        }

        public String getMessage()
        {
            return this.message;
        }

        public void setMessage(String message)
        {
            this.message = this.message;
        }


        public override String ToString()
        {
            return ("ErrorDetails [errorCode="
                        + (this.errorCode + (", errorTypeCode="
                        + (this.errorTypeCode + (", errorType="
                        + (this.errorType + (", message="
                        + (this.message + "]"))))))));
        }
    }
}