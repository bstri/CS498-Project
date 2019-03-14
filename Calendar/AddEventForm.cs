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
    public partial class AddEventForm : Form
    {
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

        private void SubmitEventButton_Click(object sender, EventArgs e)
        {
            if(EventNameTextBox.Text == "")
            {
                EmptyEventNameWarningLabel.Visible = true;
                return;
            }
            // todo add event to database (also may require an update of monthly view)
            this.Close();
        }
    }
}
