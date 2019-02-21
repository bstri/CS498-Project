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
        String[] monthsArr = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public DateTime current;
        public int numWeek(DateTime now)
        {
            var FirstDay = new DateTime(now.Year, now.Month, 1);
            string strDate = FirstDay.ToString("dddd");
            string[] dayWeek = { "Sunday", "Monday", "Tuesday", "Wedndesday", "Thursday", "Friday", "Saturday" };
            
            int iter = 0;
            while (strDate != dayWeek[iter])
                iter++;
            return iter;
        }
        public int monLen(DateTime now)
        {
            var FirstDay = new DateTime(now.Year, now.Month, 1);
            var LastDay = FirstDay.AddMonths(1).AddDays(-1);
            string last = LastDay.ToString("dd");
            return Int32.Parse(last);
        }
        public int currMonth(DateTime now)
        {
            return Int32.Parse(current.ToString("MM"))-1;
        }
        public int monPrev(DateTime now)
        {
            var FirstDay = new DateTime(now.Year, now.Month, 1);
            var prevMonth = FirstDay.AddDays(-1);
            string prevLast = prevMonth.ToString("dd");
            int prevLen = Int32.Parse(prevLast);
            return prevLen;
        }
        //public void iniDate(DateTime now)
        //{
        //    //Grabs month string 
        //    //string month = DateTime.Now.ToString("MMMM");
        //    //var FirstDay = new DateTime(now.Year, now.Month, 1);
        //    //string firstDate = FirstDay.ToString("dddd");
        //    ////Gets how long a month is
        //    //var LastDay = FirstDay.AddMonths(1).AddDays(-1);
        //    //var prevMonth = FirstDay.AddDays(-1);
        //    //string last = LastDay.ToString("dd");
        //    //int len = Int32.Parse(last);

            

            
        //}
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
            SetMonth(currMonth(current), numWeek(current), monLen(current), monPrev(current));
        }

        public void SetMonth(int mNum, int dayOfWeek, int mLen, int prevMLen)
        {
            MonthLabel.Text = monthsArr[mNum];
            int nextMonthStart = mLen + dayOfWeek;
            int j = 1;
            DayFrame d;
            for(int i = dayOfWeek; i < nextMonthStart; i++)
            {
                d = dayFrames[i];
                d.DayNumber = j;
                d.Enabled = true;
                j++;
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

        private void PreviousMonthButton_Click(object sender, EventArgs e)
        {
            current = current.AddMonths(-1);
            SetMonth(currMonth(current), numWeek(current), monLen(current), monPrev(current));
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
            DateTime newcurr = current;
            current = current.AddMonths(1);
            SetMonth(currMonth(current), numWeek(current), monLen(current), monPrev(current));
        }
    }
}
