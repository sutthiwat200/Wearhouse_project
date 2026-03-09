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
    public partial class CrytalReportPages : Form
    {
        private DateTime filterFromDate;
        private DateTime filterToDate;
        private bool isFiltered = false;
        private string filterProductName = "";
        private string filterProductType = "";
        private string filterSupplierName = "";
        private int? filterTransType = null;
        wearhouseEntities db = new wearhouseEntities();

        public CrytalReportPages()
        {
            InitializeComponent();
        }

        private void CrytalReportPages_Load(object sender, EventArgs e)
        {
            try
            {
                // ตั้งค่าวันที่เริ่มต้น
                dateTimePickerTo.Value = DateTime.Now;
                dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                // โหลดข้อมูลเพื่อใช้ในการกรอง
                LoadFilterOptions();

                LoadCrystalReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFilterOptions()
        {
            try
            {
                // โหลดชื่อสินค้า
                comboBoxProductName.Items.Clear();
                comboBoxProductName.Items.Add("");
                var productNames = db.product.AsNoTracking().Select(p => p.product_name).Distinct().OrderBy(p => p).ToList();
                foreach (var name in productNames)
                {
                    comboBoxProductName.Items.Add(name);
                }
                comboBoxProductName.SelectedIndex = 0;

                // โหลดประเภทสินค้า
                comboBoxProductType.Items.Clear();
                comboBoxProductType.Items.Add("");
                var productTypes = db.producttype.AsNoTracking().Select(pt => pt.producttype_name).Distinct().OrderBy(pt => pt).ToList();
                foreach (var type in productTypes)
                {
                    comboBoxProductType.Items.Add(type);
                }
                comboBoxProductType.SelectedIndex = 0;

                // โหลดชื่อซัพพลายเออร์
                comboBoxSupplierName.Items.Clear();
                comboBoxSupplierName.Items.Add("");
                var supplierNames = db.supplier.AsNoTracking().Select(s => s.supplier_name).Distinct().OrderBy(s => s).ToList();
                foreach (var name in supplierNames)
                {
                    comboBoxSupplierName.Items.Add(name);
                }
                comboBoxSupplierName.SelectedIndex = 0;

                // โหลดประเภทการทำรายการ
                comboBoxTransType.Items.Clear();
                comboBoxTransType.Items.Add("");
                comboBoxTransType.Items.Add("รับเข้า");
                comboBoxTransType.Items.Add("เบิกออก");
                comboBoxTransType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCrystalReport()
        {
            try
            {
                List<transaction> transactions;

                if (isFiltered)
                {
                    DateTime toDatePlusOne = filterToDate.AddDays(1);

                    transactions = db.transaction
                        .AsNoTracking()
                        .Where(t => t.trans_date_time >= filterFromDate && t.trans_date_time < toDatePlusOne)
                        .OrderByDescending(t => t.trans_date_time)
                        .ToList();
                }
                else
                {
                    transactions = db.transaction
                        .AsNoTracking()
                        .OrderByDescending(t => t.trans_date_time)
                        .ToList();
                }

                // ประยุกต์ใช้ตัวกรองเพิ่มเติม (ชื่อสินค้า ประเภท ซัพพลายเออร์ ประเภทการทำรายการ)
                if (!string.IsNullOrEmpty(filterProductName))
                {
                    transactions = transactions.Where(t => t.product != null && t.product.product_name == filterProductName).ToList();
                }

                if (!string.IsNullOrEmpty(filterProductType))
                {
                    transactions = transactions.Where(t => t.product != null && t.product.producttype != null && t.product.producttype.producttype_name == filterProductType).ToList();
                }

                if (!string.IsNullOrEmpty(filterSupplierName))
                {
                    transactions = transactions.Where(t => t.supplier != null && t.supplier.supplier_name == filterSupplierName).ToList();
                }

                if (filterTransType.HasValue)
                {
                    transactions = transactions.Where(t => t.trans_type == filterTransType.Value).ToList();
                }

                if (transactions.Count == 0)
                {
                    MessageBox.Show("ไม่พบข้อมูลรายการสำหรับแสดง", "ข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    crystalReport11 = new CrystalReport1();
                    crystalReportViewer1.ReportSource = crystalReport11;
                    crystalReportViewer1.Refresh();
                    return;
                }

                // สร้าง DataSet พร้อม DataTables และ Relationships
                DataSet dsReport = ConvertTransactionToDataSet(transactions);
                
                // สร้าง Crystal Report ใหม่ทุกครั้ง
                crystalReport11 = new CrystalReport1();
                
                // ตรวจสอบจำนวนตาราง
                if (crystalReport11.Database.Tables.Count > 0)
                {
                    // ตั้ง DataSet สำหรับ Crystal Report
                    crystalReport11.SetDataSource(dsReport);
                    
                    // ตั้ง ReportSource และ refresh
                    crystalReportViewer1.ReportSource = crystalReport11;
                    crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show("ไม่พบตารางใน Crystal Report", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message + "\n\nStackTrace: " + ex.StackTrace, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataSet ConvertTransactionToDataSet(List<transaction> transactions)
        {
            DataSet ds = new DataSet();

            // สร้าง Supplier DataTable
            DataTable dtSupplier = new DataTable("supplier");
            dtSupplier.Columns.Add("supplier_id", typeof(int));
            dtSupplier.Columns.Add("supplier_name", typeof(string));
            dtSupplier.Columns.Add("supplier_address", typeof(string));
            dtSupplier.Columns.Add("supplier_phone", typeof(string));

            // สร้าง Product DataTable
            DataTable dtProduct = new DataTable("product");
            dtProduct.Columns.Add("product_id", typeof(int));
            dtProduct.Columns.Add("product_name", typeof(string));
            dtProduct.Columns.Add("producttype_id", typeof(int));
            dtProduct.Columns.Add("product_unit", typeof(string));
            dtProduct.Columns.Add("product_unitprice", typeof(decimal));

            // สร้าง Transaction DataTable
            DataTable dtTransaction = new DataTable("transaction");
            dtTransaction.Columns.Add("trans_id", typeof(int));
            dtTransaction.Columns.Add("product_id", typeof(int));
            dtTransaction.Columns.Add("supplier_id", typeof(int));
            dtTransaction.Columns.Add("product_name", typeof(string));
            dtTransaction.Columns.Add("supplier_name", typeof(string));
            dtTransaction.Columns.Add("trans_date_time", typeof(string));
            dtTransaction.Columns.Add("trans_type", typeof(string));
            dtTransaction.Columns.Add("trans_reason", typeof(string));
            dtTransaction.Columns.Add("trans_qty", typeof(int));
            dtTransaction.Columns.Add("trans_unit_price", typeof(decimal));
            dtTransaction.Columns.Add("trans_total_amount", typeof(decimal));

            // เก็บ product_id และ supplier_id ที่ได้เพื่อหลีกเลี่ยงการเพิ่มซ้ำ
            HashSet<int> addedProductIds = new HashSet<int>();
            HashSet<int> addedSupplierIds = new HashSet<int>();

            // เติมข้อมูล Transaction, Product และ Supplier
            foreach (var t in transactions)
            {
                // แปลง trans_type เป็นข้อความ
                string transTypeText = t.trans_type == 1 ? "รับเข้า" : "เบิกออก";

                // แปลงวันที่เป็นข้อความ
                string transDateString = t.trans_date_time.ToString("d/M/yyyy");

                // เพิ่มข้อมูล Supplier (ไม่ซ้ำ)
                if (t.supplier != null && !addedSupplierIds.Contains(t.supplier.supplier_id))
                {
                    dtSupplier.Rows.Add(
                        t.supplier.supplier_id,
                        t.supplier.supplier_name ?? "",
                        t.supplier.supplier_address ?? "",
                        t.supplier.supplier_phone ?? ""
                    );
                    addedSupplierIds.Add(t.supplier.supplier_id);
                }

                // เพิ่มข้อมูล Product (ไม่ซ้ำ)
                if (!addedProductIds.Contains(t.product_id) && t.product != null)
                {
                    dtProduct.Rows.Add(
                        t.product.product_id,
                        t.product.product_name ?? "",
                        t.product.producttype_id,
                        t.product.product_unit ?? "",
                        t.product.product_unitprice.HasValue ? t.product.product_unitprice.Value : 0m
                    );
                    addedProductIds.Add(t.product_id);
                }

                // เพิ่มข้อมูล Transaction
                // ถ้า supplier_id เป็น NULL ให้แสดง "ทั้งหมด"
                string supplierNameDisplay = (t.supplier_id.HasValue && t.supplier != null)
                    ? (t.supplier.supplier_name ?? "")
                    : "ทั้งหมด";

                dtTransaction.Rows.Add(
                    t.trans_id,
                    t.product_id,
                    t.supplier_id,
                    t.product != null ? t.product.product_name ?? "" : "",
                    supplierNameDisplay,
                    transDateString,
                    transTypeText,
                    t.trans_reason ?? "",
                    t.trans_qty ?? 0,
                    t.trans_unit_price ?? 0m,
                    t.trans_total_amount ?? 0m
                );
            }

            // เพิ่ม DataTables เข้า DataSet
            ds.Tables.Add(dtSupplier);
            ds.Tables.Add(dtProduct);
            ds.Tables.Add(dtTransaction);

            // สร้าง Relationships
            if (dtSupplier.Rows.Count > 0)
            {
                try
                {
                    DataColumn supplierParentCol = ds.Tables["supplier"].Columns["supplier_id"];
                    DataColumn supplierChildCol = ds.Tables["transaction"].Columns["supplier_id"];
                    if (supplierParentCol != null && supplierChildCol != null)
                    {
                        ds.Tables["supplier"].PrimaryKey = new[] { supplierParentCol };
                        DataRelation supplierRelation = new DataRelation("FK_Supplier_Transaction", supplierParentCol, supplierChildCol, false);
                        ds.Relations.Add(supplierRelation);
                    }
                }
                catch
                {
                    // ถ้าสร้าง relationship ไม่ได้ ก็ข้าม
                }
            }

            if (dtProduct.Rows.Count > 0)
            {
                try
                {
                    DataColumn productParentCol = ds.Tables["product"].Columns["product_id"];
                    DataColumn productChildCol = ds.Tables["transaction"].Columns["product_id"];
                    if (productParentCol != null && productChildCol != null)
                    {
                        ds.Tables["product"].PrimaryKey = new[] { productParentCol };
                        DataRelation productRelation = new DataRelation("FK_Product_Transaction", productParentCol, productChildCol, false);
                        ds.Relations.Add(productRelation);
                    }
                }
                catch
                {
                    // ถ้าสร้าง relationship ไม่ได้ ก็ข้าม
                }
            }

            return ds;
        }

        private DataTable ConvertTransactionToDataTable(List<transaction> transactions)
        {
            DataTable dt = new DataTable();
            
            // Define columns ให้ตรงกับ Crystal Report design
            dt.Columns.Add("trans_id", typeof(int));
            dt.Columns.Add("product_id", typeof(int));
            dt.Columns.Add("trans_date_time", typeof(DateTime));
            dt.Columns.Add("trans_type", typeof(int));
            dt.Columns.Add("trans_reason", typeof(string));
            dt.Columns.Add("trans_qty", typeof(int));
            dt.Columns.Add("trans_unit_price", typeof(decimal));
            dt.Columns.Add("trans_total_amount", typeof(decimal));
            
            // Add rows
            foreach (var t in transactions)
            {
                dt.Rows.Add(
                    t.trans_id,
                    t.product_id,
                    t.trans_date_time,
                    t.trans_type,
                    t.trans_reason ?? "",
                    t.trans_qty ?? 0,
                    t.trans_unit_price ?? 0m,
                    t.trans_total_amount ?? 0m
                );
            }
            
            return dt;
        }

        private void ButtonFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // ตรวจสอบว่าวันเริ่มต้นต้องน้อยกว่าหรือเท่ากับวันสิ้นสุด
                if (dateTimePickerFrom.Value > dateTimePickerTo.Value)
                {
                    MessageBox.Show("วันเริ่มต้นต้องน้อยกว่าหรือเท่ากับวันสิ้นสุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                filterFromDate = dateTimePickerFrom.Value.Date;
                filterToDate = dateTimePickerTo.Value.Date;
                
                // เก็บค่าตัวกรองอื่น ๆ
                filterProductName = comboBoxProductName.SelectedItem?.ToString() ?? "";
                filterProductType = comboBoxProductType.SelectedItem?.ToString() ?? "";
                filterSupplierName = comboBoxSupplierName.SelectedItem?.ToString() ?? "";
                
                // ตั้งค่า filterTransType
                var selectedTransType = comboBoxTransType.SelectedItem?.ToString() ?? "";
                if (selectedTransType == "รับเข้า")
                {
                    filterTransType = 1;
                }
                else if (selectedTransType == "เบิกออก")
                {
                    filterTransType = 2;
                }
                else
                {
                    filterTransType = null;
                }

                isFiltered = true;

                LoadCrystalReport();
                
                // แสดงข้อมูลการกรองที่ใช้
                string filterInfo = $"กรองข้อมูลจาก {filterFromDate:dd/MM/yyyy} ถึง {filterToDate:dd/MM/yyyy}";
                if (!string.IsNullOrEmpty(filterProductName))
                    filterInfo += $"\nชื่อสินค้า: {filterProductName}";
                if (!string.IsNullOrEmpty(filterProductType))
                    filterInfo += $"\nประเภท: {filterProductType}";
                if (!string.IsNullOrEmpty(filterSupplierName))
                    filterInfo += $"\nซัพพลายเออร์: {filterSupplierName}";
                if (filterTransType.HasValue)
                    filterInfo += $"\nประเภทการทำรายการ: {(filterTransType == 1 ? "รับเข้า" : "เบิกออก")}";

                MessageBox.Show(filterInfo, "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonClear_Click(object sender, EventArgs e)
        {
            try
            {
                // รีเซตค่า
                isFiltered = false;
                filterProductName = "";
                filterProductType = "";
                filterSupplierName = "";
                filterTransType = null;
                
                dateTimePickerTo.Value = DateTime.Now;
                dateTimePickerFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                
                comboBoxProductName.SelectedIndex = 0;
                comboBoxProductType.SelectedIndex = 0;
                comboBoxSupplierName.SelectedIndex = 0;
                comboBoxTransType.SelectedIndex = 0;

                LoadCrystalReport();
                
                MessageBox.Show("ล้างการกรองสำเร็จ", "สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ข้อผิดพลาด: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panelFilter_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
