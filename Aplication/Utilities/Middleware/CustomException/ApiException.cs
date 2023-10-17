using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Utilities.Middleware.CustomException
{
    public class ApiException: Exception
    {
#pragma warning disable
        public ApiException() : base() { }

        public ApiException(string message) : base(message)
        {
            
        }

        public ApiException(string message, params object[] args) : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
            
        }

    }
}
