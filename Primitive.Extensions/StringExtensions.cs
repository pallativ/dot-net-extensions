// Copyright (c) VajraTechMinds.com. All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions;

public static class StringExtensions
{
    public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}
