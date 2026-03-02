namespace Wearhouse
{
    partial class ResetPassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelUsername = new System.Windows.Forms.Panel();
            this.buttonVerifyUsername = new System.Windows.Forms.Button();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.panelSecurityQuestions = new System.Windows.Forms.Panel();
            this.labelQuestion1 = new System.Windows.Forms.Label();
            this.labelQuestionValue1 = new System.Windows.Forms.Label();
            this.labelAnswerInput1 = new System.Windows.Forms.Label();
            this.textBoxAnswer1 = new System.Windows.Forms.TextBox();
            this.labelQuestion2 = new System.Windows.Forms.Label();
            this.labelQuestionValue2 = new System.Windows.Forms.Label();
            this.labelAnswerInput2 = new System.Windows.Forms.Label();
            this.textBoxAnswer2 = new System.Windows.Forms.TextBox();
            this.labelQuestion3 = new System.Windows.Forms.Label();
            this.labelQuestionValue3 = new System.Windows.Forms.Label();
            this.labelAnswerInput3 = new System.Windows.Forms.Label();
            this.textBoxAnswer3 = new System.Windows.Forms.TextBox();
            this.buttonVerifyAnswers = new System.Windows.Forms.Button();
            this.panelNewPassword = new System.Windows.Forms.Panel();
            this.checkBoxShowPassword = new System.Windows.Forms.CheckBox();
            this.labelPasswordStrength = new System.Windows.Forms.Label();
            this.buttonResetPassword = new System.Windows.Forms.Button();
            this.textBoxConfirmPassword = new System.Windows.Forms.TextBox();
            this.labelConfirmPassword = new System.Windows.Forms.Label();
            this.textBoxNewPassword = new System.Windows.Forms.TextBox();
            this.labelNewPassword = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelStatusMessage = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            this.panelUsername.SuspendLayout();
            this.panelSecurityQuestions.SuspendLayout();
            this.panelNewPassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.LightBlue;
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(493, 50);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTitle_Paint);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 12);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(140, 25);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "รีเซ็ตรหัสผ่าน";
            // 
            // panelUsername
            // 
            this.panelUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelUsername.Controls.Add(this.buttonVerifyUsername);
            this.panelUsername.Controls.Add(this.textBoxUsername);
            this.panelUsername.Controls.Add(this.labelUsername);
            this.panelUsername.Location = new System.Drawing.Point(12, 60);
            this.panelUsername.Name = "panelUsername";
            this.panelUsername.Size = new System.Drawing.Size(469, 70);
            this.panelUsername.TabIndex = 1;
            // 
            // buttonVerifyUsername
            // 
            this.buttonVerifyUsername.Location = new System.Drawing.Point(338, 7);
            this.buttonVerifyUsername.Name = "buttonVerifyUsername";
            this.buttonVerifyUsername.Size = new System.Drawing.Size(120, 30);
            this.buttonVerifyUsername.TabIndex = 2;
            this.buttonVerifyUsername.Text = "ตรวจสอบ";
            this.buttonVerifyUsername.UseVisualStyleBackColor = true;
            this.buttonVerifyUsername.Click += new System.EventHandler(this.ButtonVerifyUsername_Click);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(72, 7);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(260, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(10, 10);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(46, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "ชื่อผู้ใช้ :";
            // 
            // panelSecurityQuestions
            // 
            this.panelSecurityQuestions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSecurityQuestions.Controls.Add(this.labelQuestion1);
            this.panelSecurityQuestions.Controls.Add(this.labelQuestionValue1);
            this.panelSecurityQuestions.Controls.Add(this.labelAnswerInput1);
            this.panelSecurityQuestions.Controls.Add(this.textBoxAnswer1);
            this.panelSecurityQuestions.Controls.Add(this.labelQuestion2);
            this.panelSecurityQuestions.Controls.Add(this.labelQuestionValue2);
            this.panelSecurityQuestions.Controls.Add(this.labelAnswerInput2);
            this.panelSecurityQuestions.Controls.Add(this.textBoxAnswer2);
            this.panelSecurityQuestions.Controls.Add(this.labelQuestion3);
            this.panelSecurityQuestions.Controls.Add(this.labelQuestionValue3);
            this.panelSecurityQuestions.Controls.Add(this.labelAnswerInput3);
            this.panelSecurityQuestions.Controls.Add(this.textBoxAnswer3);
            this.panelSecurityQuestions.Controls.Add(this.buttonVerifyAnswers);
            this.panelSecurityQuestions.Enabled = false;
            this.panelSecurityQuestions.Location = new System.Drawing.Point(12, 140);
            this.panelSecurityQuestions.Name = "panelSecurityQuestions";
            this.panelSecurityQuestions.Size = new System.Drawing.Size(469, 260);
            this.panelSecurityQuestions.TabIndex = 2;
            // 
            // labelQuestion1
            // 
            this.labelQuestion1.AutoSize = true;
            this.labelQuestion1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelQuestion1.Location = new System.Drawing.Point(10, 10);
            this.labelQuestion1.Name = "labelQuestion1";
            this.labelQuestion1.Size = new System.Drawing.Size(73, 17);
            this.labelQuestion1.TabIndex = 0;
            this.labelQuestion1.Text = "คำถาม 1 :";
            // 
            // labelQuestionValue1
            // 
            this.labelQuestionValue1.AutoSize = true;
            this.labelQuestionValue1.Location = new System.Drawing.Point(10, 32);
            this.labelQuestionValue1.Name = "labelQuestionValue1";
            this.labelQuestionValue1.Size = new System.Drawing.Size(108, 13);
            this.labelQuestionValue1.TabIndex = 1;
            this.labelQuestionValue1.Text = "[คำถาม 1 จะแสดงที่นี่]";
            // 
            // labelAnswerInput1
            // 
            this.labelAnswerInput1.AutoSize = true;
            this.labelAnswerInput1.Location = new System.Drawing.Point(10, 52);
            this.labelAnswerInput1.Name = "labelAnswerInput1";
            this.labelAnswerInput1.Size = new System.Drawing.Size(45, 13);
            this.labelAnswerInput1.TabIndex = 2;
            this.labelAnswerInput1.Text = "คำตอบ :";
            // 
            // textBoxAnswer1
            // 
            this.textBoxAnswer1.Location = new System.Drawing.Point(72, 48);
            this.textBoxAnswer1.Name = "textBoxAnswer1";
            this.textBoxAnswer1.Size = new System.Drawing.Size(385, 20);
            this.textBoxAnswer1.TabIndex = 3;
            // 
            // labelQuestion2
            // 
            this.labelQuestion2.AutoSize = true;
            this.labelQuestion2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelQuestion2.Location = new System.Drawing.Point(10, 80);
            this.labelQuestion2.Name = "labelQuestion2";
            this.labelQuestion2.Size = new System.Drawing.Size(73, 17);
            this.labelQuestion2.TabIndex = 4;
            this.labelQuestion2.Text = "คำถาม 2 :";
            // 
            // labelQuestionValue2
            // 
            this.labelQuestionValue2.AutoSize = true;
            this.labelQuestionValue2.Location = new System.Drawing.Point(10, 102);
            this.labelQuestionValue2.Name = "labelQuestionValue2";
            this.labelQuestionValue2.Size = new System.Drawing.Size(108, 13);
            this.labelQuestionValue2.TabIndex = 5;
            this.labelQuestionValue2.Text = "[คำถาม 2 จะแสดงที่นี่]";
            // 
            // labelAnswerInput2
            // 
            this.labelAnswerInput2.AutoSize = true;
            this.labelAnswerInput2.Location = new System.Drawing.Point(10, 122);
            this.labelAnswerInput2.Name = "labelAnswerInput2";
            this.labelAnswerInput2.Size = new System.Drawing.Size(45, 13);
            this.labelAnswerInput2.TabIndex = 6;
            this.labelAnswerInput2.Text = "คำตอบ :";
            // 
            // textBoxAnswer2
            // 
            this.textBoxAnswer2.Location = new System.Drawing.Point(72, 118);
            this.textBoxAnswer2.Name = "textBoxAnswer2";
            this.textBoxAnswer2.Size = new System.Drawing.Size(385, 20);
            this.textBoxAnswer2.TabIndex = 7;
            // 
            // labelQuestion3
            // 
            this.labelQuestion3.AutoSize = true;
            this.labelQuestion3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelQuestion3.Location = new System.Drawing.Point(10, 150);
            this.labelQuestion3.Name = "labelQuestion3";
            this.labelQuestion3.Size = new System.Drawing.Size(73, 17);
            this.labelQuestion3.TabIndex = 8;
            this.labelQuestion3.Text = "คำถาม 3 :";
            // 
            // labelQuestionValue3
            // 
            this.labelQuestionValue3.AutoSize = true;
            this.labelQuestionValue3.Location = new System.Drawing.Point(10, 172);
            this.labelQuestionValue3.Name = "labelQuestionValue3";
            this.labelQuestionValue3.Size = new System.Drawing.Size(108, 13);
            this.labelQuestionValue3.TabIndex = 9;
            this.labelQuestionValue3.Text = "[คำถาม 3 จะแสดงที่นี่]";
            // 
            // labelAnswerInput3
            // 
            this.labelAnswerInput3.AutoSize = true;
            this.labelAnswerInput3.Location = new System.Drawing.Point(10, 192);
            this.labelAnswerInput3.Name = "labelAnswerInput3";
            this.labelAnswerInput3.Size = new System.Drawing.Size(45, 13);
            this.labelAnswerInput3.TabIndex = 10;
            this.labelAnswerInput3.Text = "คำตอบ :";
            // 
            // textBoxAnswer3
            // 
            this.textBoxAnswer3.Location = new System.Drawing.Point(72, 188);
            this.textBoxAnswer3.Name = "textBoxAnswer3";
            this.textBoxAnswer3.Size = new System.Drawing.Size(385, 20);
            this.textBoxAnswer3.TabIndex = 11;
            // 
            // buttonVerifyAnswers
            // 
            this.buttonVerifyAnswers.Location = new System.Drawing.Point(338, 220);
            this.buttonVerifyAnswers.Name = "buttonVerifyAnswers";
            this.buttonVerifyAnswers.Size = new System.Drawing.Size(120, 30);
            this.buttonVerifyAnswers.TabIndex = 12;
            this.buttonVerifyAnswers.Text = "ตรวจสอบคำตอบ";
            this.buttonVerifyAnswers.UseVisualStyleBackColor = true;
            this.buttonVerifyAnswers.Click += new System.EventHandler(this.ButtonVerifyAnswers_Click);
            // 
            // panelNewPassword
            // 
            this.panelNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNewPassword.Controls.Add(this.checkBoxShowPassword);
            this.panelNewPassword.Controls.Add(this.labelPasswordStrength);
            this.panelNewPassword.Controls.Add(this.buttonResetPassword);
            this.panelNewPassword.Controls.Add(this.textBoxConfirmPassword);
            this.panelNewPassword.Controls.Add(this.labelConfirmPassword);
            this.panelNewPassword.Controls.Add(this.textBoxNewPassword);
            this.panelNewPassword.Controls.Add(this.labelNewPassword);
            this.panelNewPassword.Enabled = false;
            this.panelNewPassword.Location = new System.Drawing.Point(12, 410);
            this.panelNewPassword.Name = "panelNewPassword";
            this.panelNewPassword.Size = new System.Drawing.Size(469, 135);
            this.panelNewPassword.TabIndex = 3;
            // 
            // checkBoxShowPassword
            // 
            this.checkBoxShowPassword.AutoSize = true;
            this.checkBoxShowPassword.Location = new System.Drawing.Point(10, 65);
            this.checkBoxShowPassword.Name = "checkBoxShowPassword";
            this.checkBoxShowPassword.Size = new System.Drawing.Size(91, 17);
            this.checkBoxShowPassword.TabIndex = 5;
            this.checkBoxShowPassword.Text = "แสดงรหัสผ่าน";
            this.checkBoxShowPassword.UseVisualStyleBackColor = true;
            this.checkBoxShowPassword.CheckedChanged += new System.EventHandler(this.CheckBoxShowPassword_CheckedChanged);
            // 
            // labelPasswordStrength
            // 
            this.labelPasswordStrength.AutoSize = true;
            this.labelPasswordStrength.Location = new System.Drawing.Point(84, 95);
            this.labelPasswordStrength.Name = "labelPasswordStrength";
            this.labelPasswordStrength.Size = new System.Drawing.Size(73, 13);
            this.labelPasswordStrength.TabIndex = 4;
            this.labelPasswordStrength.Text = "ความแข็งแรง:";
            // 
            // buttonResetPassword
            // 
            this.buttonResetPassword.Location = new System.Drawing.Point(338, 90);
            this.buttonResetPassword.Name = "buttonResetPassword";
            this.buttonResetPassword.Size = new System.Drawing.Size(120, 30);
            this.buttonResetPassword.TabIndex = 4;
            this.buttonResetPassword.Text = "รีเซ็ตรหัสผ่าน";
            this.buttonResetPassword.UseVisualStyleBackColor = true;
            this.buttonResetPassword.Click += new System.EventHandler(this.ButtonResetPassword_Click);
            // 
            // textBoxConfirmPassword
            // 
            this.textBoxConfirmPassword.Location = new System.Drawing.Point(108, 41);
            this.textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            this.textBoxConfirmPassword.Size = new System.Drawing.Size(224, 20);
            this.textBoxConfirmPassword.TabIndex = 3;
            this.textBoxConfirmPassword.UseSystemPasswordChar = true;
            this.textBoxConfirmPassword.TextChanged += new System.EventHandler(this.TextBoxNewPassword_TextChanged);
            // 
            // labelConfirmPassword
            // 
            this.labelConfirmPassword.AutoSize = true;
            this.labelConfirmPassword.Location = new System.Drawing.Point(10, 45);
            this.labelConfirmPassword.Name = "labelConfirmPassword";
            this.labelConfirmPassword.Size = new System.Drawing.Size(82, 13);
            this.labelConfirmPassword.TabIndex = 2;
            this.labelConfirmPassword.Text = "ยืนยันรหัสผ่าน :";
            // 
            // textBoxNewPassword
            // 
            this.textBoxNewPassword.Location = new System.Drawing.Point(84, 11);
            this.textBoxNewPassword.Name = "textBoxNewPassword";
            this.textBoxNewPassword.Size = new System.Drawing.Size(248, 20);
            this.textBoxNewPassword.TabIndex = 1;
            this.textBoxNewPassword.UseSystemPasswordChar = true;
            this.textBoxNewPassword.TextChanged += new System.EventHandler(this.TextBoxNewPassword_TextChanged);
            // 
            // labelNewPassword
            // 
            this.labelNewPassword.AutoSize = true;
            this.labelNewPassword.Location = new System.Drawing.Point(10, 15);
            this.labelNewPassword.Name = "labelNewPassword";
            this.labelNewPassword.Size = new System.Drawing.Size(72, 13);
            this.labelNewPassword.TabIndex = 0;
            this.labelNewPassword.Text = "รหัสผ่านใหม่ :";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(361, 560);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(120, 30);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "ยกเลิก";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelStatusMessage
            // 
            this.labelStatusMessage.AutoSize = true;
            this.labelStatusMessage.ForeColor = System.Drawing.Color.Red;
            this.labelStatusMessage.Location = new System.Drawing.Point(15, 545);
            this.labelStatusMessage.Name = "labelStatusMessage";
            this.labelStatusMessage.Size = new System.Drawing.Size(0, 13);
            this.labelStatusMessage.TabIndex = 5;
            // 
            // ResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 610);
            this.Controls.Add(this.labelStatusMessage);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.panelNewPassword);
            this.Controls.Add(this.panelSecurityQuestions);
            this.Controls.Add(this.panelUsername);
            this.Controls.Add(this.panelTitle);
            this.Name = "ResetPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ResetPassword";
            this.Load += new System.EventHandler(this.ResetPassword_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.panelUsername.ResumeLayout(false);
            this.panelUsername.PerformLayout();
            this.panelSecurityQuestions.ResumeLayout(false);
            this.panelSecurityQuestions.PerformLayout();
            this.panelNewPassword.ResumeLayout(false);
            this.panelNewPassword.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelUsername;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonVerifyUsername;
        private System.Windows.Forms.Panel panelSecurityQuestions;
        private System.Windows.Forms.Label labelQuestion1;
        private System.Windows.Forms.Label labelQuestionValue1;
        private System.Windows.Forms.Label labelAnswerInput1;
        private System.Windows.Forms.TextBox textBoxAnswer1;
        private System.Windows.Forms.Label labelQuestion2;
        private System.Windows.Forms.Label labelQuestionValue2;
        private System.Windows.Forms.Label labelAnswerInput2;
        private System.Windows.Forms.TextBox textBoxAnswer2;
        private System.Windows.Forms.Label labelQuestion3;
        private System.Windows.Forms.Label labelQuestionValue3;
        private System.Windows.Forms.Label labelAnswerInput3;
        private System.Windows.Forms.TextBox textBoxAnswer3;
        private System.Windows.Forms.Button buttonVerifyAnswers;
        private System.Windows.Forms.Panel panelNewPassword;
        private System.Windows.Forms.Label labelNewPassword;
        private System.Windows.Forms.TextBox textBoxNewPassword;
        private System.Windows.Forms.Label labelConfirmPassword;
        private System.Windows.Forms.TextBox textBoxConfirmPassword;
        private System.Windows.Forms.Button buttonResetPassword;
        private System.Windows.Forms.CheckBox checkBoxShowPassword;
        private System.Windows.Forms.Label labelPasswordStrength;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelStatusMessage;
    }
}
