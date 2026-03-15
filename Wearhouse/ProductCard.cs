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
    public partial class ProductCard : UserControl
    {
        private int productId;

        // Event to notify parent form when product is deleted or updated
        public event EventHandler ProductDeleted;
        public event EventHandler ProductUpdated;

        public ProductCard()
        {
            InitializeComponent();
        }

        public void SetProductData(int id, string name, int quantity, decimal price, Image image)
        {
            productId = id;
            Idlabel.Text = id.ToString();
            Namelabel.Text = name;
            Quantitylabel.Text = quantity.ToString();
            Pricelabel.Text = price.ToString("C");
            if (image != null)
            {
                pictureBox1.Image = image;
            }
        }

        // Set product unit for display
        public void SetProductUnit(string unit)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(unit))
                {
                    Unitlabel.Text = unit;
                }
                else
                {
                    Unitlabel.Text = "pcs";
                }
            }
            catch { }
        }

        // Set receive date for display
        public void SetReceiveDate(DateTime receiveDate)
        {
            try
            {
                receiveDateLabel.Text = receiveDate.ToString("dd/MM/yyyy");
                receiveDateLabel.Visible = true;
            }
            catch { }
        }

        // Show or hide the badge (e.g., "New")
        public void SetIsNew(bool isNew, string text = "New")
        {
            try
            {
                badgeLabel.Text = text;
                badgeLabel.Visible = isNew;
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Edit button - open EditProduct form with current product ID
            EditProduct editForm = new EditProduct();
            editForm.LoadProductData(productId);
            editForm.ShowDialog();
            
            // Raise event to notify parent form to refresh
            ProductUpdated?.Invoke(this, EventArgs.Empty);
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {
            // Hook up the delete button click event
            delbtn.Click += Delbtn_Click;
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            
        }

        private void delbtn_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Confirm delete action
                var result = MessageBox.Show(
                    $"คุณแน่ใจหรือว่าต้องการลบ '{Namelabel.Text}'?",
                    "ยืนยันการลบ",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    // Delete product from database
                    using (wearhouseEntities db = new wearhouseEntities())
                    {
                        var productToDelete = db.product.FirstOrDefault(p => p.product_id == productId);

                        if (productToDelete != null)
                        {
                            // Check if there are related lots or transactions
                            var relatedLots = db.lot.Where(l => l.product_id == productId).ToList();
                            var relatedTransactions = db.transaction.Where(t => t.product_id == productId).ToList();

                            if (relatedLots.Count > 0 || relatedTransactions.Count > 0)
                            {
                                // Show detailed warning
                                string warningMessage = $"คำเตือน: สินค้านี้มีข้อมูลที่เกี่ยวข้อง:\n\n";
                                warningMessage += $"• ล็อต: {relatedLots.Count}\n";
                                warningMessage += $"• การทำธุรกรรม: {relatedTransactions.Count}\n\n";
                                warningMessage += "คุณต้องการลบสินค้านี้และข้อมูลที่เกี่ยวข้องทั้งหมดหรือไม่?\n";
                                warningMessage += "การกระทำนี้ไม่สามารถยกเลิกได้!";

                                var confirmResult = MessageBox.Show(
                                    warningMessage,
                                    "ลบพร้อมข้อมูลที่เกี่ยวข้อง",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning
                                );

                                if (confirmResult == DialogResult.No)
                                {
                                    return;
                                }

                                // Delete related transactions
                                foreach (var transaction in relatedTransactions)
                                {
                                    db.transaction.Remove(transaction);
                                }

                                // Delete related lots
                                foreach (var lot in relatedLots)
                                {
                                    db.lot.Remove(lot);
                                }
                            }

                            // Delete product
                            db.product.Remove(productToDelete);
                            db.SaveChanges();

                            MessageBox.Show("ลบสินค้าสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Raise event to notify parent form
                            ProductDeleted?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            MessageBox.Show("ไม่พบสินค้า", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการลบสินค้า: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
