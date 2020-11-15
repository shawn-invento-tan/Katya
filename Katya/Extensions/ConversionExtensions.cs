using System;
using System.Collections.Generic;
using System.Text;

namespace Katya.Extensions
{
    public static class ConversionExtensions
    {
        public static short ToInt16(this object obj)
        {
            return Convert.ToInt16(obj);
        }

        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static long ToInt64(this object obj)
        {
            return Convert.ToInt64(obj);
        }
    }
}
