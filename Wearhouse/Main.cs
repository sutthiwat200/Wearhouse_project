using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Wearhouse
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void LoginFomr_Load(object sender, EventArgs e)
        {
            // Responsive UI is now handled by ResponsiveHelper
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductPages productPages = new ProductPages();
            productPages.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StockIn stockInForm = new StockIn();
            stockInForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StockOut stockOutForm = new StockOut();
            stockOutForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SummaryReport summaryReportForm = new SummaryReport();
            summaryReportForm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            suppplierPage suppplier = new suppplierPage();
            suppplier.ShowDialog();
        }
    }
}
