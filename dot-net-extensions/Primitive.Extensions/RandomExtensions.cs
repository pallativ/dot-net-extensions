namespace Primitive.Extensions
{
    public static class RandomExtensions
    {
        public static int[] Generate(this Random random, int min, int max, int length)
        {
            var ar = new int [length];
            for (var i = 0; i < length; i++)
            {
                ar[i] = random.Next(min, max);
            }
            return ar;
        }
    }
}