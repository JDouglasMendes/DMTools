using System;
using System.Collections.Generic;
using System.Text;

namespace DMTools.Utils
{
    public static class Util
    {
        public static bool IsNull(this object instance)
        {
            return instance == null;
        }

        public static bool IsValueDefault<T>(this T value) where T : struct => default(T).Equals(value);
    }
}
