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
    public partial class SummaryReport : Form
    {
        public SummaryReport()
        {
            InitializeComponent();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void SummaryReport_Load(object sender, EventArgs e)
        {
            LoadProducts();
            SetDefaultDateRange();
            LoadReport();
        }

        private void LoadProducts()
        {
            try
            {
                comboBoxProduct.Items.Clear();
                comboBoxProduct.Items.Add(new ProductFilterItem { Id = 0, Name = "สินค้าทั้งหมด" });

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var products = context.product.ToList();

                    foreach (var product in products)
                    {
                        comboBoxProduct.Items.Add(new ProductFilterItem
                        {
                            Id = product.product_id,
                            Name = product.product_name
                        });
                    }

                    if (comboBoxProduct.Items.Count > 0)
                    {
                        comboBoxProduct.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดสินค้าได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultDateRange()
        {
            // Set date range to current month
            dateTimePickerTo.Value = DateTime.Now;
            dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void LoadReport()
        {
            try
            {
                DateTime fromDate = dateTimePickerFrom.Value.Date;
                DateTime toDate = dateTimePickerTo.Value.Date.AddDays(1);
                
                int productId = 0;
                if (comboBoxProduct.SelectedItem != null)
                {
                    productId = ((ProductFilterItem)comboBoxProduct.SelectedItem).Id;
                }

                int transType = 0;
                if (comboBoxTransType.SelectedIndex > 0)
                {
                    transType = comboBoxTransType.SelectedIndex;
                }

                using (wearhouseEntities context = new wearhouseEntities())
                {
                    var transactions = context.transaction
                        .Where(t => t.trans_date_time >= fromDate && t.trans_date_time < toDate)
                        .AsEnumerable();

                    if (productId > 0)
                    {
                        transactions = transactions.Where(t => t.product_id == productId);
                    }

                    if (transType > 0)
                    {
                        transactions = transactions.Where(t => t.trans_type == transType);
                    }

                    // Display individual transactions with dates
                    var reportData = transactions
                        .Join(context.product,
                            t => t.product_id,
                            p => p.product_id,
                            (t, p) => new { t, p })
                        .Select(x => new
                        {
                            รหัส = x.t.trans_id,
                            วันที่ = x.t.trans_date_time.ToString("dd/MM/yyyy HH:mm:ss"),
                            ประเภท = x.t.trans_type == 1 ? "รับสินค้าเข้า" : "เบิกสินค้าออก",
                            สินค้า = x.p.product_name,
                            จำนวน = x.t.trans_qty ?? 0,
                            ราคาต่อหน่วย = x.t.trans_unit_price ?? 0,
                            ราคารวม = x.t.trans_total_amount ?? 0,
                            หมายเหตุ = x.t.trans_reason ?? ""
                        })
                        .OrderByDescending(x => x.วันที่)
                        .ToList();

                    dataGridViewReport.DataSource = reportData;
                    dataGridViewReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // ตั้งค่า row height
                    dataGridViewReport.RowTemplate.Height = 35;
                    dataGridViewReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

                    foreach (DataGridViewColumn column in dataGridViewReport.Columns)
                    {
                        if (column.Name == "ราคาต่อหน่วย" || column.Name == "ราคารวม")
                        {
                            column.DefaultCellStyle.Format = "#,##0.00";
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        }
                        else if (column.Name == "จำนวน")
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        }
                        else if (column.Name == "หมายเหตุ" || column.Name == "สินค้า")
                        {
                            column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopLeft;
                        }
                    }

                    // Calculate and display summary
                    DisplaySummary(transactions.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถโหลดรายงานได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySummary(List<transaction> transactionList)
        {
            try
            {
                if (transactionList.Count == 0)
                {
                    labelSummary.Text = "ไม่พบข้อมูลรายการในช่วงเวลาที่เลือก";
                    return;
                }

                int totalStockIn = transactionList
                    .Where(t => t.trans_type == 1)
                    .Sum(t => t.trans_qty ?? 0);

                int totalStockOut = transactionList
                    .Where(t => t.trans_type == 2)
                    .Sum(t => t.trans_qty ?? 0);

                decimal totalAmountIn = transactionList
                    .Where(t => t.trans_type == 1)
                    .Sum(t => t.trans_total_amount ?? 0);

                decimal totalAmountOut = transactionList
                    .Where(t => t.trans_type == 2)
                    .Sum(t => t.trans_total_amount ?? 0);

                int netQuantity = totalStockIn - totalStockOut;

                labelSummary.Text = string.Format(
                    "📥 รับเข้า: {0} ชิ้น ({1:N2} บาท)  |  📤 เบิกออก: {2} ชิ้น ({3:N2} บาท)  |  📈 คงเหลือ: {4} ชิ้น  |  📊 รวมรายการ: {5} รายการ",
                    totalStockIn,
                    totalAmountIn,
                    totalStockOut,
                    totalAmountOut,
                    netQuantity,
                    transactionList.Count
                );
            }
            catch (Exception ex)
            {
                labelSummary.Text = $"ข้อผิดพลาด: {ex.Message}";
            }
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV File (*.csv)|*.csv|Excel File (*.xlsx)|*.xlsx";
                saveFileDialog.DefaultExt = "csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName.EndsWith(".csv"))
                    {
                        ExportToCSV(saveFileDialog.FileName);
                    }
                    else
                    {
                        ExportToExcel(saveFileDialog.FileName);
                    }

                    MessageBox.Show("ส่งออกรายงานสำเร็จ!", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถส่งออกรายงานได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false, Encoding.UTF8))
            {
                // Write header
                writer.WriteLine("Product Movement Report");
                writer.WriteLine($"From: {dateTimePickerFrom.Value:yyyy-MM-dd} To: {dateTimePickerTo.Value:yyyy-MM-dd}");
                writer.WriteLine("");
                writer.WriteLine(labelSummary.Text);
                writer.WriteLine("");

                // Write column headers
                writer.WriteLine("Type,Product ID,Total Quantity,Total Amount,Transaction Count");

                // Write data
                if (dataGridViewReport.DataSource != null)
                {
                    foreach (DataGridViewRow row in dataGridViewReport.Rows)
                    {
                        writer.WriteLine($"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value},{row.Cells[3].Value},{row.Cells[4].Value}");
                    }
                }
            }
        }

        private void ExportToExcel(string filePath)
        {
            try
            {
                // Simple Excel export using Office Open XML format
                // For this implementation, we'll use a library-free approach with CSV
                ExportToCSV(filePath.Replace(".xlsx", ".csv"));
                MessageBox.Show("ส่งออก Excel เป็นรูปแบบ CSV", "ข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถส่งออก Excel ได้: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private class ProductFilterItem
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public override string ToString()
            {
                return Name;
            }
        }
    }
}
