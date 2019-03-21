using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

namespace CalendarTest
{
    [TestClass]
    public class DbManagerTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            sql_class.InitializeTestDB();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            sql_class.DestroyTestDB();
        }

        [TestMethod]
        public void TestAddEvent()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            Event e = new Event("testEvent", dt, "testDescription");
            sql_class.AddTestEvent(e);
            List<Event> events = sql_class.GetTestEvents(dt);
            Assert.AreEqual(events.Count, 1);
            Assert.AreEqual(events[0], e);
        }

        [TestMethod]
        public void TestGetEvents()
        {
            DateTime now = DateTime.Now;
            sql_class.AddTestEvent(new Event("e1", now));
            sql_class.AddTestEvent(new Event("e2", now));
            sql_class.AddTestEvent(new Event("e3", now.AddDays(1)));
            Assert.AreEqual(sql_class.GetTestEvents(now).Count, 2);
            Assert.AreEqual(sql_class.GetTestEvents(now.AddDays(1)).Count, 1);
        }
    }
}
