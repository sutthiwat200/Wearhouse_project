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
    public partial class EditSupplier : Form
    {
        wearhouseEntities context = new wearhouseEntities();
        private int currentSupplierId = 0;
        public Action OnDataUpdated { get; set; }

        public EditSupplier()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void EditSupplier_Load(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Load supplier data into the form
        /// </summary>
        public void LoadSupplierData(int supplierId)
        {
            try
            {
                currentSupplierId = supplierId;

                var supplier = context.supplier.FirstOrDefault(s => s.supplier_id == supplierId);

                if (supplier != null)
                {
                    textBoxId.Text = supplier.supplier_id.ToString();
                    textBoxName.Text = supplier.supplier_name;
                    textBoxAddress.Text = supplier.supplier_address;
                    textBoxPhone.Text = supplier.supplier_phone;
                }
                else
                {
                    MessageBox.Show("ไม่พบซัพพลายเออร์", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดซัพพลายเออร์ได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBoxName.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อซัพพลายเออร์", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBoxId.Text, out int supplierId))
                {
                    MessageBox.Show("รหัสซัพพลายเออร์ไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show confirmation dialog before updating
                var result = MessageBox.Show("คุณแน่ใจหรือว่าต้องการอัพเดตซัพพลายเออร์นี้?", "ยืนยันการอัพเดต", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    var supplier = context.supplier.FirstOrDefault(s => s.supplier_id == supplierId);

                    if (supplier != null)
                    {
                        supplier.supplier_name = textBoxName.Text.Trim();
                        supplier.supplier_address = textBoxAddress.Text.Trim();
                        supplier.supplier_phone = textBoxPhone.Text.Trim();

                        context.SaveChanges();

                        MessageBox.Show("อัพเดตซัพพลายเออร์สำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Notify parent form to refresh data
                        OnDataUpdated?.Invoke();

                        this.Close();
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
