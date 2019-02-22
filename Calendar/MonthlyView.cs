﻿using System;
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
       
        public DateTime current;
        public int numWeek(DateTime now)
        {
           
            DateTime temp = new DateTime(current.Year, current.Month, 1);
            return (int)temp.DayOfWeek;
        }
        public int monLen(DateTime now)
        {
            var temp = new DateTime(current.Year, current.Month, 1);
            var LastDay = temp.AddMonths(1).AddDays(-1);
            string last = LastDay.ToString("dd");
            return Int32.Parse(last);
        }
      
        public int monPrev(DateTime now)
        {
            var temp = new DateTime(current.Year, current.Month, 1);
           
            var prevMonth = temp.AddDays(-1);
            int prevLen = Int32.Parse(prevMonth.ToString("dd"));
            return prevLen;
        }
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
            SetMonth(current.ToString("MMMM"), numWeek(current), monLen(current), monPrev(current));
        }

        public void SetMonth(string mName, int dayOfWeek, int mLen, int prevMLen)
        {
          
            MonthLabel.Text = mName;
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
            SetMonth(current.ToString("MMMM"), numWeek(current), monLen(current), monPrev(current));
        }

        private void NextMonthButton_Click(object sender, EventArgs e)
        {
           
            current = current.AddMonths(1);
            SetMonth(current.ToString("MMMM"), numWeek(current), monLen(current), monPrev(current));
        }
    }
}
