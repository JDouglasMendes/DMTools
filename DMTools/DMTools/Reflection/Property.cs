using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DMTools.Reflection
{
    public static class PropertyUtil
    {
        public static PropertyInfo GetProperty(this object type, string name)
        {
            return type.GetType().GetProperty(name);
        }
    }
}
