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
        private TextBox ProjName;
        private BindingSource bindingSource1;
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button AddProjBtn;
        private DateTimePicker ProjDateStart;
        private DateTimePicker ProjDateEnd;
        private TextBox ProjDescTextBox;
        private Label ProjNameLbl;

        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void AddProjectForm_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ProjName = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ProjNameLbl = new System.Windows.Forms.Label();
            this.AddProjBtn = new System.Windows.Forms.Button();
            this.ProjDateStart = new System.Windows.Forms.DateTimePicker();
            this.ProjDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ProjDescTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjName
            // 
            this.ProjName.Location = new System.Drawing.Point(93, 12);
            this.ProjName.Name = "ProjName";
            this.ProjName.Size = new System.Drawing.Size(214, 20);
            this.ProjName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Project Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Description";
            // 
            // ProjNameLbl
            // 
            this.ProjNameLbl.AutoSize = true;
            this.ProjNameLbl.ForeColor = System.Drawing.Color.Red;
            this.ProjNameLbl.Location = new System.Drawing.Point(184, 214);
            this.ProjNameLbl.Name = "ProjNameLbl";
            this.ProjNameLbl.Size = new System.Drawing.Size(158, 13);
            this.ProjNameLbl.TabIndex = 6;
            this.ProjNameLbl.Text = "Project name must not be empty";
            this.ProjNameLbl.Click += new System.EventHandler(this.label5_Click);
            // 
            // AddProjBtn
            // 
            this.AddProjBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddProjBtn.Location = new System.Drawing.Point(348, 202);
            this.AddProjBtn.Name = "AddProjBtn";
            this.AddProjBtn.Size = new System.Drawing.Size(35, 32);
            this.AddProjBtn.TabIndex = 7;
            this.AddProjBtn.Text = "+";
            this.AddProjBtn.UseVisualStyleBackColor = true;
            // 
            // ProjDateStart
            // 
            this.ProjDateStart.Location = new System.Drawing.Point(76, 37);
            this.ProjDateStart.Margin = new System.Windows.Forms.Padding(2);
            this.ProjDateStart.Name = "ProjDateStart";
            this.ProjDateStart.Size = new System.Drawing.Size(187, 20);
            this.ProjDateStart.TabIndex = 8;
            // 
            // ProjDateEnd
            // 
            this.ProjDateEnd.Location = new System.Drawing.Point(76, 61);
            this.ProjDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.ProjDateEnd.Name = "ProjDateEnd";
            this.ProjDateEnd.Size = new System.Drawing.Size(187, 20);
            this.ProjDateEnd.TabIndex = 9;
            // 
            // ProjDescTextBox
            // 
            this.ProjDescTextBox.AcceptsReturn = true;
            this.ProjDescTextBox.AcceptsTab = true;
            this.ProjDescTextBox.Location = new System.Drawing.Point(19, 116);
            this.ProjDescTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProjDescTextBox.Multiline = true;
            this.ProjDescTextBox.Name = "ProjDescTextBox";
            this.ProjDescTextBox.Size = new System.Drawing.Size(364, 81);
            this.ProjDescTextBox.TabIndex = 10;
            // 
            // AddProjectForm
            // 
            this.ClientSize = new System.Drawing.Size(395, 250);
            this.Controls.Add(this.ProjDescTextBox);
            this.Controls.Add(this.ProjDateEnd);
            this.Controls.Add(this.ProjDateStart);
            this.Controls.Add(this.AddProjBtn);
            this.Controls.Add(this.ProjNameLbl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProjName);
            this.Name = "AddProjectForm";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
