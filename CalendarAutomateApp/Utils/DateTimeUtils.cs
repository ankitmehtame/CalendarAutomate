using System;
using System.Globalization;

namespace CalendarAutomateApp.Utils
{
    public static class DateTimeUtils
    {
        public static DateTimeOffset ToDate(this string dateText)
        {
            // TODO handle different time zones
            return DateTimeOffset.ParseExact(dateText, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
        }

        public static DateTimeOffset ToDateTime(this string dateTimeText)
        {
            return DateTimeOffset.ParseExact(dateTimeText, new [] { "o", "yyyy-MM-dd HH:mm zzz" }, CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces | DateTimeStyles.AssumeUniversal);
        }

        public static TimeSpan ToTime(this string timeText)
        {
            return TimeSpan.ParseExact(timeText, @"hh\:mm", CultureInfo.InvariantCulture);
        }
    }
}