// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions;
using System.ComponentModel;

/// <summary>
/// Enum extensions.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Gets the attribute using given enum.
    /// </summary>
    /// <typeparam name="T">Attribute derived type</typeparam>
    /// <param name="value">Enum value</param>
    /// <returns>returns the enum defined for the enum</returns>
    public static T? GetAttribute<T>(this Enum value)
        where T : Attribute
    {
        var type = value.GetType();
        var memberInfo = type.GetMember(value.ToString());
        var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
        return attributes.Length != 0 ? (T)attributes[0] : null;
    }

    /// <summary>
    /// Get description of the enum.
    /// </summary>
    /// <param name="value">Enum Value</param>
    /// <returns>Return string representation of enum</returns>
    public static string GetDescription(this Enum value)
    {
        var attribute = value.GetAttribute<DescriptionAttribute>();
        return attribute == null ? value.ToString() : attribute.Description;
    }
}
