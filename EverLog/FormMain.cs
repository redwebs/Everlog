using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EverLog
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnReadClipboard_Click(object sender, EventArgs e)
        {
            txtLog.Text += ClipboardHelper.GetClipbordInfo().ToString();
        }

        private void btnWriteClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                int year;
                if (!int.TryParse(txtYear.Text, out year))
                {
                    txtLog.Text += "Invalid year number";
                    return;
                }
                var everLog = GenEverLog.CreateYear(year);
                ClipboardHelper.CopyToClipboard(everLog.Item1.ToString(), everLog.Item2.ToString());

                txtLog.Text += "Added HTML to Clipboard";
            }
            catch (Exception ex)
            {
                txtLog.Text += $"Error adding HTML: {ex}";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLog.Text = string.Empty;
        }

        private void btnCopyLog_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(txtLog.Text, true);
        }
    }
}
