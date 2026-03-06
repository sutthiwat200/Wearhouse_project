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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void LoginFomr_Load(object sender, EventArgs e)
        {
            // Responsive UI is now handled by ResponsiveHelper
        }

        // Paint handlers to draw rounded gradient cards with subtle shadow
        private void DrawCard(PaintEventArgs e, Rectangle rect, Color startColor, Color endColor)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int radius = 18;
            // draw shadow
            Rectangle shadowRect = new Rectangle(rect.X + 6, rect.Y + 6, rect.Width, rect.Height);
            using (GraphicsPath shPath = GetRoundedRectPath(shadowRect, radius))
            using (SolidBrush sb = new SolidBrush(Color.FromArgb(25, 0, 0, 0)))
            {
                g.FillPath(sb, shPath);
            }

            // draw gradient card
            using (GraphicsPath path = GetRoundedRectPath(rect, radius))
            using (LinearGradientBrush br = new LinearGradientBrush(rect, startColor, endColor, 45F))
            {
                g.FillPath(br, path);
                // inner subtle highlight
                using (Pen pen = new Pen(Color.FromArgb(40, Color.White)))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetRoundedRectPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int dia = radius * 2;
            path.AddArc(rect.X, rect.Y, dia, dia, 180, 90);
            path.AddArc(rect.Right - dia, rect.Y, dia, dia, 270, 90);
            path.AddArc(rect.Right - dia, rect.Bottom - dia, dia, dia, 0, 90);
            path.AddArc(rect.X, rect.Bottom - dia, dia, dia, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DrawCard(e, new Rectangle(0, 0, panel1.Width - 1, panel1.Height - 1), Color.FromArgb(230, 245, 255), Color.FromArgb(200, 225, 255));
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            DrawCard(e, new Rectangle(0, 0, panel2.Width - 1, panel2.Height - 1), Color.FromArgb(220, 255, 235), Color.FromArgb(190, 245, 200));
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            DrawCard(e, new Rectangle(0, 0, panel3.Width - 1, panel3.Height - 1), Color.FromArgb(255, 240, 220), Color.FromArgb(255, 220, 180));
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            DrawCard(e, new Rectangle(0, 0, panel4.Width - 1, panel4.Height - 1), Color.FromArgb(250, 245, 230), Color.FromArgb(245, 230, 190));
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            DrawCard(e, new Rectangle(0, 0, panel5.Width - 1, panel5.Height - 1), Color.FromArgb(240, 230, 255), Color.FromArgb(220, 200, 250));
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProductPages productPages = new ProductPages();
            productPages.WindowState = this.WindowState;
            productPages.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            StockIn stockInForm = new StockIn();
            stockInForm.WindowState = this.WindowState;
            stockInForm.ShowDialog();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            StockOut stockOutForm = new StockOut();
            stockOutForm.WindowState = this.WindowState;
            stockOutForm.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SummaryReport summaryReportForm = new SummaryReport();
            summaryReportForm.WindowState = this.WindowState;
            summaryReportForm.ShowDialog();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            suppplierPage suppplier = new suppplierPage();
            suppplier.WindowState = this.WindowState;
            suppplier.ShowDialog();
        }
    }
}
