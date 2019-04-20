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

        public event Action<object> ProjectAdded;

        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {
            
        }
        //Actions that happen when the submission button is clicked
        private void SubmitProjectButton_Click(object sender, EventArgs e)
        {
            //Cannot be empty name
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
                    //checks to see if you try to put in an invalid date
                    MessageBox.Show("Please enter valid dates!");
                    return;
                }
                Project p = new Project(ProjectNameTextBox.Text, start, end, ColorBtn.BackColor, ProjectDescriptionTextBox.Text);
                sql_class.AddProject(p);

                if (ProjectAdded != null) { ProjectAdded(null); }
                this.Close();
            }
        }

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            //Code for the color chosen to repersent the project
            var colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ColorBtn.BackColor = colorDialog.Color;
            }
        }
    }
}
