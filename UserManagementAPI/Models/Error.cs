using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagementAPI.Models
{

    public class Error : Exception
    {
        public Error() : base() { }

        public Error(string message) : base(message) { }

        public Error(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
