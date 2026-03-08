using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Wearhouse
{
    public partial class ProductFilterDialog : Form
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public string SelectedProductType { get; set; }

        private List<string> productTypes = new List<string>();
        private Label labelDateRangeTitle;
        private Label labelStartDate;
        private DateTimePicker dateTimePickerStartDate;
        private Label labelEndDate;
        private DateTimePicker dateTimePickerEndDate;
        private Label labelPriceRangeTitle;
        private Label labelMinPrice;
        private TextBox textBoxMinPrice;
        private Label labelMaxPrice;
        private TextBox textBoxMaxPrice;
        private Label labelProductTypeTitle;
        private ComboBox comboBoxProductType;
        private Button buttonApplyFilter;
        private Button buttonClearFilters;
        private Button buttonCancel;

        public ProductFilterDialog(List<string> types)
        {
            productTypes = types ?? new List<string>();
            InitializeForm();
            ResponsiveHelper.EnableResponsive(this);
        }

        private void InitializeForm()
        {
            // Create controls
            labelDateRangeTitle = new Label();
            labelStartDate = new Label();
            dateTimePickerStartDate = new DateTimePicker();
            labelEndDate = new Label();
            dateTimePickerEndDate = new DateTimePicker();
            labelPriceRangeTitle = new Label();
            labelMinPrice = new Label();
            textBoxMinPrice = new TextBox();
            labelMaxPrice = new Label();
            textBoxMaxPrice = new TextBox();
            labelProductTypeTitle = new Label();
            comboBoxProductType = new ComboBox();
            buttonApplyFilter = new Button();
            buttonClearFilters = new Button();
            buttonCancel = new Button();

            // Set form properties
            this.Text = "ตัวกรองสินค้า";
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;

            // Date Range Section
            labelDateRangeTitle.AutoSize = true;
            labelDateRangeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            labelDateRangeTitle.Location = new System.Drawing.Point(20, 20);
            labelDateRangeTitle.Text = "กรองตามช่วงวันที่";

            labelStartDate.AutoSize = true;
            labelStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            labelStartDate.Location = new System.Drawing.Point(20, 55);
            labelStartDate.Text = "วันที่เริ่มต้น :";

            dateTimePickerStartDate.Location = new System.Drawing.Point(160, 50);
            dateTimePickerStartDate.Size = new System.Drawing.Size(310, 26);
            dateTimePickerStartDate.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            labelEndDate.AutoSize = true;
            labelEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            labelEndDate.Location = new System.Drawing.Point(20, 90);
            labelEndDate.Text = "วันที่สิ้นสุด :";

            dateTimePickerEndDate.Location = new System.Drawing.Point(160, 85);
            dateTimePickerEndDate.Size = new System.Drawing.Size(310, 26);
            dateTimePickerEndDate.Value = DateTime.Now;
            dateTimePickerEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            // Price Range Section
            labelPriceRangeTitle.AutoSize = true;
            labelPriceRangeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            labelPriceRangeTitle.Location = new System.Drawing.Point(20, 135);
            labelPriceRangeTitle.Text = "กรองตามช่วงราคา";

            labelMinPrice.AutoSize = true;
            labelMinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            labelMinPrice.Location = new System.Drawing.Point(20, 170);
            labelMinPrice.Text = "ราคาต่ำสุด :";

            textBoxMinPrice.Location = new System.Drawing.Point(160, 165);
            textBoxMinPrice.Size = new System.Drawing.Size(310, 26);
            textBoxMinPrice.Text = "0";
            textBoxMinPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            labelMaxPrice.AutoSize = true;
            labelMaxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            labelMaxPrice.Location = new System.Drawing.Point(20, 210);
            labelMaxPrice.Text = "ราคาสูงสุด :";

            textBoxMaxPrice.Location = new System.Drawing.Point(160, 205);
            textBoxMaxPrice.Size = new System.Drawing.Size(310, 26);
            textBoxMaxPrice.Text = "0";
            textBoxMaxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);

            // Product Type Section
            labelProductTypeTitle.AutoSize = true;
            labelProductTypeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            labelProductTypeTitle.Location = new System.Drawing.Point(20, 255);
            labelProductTypeTitle.Text = "กรองตามประเภท";

            comboBoxProductType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProductType.FormattingEnabled = true;
            comboBoxProductType.Location = new System.Drawing.Point(160, 290);
            comboBoxProductType.Size = new System.Drawing.Size(310, 28);
            comboBoxProductType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            comboBoxProductType.Items.Add("(ทั้งหมด)");
            foreach (var type in productTypes)
            {
                comboBoxProductType.Items.Add(type);
            }
            comboBoxProductType.SelectedIndex = 0;

            // Buttons
            buttonApplyFilter.Location = new System.Drawing.Point(250, 370);
            buttonApplyFilter.Size = new System.Drawing.Size(110, 40);
            buttonApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            buttonApplyFilter.Text = "ใช้ตัวกรอง";
            buttonApplyFilter.Click += ButtonApplyFilter_Click;
            this.AcceptButton = buttonApplyFilter;

            buttonClearFilters.Location = new System.Drawing.Point(20, 370);
            buttonClearFilters.Size = new System.Drawing.Size(110, 40);
            buttonClearFilters.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            buttonClearFilters.Text = "ล้างตัวกรอง";
            buttonClearFilters.Click += ButtonClearFilters_Click;

            buttonCancel.Location = new System.Drawing.Point(370, 370);
            buttonCancel.Size = new System.Drawing.Size(110, 40);
            buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            buttonCancel.Text = "ยกเลิก";
            buttonCancel.Click += ButtonCancel_Click;
            this.CancelButton = buttonCancel;

            // Add controls to form
            this.Controls.Add(labelDateRangeTitle);
            this.Controls.Add(labelStartDate);
            this.Controls.Add(dateTimePickerStartDate);
            this.Controls.Add(labelEndDate);
            this.Controls.Add(dateTimePickerEndDate);
            this.Controls.Add(labelPriceRangeTitle);
            this.Controls.Add(labelMinPrice);
            this.Controls.Add(textBoxMinPrice);
            this.Controls.Add(labelMaxPrice);
            this.Controls.Add(textBoxMaxPrice);
            this.Controls.Add(labelProductTypeTitle);
            this.Controls.Add(comboBoxProductType);
            this.Controls.Add(buttonApplyFilter);
            this.Controls.Add(buttonClearFilters);
            this.Controls.Add(buttonCancel);
        }

        private void ButtonApplyFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate and set date range
                StartDate = dateTimePickerStartDate.Value.Date;
                EndDate = dateTimePickerEndDate.Value.Date;

                if (StartDate > EndDate)
                {
                    MessageBox.Show("วันที่เริ่มต้นต้องน้อยกว่าวันที่สิ้นสุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate and set price range
                if (decimal.TryParse(textBoxMinPrice.Text, out decimal minPrice))
                {
                    MinPrice = minPrice >= 0 ? minPrice : (decimal?)null;
                }
                else
                {
                    MinPrice = null;
                }

                if (decimal.TryParse(textBoxMaxPrice.Text, out decimal maxPrice))
                {
                    MaxPrice = maxPrice > 0 ? maxPrice : (decimal?)null;
                }
                else
                {
                    MaxPrice = null;
                }

                if (MinPrice.HasValue && MaxPrice.HasValue && MinPrice > MaxPrice)
                {
                    MessageBox.Show("ราคาต่ำสุดต้องน้อยกว่าราคาสูงสุด", "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Set selected product type
                SelectedProductType = comboBoxProductType.SelectedItem?.ToString() == "(ทั้งหมด)" ? null : comboBoxProductType.SelectedItem?.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ButtonClearFilters_Click(object sender, EventArgs e)
        {
            StartDate = null;
            EndDate = null;
            MinPrice = null;
            MaxPrice = null;
            SelectedProductType = null;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductFilterDialog));
            this.SuspendLayout();
            // 
            // ProductFilterDialog
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductFilterDialog";
            this.ResumeLayout(false);

        }
    }
}
