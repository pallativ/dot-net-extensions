namespace Primitive.Extensions;

public static class StringExtensions
{
    public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct
    {
        return (T)Enum.Parse(typeof(T), value, ignoreCase);
    }
}