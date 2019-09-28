using DMTools.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMTools.Reflection
{
    public class Mapper
    {
        public TDestiny To<TEntry,TDestiny>(TEntry entry)
        {
    
            var destiny = Instance.Create<TDestiny>();

            var properties = entry.GetType().GetProperties().ToList();
            properties.ForEach(x =>
            {
                var propertyDestiny = destiny.GetProperty(x.Name);
                if (!propertyDestiny.IsNull())
                    propertyDestiny.SetValue(destiny, x.GetValue(entry));
            });

            return destiny;
        }
    }
}
