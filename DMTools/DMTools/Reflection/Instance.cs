using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DMTools.Reflection
{
    public class Instance
    {
        public T Create<T>()
        {
            return Activator.CreateInstance<T>();
        }

        public TReturn Create<TReturn, TEntity>(TEntity entity ,params Func<TEntity, object>[] expressions)
        {
            var param = new object[expressions.Length];
            var count = 0;
            expressions.ToList().ForEach(x => {
                param[count] = x.Invoke(entity);
                count++;
            });
            return (TReturn)Activator.CreateInstance(typeof(TReturn), param);
        }

        
    }
}
