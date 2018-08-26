

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilterFactory.Helpers
{
   public static class Helpers 
    {
        private static CultureInfo thread;

        public static  object ChangeType(object val, Type type )
        {
            Type propType = type.UnderlyingIfNull();
            if (propType == typeof(DateTime))
            {
                CultureInfo cul =FilterOptions.CultureInfo ??Thread.CurrentThread.CurrentCulture;

                return System.Convert.ChangeType(val, propType, cul);
            }
            return System.Convert.ChangeType(val, propType);
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }

        public static  Type UnderlyingIfNull(this Type type  )
        {
            if (IsNullable(type))
            {
                return Nullable.GetUnderlyingType(type);

            }
            return type;
        }

        public static bool IsNumericType(this Type type)
        {

            if (new[] { typeof(int), typeof(decimal) }.Contains(type))
            {
                return true;
            }
            return false;
        }

        public static  Boolean IsNullable(this Type  type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                return true;
            return false;
        }
       

    }
}
