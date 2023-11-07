using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TseTmc.Helper
{
   public static class DatetimeHelper
    {
        public static DateTime ToGregorianDate(this string persianDate)
        {
            string[] dateChars = persianDate.Split('/');
            return new DateTime(Convert.ToInt32(dateChars[0]), Convert.ToInt32(dateChars[1]), Convert.ToInt32(dateChars[2]), new PersianCalendar());
        }
    }
}
