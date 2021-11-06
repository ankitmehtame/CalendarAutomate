using System;
using CalendarAutomateApp.Core;
using CalendarAutomateApp.Models;
using CalendarAutomateApp.Utils;
using NUnit.Framework;

namespace CalendarAutomate.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturnNoActionOnWorkEntryAlreadyCreated()
        {
            var brains = new Brains();
            var actions = brains.CreateActions(
                "2021-11-08".ToDate(),
                "Work",
                "Test Description",
                Array.Empty<CalendarEntry>(),
                Array.Empty<CalendarEntry>(),
                new [] { new CalendarEntry("Work", "Test Description", "2021-11-08 09:00+08:00".ToDateTime(), "2021-11-08 18:00+08:00".ToDateTime()) });
            Assert.AreEqual(actions, Array.Empty<CalendarEntryAction>());
        }
    }
}