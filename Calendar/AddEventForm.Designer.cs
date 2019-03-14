namespace Calendar
{
    partial class AddEventForm
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
        private void InitializeComponent()
        {
            this.EventNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.EventDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.EventDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.SubmitEventButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.EventTimePicker = new System.Windows.Forms.DateTimePicker();
            this.EmptyEventNameWarningLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EventNameTextBox
            // 
            this.EventNameTextBox.Location = new System.Drawing.Point(103, 9);
            this.EventNameTextBox.Name = "EventNameTextBox";
            this.EventNameTextBox.Size = new System.Drawing.Size(396, 22);
            this.EventNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date";
            // 
            // EventDatePicker
            // 
            this.EventDatePicker.Location = new System.Drawing.Point(56, 50);
            this.EventDatePicker.Name = "EventDatePicker";
            this.EventDatePicker.Size = new System.Drawing.Size(248, 22);
            this.EventDatePicker.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Description";
            // 
            // EventDescriptionTextBox
            // 
            this.EventDescriptionTextBox.AcceptsReturn = true;
            this.EventDescriptionTextBox.AcceptsTab = true;
            this.EventDescriptionTextBox.Location = new System.Drawing.Point(15, 137);
            this.EventDescriptionTextBox.Multiline = true;
            this.EventDescriptionTextBox.Name = "EventDescriptionTextBox";
            this.EventDescriptionTextBox.Size = new System.Drawing.Size(484, 99);
            this.EventDescriptionTextBox.TabIndex = 5;
            // 
            // SubmitEventButton
            // 
            this.SubmitEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SubmitEventButton.AutoSize = true;
            this.SubmitEventButton.Font = new System.Drawing.Font("Lucida Console", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubmitEventButton.Location = new System.Drawing.Point(470, 242);
            this.SubmitEventButton.Name = "SubmitEventButton";
            this.SubmitEventButton.Size = new System.Drawing.Size(34, 34);
            this.SubmitEventButton.TabIndex = 6;
            this.SubmitEventButton.Text = "+";
            this.SubmitEventButton.UseVisualStyleBackColor = true;
            this.SubmitEventButton.Click += new System.EventHandler(this.SubmitEventButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Time";
            // 
            // EventTimePicker
            // 
            this.EventTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventTimePicker.Location = new System.Drawing.Point(56, 79);
            this.EventTimePicker.Name = "EventTimePicker";
            this.EventTimePicker.ShowUpDown = true;
            this.EventTimePicker.Size = new System.Drawing.Size(107, 22);
            this.EventTimePicker.TabIndex = 8;
            // 
            // EmptyEventNameWarningLabel
            // 
            this.EmptyEventNameWarningLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EmptyEventNameWarningLabel.AutoSize = true;
            this.EmptyEventNameWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.EmptyEventNameWarningLabel.Location = new System.Drawing.Point(261, 253);
            this.EmptyEventNameWarningLabel.Name = "EmptyEventNameWarningLabel";
            this.EmptyEventNameWarningLabel.Size = new System.Drawing.Size(203, 17);
            this.EmptyEventNameWarningLabel.TabIndex = 9;
            this.EmptyEventNameWarningLabel.Text = "Event name must not be empty";
            this.EmptyEventNameWarningLabel.Visible = false;
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 288);
            this.Controls.Add(this.EmptyEventNameWarningLabel);
            this.Controls.Add(this.EventTimePicker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SubmitEventButton);
            this.Controls.Add(this.EventDescriptionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.EventDatePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EventNameTextBox);
            this.Name = "AddEventForm";
            this.Text = "Add Event";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EventNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker EventDatePicker;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EventDescriptionTextBox;
        private System.Windows.Forms.Button SubmitEventButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker EventTimePicker;
        private System.Windows.Forms.Label EmptyEventNameWarningLabel;
    }
}