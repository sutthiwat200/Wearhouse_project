using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.Entity.Core;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wearhouse
{
    public partial class StockIn : Form
    {
        public StockIn()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void StockIn_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            LoadProducts();
            InitializeNumericInput();
            RefreshTransactionData();
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
                if (flowLayoutPanelProducts == null) return;

                flowLayoutPanelProducts.SuspendLayout();
                try
                {
                    flowLayoutPanelProducts.Controls.Clear();

                    using (wearhouseEntities context = new wearhouseEntities())
                    {
                        // enable double buffering
                        try
                        {
                            var prop = typeof(Panel).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                            if (prop != null)
                                prop.SetValue(flowLayoutPanelProducts, true, null);
                        }
                        catch { }

                        // Load products with minimal fields in one query
                        var products = context.product
                            .AsNoTracking()
                            .Select(p => new
                            {
                                p.product_id,
                                p.product_name,
                                UnitPrice = p.product_unitprice,
                                p.product_image
                            })
                            .ToList();

                        var controlsToAdd = new List<Control>(products.Count);

                        foreach (var p in products)
                        {
                            var productButton = CreateProductButton(new ProductItem
                            {
                                Id = p.product_id,
                                Name = p.product_name,
                                UnitPrice = p.UnitPrice ?? 0,
                                ImageData = p.product_image
                            });

                            controlsToAdd.Add(productButton);
                        }

                        flowLayoutPanelProducts.Controls.AddRange(controlsToAdd.ToArray());
                    }
                }
                finally
                {
                    flowLayoutPanelProducts.ResumeLayout();
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
                        using (var img = Image.FromStream(ms))
                        {
                            pb.Image = new Bitmap(img);
                        }
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

            try
            {
                if (product.ImageData != null && product.ImageData.Length > 0)
                {
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(product.ImageData))
                    {
                        using (var img = Image.FromStream(ms))
                        {
                            pictureBoxLargeProduct.Image = new Bitmap(img);
                        }
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

        private void LoadSuppliers()
        {
            try
            {
                comboBoxSupplier.Items.Clear();

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var suppliers = context.supplier.AsNoTracking().Select(s => new { s.supplier_id, s.supplier_name }).ToList();

                    foreach (var supplier in suppliers)
                    {
                        comboBoxSupplier.Items.Add(new SupplierItem
                        {
                            Id = supplier.supplier_id,
                            Name = supplier.supplier_name
                        });
                    }

                    if (comboBoxSupplier.Items.Count > 0)
                    {
                        comboBoxSupplier.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดซัพพลายเออร์ได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบซัพพลายเออร์ก่อน
                if (comboBoxSupplier.SelectedItem == null)
                {
                    MessageBox.Show("กรุณากรอกซัพพลายเออร์ก่อน", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductItem selectedProduct = GetSelectedProduct();

                if (selectedProduct == null)
                {
                    MessageBox.Show("กรุณาเลือกสินค้า", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxQuantity.Text) || !int.TryParse(textBoxQuantity.Text, out int quantity) || quantity <= 0)
                {
                    MessageBox.Show("กรุณาใส่จำนวนที่ถูกต้อง (มากกว่า 0)", "ข้อผิดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string reason = textBoxReason.Text.Trim();

                decimal totalAmount = quantity * selectedProduct.UnitPrice;

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    SupplierItem selectedSupplier = (SupplierItem)comboBoxSupplier.SelectedItem;

                    // บันทึก transaction พร้อม supplier_id
                    transaction newTransaction = new transaction
                    {
                        product_id = selectedProduct.Id,
                        supplier_id = selectedSupplier.Id,  // เพิ่มการบันทึก supplier_id
                        trans_date_time = dateTimePickerDate.Value,
                        trans_type = 1,
                        trans_reason = reason,
                        trans_qty = quantity,
                        trans_unit_price = selectedProduct.UnitPrice,
                        trans_total_amount = totalAmount
                    };

                    context.transaction.Add(newTransaction);

                    // Create lot record
                    lot newLot = new lot
                    {
                        product_id = selectedProduct.Id,
                        supplier_id = selectedSupplier.Id,
                        lot_receive_date = dateTimePickerDate.Value,
                        lot_receive_qty = quantity,
                        lot_balance_qty = quantity,
                        lot_unit_cost = selectedProduct.UnitPrice,
                        lot_total_cost = totalAmount,
                        lot_expire_date = dateTimePickerExpireDate.Value,
                        lot_create_at = null
                    };

                    context.lot.Add(newLot);

                    // อัพเดต product_stock_qty
                    var productToUpdate = context.product.FirstOrDefault(p => p.product_id == selectedProduct.Id);
                    if (productToUpdate != null)
                    {
                        productToUpdate.product_stock_qty = (productToUpdate.product_stock_qty ?? 0) + quantity;
                    }

                    context.SaveChanges();

                    MessageBox.Show("บันทึกข้อมูลสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadProducts();
                    RefreshTransactionData();
                }
            }
            catch (DbEntityValidationException ex)
            {
                string errorMessage = "ข้อผิดพลาดการตรวจสอบ:\n";
                foreach (var entityValidationError in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationError.ValidationErrors)
                    {
                        errorMessage += $"คุณสมบัติ: {validationError.PropertyName}\nข้อผิดพลาด: {validationError.ErrorMessage}\n\n";
                    }
                }
                MessageBox.Show(errorMessage, "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                string errorMessage = "ข้อผิดพลาดการอัพเดตฐานข้อมูล:\n";
                if (ex.InnerException != null)
                {
                    errorMessage += $"รายละเอียด: {ex.InnerException.Message}";
                }
                else
                {
                    errorMessage += ex.Message;
                }
                MessageBox.Show(errorMessage, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                string errorMessage = "ข้อผิดพลาด: " + ex.Message;
                if (ex.InnerException != null)
                {
                    errorMessage += "\n\nข้อผิดพลาดภายใน: " + ex.InnerException.Message;
                }
                MessageBox.Show(errorMessage, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            dateTimePickerDate.Value = DateTime.Now;
            dateTimePickerExpireDate.Value = DateTime.Now.AddMonths(1);
            textBoxQuantity.Clear();
            textBoxReason.Clear();
            labelSelectedProductName.Text = "ยังไม่เลือกสินค้า";
            labelSelectedProductPrice.Text = "ราคา : -";
            pictureBoxLargeProduct.Image = null;
            flowLayoutPanelProducts.Tag = null;
        }

        private void RefreshTransactionData()
        {
            try
            {
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var transactions = context.transaction
                        .AsNoTracking()
                        .Where(t => t.trans_type == 1)
                        .OrderByDescending(t => t.trans_date_time)
                        .Select(t => new
                        {
                            Id = t.trans_id,
                            Date = t.trans_date_time,
                            ProductName = t.product != null ? t.product.product_name : "ไม่พบสินค้า",
                            Qty = t.trans_qty,
                            UnitPrice = t.trans_unit_price,
                            Total = t.trans_total_amount,
                            Reason = t.trans_reason
                        })
                        .ToList();

                    if (transactions.Count == 0)
                    {
                        dataGridViewTransactions.DataSource = null;
                        return;
                    }

                    var transactionData = transactions.Select(t => new
                    {
                        รหัส = t.Id,
                        วันที่ = ((DateTime)t.Date).ToString("dd/MM/yyyy HH:mm"),
                        สินค้า = t.ProductName,
                        จำนวน = t.Qty,
                        ราคาต่อหน่วย = t.UnitPrice,
                        ราคารวม = t.Total,
                        หมายเหตุ = t.Reason ?? ""
                    }).ToList();

                    dataGridViewTransactions.SuspendLayout();
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
                    dataGridViewTransactions.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถรีเฟรชข้อมูลรายการได้: " + ex.Message + "\n\n" + ex.StackTrace, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal UnitPrice { get; set; }
            public byte[] ImageData { get; set; }

            public override string ToString()
            {
                return $"{Name} (Price: {UnitPrice:C})";
            }
        }

        private class SupplierItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
