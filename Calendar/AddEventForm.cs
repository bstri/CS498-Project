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
    // form that allows user to enter in an event
    public partial class AddEventForm : Form
    {
        public event Action<DateTime> EventAdded;
        public AddEventForm()
        {
            InitializeComponent();
            EventTimePicker.CustomFormat = "h:mm tt";
            this.Initialize(DateTime.Now);
        }

        public void Initialize(DateTime d)
        {
            EventDatePicker.Value = d;
            EventTimePicker.Value = d;
        }

        public string EventName
        {
            get { return EventNameTextBox.Text; }
            set { EventNameTextBox.Text = value; }
        }

        public string EventDesc
        {
            set { EventDescriptionTextBox.Text = value; }
        }

        public DateTime EventTime
        {
            set { EventTimePicker.Value = value; }
        }

        //public Event newEvent
        //{
        //    get { return newEvent; }
        //}

        private void SubmitEventButton_Click(object sender, EventArgs e)
        {
            if (EventNameTextBox.Text == "")
            {
                EmptyEventNameWarningLabel.Visible = true;
                return;
            }
            DateTime date = EventDatePicker.Value;
            DateTime time = EventTimePicker.Value;
            DateTime combined = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, 0);
            Event newEvent = new Event(EventNameTextBox.Text, combined, EventDescriptionTextBox.Text);
            SqlClass.AddEvent(newEvent);
            if (EventAdded != null) { EventAdded(combined); }
            
            //EventAdded?.Invoke(combined);
            Close();
        }
    }
}
