using Xunit;
using Lab_2;

namespace Lab_2.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var data = 0.05;
            var result = MyFormatter.FormatUsdPrice(data);
            var dataString = data.ToString();

            Assert.StartsWith($"${dataString[0]}", result);
            Assert.Contains(".", result);
            Assert.EndsWith($"{dataString[2]}{dataString[3]}", result);
        }
    }
}