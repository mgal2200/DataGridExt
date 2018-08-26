

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataGridExt.Models
{
   public static class Helpers 
    {
        private static CultureInfo thread;

        public static  object ChangeType(object val, Type type )
        {
            Type propType = type;
            if (propType == typeof(DateTime))
            {
                CultureInfo cul = CultureInfo.InvariantCulture;//Thread.CurrentThread.CurrentCulture;

                return System.Convert.ChangeType(val, propType, cul);
            }
            return System.Convert.ChangeType(val, propType);
        }

    }
}
