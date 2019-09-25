using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMTools.Clone;

namespace DMTools.Collection
{
    public static class ListUtil
    {
        public static List<TSource> Copy<TSource>(this List<TSource> list) where TSource : struct
        {
           var newList = new List<TSource>();
            newList.AddRange(list);
            return newList;
        }

        public static List<TSource> CopyReferenceType<TSource>(this List<TSource> list) where TSource : ICloneable
        {
            var newList = new List<TSource>(list.Count);
            list.ForEach(x => newList.Add((TSource)x.Clone()));
            return newList;
        }

        public static List<TSource> CopyCloneableType<TSource>(this List<TSource> list)
            where TSource : ICloneable<TSource>
        {
            var newList = new List<TSource>(list.Count);
            list.ForEach(x => newList.Add(x.Clone()));
            return newList;
        }
    }
}
