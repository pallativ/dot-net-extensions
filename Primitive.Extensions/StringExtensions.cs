// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions;

/// <summary>
/// String extensions.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Converts the string to enum.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="value">string value to be converted.</param>
    /// <param name="ignoreCase">Flag indicates to ignore the case.</param>
    /// <returns>returns the enum from given string.</returns>
    public static T ToEnum<T>(this string value, bool ignoreCase = true)
        where T : struct
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}
