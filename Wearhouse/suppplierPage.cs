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
    public partial class suppplierPage : Form
    {
        public suppplierPage()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void suppplierPage_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wearhouseDataSet.supplier' table. You can move, or remove it, as needed.
            this.supplierTableAdapter.Fill(this.wearhouseDataSet.supplier);
            LoadSuppliers();
            InitializePhoneInput();
        }

        private void InitializePhoneInput()
        {
            // Set up textBoxPhone to accept only digits and specific characters
            textBoxPhone.KeyPress += TextBoxPhone_KeyPress;
        }

        private void TextBoxPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow backspace
            if (e.KeyChar == (char)Keys.Back)
            {
                e.Handled = false;
                return;
            }

            // Allow digits and common phone characters: ( ) - space
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '(' || e.KeyChar == ')' || 
                e.KeyChar == '-' || e.KeyChar == ' ')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                // Recreate context to ensure fresh data from database
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var suppliers = context.supplier.ToList();
                    
                    // Rebind the DataGridView to refresh it
                    supplierBindingSource.DataSource = suppliers;
                    dataGridViewSupplier.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดซัพพลายเออร์ได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (string.IsNullOrWhiteSpace(textBoxSupplierName.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อซัพพลายเออร์", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string name = textBoxSupplierName.Text.Trim();
                string address = textBoxAddress.Text.Trim();
                string phone = textBoxPhone.Text.Trim();

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    supplier newSupplier = new supplier
                    {
                        supplier_name = name,
                        supplier_address = address,
                        supplier_phone = phone
                    };

                    context.supplier.Add(newSupplier);
                    context.SaveChanges();

                    MessageBox.Show("เพิ่มซัพพลายเออร์สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSupplierId.Text))
                {
                    MessageBox.Show("กรุณาเลือกซัพพลายเออร์เพื่ออัพเดต", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBoxSupplierName.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อซัพพลายเออร์", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxSupplierId.Text, out int supplierId))
                {
                    MessageBox.Show("รหัสซัพพลายเออร์ไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string name = textBoxSupplierName.Text.Trim();
                string address = textBoxAddress.Text.Trim();
                string phone = textBoxPhone.Text.Trim();

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var supplier = context.supplier.FirstOrDefault(s => s.supplier_id == supplierId);

                    if (supplier != null)
                    {
                        supplier.supplier_name = name;
                        supplier.supplier_address = address;
                        supplier.supplier_phone = phone;

                        context.SaveChanges();

                        MessageBox.Show("อัพเดตซัพพลายเออร์สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        LoadSuppliers();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบซัพพลายเออร์", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxSupplierId.Text))
                {
                    MessageBox.Show("กรุณาเลือกซัพพลายเออร์เพื่อลบ", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxSupplierId.Text, out int supplierId))
                {
                    MessageBox.Show("รหัสซัพพลายเออร์ไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"คุณแน่ใจหรือว่าต้องการลบ '{textBoxSupplierName.Text}'?",
                    "ยืนยันการลบ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    using (wearhouseEntities context = new wearhouseEntities())
                    {
                        var supplier = context.supplier.FirstOrDefault(s => s.supplier_id == supplierId);

                        if (supplier != null)
                        {
                            context.supplier.Remove(supplier);
                            context.SaveChanges();

                            MessageBox.Show("ลบซัพพลายเออร์สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearForm();
                            LoadSuppliers();
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบซัพพลายเออร์", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
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
            textBoxSupplierId.Clear();
            textBoxSupplierName.Clear();
            textBoxAddress.Clear();
            textBoxPhone.Clear();
        }

        private void DataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                    string columnName = dataGridViewSupplier.Columns[e.ColumnIndex].Name;

                    // Load data to form when clicking any cell
                    if (row.Cells[0].Value != null)
                    {
                        textBoxSupplierId.Text = row.Cells[0].Value.ToString();
                    }

                    if (row.Cells[1].Value != null)
                    {
                        textBoxSupplierName.Text = row.Cells[1].Value.ToString();
                    }

                    if (row.Cells[2].Value != null)
                    {
                        textBoxAddress.Text = row.Cells[2].Value.ToString();
                    }

                    if (row.Cells[3].Value != null)
                    {
                        textBoxPhone.Text = row.Cells[3].Value.ToString();
                    }

                    // Handle action columns
                    if (columnName == "แก้ไข")
                    {
                        // Trigger Edit button click
                        ButtonUpdate_Click(null, null);
                    }
                    else if (columnName == "ลบ")
                    {
                        // Trigger Delete button click
                        ButtonDelete_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถเลือกแถวได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewSupplier_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                // Edit button click
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                    
                    if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int supplierId))
                    {
                        EditSupplier editForm = new EditSupplier();
                        editForm.OnDataUpdated += LoadSuppliers;
                        editForm.LoadSupplierData(supplierId);
                        editForm.Show();
                    }
                }
            }
            else if (e.ColumnIndex == 5)
            {
                // Delete button click
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];
                    
                    if (row.Cells[0].Value != null)
                    {
                        textBoxSupplierId.Text = row.Cells[0].Value.ToString();
                    }
                    if (row.Cells[1].Value != null)
                    {
                        textBoxSupplierName.Text = row.Cells[1].Value.ToString();
                    }
                    
                    ButtonDelete_Click(null, null);
                }
            }
        }
    }
}
