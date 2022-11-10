using Primitive.Extensions;

namespace Primitive.Extension.Tests
{
    public class RandomExtensionsTests
    {
        [Fact]
        public void VerifyRandomArrayGeneration()
        {
            var random = new Random();
            var result = random.Generate(10, 20, 10);
            foreach (var i in result)
            {
              Assert.True(i is >= 10 and <= 20); 
            }
        }
    }
}