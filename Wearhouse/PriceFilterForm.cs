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
    public partial class PriceFilterForm : Form
    {
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        public PriceFilterForm()
        {
            InitializeComponent();
        }

        private void PriceFilterForm_Load(object sender, EventArgs e)
        {
            // Initialize with default values
            MinPrice = 0;
            MaxPrice = decimal.MaxValue;
            
            textBoxMinPrice.Text = "0";
            textBoxMaxPrice.Text = "";
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate and parse minimum price
                if (string.IsNullOrWhiteSpace(textBoxMinPrice.Text))
                {
                    MinPrice = 0;
                }
                else if (!decimal.TryParse(textBoxMinPrice.Text, out decimal minPrice))
                {
                    MessageBox.Show("กรุณาใส่ราคาน้อยสุดที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MinPrice = minPrice;
                }

                // Validate and parse maximum price
                if (string.IsNullOrWhiteSpace(textBoxMaxPrice.Text))
                {
                    MaxPrice = decimal.MaxValue;
                }
                else if (!decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPrice))
                {
                    MessageBox.Show("กรุณาใส่ราคามากสุดที่ถูกต้อง", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    MaxPrice = maxPrice;
                }

                // Validate that min price is not greater than max price
                if (MinPrice > MaxPrice)
                {
                    MessageBox.Show("ราคาน้อยสุดต้องไม่มากกว่าราคามากสุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow digits, decimal point, and backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
    }
}
