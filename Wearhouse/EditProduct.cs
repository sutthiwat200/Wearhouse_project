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
    public partial class EditProduct : Form
    {
        private int currentProductId = 0;

        public EditProduct()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void EditProduct_Load(object sender, EventArgs e)
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
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;
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
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var productTypes = context.producttype.ToList();

                    comboBox1.DataSource = productTypes;
                    comboBox1.DisplayMember = "producttype_name";
                    comboBox1.ValueMember = "producttype_id";
                    comboBox1.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดประเภทสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Load product data into the form
        /// </summary>
        public void LoadProductData(int productId)
        {
            try
            {
                currentProductId = productId;
                
                LoadProductTypes();
                
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var product = context.product.FirstOrDefault(p => p.product_id == productId);

                    if (product != null)
                    {
                        textBox1.Text = product.product_id.ToString();
                        textBox2.Text = product.product_name;
                        textBox3.Text = product.product_unitprice.ToString();
                        
                        // Display total stock quantity (same as ProductPages)
                        int totalStock = product.product_stock_qty ?? 0;
                        textBox4.Text = totalStock.ToString();

                        // Load product unit
                        textBox6.Text = product.product_unit ?? "pcs";

                        Application.DoEvents();
                        
                        if (comboBox1.Items.Count > 0)
                        {
                            comboBox1.SelectedValue = product.producttype_id;
                        }

                        if (product.product_image != null && product.product_image.Length > 0)
                        {
                            try
                            {
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream(product.product_image))
                                {
                                    Image tempImage = Image.FromStream(ms);
                                    pictureBox1.Image = new Bitmap(tempImage);
                                    tempImage.Dispose();
                                }
                            }
                            catch
                            {
                                pictureBox1.Image = null;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboBox1.SelectedValue == null || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("กรุณาเลือกประเภทสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox3.Text))
                {
                    MessageBox.Show("กรุณาใส่ราคา", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    MessageBox.Show("กรุณาใส่จำนวน", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(textBox3.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("กรุณาใส่ราคาที่ถูกต้อง (ตัวเลขบวก)", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox4.Text, out int quantity) || quantity < 0)
                {
                    MessageBox.Show("กรุณาใส่จำนวนที่ถูกต้อง (ตัวเลขบวก)", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int productId))
                {
                    MessageBox.Show("รหัสสินค้าไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show confirmation dialog before updating
                var result = MessageBox.Show("คุณแน่ใจหรือว่าต้องการอัพเดตสินค้านี้?", "ยืนยันการอัพเดต", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    using (wearhouseEntities context = new wearhouseEntities())
                    {
                        // Find product to update
                        var productToUpdate = context.product.FirstOrDefault(p => p.product_id == productId);

                        if (productToUpdate != null)
                        {
                            // Update product data
                            productToUpdate.product_name = textBox2.Text.Trim();
                            productToUpdate.producttype_id = (int)comboBox1.SelectedValue;
                            productToUpdate.product_unitprice = price;
                            productToUpdate.product_unit = textBox6.Text.Trim();
                            // NOTE: product_stock_qty is no longer updated here
                            // Stock quantity is now managed through lot_balance_qty in the lot table

                            // Update image if a new one was selected
                            if (pictureBox1.Image != null && !string.IsNullOrWhiteSpace(textBox5.Text))
                            {
                                byte[] imageData = null;
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                                {
                                    pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                    imageData = ms.ToArray();
                                }
                                productToUpdate.product_image = imageData;
                            }

                            context.SaveChanges();

                            MessageBox.Show("อัพเดตสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void EditProduct_Load_1(object sender, EventArgs e)
        {

        }
    }
}
