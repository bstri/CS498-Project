using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calendar
{
    public partial class MonthlyView : Form
    {
        private int gridSize;
        private DayFrame[] dayFrames;
        public DateTime current; // the datetime storing the month currently being viewed
        DateTime today = DateTime.Now; // today's date

        public MonthlyView()
        {
            InitializeComponent();
            //Makes the grid that the calendar is represented on
            gridSize = DayGrid.ColumnCount * DayGrid.RowCount;
            current = DateTime.Now;
            dayFrames = new DayFrame[gridSize];
            for(int r = 0; r < DayGrid.RowCount; r++)
            {
                for(int c = 0; c < DayGrid.ColumnCount; c++)
                {
                    DayFrame d = new DayFrame();
                    dayFrames[r * DayGrid.ColumnCount + c] = d;
                    DayGrid.Controls.Add(d);
                    DayGrid.SetRow(d, r);
                    DayGrid.SetColumn(d, c);
                }
            }
            SetMonth(current);
        }
        //Gets the current day information
        private int getYear(DateTime d)
        {
            return d.Year;
        }
        private string getMonthName(DateTime d)
        {
            return d.ToString("MMMM");
        }
        private int getFirstDayOfMonth(DateTime d)
        {
            DateTime monthStart = new DateTime(d.Year, d.Month, 1);
            return (int)monthStart.DayOfWeek;
        }
        private int getMonthLength(DateTime d)
        {
            var monthStart = new DateTime(d.Year, d.Month, 1);
            var lastDay = monthStart.AddMonths(1).AddDays(-1);
            string last = lastDay.ToString("dd");
            return int.Parse(last);
        }
        //Ges the last month length to fill in the first bit of space of the calendar
        private int getPreviousMonthLength(DateTime d)
        {
            var monthStart = new DateTime(d.Year, d.Month, 1);
            var prevMonthEnd = monthStart.AddDays(-1);
            int prevLen = int.Parse(prevMonthEnd.ToString("dd"));
            return prevLen;
        }
        //Establish the current date
        public void SetMonth(DateTime dayInMonth)
        {
            string mName = getMonthName(dayInMonth);
            int year = getYear(dayInMonth);
            int mLen = getMonthLength(dayInMonth);
            int myMonth = 0;
            int dayOfWeek = getFirstDayOfMonth(dayInMonth);
            int prevMLen = getPreviousMonthLength(dayInMonth);
           
            MonthLabel.Text = mName + " " + year.ToString();
            int nextMonthStart = mLen + dayOfWeek;
            int j = 1;
            DayFrame d;
            bool bold = false;
            if (current.Month == today.Month && current.Year == today.Year)
            {
                bold = true;
            }

            for (int i = dayOfWeek; i < nextMonthStart; i++)
            {
                d = dayFrames[i];
                bool highlighted = false;
                // todo turn this part into a function so you can call it in each for loop
                if (bold && today.Day == j)
                {
                    d.Font = new Font("Sans Serif", 9, FontStyle.Bold);
                    highlighted = true;
                }
                else
                {
                    d.Font = new Font("Sans Serif", 8);
                }
                d.DayNumber = j;
                d.Enabled = true;

                DateTime date = new DateTime(year, dayInMonth.Month, j);
                d.Date = date;
                RefreshDayFrame(d, date, d.Enabled, highlighted);
                j++;
            }
            j = 1;
            for(int i = nextMonthStart; i < gridSize; i++)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = false;
                
                //This bit is to help year switching
                if (dayInMonth.Month == 12)
                {
                    myMonth = 0;
                } else
                {
                    myMonth = dayInMonth.Month;
                }

                DateTime date = new DateTime(year, myMonth + 1, j);
                d.Date = date;

                RefreshDayFrame(d, date, d.Enabled, false);
                j++;
            }
            j = prevMLen;
            for(int i = dayOfWeek - 1; i >= 0; i--)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = false;
                if (dayInMonth.Month == 1)
                {
                    myMonth = 13;
                } else
                {
                    myMonth = dayInMonth.Month;
                }
                DateTime date = new DateTime(year, myMonth - 1, j);
                d.Date = date;
                RefreshDayFrame(d, date, d.Enabled, false);
                j--;
            }
        }
        //Switches to next month
        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            current = current.AddMonths(1);
            SetMonth(current);
        }
        //Switches to last month
        private void PreviousMonthButton_Click(object sender, EventArgs e)
        {
            current = current.AddMonths(-1);
            SetMonth(current);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            var f = new AddEventForm();
            f.EventAdded += new Action<DateTime>(RefreshDayFrame);
            f.ShowDialog();
        }

        //Given dayFrame and date calls appropriate function in DayFrame
        private void RefreshDayFrame(DayFrame df, DateTime date, bool enabled, bool highlighted)
        {
            df.RefreshDay(date);
            
        }

        //Given a date to refresh, finds the dayFrame to access RefreshDay function
        private void RefreshDayFrame(DateTime date)
        {
            DayFrame d = dayFrames[0];
            int correctFrame = -1;
            bool highlighted = false;

            //Finding Dayframe from DateTime
            if (date.Month == current.Month)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    d = dayFrames[i];
                    if (d.Enabled && d.DayNumber == date.Day)
                    {
                        highlighted = true;
                        correctFrame = i;
                    }
                }
            }
            else if (date.Month == current.Month - 1 || date.Month == current.Month + 1)
            {
                for (int i = 0; i < gridSize; i++)
                {
                    d = dayFrames[i];
                    if (!d.Enabled && d.DayNumber == date.Day)
                    {
                        correctFrame = i;
                    }
                }
            }

            if (correctFrame > -1)
            {
                d = dayFrames[correctFrame];
                RefreshDayFrame(d, date, d.Enabled, highlighted);
            }
        }
        //Creates form to allow user to input information about project
        private void btnAddProj_Click(object sender, EventArgs e)
        {
            var f = new AddProjectForm();
            f.ProjectAdded += new Action<object>((object o) => { SetMonth(current); });
            f.ShowDialog();
        }

        private void DayGrid_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
        }
    }
}
