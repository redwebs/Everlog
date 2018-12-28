using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GoogCalLib;
using log4net.Config;


namespace EverLog
{
    public partial class FormMain : Form
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Replace this with the path to your personal Google Client JSON
        private const string ClientSecretPath = "C:\\Users\\fred\\Dropbox\\GoogleClientSecret1.json";

        private List<CalendarItem> _calendarItems = new List<CalendarItem>();

        public FormMain()
        {
            InitializeComponent();
            XmlConfigurator.Configure();
            YearList.ClientSecretPath = ClientSecretPath;
            Log.Debug("Started program Everlog");
        }

        private void btnReadClipboard_Click(object sender, EventArgs e)
        {
            txtLog.Text += ClipboardHelper.GetClipbordInfo().ToString();
        }

        private void btnWriteClipboard_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtYear.Text, out var year))
                {
                    txtLog.Text += "Invalid year number\r\n";
                    return;
                }
                _calendarItems = YearList.GetList(2019, txtGmail.Text, txtHolidayCalendar.Text, chkPersonal.Checked, chkHolidays.Checked);
                var everLog = GenEverLog.CreateYear(year, _calendarItems);
                ClipboardHelper.CopyToClipboard(everLog.Item1.ToString(), everLog.Item2.ToString());

                txtLog.Text += "Added HTML to Clipboard\r\n";
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
