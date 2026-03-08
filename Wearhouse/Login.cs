using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            // ตั้งค่า placeholder และการแสดงรหัสผ่านแบบมี placeholder logic
            string userPH = "กรุณาใส่ชื่อผู้ใช้...";
            string passPH = "กรุณาใส่รหัสผ่าน...";

            // ตั้ง placeholder เริ่มต้น
            UserNameTB.Text = userPH;
            UserNameTB.ForeColor = Color.Gray;
            PasswordTB.Text = passPH;
            PasswordTB.ForeColor = Color.Gray;
            PasswordTB.UseSystemPasswordChar = false; // ไม่ซ่อนตอนเป็น placeholder

            // event handlers สำหรับ placeholder
            UserNameTB.Enter += UserNameTB_Enter;
            UserNameTB.Leave += UserNameTB_Leave;
            PasswordTB.Enter += PasswordTB_Enter;
            PasswordTB.Leave += PasswordTB_Leave;

            // Center panel card in the form
            CenterCardPanel();

            // เพิ่ม responsive helper
            ResponsiveHelper.EnableResponsive(this);

            // Subscribe to resize event to keep card centered
            this.Resize += (s, ev) => CenterCardPanel();

            // กด Enter เพื่อเข้าสู่ระบบ
            this.AcceptButton = this.LoginBT;

            // ทำมุมโค้งให้การ์ด ปุ่ม และ subpanels
            int cardRadius = 16;
            int btnRadius = 22;
            int subRadius = 10;
            // กำหนด Region ตอนโหลดและเมื่อขนาดเปลี่ยน
            panelCard.Region = new Region(GetRoundedRect(panelCard.ClientRectangle, cardRadius));
            LoginBT.Region = new Region(GetRoundedRect(LoginBT.ClientRectangle, btnRadius));
            userPanel.Region = new Region(GetRoundedRect(userPanel.ClientRectangle, subRadius));
            passPanel.Region = new Region(GetRoundedRect(passPanel.ClientRectangle, subRadius));

            // set shadow regions and bring shadows behind
            panelCardShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,panelCardShadow.Width,panelCardShadow.Height), cardRadius));
            userPanelShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,userPanelShadow.Width,userPanelShadow.Height), subRadius));
            passPanelShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,passPanelShadow.Width,passPanelShadow.Height), subRadius));
            panelCardShadow.SendToBack();
            userPanelShadow.SendToBack();
            passPanelShadow.SendToBack();

            panelCard.SizeChanged += (s, ev) => { panelCard.Region = new Region(GetRoundedRect(panelCard.ClientRectangle, cardRadius)); };
            LoginBT.SizeChanged += (s, ev) => { LoginBT.Region = new Region(GetRoundedRect(LoginBT.ClientRectangle, btnRadius)); };
            userPanel.SizeChanged += (s, ev) => { userPanel.Region = new Region(GetRoundedRect(userPanel.ClientRectangle, subRadius)); };
            passPanel.SizeChanged += (s, ev) => { passPanel.Region = new Region(GetRoundedRect(passPanel.ClientRectangle, subRadius)); };
            panelCardShadow.SizeChanged += (s, ev) => { panelCardShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,panelCardShadow.Width,panelCardShadow.Height), cardRadius)); };
            userPanelShadow.SizeChanged += (s, ev) => { userPanelShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,userPanelShadow.Width,userPanelShadow.Height), subRadius)); };
            passPanelShadow.SizeChanged += (s, ev) => { passPanelShadow.Region = new Region(GetRoundedRect(new Rectangle(0,0,passPanelShadow.Width,passPanelShadow.Height), subRadius)); };

            // ตั้งค่าไอคอนดวงตาเริ่มต้น
            UpdateEyeIcon();
        }

        private void CenterCardPanel()
        {
            int cardWidth = panelCard.Width;
            int cardHeight = panelCard.Height;
            int x = (this.ClientSize.Width - cardWidth) / 2;
            int y = (this.ClientSize.Height - cardHeight) / 2;
            panelCard.Location = new Point(x, y);
            panelCardShadow.Location = new Point(x + 4, y + 4);
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            // (old checkbox handler removed) 
            // This method is no longer used.
        }

        private void LoginBT_Click(object sender, EventArgs e)
        {
            string user = UserNameTB.Text.Trim();
            string pass = PasswordTB.Text.Trim();

            // ตรวจสอบว่าผู้ใช้กรอกข้อมูลครบถ้วน (ตรวจสอบ placeholder ผ่าน ForeColor)
            if (UserNameTB.ForeColor == Color.Gray || PasswordTB.ForeColor == Color.Gray || string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
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
                        mainForm.WindowState = this.WindowState;
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

        // สร้าง GraphicsPath ของรูปสี่เหลี่ยมมุมโค้ง
        private GraphicsPath GetRoundedRect(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(rect.Location, new Size(diameter, diameter));

            // top left
            path.AddArc(arc, 180, 90);

            // top right
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        // Placeholder handlers
        private void UserNameTB_Enter(object sender, EventArgs e)
        {
            if (UserNameTB.ForeColor == Color.Gray)
            {
                UserNameTB.Text = string.Empty;
                UserNameTB.ForeColor = Color.Black;
            }
        }

        private void UserNameTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameTB.Text))
            {
                UserNameTB.Text = "กรุณาใส่ชื่อผู้ใช้...";
                UserNameTB.ForeColor = Color.Gray;
            }
        }

        private void PasswordTB_Enter(object sender, EventArgs e)
        {
            if (PasswordTB.ForeColor == Color.Gray)
            {
                PasswordTB.Text = string.Empty;
                PasswordTB.ForeColor = Color.Black;
                PasswordTB.UseSystemPasswordChar = true;
                UpdateEyeIcon();
            }
        }

        private void PasswordTB_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PasswordTB.Text))
            {
                PasswordTB.Text = "กรุณาใส่รหัสผ่าน...";
                PasswordTB.ForeColor = Color.Gray;
                PasswordTB.UseSystemPasswordChar = false;
            }
        }

        // Toggle password visibility via eye icon; ignore if currently showing placeholder
        private void eyePictureBox_Click(object sender, EventArgs e)
        {
            // ถ้าเป็น placeholder ให้ไม่ทำอะไร
            if (PasswordTB.ForeColor == Color.Gray) return;
            PasswordTB.UseSystemPasswordChar = !PasswordTB.UseSystemPasswordChar;
            // อัปเดตไอคอนของ eyePictureBox ตามสถานะ
            UpdateEyeIcon();
        }

        // อัปเดตไอคอนดวงตาตามสถานะการมองเห็น (visible = true -> eye open)
        private void UpdateEyeIcon()
        {
            bool visible = !PasswordTB.UseSystemPasswordChar && PasswordTB.ForeColor != Color.Gray;
            // สร้าง bitmap ไอคอนขนาดเดียวกับ picturebox
            Size sz = eyePictureBox.Size;
            if (sz.Width <= 0 || sz.Height <= 0) sz = new Size(20, 20);
            eyePictureBox.Image = GetEyeBitmap(visible, sz);
        }

        // สร้างไอคอนรูปดวงตาแบบง่ายๆ (open/closed)
        private Bitmap GetEyeBitmap(bool open, Size size)
        {
            Bitmap bmp = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.Clear(Color.Transparent);
                int w = size.Width;
                int h = size.Height;
                using (Pen pen = new Pen(Color.DarkGray, Math.Max(1, w / 12)))
                {
                    // draw eye outline as ellipse-like curve
                    Rectangle eyeRect = new Rectangle(2, h/4, w-4, h/2);
                    g.DrawEllipse(pen, eyeRect);
                    if (open)
                    {
                        // draw pupil
                        int pupilSize = Math.Max(2, Math.Min(w, h) / 4);
                        Rectangle pupil = new Rectangle((w - pupilSize)/2, (h - pupilSize)/2, pupilSize, pupilSize);
                        using (Brush b = new SolidBrush(Color.DarkGray)) g.FillEllipse(b, pupil);
                    }
                    else
                    {
                        // draw slash for closed eye
                        using (Pen slash = new Pen(Color.DarkGray, Math.Max(1, w / 10)))
                        {
                            g.DrawLine(slash, 2, h-3, w-2, 3);
                        }
                    }
                }
            }
            return bmp;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
