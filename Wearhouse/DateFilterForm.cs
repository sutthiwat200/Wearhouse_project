using System;
using System.Windows.Forms;

namespace Wearhouse
{
    public partial class DateFilterForm : Form
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateFilterForm()
        {
            InitializeComponent();
        }

        private void DateFilterForm_Load(object sender, EventArgs e)
        {
            // Set default values to today's date range
            dateTimePickerStart.Value = DateTime.Today;
            dateTimePickerEnd.Value = DateTime.Today;
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            StartDate = dateTimePickerStart.Value;
            EndDate = dateTimePickerEnd.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            dateTimePickerStart.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerEnd.Value = DateTime.Now;
        }
    }
}
