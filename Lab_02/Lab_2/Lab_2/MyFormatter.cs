using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{
    public class MyFormatter
    {
        public static string FormatUsdPrice(double price)
        {
            return price.ToString("C2", new CultureInfo("en-us"));
        }
    }
}
