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
            SqlClass.InitializeTestDB();
        }

        [TestMethod]
        public void TestInitializetrue()
        {
            SqlClass.InitializeDB();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            SqlClass.DestroyTestDB();
        }

        [TestMethod]
        public void TestDeleteAppointment()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            Event e = new Event("testEvent", dt, "testDescription");
            List<Event> events_initial = SqlClass.GetEvents(dt);
            SqlClass.AddEvent(e);
            SqlClass.DeleteAppointment(e);
            List<Event> events_after = SqlClass.GetEvents(dt);
            Assert.AreEqual(events_initial.Count, events_after.Count);
        }

        [TestMethod]
        public void TestAddEvent()
        {
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            Event e = new Event("testEvent", dt, "testDescription");
            List<Event> events_before = SqlClass.GetTestEvents(dt);
            SqlClass.AddTestEvent(e);
            List<Event> events_after = SqlClass.GetTestEvents(dt);
            Assert.AreEqual(events_before.Count + 1, events_after.Count);
            //Assert.AreEqual(events_after[0], e);
        }

        [TestMethod]
        public void TestAddProject()
        {
            SqlClass.DestroyDB();
            SqlClass.InitializeDB();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            System.Drawing.Color testColor = System.Drawing.Color.Red;
            DateTime dt2 = new DateTime(2019, 12, 25, 0, 0, 0);
            Project p = new Project("test proj", dt, dt2, testColor, "test description");
            List<Project> projs_before = SqlClass.GetProjects(dt);
            Console.WriteLine(projs_before.Count);
            SqlClass.AddProject(p);
            List<Project> projs_after = SqlClass.GetProjects(dt);
            Assert.AreEqual(projs_before.Count + 1, projs_after.Count);
        }

        [TestMethod]
        public void TestAddProjectBadDate()
        {
            SqlClass.DestroyDB();
            SqlClass.InitializeDB();
            DateTime now = DateTime.Now;
            DateTime dt = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0); // important to use 0 for seconds since dbmanager doesn't store seconds
            System.Drawing.Color testColor = System.Drawing.Color.AliceBlue;
            DateTime dt2 = new DateTime(2019, 12, 25, 0, 0, 0);
            DateTime dt3 = new DateTime(2019, 12, 26, 0, 0, 0);
            Project p = new Project("test proj", dt, dt2, testColor, "test description");
            List<Project> projs_before = SqlClass.GetProjects(dt);
            Console.WriteLine(projs_before.Count);
            SqlClass.AddProject(p);
            List<Project> projs_after = SqlClass.GetProjects(dt3);
            Assert.AreEqual(projs_before.Count, projs_after.Count);
        }

        [TestMethod]
        public void TestGetEvents()
        {
            DateTime now = DateTime.Now;
            SqlClass.AddTestEvent(new Event("e1", now));
            SqlClass.AddTestEvent(new Event("e2", now));
            SqlClass.AddTestEvent(new Event("e3", now.AddDays(1)));
            Assert.AreEqual(SqlClass.GetTestEvents(now).Count, 2);
            Assert.AreEqual(SqlClass.GetTestEvents(now.AddDays(1)).Count, 1);
        }
    }
}
