using Primitive.Extensions;
using System.Text.RegularExpressions;

namespace Primitive.Extension.Tests
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void Verify_Random_Array_Generation()
        {
            var random = new Random();
            var result = random.Generate(10, 20, 10);
            foreach (var i in result)
            {
              Assert.True(i is >= 10 and <= 20); 
            }
        }


        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(5)]
        [InlineData(21)]
        [InlineData(26)]
        [InlineData(1000)]
        public void Verify_NextString(int size)
        {
            Regex regex = new Regex("^[A-Z]*$");
            var random = new Random();
            var result = random.NextString(size);
            Assert.True(result.Length == size);
            Assert.Matches(regex, result);
        }
    }
}