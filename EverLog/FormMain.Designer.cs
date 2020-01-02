namespace EverLog
{
    partial class FormMain
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
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyLog = new System.Windows.Forms.Button();
            this.btnReadClipboard = new System.Windows.Forms.Button();
            this.btnWriteClipboard = new System.Windows.Forms.Button();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.lblGmail = new System.Windows.Forms.Label();
            this.txtGmail = new System.Windows.Forms.TextBox();
            this.chkHolidays = new System.Windows.Forms.CheckBox();
            this.chkPersonal = new System.Windows.Forms.CheckBox();
            this.lblHolidayCalendar = new System.Windows.Forms.Label();
            this.txtHolidayCalendar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(12, 79);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLog.Size = new System.Drawing.Size(593, 398);
            this.txtLog.TabIndex = 1;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(623, 79);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 27);
            this.btnClear.TabIndex = 31;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopyLog
            // 
            this.btnCopyLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyLog.Location = new System.Drawing.Point(623, 117);
            this.btnCopyLog.Name = "btnCopyLog";
            this.btnCopyLog.Size = new System.Drawing.Size(60, 27);
            this.btnCopyLog.TabIndex = 32;
            this.btnCopyLog.Text = "Copy";
            this.btnCopyLog.UseVisualStyleBackColor = true;
            this.btnCopyLog.Click += new System.EventHandler(this.btnCopyLog_Click);
            // 
            // btnReadClipboard
            // 
            this.btnReadClipboard.Location = new System.Drawing.Point(14, 42);
            this.btnReadClipboard.Name = "btnReadClipboard";
            this.btnReadClipboard.Size = new System.Drawing.Size(122, 23);
            this.btnReadClipboard.TabIndex = 114;
            this.btnReadClipboard.Text = "Read Clipboard";
            this.btnReadClipboard.UseVisualStyleBackColor = true;
            this.btnReadClipboard.Click += new System.EventHandler(this.btnReadClipboard_Click);
            // 
            // btnWriteClipboard
            // 
            this.btnWriteClipboard.Location = new System.Drawing.Point(13, 11);
            this.btnWriteClipboard.Name = "btnWriteClipboard";
            this.btnWriteClipboard.Size = new System.Drawing.Size(123, 23);
            this.btnWriteClipboard.TabIndex = 113;
            this.btnWriteClipboard.Text = "EverLog  to Clipboard";
            this.btnWriteClipboard.UseVisualStyleBackColor = true;
            this.btnWriteClipboard.Click += new System.EventHandler(this.btnWriteClipboard_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(143, 43);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(41, 20);
            this.txtYear.TabIndex = 115;
            this.txtYear.Text = "2020";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(148, 16);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 116;
            this.lblYear.Text = "Year";
            // 
            // lblGmail
            // 
            this.lblGmail.AutoSize = true;
            this.lblGmail.Location = new System.Drawing.Point(223, 16);
            this.lblGmail.Name = "lblGmail";
            this.lblGmail.Size = new System.Drawing.Size(74, 13);
            this.lblGmail.TabIndex = 118;
            this.lblGmail.Text = "Gmail Address";
            // 
            // txtGmail
            // 
            this.txtGmail.AllowDrop = true;
            this.txtGmail.Location = new System.Drawing.Point(190, 44);
            this.txtGmail.MaxLength = 100;
            this.txtGmail.Name = "txtGmail";
            this.txtGmail.Size = new System.Drawing.Size(139, 20);
            this.txtGmail.TabIndex = 117;
            this.txtGmail.Text = "MyGmail@gmail.com";
            this.txtGmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkHolidays
            // 
            this.chkHolidays.AutoSize = true;
            this.chkHolidays.Checked = true;
            this.chkHolidays.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHolidays.Location = new System.Drawing.Point(596, 16);
            this.chkHolidays.Name = "chkHolidays";
            this.chkHolidays.Size = new System.Drawing.Size(104, 17);
            this.chkHolidays.TabIndex = 119;
            this.chkHolidays.Text = "Include Holidays";
            this.chkHolidays.UseVisualStyleBackColor = true;
            // 
            // chkPersonal
            // 
            this.chkPersonal.AutoSize = true;
            this.chkPersonal.Checked = true;
            this.chkPersonal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPersonal.Location = new System.Drawing.Point(596, 46);
            this.chkPersonal.Name = "chkPersonal";
            this.chkPersonal.Size = new System.Drawing.Size(105, 17);
            this.chkPersonal.TabIndex = 120;
            this.chkPersonal.Text = "Include Personal";
            this.chkPersonal.UseVisualStyleBackColor = true;
            // 
            // lblHolidayCalendar
            // 
            this.lblHolidayCalendar.AutoSize = true;
            this.lblHolidayCalendar.Location = new System.Drawing.Point(407, 16);
            this.lblHolidayCalendar.Name = "lblHolidayCalendar";
            this.lblHolidayCalendar.Size = new System.Drawing.Size(87, 13);
            this.lblHolidayCalendar.TabIndex = 122;
            this.lblHolidayCalendar.Text = "Holiday Calendar";
            // 
            // txtHolidayCalendar
            // 
            this.txtHolidayCalendar.Location = new System.Drawing.Point(336, 44);
            this.txtHolidayCalendar.MaxLength = 150;
            this.txtHolidayCalendar.Name = "txtHolidayCalendar";
            this.txtHolidayCalendar.Size = new System.Drawing.Size(252, 20);
            this.txtHolidayCalendar.TabIndex = 121;
            this.txtHolidayCalendar.Text = "en.usa#holiday@group.v.calendar.google.com";
            this.txtHolidayCalendar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 488);
            this.Controls.Add(this.lblHolidayCalendar);
            this.Controls.Add(this.txtHolidayCalendar);
            this.Controls.Add(this.chkPersonal);
            this.Controls.Add(this.chkHolidays);
            this.Controls.Add(this.lblGmail);
            this.Controls.Add(this.txtGmail);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.btnReadClipboard);
            this.Controls.Add(this.btnWriteClipboard);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCopyLog);
            this.Controls.Add(this.txtLog);
            this.Name = "FormMain";
            this.Text = "Evernote Log";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopyLog;
        private System.Windows.Forms.Button btnReadClipboard;
        private System.Windows.Forms.Button btnWriteClipboard;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.Label lblGmail;
        private System.Windows.Forms.TextBox txtGmail;
        private System.Windows.Forms.CheckBox chkHolidays;
        private System.Windows.Forms.CheckBox chkPersonal;
        private System.Windows.Forms.Label lblHolidayCalendar;
        private System.Windows.Forms.TextBox txtHolidayCalendar;
    }
}

