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
            ExceptionTest result = Instance.Create<ExceptionTest, System.Exception>(ex, c => c.Message);
            Assert.NotNull(result);
            Assert.Equal("MessageTest", result.Message);

        }

        [Fact]
        public void CreateTest()
        {
            var ex = Instance.Create<ExceptionTest>();
            Assert.NotNull(ex);
            Assert.IsType<ExceptionTest>(ex);

        }

        public class ExceptionTest : System.Exception
        {
            public ExceptionTest()
            {

            }
            public ExceptionTest(string msg) : base(msg)
            {
            }
        }
    }

    }
