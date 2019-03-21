using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class MonthlyView : Form
    {
        private int gridSize;
        private DayFrame[] dayFrames;
       
        public DateTime current; // the datetime storing the month currently being viewed
       
        public MonthlyView()
        {
            InitializeComponent();

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
        private int getPreviousMonthLength(DateTime d)
        {
            var monthStart = new DateTime(d.Year, d.Month, 1);
            var prevMonthEnd = monthStart.AddDays(-1);
            int prevLen = int.Parse(prevMonthEnd.ToString("dd"));
            return prevLen;
        }

        public void SetMonth(DateTime dayInMonth)
        {
            // todo: refresh the dayframes
            string mName = getMonthName(dayInMonth);
            int year = getYear(dayInMonth);
            int mLen = getMonthLength(dayInMonth);
            int dayOfWeek = getFirstDayOfMonth(dayInMonth);
            int prevMLen = getPreviousMonthLength(dayInMonth);

            MonthLabel.Text = mName + " " + year.ToString();
            int nextMonthStart = mLen + dayOfWeek;
            int j = 1;
            DayFrame d;
            for(int i = dayOfWeek; i < nextMonthStart; i++)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = true;
                d.ClearEvents();

                DateTime date = new DateTime(year, dayInMonth.Month, j);
                j++;

                // todo: get day's events and add them to the day frame
                List<Event> events = sql_class.GetEvents(date);
                foreach(var e in events)
                {
                    d.AddEvent(e);
                    // iterate through the event list returned and call DayFrame.
                }

            }
            j = 1;
            for(int i = nextMonthStart; i < gridSize; i++)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = false;
                j++;
            }
            j = prevMLen;
            for(int i = dayOfWeek - 1; i >= 0; i--)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = false;
                j--;
            }
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            current = current.AddMonths(1);
            SetMonth(current);
        }

        private void PreviousMonthButton_Click(object sender, EventArgs e)
        {
            current = current.AddMonths(-1);
            SetMonth(current);
        }

        private void AddEventButton_Click(object sender, EventArgs e)
        {
            var f = new AddEventForm();
            f.ShowDialog();
        }
    }
}
