using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFormAccounting0728.Extensions
{
    public static class StringExtension
    {
        public static Guid ToGuid(this string guidtxt)
        {
            if (Guid.TryParse(guidtxt, out Guid tempGuid))
                return tempGuid;
            else
                return Guid.Empty;
        }
    }
}