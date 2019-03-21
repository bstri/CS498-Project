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
            // initialize temporary testing database
            // i.e. sql_class.initialize_db("testDB");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            // destroy testing database
        }

        [TestMethod]
        public void TestAddEvent()
        {
            DateTime now = DateTime.Now;
            Event e = new Event("testEvent", now, "testDescription");
            sql_class.addAppointment(e);
            List<Event> events = sql_class.GetEvents(now);
            Assert.AreEqual(events.Count, 1);
            Assert.AreEqual(events[1], e);
        }

        public void TestGetEvents()
        {
            DateTime now = DateTime.Now;
            sql_class.addAppointment(new Event("e1", now));
            sql_class.addAppointment(new Event("e2", now));
            sql_class.addAppointment(new Event("e3", now.AddDays(1)));
            Assert.AreEqual(sql_class.GetEvents(now).Count, 2);
            Assert.AreEqual(sql_class.GetEvents(now.AddDays(1)).Count, 1);
        }
    }
}
