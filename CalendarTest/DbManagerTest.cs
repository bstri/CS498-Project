using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;
using System.Drawing;

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

        [TestMethod]
        public void TestInitializetrue()
        {
            sql_class.InitializeDB();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            sql_class.DestroyTestDB();
        }

        [TestMethod]
        public void TestDeleteAppointment()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            Event e = new Event("testEvent", dt, "testDescription");
            sql_class.AddEvent(e);
            sql_class.DeleteAppointment(e);
            List<Event> events = sql_class.GetEvents(dt);
            Assert.AreEqual(0, events.Count);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            Event e = new Event("testEvent", dt, "testDescription");
            List<Event> events_before = sql_class.GetTestEvents(dt);
            sql_class.AddTestEvent(e);
            List<Event> events_after = sql_class.GetTestEvents(dt);
            Assert.AreEqual(events_before.Count + 1, events_after.Count);
            //Assert.AreEqual(events_after[0], e);
        }

        [TestMethod]
        public void TestAddProject()
        {
            sql_class.DestroyDB();
            sql_class.InitializeDB();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            System.Drawing.Color testColor = System.Drawing.Color.Red;
            DateTime dt2 = new DateTime(2019, 12, 25, 0, 0, 0);
            Project p = new Project("test proj", dt, dt2, testColor, "test description");
            List<Project> projs_before = sql_class.GetProjects(dt);
            Console.WriteLine(projs_before.Count);
            sql_class.AddProject(p);
            List<Project> projs_after = sql_class.GetProjects(dt);
            Assert.AreEqual(projs_before.Count + 1, projs_after.Count);
        }

        [TestMethod]
        public void TestAddProjectBadDate()
        {
            sql_class.DestroyDB();
            sql_class.InitializeDB();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            System.Drawing.Color testColor = System.Drawing.Color.AliceBlue;
            DateTime dt2 = new DateTime(2019, 12, 25, 0, 0, 0);
            DateTime dt3 = new DateTime(2019, 12, 26, 0, 0, 0);
            Project p = new Project("test proj", dt, dt2, testColor, "test description");
            List<Project> projs_before = sql_class.GetProjects(dt);
            Console.WriteLine(projs_before.Count);
            sql_class.AddProject(p);
            List<Project> projs_after = sql_class.GetProjects(dt3);
            Assert.AreEqual(projs_before.Count, projs_after.Count);
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
