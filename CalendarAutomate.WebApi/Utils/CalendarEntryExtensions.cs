using System;
using CalendarAutomate.WebApi.Models;

namespace CalendarAutomate.WebApi.Utils;

public static class CalendarEntryExtensions
{
    public static bool Includes(this CalendarEntry calendarEntry, DateTimeOffset dateTime)
    {
        return Includes(calendarEntry, dateTime, dateTime);
    }

    public static bool Includes(this CalendarEntry calendarEntry, DateTimeOffset start, DateTimeOffset end)
    {
        return calendarEntry.Start <= start && calendarEntry.End >= end;
    }

    public static bool OverlapsWith(this CalendarEntry calendarEntry, DateTimeOffset eventStart, DateTimeOffset eventEnd)
    {
        return (calendarEntry.Start <= eventStart && calendarEntry.End > eventStart && calendarEntry.End < eventEnd)
            || (eventStart < calendarEntry.Start && eventEnd > calendarEntry.Start && eventEnd <= calendarEntry.End);
    }
}
