namespace Wearhouse
{
    partial class StockIn
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
            this.components = new System.ComponentModel.Container();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelProductSelection = new System.Windows.Forms.Panel();
            this.labelSelectProduct = new System.Windows.Forms.Label();
            this.panelProductGrid = new System.Windows.Forms.Panel();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxLargeProduct = new System.Windows.Forms.PictureBox();
            this.labelSelectedProductName = new System.Windows.Forms.Label();
            this.labelSelectedProductPrice = new System.Windows.Forms.Label();
            this.panelInputForm = new System.Windows.Forms.Panel();
            this.groupBoxSupplierInfo = new System.Windows.Forms.GroupBox();
            this.labelSupplier = new System.Windows.Forms.Label();
            this.comboBoxSupplier = new System.Windows.Forms.ComboBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxQuantityInfo = new System.Windows.Forms.GroupBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.labelExpireDate = new System.Windows.Forms.Label();
            this.dateTimePickerExpireDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxReason = new System.Windows.Forms.GroupBox();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.transactionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wearhouseDataSet = new Wearhouse.wearhouseDataSet();
            this.transactionTableAdapter = new Wearhouse.wearhouseDataSetTableAdapters.transactionTableAdapter();
            this.panelProductSelection.SuspendLayout();
            this.panelProductGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLargeProduct)).BeginInit();
            this.panelInputForm.SuspendLayout();
            this.groupBoxSupplierInfo.SuspendLayout();
            this.groupBoxQuantityInfo.SuspendLayout();
            this.groupBoxReason.SuspendLayout();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wearhouseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTitle.Location = new System.Drawing.Point(20, 15);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(197, 44);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "รับสินค้าเข้า";
            // 
            // panelProductSelection
            // 
            this.panelProductSelection.BackColor = System.Drawing.Color.AliceBlue;
            this.panelProductSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductSelection.Controls.Add(this.labelSelectProduct);
            this.panelProductSelection.Controls.Add(this.panelProductGrid);
            this.panelProductSelection.Controls.Add(this.pictureBoxLargeProduct);
            this.panelProductSelection.Controls.Add(this.labelSelectedProductName);
            this.panelProductSelection.Controls.Add(this.labelSelectedProductPrice);
            this.panelProductSelection.Location = new System.Drawing.Point(20, 75);
            this.panelProductSelection.Name = "panelProductSelection";
            this.panelProductSelection.Size = new System.Drawing.Size(500, 390);
            this.panelProductSelection.TabIndex = 1;
            // 
            // labelSelectProduct
            // 
            this.labelSelectProduct.AutoSize = true;
            this.labelSelectProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelSelectProduct.Location = new System.Drawing.Point(10, 10);
            this.labelSelectProduct.Name = "labelSelectProduct";
            this.labelSelectProduct.Size = new System.Drawing.Size(92, 24);
            this.labelSelectProduct.TabIndex = 0;
            this.labelSelectProduct.Text = "เลือกสินค้า";
            // 
            // panelProductGrid
            // 
            this.panelProductGrid.AutoScroll = true;
            this.panelProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductGrid.Controls.Add(this.flowLayoutPanelProducts);
            this.panelProductGrid.Location = new System.Drawing.Point(10, 40);
            this.panelProductGrid.Name = "panelProductGrid";
            this.panelProductGrid.Size = new System.Drawing.Size(445, 164);
            this.panelProductGrid.TabIndex = 1;
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(443, 162);
            this.flowLayoutPanelProducts.TabIndex = 0;
            // 
            // pictureBoxLargeProduct
            // 
            this.pictureBoxLargeProduct.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxLargeProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLargeProduct.Location = new System.Drawing.Point(10, 214);
            this.pictureBoxLargeProduct.Name = "pictureBoxLargeProduct";
            this.pictureBoxLargeProduct.Size = new System.Drawing.Size(200, 170);
            this.pictureBoxLargeProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLargeProduct.TabIndex = 2;
            this.pictureBoxLargeProduct.TabStop = false;
            // 
            // labelSelectedProductName
            // 
            this.labelSelectedProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelSelectedProductName.ForeColor = System.Drawing.Color.DarkGreen;
            this.labelSelectedProductName.Location = new System.Drawing.Point(219, 216);
            this.labelSelectedProductName.Name = "labelSelectedProductName";
            this.labelSelectedProductName.Size = new System.Drawing.Size(270, 50);
            this.labelSelectedProductName.TabIndex = 3;
            this.labelSelectedProductName.Text = "ยังไม่เลือกสินค้า";
            // 
            // labelSelectedProductPrice
            // 
            this.labelSelectedProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelSelectedProductPrice.ForeColor = System.Drawing.Color.Red;
            this.labelSelectedProductPrice.Location = new System.Drawing.Point(216, 264);
            this.labelSelectedProductPrice.Name = "labelSelectedProductPrice";
            this.labelSelectedProductPrice.Size = new System.Drawing.Size(270, 35);
            this.labelSelectedProductPrice.TabIndex = 4;
            this.labelSelectedProductPrice.Text = "ราคา : -";
            // 
            // panelInputForm
            // 
            this.panelInputForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelInputForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputForm.Controls.Add(this.groupBoxSupplierInfo);
            this.panelInputForm.Controls.Add(this.groupBoxQuantityInfo);
            this.panelInputForm.Controls.Add(this.groupBoxReason);
            this.panelInputForm.Controls.Add(this.panelButtons);
            this.panelInputForm.Location = new System.Drawing.Point(530, 75);
            this.panelInputForm.Name = "panelInputForm";
            this.panelInputForm.Size = new System.Drawing.Size(250, 350);
            this.panelInputForm.TabIndex = 2;
            // 
            // groupBoxSupplierInfo
            // 
            this.groupBoxSupplierInfo.Controls.Add(this.labelSupplier);
            this.groupBoxSupplierInfo.Controls.Add(this.comboBoxSupplier);
            this.groupBoxSupplierInfo.Controls.Add(this.labelDate);
            this.groupBoxSupplierInfo.Controls.Add(this.dateTimePickerDate);
            this.groupBoxSupplierInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxSupplierInfo.Location = new System.Drawing.Point(10, 1);
            this.groupBoxSupplierInfo.Name = "groupBoxSupplierInfo";
            this.groupBoxSupplierInfo.Size = new System.Drawing.Size(230, 98);
            this.groupBoxSupplierInfo.TabIndex = 0;
            this.groupBoxSupplierInfo.TabStop = false;
            this.groupBoxSupplierInfo.Text = "ข้อมูลการรับสินค้า";
            // 
            // labelSupplier
            // 
            this.labelSupplier.AutoSize = true;
            this.labelSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelSupplier.Location = new System.Drawing.Point(10, 18);
            this.labelSupplier.Name = "labelSupplier";
            this.labelSupplier.Size = new System.Drawing.Size(87, 17);
            this.labelSupplier.TabIndex = 0;
            this.labelSupplier.Text = "ซัพพลายเออร์ :";
            // 
            // comboBoxSupplier
            // 
            this.comboBoxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.comboBoxSupplier.FormattingEnabled = true;
            this.comboBoxSupplier.Location = new System.Drawing.Point(10, 35);
            this.comboBoxSupplier.Name = "comboBoxSupplier";
            this.comboBoxSupplier.Size = new System.Drawing.Size(210, 24);
            this.comboBoxSupplier.TabIndex = 1;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelDate.Location = new System.Drawing.Point(10, 65);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(40, 17);
            this.labelDate.TabIndex = 2;
            this.labelDate.Text = "วันที่ :";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerDate.Location = new System.Drawing.Point(70, 64);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(150, 23);
            this.dateTimePickerDate.TabIndex = 3;
            // 
            // groupBoxQuantityInfo
            // 
            this.groupBoxQuantityInfo.Controls.Add(this.labelQuantity);
            this.groupBoxQuantityInfo.Controls.Add(this.textBoxQuantity);
            this.groupBoxQuantityInfo.Controls.Add(this.labelExpireDate);
            this.groupBoxQuantityInfo.Controls.Add(this.dateTimePickerExpireDate);
            this.groupBoxQuantityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxQuantityInfo.Location = new System.Drawing.Point(10, 97);
            this.groupBoxQuantityInfo.Name = "groupBoxQuantityInfo";
            this.groupBoxQuantityInfo.Size = new System.Drawing.Size(230, 116);
            this.groupBoxQuantityInfo.TabIndex = 1;
            this.groupBoxQuantityInfo.TabStop = false;
            this.groupBoxQuantityInfo.Text = "จำนวนและการหมดอายุ";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelQuantity.Location = new System.Drawing.Point(10, 21);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(54, 17);
            this.labelQuantity.TabIndex = 0;
            this.labelQuantity.Text = "จำนวน :";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.textBoxQuantity.Location = new System.Drawing.Point(10, 41);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(210, 29);
            this.textBoxQuantity.TabIndex = 1;
            this.textBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelExpireDate
            // 
            this.labelExpireDate.AutoSize = true;
            this.labelExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelExpireDate.Location = new System.Drawing.Point(10, 70);
            this.labelExpireDate.Name = "labelExpireDate";
            this.labelExpireDate.Size = new System.Drawing.Size(61, 17);
            this.labelExpireDate.TabIndex = 2;
            this.labelExpireDate.Text = "หมดอายุ :";
            // 
            // dateTimePickerExpireDate
            // 
            this.dateTimePickerExpireDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dateTimePickerExpireDate.Location = new System.Drawing.Point(10, 90);
            this.dateTimePickerExpireDate.Name = "dateTimePickerExpireDate";
            this.dateTimePickerExpireDate.Size = new System.Drawing.Size(210, 23);
            this.dateTimePickerExpireDate.TabIndex = 3;
            // 
            // groupBoxReason
            // 
            this.groupBoxReason.Controls.Add(this.textBoxReason);
            this.groupBoxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.groupBoxReason.Location = new System.Drawing.Point(10, 216);
            this.groupBoxReason.Name = "groupBoxReason";
            this.groupBoxReason.Size = new System.Drawing.Size(230, 77);
            this.groupBoxReason.TabIndex = 2;
            this.groupBoxReason.TabStop = false;
            this.groupBoxReason.Text = "หมายเหตุ";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.textBoxReason.Location = new System.Drawing.Point(10, 25);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(210, 45);
            this.textBoxReason.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonSubmit);
            this.panelButtons.Controls.Add(this.buttonClear);
            this.panelButtons.Location = new System.Drawing.Point(10, 295);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(230, 50);
            this.panelButtons.TabIndex = 3;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(5, 5);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(105, 40);
            this.buttonSubmit.TabIndex = 0;
            this.buttonSubmit.Text = "✓ บันทึก";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(120, 5);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(105, 40);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "✕ ล้างข้อมูล";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridViewTransactions.Location = new System.Drawing.Point(0, 471);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.RowHeadersVisible = false;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(800, 199);
            this.dataGridViewTransactions.TabIndex = 3;
            // 
            // transactionBindingSource
            // 
            this.transactionBindingSource.DataMember = "transaction";
            this.transactionBindingSource.DataSource = this.wearhouseDataSet;
            // 
            // wearhouseDataSet
            // 
            this.wearhouseDataSet.DataSetName = "wearhouseDataSet";
            this.wearhouseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // transactionTableAdapter
            // 
            this.transactionTableAdapter.ClearBeforeFill = true;
            // 
            // StockIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 670);
            this.Controls.Add(this.panelInputForm);
            this.Controls.Add(this.panelProductSelection);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Controls.Add(this.labelTitle);
            this.Name = "StockIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock In";
            this.Load += new System.EventHandler(this.StockIn_Load);
            this.panelProductSelection.ResumeLayout(false);
            this.panelProductSelection.PerformLayout();
            this.panelProductGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLargeProduct)).EndInit();
            this.panelInputForm.ResumeLayout(false);
            this.groupBoxSupplierInfo.ResumeLayout(false);
            this.groupBoxSupplierInfo.PerformLayout();
            this.groupBoxQuantityInfo.ResumeLayout(false);
            this.groupBoxQuantityInfo.PerformLayout();
            this.groupBoxReason.ResumeLayout(false);
            this.groupBoxReason.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.transactionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wearhouseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelProductSelection;
        private System.Windows.Forms.Panel panelInputForm;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        
        private System.Windows.Forms.Label labelSelectProduct;
        private System.Windows.Forms.Panel panelProductGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.PictureBox pictureBoxLargeProduct;
        private System.Windows.Forms.Label labelSelectedProductName;
        private System.Windows.Forms.Label labelSelectedProductPrice;
        
        private System.Windows.Forms.GroupBox groupBoxSupplierInfo;
        private System.Windows.Forms.Label labelSupplier;
        private System.Windows.Forms.ComboBox comboBoxSupplier;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        
        private System.Windows.Forms.GroupBox groupBoxQuantityInfo;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.Label labelExpireDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpireDate;
        
        private System.Windows.Forms.GroupBox groupBoxReason;
        private System.Windows.Forms.TextBox textBoxReason;
        
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonClear;
        
        private System.Windows.Forms.BindingSource transactionBindingSource;
        private wearhouseDataSet wearhouseDataSet;
        private wearhouseDataSetTableAdapters.transactionTableAdapter transactionTableAdapter;
    }
}