using System;
using CalendarAutomate.WebApi.Core;
using CalendarAutomate.WebApi.Models;
using CalendarAutomate.WebApi.Utils;
using NUnit.Framework;

namespace CalendarAutomate.Test;

public class CalendarEntryExtensionsTests
{
    [Test]
    public void ShouldDetermineIncludes()
    {
        var calendarEntry = CreateCalendarEntry(start: "2021-11-08 00:00+08:00", end: "2021-11-09 00:00+08:00");
        Assert.IsTrue(calendarEntry.Includes("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()));
        Assert.IsTrue(calendarEntry.Includes("2021-11-08 00:00+08:00".ToDateTime(), "2021-11-09 00:00+08:00".ToDateTime()));
        Assert.IsFalse(calendarEntry.Includes("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-09 18:00+08:00".ToDateTime()));
        Assert.IsFalse(calendarEntry.Includes("2021-11-07 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()));
        Assert.IsFalse(calendarEntry.Includes("2021-11-07 09:00+08:00".ToDateTime(), "2021-11-07 18:00+08:00".ToDateTime()));
    }

    [Test]
    public void ShouldDetermineOverlaps()
    {
        var fullDayCalendarEntry = CreateCalendarEntry(start: "2021-11-08 00:00+08:00", end: "2021-11-09 00:00+08:00");
        Assert.IsTrue(fullDayCalendarEntry.OverlapsWith("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-09 18:00+08:00".ToDateTime()));
        Assert.IsFalse(fullDayCalendarEntry.OverlapsWith("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 09:00+08:00".ToDateTime()));
        Assert.IsFalse(fullDayCalendarEntry.OverlapsWith("2021-11-09 00:00+08:00".ToDateTime(), "2021-11-09 08:00+08:00".ToDateTime()));
        Assert.IsFalse(fullDayCalendarEntry.OverlapsWith("2021-11-08 00:00+08:00".ToDateTime(), "2021-11-08 13:00+08:00".ToDateTime()));
        Assert.IsTrue(fullDayCalendarEntry.OverlapsWith("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-09 18:00+08:00".ToDateTime()));
        Assert.IsTrue(fullDayCalendarEntry.OverlapsWith("2021-11-07 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()));
        Assert.IsTrue(fullDayCalendarEntry.OverlapsWith("2021-11-08 13:00+08:00".ToDateTime(), "2021-11-09 13:00+08:00".ToDateTime()));
        Assert.IsFalse(fullDayCalendarEntry.OverlapsWith("2021-11-07 09:00+08:00".ToDateTime(), "2021-11-07 18:00+08:00".ToDateTime()));

        var firstHalfDayCalendarEntry = CreateCalendarEntry(start: "2021-11-08 00:00+08:00", end: "2021-11-08 13:00+08:00");
        Assert.IsTrue(firstHalfDayCalendarEntry.OverlapsWith("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()));

        var secondHalfDayCalendarEntry = CreateCalendarEntry(start: "2021-11-08 13:00+08:00", end: "2021-11-09 00:00+08:00");
        Assert.IsTrue(secondHalfDayCalendarEntry.OverlapsWith("2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()));
    }

    private CalendarEntry CreateCalendarEntry(string title = "Work", string? description = "Test description", string start = "2021-11-08 00:00+08:00", string end = "2021-11-09 00:00+08:00")
    {
        return new CalendarEntry(title, description, start.ToDateTime(), end.ToDateTime());
    }
}
