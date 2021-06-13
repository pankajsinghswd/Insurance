using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insurance.Utils
{
    public class InsuranceErrorService : Exception
    {
        private static long serialVersionUID;

        private ErrorDetails errorDetails;

        private Exception throwable;

        public InsuranceErrorService(ErrorDetails errorDetails, Exception throwable) :
                base()
        {
            this.errorDetails = this.errorDetails;
            this.throwable = this.throwable;
        }

        public InsuranceErrorService(ErrorDetails errorDetails) :
                base()
        {
            this.errorDetails = this.errorDetails;
            this.throwable = null;
        }

        public ErrorDetails getErrorDetails()
        {
            return this.errorDetails;
        }

        public Exception getThrowable()
        {
            return this.throwable;
        }
    }
}