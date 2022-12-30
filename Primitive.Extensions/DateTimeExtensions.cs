// Copyright (c) . All Rights Reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace Primitive.Extensions
{
    using System.Globalization;

    public static class DateTimeExtensions
    {
        public const string DateTimeFormat = "dd-MM-yyyy HH:mm:ss";

        /// <summary>
        /// Converts the given date time to epoch date time.
        /// </summary>
        /// <param name="date">given input date.</param>
        /// <returns></returns>
        public static double ToEpochTime(this DateTime date)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan diff = date - origin;
            return diff.TotalSeconds;
        }

        /// <summary>
        /// Converts to dateTime using the given datetime format. Default Format: dd-MM-yyyy HH:mm:ss
        /// </summary>
        /// <param name="dateTimeString"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string dateTimeString, string format = DateTimeFormat)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            var dateTime = DateTime.ParseExact(dateTimeString, format, provider);
            return dateTime;
        }

        /// <summary>
        /// Validates the given date string and outputs the result date if it is valid.
        /// </summary>
        /// <param name="dateTimeString">Input datetime string to be validated.</param>
        /// <param name="dateTime">Output parameter</param>
        /// <param name="format">Format of the date time string to be validated against</param>
        /// <returns></returns>
        public static bool IsValid(this string dateTimeString, out DateTime dateTime, string format = DateTimeFormat)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            return DateTime.TryParseExact(dateTimeString, format, provider,
                DateTimeStyles.AdjustToUniversal, out dateTime);
        }
    }
}
