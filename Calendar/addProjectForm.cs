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
    public partial class AddProjectForm : Form
    {


        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SubmitProjectButton_Click(object sender, EventArgs e)
        {
            if (ProjectNameTextBox.Text == "")
            {
                EmptyProjectNameWarningLabel.Visible = true;
            }
            else
            {
                EmptyProjectNameWarningLabel.Visible = false;
                //todo
                //Add SQL database project creation

                DateTime start = ProjDateStart.Value;
                DateTime end = ProjectDateEnd.Value;
                if((Int32.Parse(start.ToString("dd")) > Int32.Parse(end.ToString("dd")))|| (Int32.Parse(start.ToString("yyyy")) > Int32.Parse(end.ToString("yyyy")))|| Int32.Parse(start.ToString("MM")) > Int32.Parse(end.ToString("MM")))
                {
                    MessageBox.Show("Please enter valid dates!");
                    return;
                }
                //Event newEvent = new Event(EventNameTextBox.Text, combined, EventDescriptionTextBox.Text);
                //sql_class.AddEvent(newEvent);
                MonthlyView mv = new MonthlyView(true);
                //DateTime refreshDate = new DateTime(date.Year, date.Month, date.Day);
                //mv.RefreshDayFrame(refreshDate, newEvent);
                //MonthlyView.RefreshDayFrame(refreshDate, true, newEvent);
                //mv.RefreshDayFrame(refreshDate, true, newEvent);
                //DayFrame d = MonthlyView.dayFrames[0];
                this.Close();
            }
        }

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorBtn.BackColor = colorDialog.Color;
            }
        }
    }
}
