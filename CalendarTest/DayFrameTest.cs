using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calendar;
using System.Collections.Generic;

namespace CalendarTest
{
    [TestClass]
    public class DayFrameTest
    {
        DayFrame df;

        [TestInitialize]
        public void TestInitialize()
        {
            df = new DayFrame();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetSmallInvalidDay()
        {
            df.DayNumber = 0;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSetLargeInvalidDay()
        {
            df.DayNumber = 32;
        }

        [TestMethod]
        public void TestSetValidDays()
        {
            df.DayNumber = 1;
            df.DayNumber = 31;
            df.DayNumber = 15;
        }
    }
}
