using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Configuration;
namespace Telefonica.Pdt.Common
{
    public class NullableTypes
    {

        private static bool IsNull(object s)
        {
            if (Convert.IsDBNull(s))
            {
                return true;
            }
            if (s == null)
            {
                return true;
            }

            return false;
        }
        public static int? ConvertNullInt32(object s)
        {
            if (IsNull(s) == true)
            {
                return null;
            }
            return Convert.ToInt32(s);
        }
        public static DateTime? ConvertNullDateTime(object s)
        {
            if (IsNull(s) == true)
            {
                return null;
            }
            return Convert.ToDateTime(s);
        }
        public static decimal? ConvertNullDecimal(object s)
        {
            if (IsNull(s) == true)
            {
                return null;
            }
            return Convert.ToDecimal(s);
        }
        public static double? ConvertNullDouble(object s)
        {
            if (IsNull(s) == true)
            {
                return null;
            }
            return Convert.ToDouble(s);
        }

         
    }
}
