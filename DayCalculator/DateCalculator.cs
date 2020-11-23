//-----------------------------------------------------------------------
// <copyright file="DateCalculator.cs" company="Graham D Wardle">
//     Demo Calculator for Date.
// </copyright>
//-----------------------------------------------------------------------
namespace DayCalculator
{
    /// <summary>
    /// The helper method to calculate date related 
    /// </summary>
    internal class DateCalculator
    {
        /// <summary>
        /// The method to determine if a date valid.
        /// </summary>
        /// <param name="day">The day of the month to validate.</param>
        /// <param name="month">The month to validate.</param>
        /// <param name="year">The year to validate.</param>
        /// <returns>True if the date is valid; False otherwise</returns>
        internal static bool DateValid(int day, int month, int year)
        {
            bool yearValid = year < 10000 && year > 0;
            bool monthValid = month > 0 && month < 13;
            bool dayValid = (day <= DaysPerMonth(month, year)) && day > 0;
            return yearValid && monthValid && dayValid;
        }

        /// <summary>
        /// The method to determine the days in the month.
        /// </summary>
        /// <param name="month">The month.</param>
        /// <param name="year">The year.</param>
        /// <returns>The number of days in the month.</returns>
        internal static int DaysPerMonth(int month, int year)
        {
            int days = 0;
            switch (month)
            {
                case 1: // Jan
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: // Dec
                    days = 31;
                    break;
                case 2:
                    days = IsLeapYear(year) ? 29 : 28;
                    break;
                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;
            }

            return days;
        }

        /// <summary>
        /// The method to determine the day number of the year for a day/month/year 
        /// </summary>
        /// <param name="day">The day of the month to calculated.</param>
        /// <param name="month">The month to calculated.</param>
        /// <param name="year">The year to calculated.</param>
        /// <returns>The day number 1 Jan is day 1,</returns>
        internal static int DayNumber(int day, int month, int year)
        {
            int total = 0;
            if (DateCalculator.DateValid(day, month, year))
            {
                for (int index = 1; index < month; index++)
                {
                    total += DateCalculator.DaysPerMonth(index, year);
                }

                total += day;
            }

            return total;
        }

        /// <summary>
        /// The method to determine if a year is a Leap year.
        /// </summary>
        /// <param name="year">The year to determine if it is a leap year.</param>
        /// <returns>True if the year is a leap year; False otherwise.</returns>
        internal static bool IsLeapYear(int year)
        {
            bool isLeapYear = false;
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        isLeapYear = true;
                    }
                }
                else
                {
                    isLeapYear = true;
                }
            }

            return isLeapYear;
        }
    }
}
