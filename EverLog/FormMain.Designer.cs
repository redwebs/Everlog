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
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(14, 78);
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
            this.btnReadClipboard.Location = new System.Drawing.Point(14, 29);
            this.btnReadClipboard.Name = "btnReadClipboard";
            this.btnReadClipboard.Size = new System.Drawing.Size(167, 23);
            this.btnReadClipboard.TabIndex = 114;
            this.btnReadClipboard.Text = "Read Clipboard";
            this.btnReadClipboard.UseVisualStyleBackColor = true;
            this.btnReadClipboard.Click += new System.EventHandler(this.btnReadClipboard_Click);
            // 
            // btnWriteClipboard
            // 
            this.btnWriteClipboard.Location = new System.Drawing.Point(192, 29);
            this.btnWriteClipboard.Name = "btnWriteClipboard";
            this.btnWriteClipboard.Size = new System.Drawing.Size(167, 23);
            this.btnWriteClipboard.TabIndex = 113;
            this.btnWriteClipboard.Text = "Write EverLog  to Clipboard";
            this.btnWriteClipboard.UseVisualStyleBackColor = true;
            this.btnWriteClipboard.Click += new System.EventHandler(this.btnWriteClipboard_Click);
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(407, 31);
            this.txtYear.MaxLength = 4;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(41, 20);
            this.txtYear.TabIndex = 115;
            this.txtYear.Text = "2017";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Location = new System.Drawing.Point(372, 34);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 13);
            this.lblYear.TabIndex = 116;
            this.lblYear.Text = "Year";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 488);
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
    }
}

