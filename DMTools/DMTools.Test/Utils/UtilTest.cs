using Xunit;
using DMTools.Utils;

namespace DMTools.Test.Reflection
{
    public class UtilTest 
    {
        [Theory]
        [InlineData(0, true)]
        [InlineData(1,false)]
        public void IsValueDefaultTest(int paran,bool result) => Assert.Equal(result, paran.IsValueDefault());

    }
}
