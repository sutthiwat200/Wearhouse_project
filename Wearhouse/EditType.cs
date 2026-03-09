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
    public partial class EditType : Form
    {
        wearhouseEntities context = new wearhouseEntities();
        private int currentTypeId = 0;
        public Action OnDataUpdated { get; set; }

        public EditType()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void EditType_Load(object sender, EventArgs e)
        {
            // Empty by design - will be populated when form is opened
        }

        /// <summary>
        /// Load product type data into the form
        /// </summary>
        public void LoadTypeData(int typeId)
        {
            try
            {
                currentTypeId = typeId;
                
                var productType = context.producttype.FirstOrDefault(pt => pt.producttype_id == typeId);

                if (productType != null)
                {
                    textBox1.Text = productType.producttype_id.ToString();
                    textBox2.Text = productType.producttype_name;
                }
                else
                {
                    MessageBox.Show("ไม่พบประเภทสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดประเภทสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อประเภท", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox1.Text, out int typeId))
                {
                    MessageBox.Show("รหัสประเภทไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newTypeName = textBox2.Text.Trim();

                // Check if product type name already exists (excluding current record)
                var existingType = context.producttype.FirstOrDefault(pt => pt.producttype_name == newTypeName && pt.producttype_id != typeId);
                if (existingType != null)
                {
                    MessageBox.Show("ชื่อประเภทนี้มีอยู่แล้ว", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show confirmation dialog before updating
                var result = MessageBox.Show("คุณแน่ใจหรือว่าต้องการอัพเดตประเภทสินค้านี้?", "ยืนยันการอัพเดต", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                
                if (result == DialogResult.Yes)
                {
                    var productType = context.producttype.FirstOrDefault(pt => pt.producttype_id == typeId);

                    if (productType != null)
                    {
                        productType.producttype_name = newTypeName;
                        context.SaveChanges();

                        MessageBox.Show("อัพเดตประเภทสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Notify parent form to refresh data
                        OnDataUpdated?.Invoke();
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ไม่พบประเภทสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
