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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // ตั้งค่า TextBox รหัสผ่านให้ซ่อนอักษร
            PasswordTB.UseSystemPasswordChar = true;
            
            // เพิ่ม event handler สำหรับ checkbox
            checkBox1.CheckedChanged += CheckBox1_CheckedChanged;
            
            // เพิ่ม responsive helper
            ResponsiveHelper.EnableResponsive(this);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // เปลี่ยนการแสดงรหัสผ่านตามสถานะ checkbox
            PasswordTB.UseSystemPasswordChar = !checkBox1.Checked;
        }

        private void LoginBT_Click(object sender, EventArgs e)
        {
            string user = UserNameTB.Text.Trim();
            string pass = PasswordTB.Text.Trim();

            // ตรวจสอบว่าผู้ใช้กรอกข้อมูลครบถ้วน
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("กรุณากรอกชื่อผู้ใช้และรหัสผ่าน", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    // ตรวจสอบชื่อผู้ใช้และรหัสผ่านในฐานข้อมูล
                    var userAccount = context.userPass
                        .FirstOrDefault(u => u.user_name == user && u.user_password == pass);

                    if (userAccount != null)
                    {
                        // ซ่อนหน้า Login และเปิดหน้าหลัก
                        this.Hide();
                        Main mainForm = new Main();
                        mainForm.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("ชื่อผู้ใช้หรือรหัสผ่านไม่ถูกต้อง", "แจ้งเตือน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        PasswordTB.Clear();
                        UserNameTB.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเชื่อมต่อฐานข้อมูล: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();
            resetPassword.ShowDialog();
        }
    }
}
