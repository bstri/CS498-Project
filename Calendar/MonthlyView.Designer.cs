namespace Calendar
{
    partial class MonthlyView
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
            this.DayGrid = new System.Windows.Forms.TableLayoutPanel();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.PreviousMonthButton = new System.Windows.Forms.Button();
            this.NextMonthButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DayGrid
            // 
            this.DayGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DayGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.DayGrid.ColumnCount = 7;
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.DayGrid.Location = new System.Drawing.Point(0, 39);
            this.DayGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DayGrid.Name = "DayGrid";
            this.DayGrid.RowCount = 6;
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.DayGrid.Size = new System.Drawing.Size(1192, 478);
            this.DayGrid.TabIndex = 0;
            // 
            // MonthLabel
            // 
            this.MonthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonthLabel.Location = new System.Drawing.Point(553, 11);
            this.MonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(87, 17);
            this.MonthLabel.TabIndex = 1;
            this.MonthLabel.Text = "January";
            this.MonthLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PreviousMonthButton
            // 
            this.PreviousMonthButton.Location = new System.Drawing.Point(517, 5);
            this.PreviousMonthButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PreviousMonthButton.Name = "PreviousMonthButton";
            this.PreviousMonthButton.Size = new System.Drawing.Size(31, 28);
            this.PreviousMonthButton.TabIndex = 2;
            this.PreviousMonthButton.Text = "<";
            this.PreviousMonthButton.UseVisualStyleBackColor = true;
            this.PreviousMonthButton.Click += new System.EventHandler(this.PreviousMonthButton_Click);
            // 
            // NextMonthButton
            // 
            this.NextMonthButton.Location = new System.Drawing.Point(644, 5);
            this.NextMonthButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.NextMonthButton.Name = "NextMonthButton";
            this.NextMonthButton.Size = new System.Drawing.Size(31, 28);
            this.NextMonthButton.TabIndex = 3;
            this.NextMonthButton.Text = ">";
            this.NextMonthButton.UseVisualStyleBackColor = true;
            this.NextMonthButton.Click += new System.EventHandler(this.NextMonthButton_Click);
            // 
            // MonthlyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1192, 517);
            this.Controls.Add(this.NextMonthButton);
            this.Controls.Add(this.PreviousMonthButton);
            this.Controls.Add(this.MonthLabel);
            this.Controls.Add(this.DayGrid);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MonthlyView";
            this.Text = "Calendar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel DayGrid;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.Button PreviousMonthButton;
        private System.Windows.Forms.Button NextMonthButton;
    }
}

