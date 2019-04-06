namespace Calendar
{
    partial class AddProjectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.SubmitProjectButton = new System.Windows.Forms.Button();
            this.ProjectNameTextBox = new System.Windows.Forms.TextBox();
            this.ProjectDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.EmptyProjectNameWarningLabel = new System.Windows.Forms.Label();
            this.ProjDateStart = new System.Windows.Forms.DateTimePicker();
            this.ProjectDateEnd = new System.Windows.Forms.DateTimePicker();
            this.ColorBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Project Name";
            // 
            // SubmitProjectButton
            // 
            this.SubmitProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitProjectButton.Font = new System.Drawing.Font("Lucida Console", 13.8F);
            this.SubmitProjectButton.Location = new System.Drawing.Point(412, 226);
            this.SubmitProjectButton.Margin = new System.Windows.Forms.Padding(2);
            this.SubmitProjectButton.Name = "SubmitProjectButton";
            this.SubmitProjectButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SubmitProjectButton.Size = new System.Drawing.Size(30, 29);
            this.SubmitProjectButton.TabIndex = 3;
            this.SubmitProjectButton.Text = "+";
            this.SubmitProjectButton.UseVisualStyleBackColor = true;
            this.SubmitProjectButton.Click += new System.EventHandler(this.SubmitProjectButton_Click);
            // 
            // ProjectNameTextBox
            // 
            this.ProjectNameTextBox.Location = new System.Drawing.Point(86, 6);
            this.ProjectNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectNameTextBox.Name = "ProjectNameTextBox";
            this.ProjectNameTextBox.Size = new System.Drawing.Size(298, 20);
            this.ProjectNameTextBox.TabIndex = 4;
            // 
            // ProjectDescriptionTextBox
            // 
            this.ProjectDescriptionTextBox.AcceptsReturn = true;
            this.ProjectDescriptionTextBox.AcceptsTab = true;
            this.ProjectDescriptionTextBox.Location = new System.Drawing.Point(79, 140);
            this.ProjectDescriptionTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectDescriptionTextBox.Multiline = true;
            this.ProjectDescriptionTextBox.Name = "ProjectDescriptionTextBox";
            this.ProjectDescriptionTextBox.Size = new System.Drawing.Size(364, 81);
            this.ProjectDescriptionTextBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date Start:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 71);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date End:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Description";
            // 
            // EmptyProjectNameWarningLabel
            // 
            this.EmptyProjectNameWarningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EmptyProjectNameWarningLabel.AutoSize = true;
            this.EmptyProjectNameWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.EmptyProjectNameWarningLabel.Location = new System.Drawing.Point(255, 234);
            this.EmptyProjectNameWarningLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EmptyProjectNameWarningLabel.Name = "EmptyProjectNameWarningLabel";
            this.EmptyProjectNameWarningLabel.Size = new System.Drawing.Size(158, 13);
            this.EmptyProjectNameWarningLabel.TabIndex = 10;
            this.EmptyProjectNameWarningLabel.Text = "Project name must not be empty";
            this.EmptyProjectNameWarningLabel.Visible = false;
            // 
            // ProjDateStart
            // 
            this.ProjDateStart.Location = new System.Drawing.Point(79, 43);
            this.ProjDateStart.Margin = new System.Windows.Forms.Padding(2);
            this.ProjDateStart.Name = "ProjDateStart";
            this.ProjDateStart.Size = new System.Drawing.Size(187, 20);
            this.ProjDateStart.TabIndex = 11;
            // 
            // ProjectDateEnd
            // 
            this.ProjectDateEnd.Location = new System.Drawing.Point(79, 71);
            this.ProjectDateEnd.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectDateEnd.Name = "ProjectDateEnd";
            this.ProjectDateEnd.Size = new System.Drawing.Size(187, 20);
            this.ProjectDateEnd.TabIndex = 12;
            // 
            // ColorBtn
            // 
            this.ColorBtn.Location = new System.Drawing.Point(299, 39);
            this.ColorBtn.Name = "ColorBtn";
            this.ColorBtn.Size = new System.Drawing.Size(48, 45);
            this.ColorBtn.TabIndex = 13;
            this.ColorBtn.Text = "Color";
            this.ColorBtn.UseVisualStyleBackColor = true;
            this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // AddProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 269);
            this.Controls.Add(this.ColorBtn);
            this.Controls.Add(this.ProjectDateEnd);
            this.Controls.Add(this.ProjDateStart);
            this.Controls.Add(this.EmptyProjectNameWarningLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ProjectDescriptionTextBox);
            this.Controls.Add(this.ProjectNameTextBox);
            this.Controls.Add(this.SubmitProjectButton);
            this.Controls.Add(this.label1);
            this.Name = "AddProjectForm";
            this.Text = "Add Project";
            this.Load += new System.EventHandler(this.AddProjectForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SubmitProjectButton;
        private System.Windows.Forms.TextBox ProjectNameTextBox;
        private System.Windows.Forms.TextBox ProjectDescriptionTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label EmptyProjectNameWarningLabel;
        private System.Windows.Forms.DateTimePicker ProjDateStart;
        private System.Windows.Forms.DateTimePicker ProjectDateEnd;
        private System.Windows.Forms.Button ColorBtn;
    }
}