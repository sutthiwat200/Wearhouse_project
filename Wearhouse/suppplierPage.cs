using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Wearhouse;

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

        private void DataGridViewSupplier_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var dgv = dataGridViewSupplier;
                dgv.RowHeadersVisible = false;
                dgv.GridColor = Color.FromArgb(230, 230, 230);
                dgv.BorderStyle = BorderStyle.None;
                dgv.CellBorderStyle = DataGridViewCellBorderStyle.None;

                // alternating row colors
                if (e.RowIndex % 2 == 0)
                {
                    e.CellStyle.BackColor = Color.FromArgb(245, 250, 255);
                }
                else
                {
                    e.CellStyle.BackColor = Color.White;
                }

                e.CellStyle.SelectionBackColor = Color.FromArgb(197, 225, 245);
                e.CellStyle.SelectionForeColor = Color.Black;
            }
            catch
            {
                // ignore formatting errors
            }
        }

        private void LoadSuppliers()
        {
            try
            {
                // Clear existing data
                dataGridViewSupplier.DataSource = null;

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var suppliers = context.supplier.ToList();
                    
                    // Bind data directly to DataGridView
                    dataGridViewSupplier.DataSource = suppliers;
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
            LoadSuppliers();
        }

        private void DataGridViewSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridViewSupplier.Rows[e.RowIndex];

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
                    
                    if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int supplierId))
                    {
                        var result = MessageBox.Show(
                            $"คุณแน่ใจหรือว่าต้องการลบ?",
                            "ยืนยันการลบ",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (result == DialogResult.Yes)
                        {
                            try
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
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void textBoxPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxSupplierId_Load(object sender, EventArgs e)
        {

        }

        private void panelInput_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
