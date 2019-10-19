using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using DMTools.Reflection;
using Xunit;

namespace DMTools.Test.Reflection
{
    public class PropertyTest
    {
        [Fact]
        public void GetPropertyTest()
        {
            ClassTest classe = new ClassTest();
            Assert.IsAssignableFrom<PropertyInfo>(classe.GetProperty(nameof(classe.Test)));                                
        }
    }

    public class ClassTest
    {
        public int Test { get; set; }
    }
}
