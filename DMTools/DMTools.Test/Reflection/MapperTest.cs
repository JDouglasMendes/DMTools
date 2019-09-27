using DMTools.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTools.Test.Reflection
{
    public class MapperTest
    {
        [Fact]
        public void ToTest()
        {
            var class1 = new Class1();
            class1.propriedade = 100;
            var convert = new Mapper();
            var class2 = convert.To<Class1, Class2>(class1);
            Assert.Equal(class1.propriedade, class2.propriedade);
        }
    }

    public class Class1
    {
        public int propriedade1 { get; set; }
        public int propriedade { get; set; }
    }

    public class Class2
    {
        public int propriedade { get; set; }
    }
}
