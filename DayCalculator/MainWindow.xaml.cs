//-----------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Graham D Wardle">
//     Demo Calculator for Date.
// </copyright>
//-----------------------------------------------------------------------
namespace DayCalculator
{
    using System;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The event handler for the Check date button click press.
        /// </summary>
        /// <param name="sender">The source of the click event.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckDate_Click(object sender, RoutedEventArgs e)
        {
            int year, month, day;
            int.TryParse(this.Day.Text, out day);
            int.TryParse(this.Month.Text, out month);
            int.TryParse(this.Year.Text, out year);
            if (DateCalculator.DateValid(day, month, year))
            {
                this.Total.Text = string.Format("Total Days = {0}", DateCalculator.DayNumber(day, month, year));
                this.DateYear.Text = DateCalculator.IsLeapYear(year) ? "Is Leap Year" : "Date is valid";
                DateTime date = new DateTime(year, month, day);
                DateTime decThirtyFirst = new DateTime(year - 1, 12, 31);
                TimeSpan diff = date.Subtract(decThirtyFirst);
                this.DateDay.Text = date.ToString("dd");
                this.DateMonth.Text = date.ToString("MMM");
                this.Since.Text = string.Format(@"Since {0}", decThirtyFirst.ToShortDateString());
                this.Date.Text = string.Format(@"{0}", diff.TotalDays);
            }
            else
            {
                this.DateYear.Text = "Date is not valid";
                this.Date.Text = string.Empty;
                this.Total.Text = string.Empty;
                this.DateDay.Text = string.Empty;
                this.DateMonth.Text = string.Empty;
            }
        }
    }
}
