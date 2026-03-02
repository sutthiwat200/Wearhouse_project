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
    public partial class ResetPassword : Form
    {
        private string currentUsername = "";
        private List<verify_question> securityQuestions = new List<verify_question>();

        public ResetPassword()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            // ตั้งค่า TextBox รหัสผ่านให้ซ่อนอักษร
            textBoxNewPassword.UseSystemPasswordChar = true;
            textBoxConfirmPassword.UseSystemPasswordChar = true;
            checkBoxShowPassword.CheckedChanged += CheckBoxShowPassword_CheckedChanged;
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // เปลี่ยนการแสดงรหัสผ่านตามสถานะ checkbox
            bool showPassword = checkBoxShowPassword.Checked;
            textBoxNewPassword.UseSystemPasswordChar = !showPassword;
            textBoxConfirmPassword.UseSystemPasswordChar = !showPassword;
        }

        private void TextBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            // ตรวจสอบความแข็งแรงของรหัสผ่าน
            string password = textBoxNewPassword.Text;
            string strength = ValidatePasswordStrength(password);
            labelPasswordStrength.Text = "ความแข็งแรง: " + strength;
        }

        private void ButtonVerifyUsername_Click(object sender, EventArgs e)
        {
            // ลอจิกสำหรับตรวจสอบชื่อผู้ใช้
            // และแสดง 3 คำถามความปลอดภัยถ้าพบผู้ใช้
            if (string.IsNullOrWhiteSpace(textBoxUsername.Text))
            {
                labelStatusMessage.Text = "กรุณาใส่ชื่อผู้ใช้";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            try
            {
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    string username = textBoxUsername.Text.Trim();
                    
                    // ตรวจสอบว่าชื่อผู้ใช้มีอยู่ในฐานข้อมูลหรือไม่
                    var userExists = context.userPass.FirstOrDefault(u => u.user_name == username);
                    
                    if (userExists == null)
                    {
                        labelStatusMessage.Text = "ไม่พบชื่อผู้ใช้นี้ในระบบ";
                        labelStatusMessage.ForeColor = Color.Red;
                        return;
                    }

                    // บันทึกชื่อผู้ใช้ที่ได้รับการตรวจสอบ
                    currentUsername = username;

                    // ดึงคำถามความปลอดภัยจากฐานข้อมูล (3 คำถามแรก)
                    securityQuestions = context.verify_question
                        .Take(3)
                        .ToList();

                    if (securityQuestions.Count < 3)
                    {
                        labelStatusMessage.Text = "ไม่มีคำถามความปลอดภัยเพียงพอในระบบ";
                        labelStatusMessage.ForeColor = Color.Red;
                        return;
                    }

                    // แสดงคำถามในฟอร์ม - แทนข้อมูลที่เป็นค่า null หรือว่างเปล่าด้วยข้อความแจ้ง
                    string q1 = string.IsNullOrWhiteSpace(securityQuestions[0].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[0].verify_question1;
                    string q2 = string.IsNullOrWhiteSpace(securityQuestions[1].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[1].verify_question1;
                    string q3 = string.IsNullOrWhiteSpace(securityQuestions[2].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[2].verify_question1;

                    labelQuestionValue1.Text = q1;
                    labelQuestionValue2.Text = q2;
                    labelQuestionValue3.Text = q3;

                    // เปิดใช้งาน panel คำถามความปลอดภัย
                    panelSecurityQuestions.Enabled = true;
                    textBoxAnswer1.Focus();

                    // เคลียร์ข้อความแสดงสถานะและเปิดใช้งาน textbox
                    labelStatusMessage.Text = "";
                    textBoxAnswer1.Clear();
                    textBoxAnswer2.Clear();
                    textBoxAnswer3.Clear();
                }
            }
            catch (Exception ex)
            {
                labelStatusMessage.Text = "เกิดข้อผิดพลาด: " + ex.Message;
                labelStatusMessage.ForeColor = Color.Red;
            }
        }

        private void ButtonVerifyAnswers_Click(object sender, EventArgs e)
        {
            // ลอจิกสำหรับตรวจสอบคำตอบของ 3 คำถาม
            if (string.IsNullOrWhiteSpace(textBoxAnswer1.Text) ||
                string.IsNullOrWhiteSpace(textBoxAnswer2.Text) ||
                string.IsNullOrWhiteSpace(textBoxAnswer3.Text))
            {
                labelStatusMessage.Text = "กรุณากรอกคำตอบทั้ง 3 คำถาม";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            if (securityQuestions.Count < 3)
            {
                labelStatusMessage.Text = "ข้อมูลคำถามไม่ครบถ้วน";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            try
            {
                // ตรวจสอบคำตอบจากฐานข้อมูล
                string answer1 = textBoxAnswer1.Text.Trim();
                string answer2 = textBoxAnswer2.Text.Trim();
                string answer3 = textBoxAnswer3.Text.Trim();

                bool isAnswer1Correct = answer1.Equals(securityQuestions[0].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);
                bool isAnswer2Correct = answer2.Equals(securityQuestions[1].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);
                bool isAnswer3Correct = answer3.Equals(securityQuestions[2].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);

                // หากถูกต้องทั้ง 3 คำถาม ให้เปิด panelNewPassword
                if (isAnswer1Correct && isAnswer2Correct && isAnswer3Correct)
                {
                    labelStatusMessage.Text = "ตรวจสอบคำตอบสำเร็จ";
                    labelStatusMessage.ForeColor = Color.Green;
                    panelNewPassword.Enabled = true;
                    textBoxNewPassword.Focus();
                    panelSecurityQuestions.Enabled = false;
                }
                else
                {
                    labelStatusMessage.Text = "คำตอบไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง";
                    labelStatusMessage.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                labelStatusMessage.Text = "เกิดข้อผิดพลาด: " + ex.Message;
                labelStatusMessage.ForeColor = Color.Red;
            }
        }

        private void ButtonResetPassword_Click(object sender, EventArgs e)
        {
            // ลอจิกสำหรับรีเซ็ตรหัสผ่าน
            if (string.IsNullOrWhiteSpace(textBoxNewPassword.Text))
            {
                labelStatusMessage.Text = "กรุณาใส่รหัสผ่านใหม่";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxConfirmPassword.Text))
            {
                labelStatusMessage.Text = "กรุณายืนยันรหัสผ่าน";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            if (textBoxNewPassword.Text != textBoxConfirmPassword.Text)
            {
                labelStatusMessage.Text = "รหัสผ่านไม่ตรงกัน";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            // ตรวจสอบความแข็งแรงของรหัสผ่าน
            if (!IsPasswordStrong(textBoxNewPassword.Text))
            {
                labelStatusMessage.Text = "รหัสผ่านต้องมีความยาวอย่างน้อย 8 ตัว มีตัวอักษรพิมใหญ่ พิมเล็ก และตัวเลข";
                labelStatusMessage.ForeColor = Color.Red;
                return;
            }

            try
            {
                using (wearhouseEntities context = new wearhouseEntities())
                {
                    // ค้นหาผู้ใช้ในฐานข้อมูล
                    var user = context.userPass.FirstOrDefault(u => u.user_name == currentUsername);

                    if (user != null)
                    {
                        // อัปเดตรหัสผ่านในฐานข้อมูล
                        user.user_password = textBoxNewPassword.Text;
                        context.SaveChanges();

                        labelStatusMessage.Text = "รีเซ็ตรหัสผ่านสำเร็จ!";
                        labelStatusMessage.ForeColor = Color.Green;

                        // รีเซ็ตฟอร์มเพื่อใช้งานใหม่
                        Task.Delay(1500).ContinueWith(_ =>
                        {
                            this.Invoke((Action)(() =>
                            {
                                ClearForm();
                            }));
                        });
                    }
                    else
                    {
                        labelStatusMessage.Text = "ไม่พบผู้ใช้";
                        labelStatusMessage.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception ex)
            {
                labelStatusMessage.Text = "เกิดข้อผิดพลาด: " + ex.Message;
                labelStatusMessage.ForeColor = Color.Red;
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            // ปิดฟอร์ม
            ClearForm();
            this.Close();
        }

        private void ClearForm()
        {
            textBoxUsername.Clear();
            textBoxAnswer1.Clear();
            textBoxAnswer2.Clear();
            textBoxAnswer3.Clear();
            textBoxNewPassword.Clear();
            textBoxConfirmPassword.Clear();
            labelStatusMessage.Text = "";
            labelQuestionValue1.Text = "[คำถามที่ 1 จะแสดงที่นี่]";
            labelQuestionValue2.Text = "[คำถามที่ 2 จะแสดงที่นี่]";
            labelQuestionValue3.Text = "[คำถามที่ 3 จะแสดงที่นี่]";
            labelPasswordStrength.Text = "ความแข็งแรง:";
            panelSecurityQuestions.Enabled = false;
            panelNewPassword.Enabled = false;
            currentUsername = "";
            securityQuestions.Clear();
            textBoxUsername.Focus();
        }

        private void panelTitle_Paint(object sender, PaintEventArgs e)
        {
            // Event handler for panel title paint
        }

        private bool IsPasswordStrong(string password)
        {
            // ตรวจสอบความยาวของรหัสผ่าน (ต้องมีความยาวอย่างน้อย 8 ตัว)
            if (password.Length < 8)
                return false;
            
            // ตรวจสอบว่ารหัสผ่านมีตัวอักษรพิมใหญ่
            bool hasUpperCase = password.Any(c => char.IsUpper(c));
            // ตรวจสอบว่ารหัสผ่านมีตัวอักษรพิมเล็ก
            bool hasLowerCase = password.Any(c => char.IsLower(c));
            // ตรวจสอบว่ารหัสผ่านมีตัวเลข
            bool hasDigit = password.Any(c => char.IsDigit(c));

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        private string ValidatePasswordStrength(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "ว่าง";

            // ตรวจสอบความยาวของรหัสผ่าน
            if (password.Length < 8)
                return "ต่ำ ❌ (น้อยกว่า 8 ตัว)";

            bool hasUpperCase = password.Any(c => char.IsUpper(c));
            bool hasLowerCase = password.Any(c => char.IsLower(c));
            bool hasDigit = password.Any(c => char.IsDigit(c));

            int strengthScore = 0;
            if (hasUpperCase) strengthScore++;
            if (hasLowerCase) strengthScore++;
            if (hasDigit) strengthScore++;

            switch (strengthScore)
            {
                case 0:
                case 1:
                    return "ต่ำ ❌";
                case 2:
                    return "ปานกลาง ⚠️";
                case 3:
                    return "แข็งแรง ✓";
                default:
                    return "ว่าง";
            }
        }
    }
}
