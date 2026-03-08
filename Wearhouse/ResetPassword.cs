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
        private bool question1Expanded = false;
        private bool question2Expanded = false;
        private bool question3Expanded = false;
        private System.Windows.Forms.Label labelStatusMessage;

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
            
            // ตั้งค่าปุ่ม "ตรวจสอบคำตอบ" และ "รีเซ็ตรหัสผ่าน" ให้ disabled
            buttonVerifyAnswers.Enabled = false;
            panelStep3.Enabled = false;
        }

        private void TextBoxNewPassword_TextChanged(object sender, EventArgs e)
        {
            // ตรวจสอบความแข็งแรงของรหัสผ่าน
            string password = textBoxNewPassword.Text;
            UpdatePasswordStrengthBar(password);
        }

        private void UpdatePasswordStrengthBar(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                labelPasswordStrengthBar.BackColor = Color.LightGray;
                labelPasswordStrengthBar.Text = "";
                return;
            }

            int strengthScore = 0;
            bool hasUpperCase = password.Any(c => char.IsUpper(c));
            bool hasLowerCase = password.Any(c => char.IsLower(c));
            bool hasDigit = password.Any(c => char.IsDigit(c));

            if (password.Length >= 8) strengthScore++;
            if (hasUpperCase) strengthScore++;
            if (hasLowerCase) strengthScore++;
            if (hasDigit) strengthScore++;

            switch (strengthScore)
            {
                case 0:
                case 1:
                    labelPasswordStrengthBar.BackColor = Color.FromArgb(220, 53, 69); // Red
                    break;
                case 2:
                    labelPasswordStrengthBar.BackColor = Color.FromArgb(255, 193, 7); // Yellow
                    break;
                case 3:
                    labelPasswordStrengthBar.BackColor = Color.FromArgb(40, 167, 69); // Green
                    break;
                case 4:
                    labelPasswordStrengthBar.BackColor = Color.FromArgb(0, 128, 0); // Dark Green
                    break;
            }
        }

        private void ButtonVerifyUsername_Click(object sender, EventArgs e)
        {
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
                    
                    var userExists = context.userPass.FirstOrDefault(u => u.user_name == username);
                    
                    if (userExists == null)
                    {
                        labelStatusMessage.Text = "ไม่พบชื่อผู้ใช้นี้ในระบบ";
                        labelStatusMessage.ForeColor = Color.Red;
                        return;
                    }

                    currentUsername = username;

                    securityQuestions = context.verify_question
                        .Take(3)
                        .ToList();

                    if (securityQuestions.Count < 3)
                    {
                        labelStatusMessage.Text = "ไม่มีคำถามความปลอดภัยเพียงพอในระบบ";
                        labelStatusMessage.ForeColor = Color.Red;
                        return;
                    }

                    // Set question headers and values
                    string q1 = string.IsNullOrWhiteSpace(securityQuestions[0].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[0].verify_question1;
                    string q2 = string.IsNullOrWhiteSpace(securityQuestions[1].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[1].verify_question1;
                    string q3 = string.IsNullOrWhiteSpace(securityQuestions[2].verify_question1) 
                        ? "(ไม่มีข้อมูลคำถาม)" 
                        : securityQuestions[2].verify_question1;

                    labelQuestion1Header.Text = "คำถาม 1: " + q1;
                    labelQuestion2Header.Text = "คำถาม 2: " + q2;
                    labelQuestion3Header.Text = "คำถาม 3: " + q3;
                    
                    labelQuestionValue1.Text = q1;
                    labelQuestionValue2.Text = q2;
                    labelQuestionValue3.Text = q3;

                    // Enable security questions panels
                    panelQuestion1.Enabled = true;
                    panelQuestion2.Enabled = true;
                    panelQuestion3.Enabled = true;
                    buttonVerifyAnswers.Enabled = true;

                    // Clear inputs
                    labelStatusMessage.Text = "";
                    textBoxAnswer1.Clear();
                    textBoxAnswer2.Clear();
                    textBoxAnswer3.Clear();
                    
                    // Reset expanded state
                    question1Expanded = false;
                    question2Expanded = false;
                    question3Expanded = false;
                    CollapseAllQuestions();
                }
            }
            catch (Exception ex)
            {
                labelStatusMessage.Text = "เกิดข้อผิดพลาด: " + ex.Message;
                labelStatusMessage.ForeColor = Color.Red;
            }
        }

        private void ToggleQuestion(Panel questionPanel, Label toggleIcon, bool skipAnimation = false)
        {
            // Determine which question this is
            bool isQuestion1 = questionPanel == panelQuestion1;
            bool isQuestion2 = questionPanel == panelQuestion2;
            bool isQuestion3 = questionPanel == panelQuestion3;

            // Get current expanded state
            bool isExpanded = isQuestion1 ? question1Expanded : isQuestion2 ? question2Expanded : question3Expanded;

            if (isExpanded)
            {
                // Collapse
                CollapseQuestion(questionPanel, toggleIcon);
                if (isQuestion1) question1Expanded = false;
                else if (isQuestion2) question2Expanded = false;
                else if (isQuestion3) question3Expanded = false;
            }
            else
            {
                // Expand
                ExpandQuestion(questionPanel, toggleIcon);
                if (isQuestion1) question1Expanded = true;
                else if (isQuestion2) question2Expanded = true;
                else if (isQuestion3) question3Expanded = true;
            }
        }

        private void ExpandQuestion(Panel questionPanel, Label toggleIcon)
        {
            // Make hidden elements visible
            foreach (Control ctrl in questionPanel.Controls)
            {
                if (ctrl is Label && (ctrl.Name.Contains("QuestionValue") || ctrl.Name.Contains("AnswerInput")))
                    ctrl.Visible = true;
                if (ctrl is TextBox && ctrl.Name.Contains("Answer"))
                    ctrl.Visible = true;
            }

            // Adjust panel height
            questionPanel.Height = 110;
            toggleIcon.Text = "🔼";
        }

        private void CollapseQuestion(Panel questionPanel, Label toggleIcon)
        {
            // Hide details
            foreach (Control ctrl in questionPanel.Controls)
            {
                if (ctrl is Label && (ctrl.Name.Contains("QuestionValue") || ctrl.Name.Contains("AnswerInput")))
                    ctrl.Visible = false;
                if (ctrl is TextBox && ctrl.Name.Contains("Answer"))
                    ctrl.Visible = false;
            }

            // Reset panel height
            questionPanel.Height = 56;
            toggleIcon.Text = "🔽";
        }

        private void CollapseAllQuestions()
        {
            CollapseQuestion(panelQuestion1, labelQuestion1Icon);
            CollapseQuestion(panelQuestion2, labelQuestion2Icon);
            CollapseQuestion(panelQuestion3, labelQuestion3Icon);
        }

        private void ButtonVerifyAnswers_Click(object sender, EventArgs e)
        {

            try
            {
                string answer1 = textBoxAnswer1.Text.Trim();
                string answer2 = textBoxAnswer2.Text.Trim();
                string answer3 = textBoxAnswer3.Text.Trim();

                bool isAnswer1Correct = answer1.Equals(securityQuestions[0].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);
                bool isAnswer2Correct = answer2.Equals(securityQuestions[1].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);
                bool isAnswer3Correct = answer3.Equals(securityQuestions[2].verify_answer ?? "", StringComparison.OrdinalIgnoreCase);

                if (isAnswer1Correct || isAnswer2Correct || isAnswer3Correct)
                {
                    labelStatusMessage.Text = "ตรวจสอบคำตอบสำเร็จ";
                    labelStatusMessage.ForeColor = Color.Green;
                    panelStep3.Enabled = true;
                    textBoxNewPassword.Focus();
                    panelQuestion1.Enabled = false;
                    panelQuestion2.Enabled = false;
                    panelQuestion3.Enabled = false;
                    buttonVerifyAnswers.Enabled = false;
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
                    var user = context.userPass.FirstOrDefault(u => u.user_name == currentUsername);

                    if (user != null)
                    {
                        user.user_password = textBoxNewPassword.Text;
                        context.SaveChanges();

                        labelStatusMessage.Text = "รีเซ็ตรหัสผ่านสำเร็จ!";
                        labelStatusMessage.ForeColor = Color.Green;

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
            ClearForm();
            this.Close();
        }

        private void LabelQuestion1Icon_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion1, labelQuestion1Icon);
        }

        private void LabelQuestion1Header_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion1, labelQuestion1Icon);
        }

        private void LabelQuestion2Icon_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion2, labelQuestion2Icon);
        }

        private void LabelQuestion2Header_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion2, labelQuestion2Icon);
        }

        private void LabelQuestion3Icon_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion3, labelQuestion3Icon);
        }

        private void LabelQuestion3Header_Click(object sender, EventArgs e)
        {
            ToggleQuestion(panelQuestion3, labelQuestion3Icon);
        }

        private void CheckBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNewPassword.UseSystemPasswordChar = !checkBoxShowPassword.Checked;
        }

        private void CheckBoxShowConfirmPassword_CheckedChanged(object sender, EventArgs e)
        {
            textBoxConfirmPassword.UseSystemPasswordChar = !checkBoxShowConfirmPassword.Checked;
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
            labelPasswordStrengthBar.BackColor = Color.LightGray;
            panelQuestion1.Enabled = false;
            panelQuestion2.Enabled = false;
            panelQuestion3.Enabled = false;
            panelStep3.Enabled = false;
            buttonVerifyAnswers.Enabled = false;
            currentUsername = "";
            securityQuestions.Clear();
            textBoxUsername.Focus();
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8)
                return false;
            
            bool hasUpperCase = password.Any(c => char.IsUpper(c));
            bool hasLowerCase = password.Any(c => char.IsLower(c));
            bool hasDigit = password.Any(c => char.IsDigit(c));

            return hasUpperCase && hasLowerCase && hasDigit;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
