// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions;

/// <summary>
/// Random extensions.
/// </summary>
public static class RandomExtensions
{
    private const string Alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string AlphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    /// <summary>
    /// Gets the array of random numbers.
    /// </summary>
    /// <param name="random"><see cref="Random"/>.</param>
    /// <param name="min">Range's min value.</param>
    /// <param name="max">Range's max value.</param>
    /// <param name="size">size of the number.</param>
    /// <returns>return array of integers.</returns>
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
    /// <param name="random"><see cref="Random"/>.</param>
    /// <param name="size">Size of the random string.</param>
    /// <param name="isAlphaNumeric">Indicates flag for Alpha Numeric.</param>
    /// <returns>return next string.</returns>
    public static string NextString(this Random random, int size, bool isAlphaNumeric = false)
    {
        var result = new char[size];
        for (var i = 0; i < size; i++)
        {
            var charSet = isAlphaNumeric ? AlphaNumeric : Alphabets;
            var position = random.Next(charSet.Length);
            result[i] = charSet[position];
        }

        return new string(result);
    }
}
