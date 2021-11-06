using System;
using CalendarAutomateApp.Models;

namespace CalendarAutomateApp.Core
{
    public class Brains
    {
        public CalendarEntryAction[] CreateActions(DateTimeOffset date, string workEntryTitle, string? workEntryDescription, CalendarEntry[] holidayEntriesForTheDay, CalendarEntry[] leaveEntriesForTheDay, CalendarEntry[] workEntriesForTheDay)
        {
            return Array.Empty<CalendarEntryAction>();
        }
    }
}