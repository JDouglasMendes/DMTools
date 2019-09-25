using System;
using System.Collections.Generic;
using System.Text;
using DMTools.Clone;
using DMTools.Collection;

namespace DMTools.Test.Collection
{
    public class Person : ICloneable, ICloneable<Person>
    {
        public string Name { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        Person ICloneable<Person>.Clone()
        {
            return new Person() {Name = this.Name};
        }
    }
}
