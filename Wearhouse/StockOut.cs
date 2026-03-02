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
    public partial class StockOut : Form
    {
        public StockOut()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void StockOut_Load(object sender, EventArgs e)
        {
            LoadProducts();
            InitializeNumericInput();
            LoadTransactions();
        }

        private void InitializeNumericInput()
        {
            textBoxQuantity.KeyPress += TextBoxQuantity_KeyPress;
        }

        private void TextBoxQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void LoadProducts()
        {
            try
            {
                flowLayoutPanelProducts.Controls.Clear();
                
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var products = context.product.ToList();

                    foreach (var product in products)
                    {
                        // Calculate stock from lot balance quantities
                        int totalStock = context.lot
                            .Where(l => l.product_id == product.product_id)
                            .Sum(l => (int?)l.lot_balance_qty) ?? 0;

                        // Only add products with stock available
                        if (totalStock > 0)
                        {
                            var productButton = CreateProductButton(new ProductItem
                            {
                                Id = product.product_id,
                                Name = product.product_name,
                                UnitPrice = product.product_unitprice ?? 0,
                                CurrentStock = totalStock,
                                ImageData = product.product_image
                            });

                            flowLayoutPanelProducts.Controls.Add(productButton);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateProductButton(ProductItem product)
        {
            Panel panel = new Panel();
            panel.Size = new System.Drawing.Size(110, 120);
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.BackColor = System.Drawing.Color.White;
            panel.Margin = new Padding(5);
            panel.Tag = product;
            panel.Cursor = Cursors.Hand;

            // Product image
            PictureBox pb = new PictureBox();
            pb.Size = new System.Drawing.Size(100, 85);
            pb.Location = new System.Drawing.Point(5, 5);
            pb.BorderStyle = BorderStyle.None;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Cursor = Cursors.Hand;

            if (product.ImageData != null && product.ImageData.Length > 0)
            {
                try
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(product.ImageData))
                    {
                        Image productImage = Image.FromStream(ms);
                        pb.Image = new System.Drawing.Bitmap(productImage);
                    }
                }
                catch
                {
                    pb.BackColor = System.Drawing.Color.LightGray;
                }
            }
            else
            {
                pb.BackColor = System.Drawing.Color.LightGray;
            }

            // Product name label
            Label nameLabel = new Label();
            nameLabel.Text = product.Name.Length > 15 ? product.Name.Substring(0, 12) + "..." : product.Name;
            nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            nameLabel.AutoSize = false;
            nameLabel.Size = new System.Drawing.Size(100, 30);
            nameLabel.Location = new System.Drawing.Point(5, 93);
            nameLabel.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            nameLabel.Cursor = Cursors.Hand;

            // Click event
            pb.Click += (sender, e) => SelectProduct(product);
            panel.Click += (sender, e) => SelectProduct(product);
            nameLabel.Click += (sender, e) => SelectProduct(product);
            pb.MouseHover += (sender, e) => 
            {
                panel.BackColor = System.Drawing.Color.LightYellow;
                panel.BorderStyle = BorderStyle.Fixed3D;
            };
            pb.MouseLeave += (sender, e) => 
            {
                panel.BackColor = System.Drawing.Color.White;
                panel.BorderStyle = BorderStyle.FixedSingle;
            };

            panel.Controls.Add(pb);
            panel.Controls.Add(nameLabel);

            return panel;
        }

        private void SelectProduct(ProductItem product)
        {
            labelSelectedProductName.Text = product.Name;
            labelSelectedProductPrice.Text = $"ราคา : {product.UnitPrice:N2} บาท";
            UpdateCurrentStockDisplay(product);

            try
            {
                if (product.ImageData != null && product.ImageData.Length > 0)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(product.ImageData))
                    {
                        Image productImage = Image.FromStream(ms);
                        pictureBoxLargeProduct.Image = new System.Drawing.Bitmap(productImage);
                    }
                }
                else
                {
                    pictureBoxLargeProduct.Image = null;
                }
            }
            catch
            {
                pictureBoxLargeProduct.Image = null;
            }

            // Store selected product
            flowLayoutPanelProducts.Tag = product;
        }

        private ProductItem GetSelectedProduct()
        {
            return flowLayoutPanelProducts.Tag as ProductItem;
        }

        private void LoadTransactions()
        {
            try
            {
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var transactions = context.transaction
                        .Where(t => t.trans_type == 2)  // 2 = Stock Out
                        .OrderByDescending(t => t.trans_date_time)
                        .ToList();

                    if (transactions.Count == 0)
                    {
                        dataGridViewTransactions.DataSource = null;
                        return;
                    }

                    var transactionData = transactions
                        .Select(t => new
                        {
                            รหัส = t.trans_id,
                            วันที่ = t.trans_date_time.ToString("dd/MM/yyyy HH:mm"),
                            สินค้า = t.product != null ? t.product.product_name : "ไม่พบสินค้า",
                            จำนวน = t.trans_qty,
                            ราคาต่อหน่วย = t.trans_unit_price,
                            ราคารวม = t.trans_total_amount,
                            หมายเหตุ = t.trans_reason ?? ""
                        }).ToList();

                    dataGridViewTransactions.DataSource = transactionData;
                    dataGridViewTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    
                    // ตั้งค่า row height
                    dataGridViewTransactions.RowTemplate.Height = 35;
                    dataGridViewTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                    
                    foreach (DataGridViewColumn column in dataGridViewTransactions.Columns)
                    {
                        if (column.Name == "ราคาต่อหน่วย" || column.Name == "ราคารวม")
                        {
                            column.DefaultCellStyle.Format = "#,##0.00";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.Name == "จำนวน")
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else if (column.Name == "หมายเหตุ" || column.Name == "สินค้า")
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดข้อมูลรายการได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCurrentStockDisplay(ProductItem product)
        {
            if (product.CurrentStock <= 0)
            {
                labelCurrentStock.Text = $"จำนวนคงเหลือ : 0 ชิ้น (สินค้าหมด)";
                labelCurrentStock.ForeColor = Color.Red;
            }
            else if (product.CurrentStock <= 10)
            {
                labelCurrentStock.Text = $"จำนวนคงเหลือ : {product.CurrentStock} ชิ้น (ใกล้หมด)";
                labelCurrentStock.ForeColor = Color.Orange;
            }
            else
            {
                labelCurrentStock.Text = $"จำนวนคงเหลือ : {product.CurrentStock} ชิ้น";
                labelCurrentStock.ForeColor = Color.Green;
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ProductItem selectedProduct = GetSelectedProduct();

                if (selectedProduct == null)
                {
                    MessageBox.Show("กรุณาเลือกสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxQuantity.Text) || !int.TryParse(textBoxQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("กรุณาใส่จำนวนที่ถูกต้อง (มากกว่า 0)", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate stock availability
                if (selectedProduct.CurrentStock < quantity)
                {
                    MessageBox.Show($"จำนวนไม่เพียงพอ! จำนวนคงเหลือ: {selectedProduct.CurrentStock} ชิ้น", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reason = textBoxReason.Text.Trim();

                decimal totalAmount = quantity * selectedProduct.UnitPrice;

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    transaction newTransaction = new transaction
                    {
                        product_id = selectedProduct.Id,
                        trans_date_time = dateTimePickerDate.Value,
                        trans_type = 2,  // 2 = Stock Out
                        trans_reason = reason,
                        trans_qty = quantity,
                        trans_unit_price = selectedProduct.UnitPrice,
                        trans_total_amount = totalAmount
                    };

                    context.transaction.Add(newTransaction);

                    // Deduct from lot balance quantities (FIFO - First In First Out)
                    int remainingQuantity = quantity;
                    var lots = context.lot
                        .Where(l => l.product_id == selectedProduct.Id && l.lot_balance_qty > 0)
                        .OrderBy(l => l.lot_receive_date)
                        .ToList();

                    foreach (var lot in lots)
                    {
                        if (remainingQuantity <= 0)
                            break;

                        int lotBalance = lot.lot_balance_qty ?? 0;
                        int deductAmount = Math.Min(remainingQuantity, lotBalance);
                        lot.lot_balance_qty -= deductAmount;
                        remainingQuantity -= deductAmount;
                    }

                    context.SaveChanges();

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadProducts();
                    LoadTransactions();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            dateTimePickerDate.Value = DateTime.Now;
            textBoxQuantity.Clear();
            textBoxReason.Clear();
            labelSelectedProductName.Text = "ยังไม่เลือกสินค้า";
            labelSelectedProductPrice.Text = "ราคา : -";
            labelCurrentStock.Text = "จำนวนคงเหลือ : -";
            pictureBoxLargeProduct.Image = null;
            flowLayoutPanelProducts.Tag = null;
        }

        private class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public int CurrentStock { get; set; }
            public byte[] ImageData { get; set; }

            public override string ToString()
            {
                return $"{Name} (Price: {UnitPrice:C}, Stock: {CurrentStock})";
            }
        }
    }
}
