using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Calendar
{
    public partial class DayViewForm : Form
    {
        public DayViewForm(DayFrame df)
        {
            InitializeComponent();
            if (df.events.Count > 0)
                this.Text = "Events for " + df.events[0].When.ToString("MM-dd-yyyy"); //maybe make only populated dayframes clickable    
            CreateListView(df);
        }

        //Todo: Have description keep formatting
        private void CreateListView(DayFrame df)
        {
            ListView listView = new ListView();
            listView.Bounds = new Rectangle(new Point(10, 10), new Size(300, 200));
            listView.View = View.Details;
            listView.GridLines = true;
            listView.Columns.Add("", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Time", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Name", -2, HorizontalAlignment.Left);
            listView.Columns.Add("Description", -2, HorizontalAlignment.Left);

            DateTime eventTime;

            for (int i = 0; i < df.events.Count; i++)
            {
                string eventHeader = "Event " + (i + 1);
                ListViewItem item = new ListViewItem(eventHeader, 0);
                eventTime = df.events[i].When;
                item.SubItems.Add(eventTime.ToString("hh:mm tt"));
                item.SubItems.Add(df.events[i].Name);
                item.SubItems.Add(df.events[i].Description);
                listView.Items.AddRange(new ListViewItem[] { item });
                AddButtons(i, df, listView);
            }

            

            this.Controls.Add(listView);
            
        }

        private void AddButtons(int eventNumber, DayFrame df, ListView listView)
        {
            Button newEdit = new Button();
            newEdit.Width = 40;
            newEdit.Height = 18;
            newEdit.Text = "Edit";
            newEdit.Font = new Font(newEdit.Font.FontFamily, 6);
            newEdit.Location = new Point(310, 35 + eventNumber*18);
            this.Controls.Add(newEdit);
            newEdit.Click += (sender, EventArgs) => { newEdit_Click(sender, EventArgs, eventNumber, df, listView); };

            Button delete = new Button();
            delete.Width = 50;
            delete.Height = 18;
            delete.Text = "Delete";
            delete.Font = new Font(newEdit.Font.FontFamily, 6);
            delete.Location = new Point(350, 35 + eventNumber * 18);
            this.Controls.Add(delete);
            delete.Click += (sender, EventArgs) => { delete_Click(sender, EventArgs, eventNumber, df, listView); };
        }

        //Remove event from database, RefreshDayFrame, strike out event in 
        //DayView or reload dayview 
        private void delete_Click(object sender, System.EventArgs e, int eventNumber, DayFrame df, ListView listView)
        {
            sql_class.DeleteAppointment(df.events[eventNumber]);    //delete from database
            listView.Items.RemoveAt(eventNumber);
            ListViewItem item = new ListViewItem("", 0);
            listView.Items.Insert(eventNumber, item);
            this.Controls.Add(listView);
        }


        //ToDo handle changing the day of the event (RefreshDayFrame)
        private void newEdit_Click(object sender, System.EventArgs e, int eventNumber, DayFrame df, ListView listView)
        {
            var f = new AddEventForm();
            f.EventAdded += new Action<DateTime>(blankMethod);
            f.EventName = df.events[eventNumber].Name;
            f.EventDesc = df.events[eventNumber].Description;
            f.EventTime = df.events[eventNumber].When;
            sql_class.DeleteAppointment(df.events[eventNumber]);
            this.Close();
            f.ShowDialog();
        }

        private void blankMethod(DateTime date) { }
    }
}
