namespace Primitive.Extensions
{
    public static class RandomExtensions
    {
        private const string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Gets the array of random numbers.
        /// </summary>
        /// <param name="random"><see cref="Random"/></param>
        /// <param name="min">Range's min value</param>
        /// <param name="max">Range's max value</param>
        /// <param name="size">size of the number</param>
        /// <returns></returns>
        public static int[] Generate(this Random random, int min, int max, int size)
        {
            var ar = new int[size];
            for (var i = 0; i < size; i++)
            {
                ar[i] = random.Next(min, max);
            }
            return ar;
        }

        /// <summary>
        /// Gets the next random string.
        /// </summary>
        /// <param name="random"><see cref="Random"/></param>
        /// <param name="size">Size of the random string</param>
        /// <returns></returns>
        public static string NextString(this Random random, int size)
        {
            var result = new char[size];
            for (var i = 0; i < size; i++)
            {
                var position = random.Next(Alphabets.Length);
                result[i] = Alphabets[position];
            }

            return new string(result);
        }
    }
}