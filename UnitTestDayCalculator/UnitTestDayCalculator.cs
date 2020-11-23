using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestDayCalculator
{
    using DayCalculator;
    [TestClass]
    public class UnitTestDayCalculator
    {
        [TestMethod]
        [DataRow(100, false)]
        [DataRow(2100, false)]
        [DataRow(1600, true)]
        [DataRow(1001, false)]
        [DataRow(2001, false)]
        [DataRow(1980, true)]
        [DataRow(2001, false)]
        public void DateCalculatorVerifyLeapYear(int year, bool expectedValue)
        {
            bool isLeapYear = DateCalculator.IsLeapYear(year);
            Assert.AreEqual(expectedValue, isLeapYear, "Verify that the leap Year calculator matches the expected value");
        }

        [TestMethod]
        [DataRow(1, 31)]
        [DataRow(3, 31)]
        [DataRow(4, 30)]
        [DataRow(5, 31)]
        [DataRow(6, 30)]
        [DataRow(7, 31)]
        [DataRow(8, 31)]
        [DataRow(9, 30)]
        [DataRow(10, 31)]
        [DataRow(11, 30)]
        [DataRow(12, 31)]
        public void DateCalculatorVerifyDaysPerMonth(int month, int expectedDays)
        {
            int year = 2019;
            int days = DateCalculator.DaysPerMonth(month, year);
            Assert.AreEqual(expectedDays, days, "Verify that the days matches the expected value for month ", month);
        }

        [TestMethod]
        [DataRow(2011, 28)]
        [DataRow(2004, 29)]
        public void DateCalculatorVerifyFebuaryDaysPerMonth(int year, int expectedDays)
        {
            int month = 2;
            int days = DateCalculator.DaysPerMonth(month, year);
            Assert.AreEqual(expectedDays, days, "Verify that the days matches the expected value for month ", month);
        }

        [TestMethod]
        [DataRow(2011, 2, 28, true)]
        [DataRow(2011, 2, 29, false)]
        [DataRow(2004, 2, 29, true)]
        [DataRow(2004, 12, 29, true)]
        [DataRow(2003, 12, 32, false)]
        public void DateCalculatorVerifyDateValid(int year, int month, int day, bool expectedValid)
        {
            bool valid = DateCalculator.DateValid(day, month, year);
            Assert.AreEqual(expectedValid, valid, "Verify that the DateValid the expected value for month ", month);
        }


        [TestMethod]
        [DataRow(2011, 2, 28, 59)]
        [DataRow(2011, 2, 29, 0)]
        [DataRow(2004, 2, 29, 60)]
        [DataRow(2004, 12, 29, 364)]
        [DataRow(2003, 12, 32, 0)]
        public void DateCalculatorVerifyDValid(int year, int month, int day, int expectedValid)
        {
            int dayNumber = DateCalculator.DayNumber(day, month, year);
            Assert.AreEqual(expectedValid, dayNumber, "Verify that the Day Number the expected value for month ", month);
        }
    }
}
