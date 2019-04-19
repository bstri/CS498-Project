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
                Project p = new Project(ProjectNameTextBox.Text, start, end, ColorBtn.BackColor, ProjectDescriptionTextBox.Text);
                SqlClass.AddProject(p);

                if (ProjectAdded != null) { ProjectAdded(null); }
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
