using DMTools.Reflection;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DMTools.Test.Reflection
{
    public class InstanceTest
    {
        [Fact]
        public void CreateExpressionTest()
        {
            var ex = new System.Exception("MessageTest");
            var instance = new Instance();
            ExceptionTest result = instance.Create<ExceptionTest, System.Exception>(ex, c => c.Message);
            Assert.NotNull(result);
            Assert.Equal("MessageTest", result.Message);
           
        }
    }

    public class ExceptionTest : System.Exception
    {
        public ExceptionTest(string msg): base(msg)
        {
        }
    }

}
