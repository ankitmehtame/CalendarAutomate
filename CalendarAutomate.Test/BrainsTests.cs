using System;
using CalendarAutomateApp.Core;
using CalendarAutomateApp.Models;
using CalendarAutomateApp.Utils;
using NUnit.Framework;

namespace CalendarAutomate.Test
{
    public class BrainsTests
    {
        [Test]
        public void ShouldReturnNoActionOnWorkEntryAlreadyCreated()
        {
            var actions = CreateActions(
                holidayEntriesForTheDay: Array.Empty<CalendarEntry>(),
                leaveEntriesForTheDay: Array.Empty<CalendarEntry>(),
                workEntriesForTheDay: new [] { new CalendarEntry("Work", "Test Description", "2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()) });
            Assert.AreEqual(actions, Array.Empty<CalendarEntryAction>());
        }

        [Test]
        public void ShouldReturnNoActionOnHoliday()
        {
            var brains = new Brains();
            var actions = CreateActions(
                holidayEntriesForTheDay: new [] { new CalendarEntry("Work", "Test Description", "2021-11-08 00:00+08:00".ToDateTime(), "2021-11-09 00:00+08:00".ToDateTime()) },
                leaveEntriesForTheDay: Array.Empty<CalendarEntry>(),
                workEntriesForTheDay: Array.Empty<CalendarEntry>());
            Assert.AreEqual(actions, Array.Empty<CalendarEntryAction>());
        }

        [Test]
        public void ShouldReturnNoActionOnLeave()
        {
            var brains = new Brains();
            var actions = CreateActions(
                holidayEntriesForTheDay: Array.Empty<CalendarEntry>(),
                leaveEntriesForTheDay: new [] { new CalendarEntry("Work", "Test Description", "2021-11-08 00:00+08:00".ToDateTime(), "2021-11-09 00:00+08:00".ToDateTime()) },
                workEntriesForTheDay: Array.Empty<CalendarEntry>());
            Assert.AreEqual(actions, Array.Empty<CalendarEntryAction>());
        }

        private CalendarEntryAction[] CreateActions(string date = "2021-11-08", string workStartTime = "09:00", string workEndTime = "18:00", string workEntryTitle = "Work", string? workEntryDescription = "Test description", CalendarEntry[]? holidayEntriesForTheDay = null, CalendarEntry[]? leaveEntriesForTheDay = null, CalendarEntry[]? workEntriesForTheDay = null)
        {
            return new Brains().CreateActions(
                date.ToDate(),
                workStartTime.ToTime(),
                workEndTime.ToTime(),
                workEntryTitle,
                workEntryDescription,
                holidayEntriesForTheDay ?? Array.Empty<CalendarEntry>(),
                leaveEntriesForTheDay ?? Array.Empty<CalendarEntry>(),
                workEntriesForTheDay ?? Array.Empty<CalendarEntry>()
            );
        }
    }
}