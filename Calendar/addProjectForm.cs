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

                DateTime start = ProjDateStart.Value;
                DateTime end = ProjectDateEnd.Value;
                if(start > end)
                {
                    MessageBox.Show("Please enter valid dates!");
                    return;
                }
                //todo add the project to the database
                //Event newEvent = new Event(EventNameTextBox.Text, combined, EventDescriptionTextBox.Text);
                //sql_class.AddEvent(newEvent);
                
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
