namespace Primitive.Extensions;

public static class ConsoleExtensions
{
    /// <summary>
    /// Reads the integer from console.
    /// </summary>
    /// <returns></returns>
    public static int ReadInt()
    {
        return Convert.ToInt32(Console.ReadLine());
    }

    /// <summary>
    /// Reads the double from the console.
    /// </summary>
    /// <returns></returns>
    public static double ReadDouble()
    {
        return Convert.ToDouble(Console.ReadLine());
    }
}