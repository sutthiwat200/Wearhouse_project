using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wearhouse
{
    public partial class AddProduct : Form
    {
        wearhouseEntities context = new wearhouseEntities();

        public AddProduct()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            LoadProductTypes();
            InitializeNumericInputs();
        }

        private void InitializeNumericInputs()
        {
            // Set up textBox3 (Price) to accept only decimal numbers
            textBox3.KeyPress += TextBox_KeyPress;
            textBox3.Tag = "decimal";

            // Set up textBox4 (Quantity) to accept only integers
            textBox4.KeyPress += TextBox_KeyPress;
            textBox4.Tag = "integer";
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            string inputType = textBox.Tag as string;

            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            // Allow decimal point only for decimal input
            if (inputType == "decimal")
            {
                if (e.KeyChar == '.' && textBox.Text.Contains("."))
                {
                    e.Handled = true;
                    return;
                }

                if (char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
            // Allow only digits for integer input
            else if (inputType == "integer")
            {
                if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void LoadProductTypes()
        {
            try
            {
                comboBox1.Items.Clear();
                var productTypes = context.producttype.ToList();

                foreach (var type in productTypes)
                {
                    comboBox1.Items.Add(new ComboBoxItem
                    {
                        Id = type.producttype_id,
                        Name = type.producttype_name
                    });
                }

                if (comboBox1.Items.Count > 0)
                {
                    comboBox1.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดประเภทสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image file(*.jpg; *.png; *.jpeg) | *.jpg; *.png; *.jpeg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(open.FileName);
                textBox5.Text = open.FileName;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void ClearForm()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            pictureBox1.Image = null;
            
            if (comboBox1.Items.Count > 0)
            {
                comboBox1.SelectedIndex = 0;
            }
        }

        // Helper class for ComboBox display
        private class ComboBoxItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("กรุณาเลือกประเภทสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text) || !decimal.TryParse(textBox3.Text, out decimal price))
                {
                    MessageBox.Show("กรุณาใส่ราคาที่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text) || !int.TryParse(textBox4.Text, out int quantity))
                {
                    MessageBox.Show("กรุณาใส่จำนวนที่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get selected type ID
                ComboBoxItem selectedType = (ComboBoxItem)comboBox1.SelectedItem;
                int typeId = selectedType.Id;

                // Convert image to byte array
                byte[] imageData = null;
                if (pictureBox1.Image != null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageData = ms.ToArray();
                    }
                }

                // Create new product
                product newProduct = new product
                {
                    product_name = textBox2.Text.Trim(),
                    producttype_id = typeId,
                    product_unitprice = price,
                    product_stock_qty = quantity,
                    product_image = imageData,
                    product_unit = textBox1.Text  // Default unit
                };

                context.product.Add(newProduct);
                context.SaveChanges();

                MessageBox.Show("เพิ่มสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
