using System;
using System.Linq;
using CalendarAutomateApp.Models;
using CalendarAutomateApp.Utils;

namespace CalendarAutomateApp.Core
{
    public class Brains
    {
        public CalendarEntryAction[] CreateActions(DateTimeOffset date, TimeSpan workStartTime, TimeSpan workEndTime, string workEntryTitle, string? workEntryDescription,
            CalendarEntry[] holidayEntriesForTheDay, CalendarEntry[] leaveEntriesForTheDay, CalendarEntry[] workEntriesForTheDay)
        {
            var workTimeStart = date + workStartTime;
            var workTimeEnd = date + workEndTime;
            if (holidayEntriesForTheDay.Any(he => he.Includes(workTimeStart, workTimeEnd)))
            {
                // Falls within holiday
                return Array.Empty<CalendarEntryAction>();
            }
            if (leaveEntriesForTheDay.Any(le => le.Includes(workTimeStart, workTimeEnd)))
            {
                // Falls within leave
                return Array.Empty<CalendarEntryAction>();
            }
            if (leaveEntriesForTheDay.Any(le => le.OverlapsWith(workTimeStart, workTimeEnd)))
            {
                // TODO find work time that fills in the gap
                // Work starts on time, ends earlier
            }
            return Array.Empty<CalendarEntryAction>();
        }
    }
}