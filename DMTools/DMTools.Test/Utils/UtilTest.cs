using System;
using System.Runtime.InteropServices.ComTypes;
using Xunit;
using DMTools.Utils;

namespace DMTools.Test.Utils
{
    public class UtilTest 
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1,false)]
        public void IsValueDefaultTest(int paran,bool result) => Assert.Equal(result, paran.IsValueDefault());

        [Fact]
        public void IsNullTestValid()
        {
            var obj = new object();
            Assert.False(obj.IsNull());
        }

        [Fact]
        public void IsNullTestInvalid()
        {
            object obj = null;
            Assert.True(obj.IsNull());
        }
    }
}
