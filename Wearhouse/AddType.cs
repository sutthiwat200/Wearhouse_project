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
    public partial class AddType : Form
    {
        wearhouseEntities context = new wearhouseEntities();
        public AddType()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void AddType_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wearhouseDataSet.producttype' table. You can move, or remove it, as needed.
            this.producttypeTableAdapter.Fill(this.wearhouseDataSet.producttype);
            LoadProductTypes();
        }
        
        private void LoadProductTypes()
        {
            try
            {
                // Recreate context to ensure fresh data from database
                context = new wearhouseEntities();
                
                var productTypes = from pt in context.producttype
                                   select pt;
                dataGridView1.DataSource = productTypes.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดประเภทสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    // Handle Edit button (Column1)
                    if (e.ColumnIndex == 2) // Column1 is the Edit button
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        
                        if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int typeId))
                        {
                            EditType editForm = new EditType();
                            editForm.OnDataUpdated += LoadProductTypes;
                            editForm.LoadTypeData(typeId);
                            editForm.Show();
                            editForm.FormClosed += (s, args) => LoadProductTypes();
                        }
                    }
                    // Handle Delete button (Column2)
                    else if (e.ColumnIndex == 3) // Column2 is the Delete button
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        
                        if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int typeId))
                        {
                            var result = MessageBox.Show("คุณแน่ใจหรือว่าต้องการลบประเภทสินค้าชิ้นนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            
                            if (result == DialogResult.Yes)
                            {
                                var productType = context.producttype.FirstOrDefault(pt => pt.producttype_id == typeId);
                                
                                if (productType != null)
                                {
                                    context.producttype.Remove(productType);
                                    context.SaveChanges();
                                    
                                    LoadProductTypes();
                                    textBox1.Clear();
                                    textBox2.Clear();
                                    
                                    MessageBox.Show("ลบประเภทสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("ไม่พบประเภทสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    // Load data for regular cell clicks (not button clicks)
                    else if (e.ColumnIndex < 2)
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        
                        if (row.Cells[0].Value != null)
                        {
                            textBox2.Text = row.Cells[0].Value.ToString();
                        }
                        
                        if (row.Cells[1].Value != null)
                        {
                            textBox1.Text = row.Cells[1].Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถดำเนินการได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อประเภท", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string newTypeName = textBox1.Text.Trim();

                // Check if product type name already exists
                var existingType = context.producttype.FirstOrDefault(pt => pt.producttype_name == newTypeName);
                if (existingType != null)
                {
                    MessageBox.Show("ชื่อประเภทนี้มีอยู่แล้ว", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                producttype newType = new producttype
                {
                    producttype_name = newTypeName
                };

                context.producttype.Add(newType);
                context.SaveChanges();

                LoadProductTypes();
                textBox1.Clear();
                textBox2.Clear();

                MessageBox.Show("เพิ่มประเภทสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("กรุณาเลือกประเภทสินค้าเพื่ออัพเดต", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(textBox1.Text))
                {
                    MessageBox.Show("กรุณาใส่ชื่อประเภท", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(textBox2.Text, out int typeId))
                {
                    MessageBox.Show("รหัสประเภทไม่ถูกต้อง", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var productType = context.producttype.FirstOrDefault(pt => pt.producttype_id == typeId);

                if (productType != null)
                {
                    string newTypeName = textBox1.Text.Trim();

                    // Check if product type name already exists (excluding current record)
                    var existingType = context.producttype.FirstOrDefault(pt => pt.producttype_name == newTypeName && pt.producttype_id != typeId);
                    if (existingType != null)
                    {
                        MessageBox.Show("ชื่อประเภทนี้มีอยู่แล้ว", "ข้อผิดพลาดการตรวจสอบ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    productType.producttype_name = newTypeName;
                    context.SaveChanges();

                    LoadProductTypes();
                    textBox1.Clear();
                    textBox2.Clear();

                    MessageBox.Show("อัพเดตประเภทสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ไม่พบประเภทสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Delete functionality moved to DataGridView button column
        }
    }
}
