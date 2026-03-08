namespace Wearhouse
{
    partial class StockOut
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
        /// the contents of this method or the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockOut));
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelProductSelection = new System.Windows.Forms.Panel();
            this.labelSelectProduct = new System.Windows.Forms.Label();
            this.panelProductGrid = new System.Windows.Forms.Panel();
            this.flowLayoutPanelProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxLargeProduct = new System.Windows.Forms.PictureBox();
            this.labelSelectedProductName = new System.Windows.Forms.Label();
            this.labelSelectedProductPrice = new System.Windows.Forms.Label();
            this.labelCurrentStock = new System.Windows.Forms.Label();
            this.panelInputForm = new System.Windows.Forms.Panel();
            this.panelFormContent = new System.Windows.Forms.Panel();
            this.labelFormTitle = new System.Windows.Forms.Label();
            this.groupBoxDateInfo = new System.Windows.Forms.GroupBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.dateTimePickerDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxQuantityInfo = new System.Windows.Forms.GroupBox();
            this.labelQuantity = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.groupBoxReasonInfo = new System.Windows.Forms.GroupBox();
            this.textBoxReason = new System.Windows.Forms.TextBox();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelDataGrid = new System.Windows.Forms.Panel();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.panelProductSelection.SuspendLayout();
            this.panelProductGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLargeProduct)).BeginInit();
            this.panelInputForm.SuspendLayout();
            this.panelFormContent.SuspendLayout();
            this.groupBoxDateInfo.SuspendLayout();
            this.groupBoxQuantityInfo.SuspendLayout();
            this.groupBoxReasonInfo.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.BackColor = System.Drawing.Color.White;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 32F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.labelTitle.Location = new System.Drawing.Point(15, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(814, 50);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "เบิกสินค้าออก";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelProductSelection
            // 
            this.panelProductSelection.BackColor = System.Drawing.Color.MistyRose;
            this.panelProductSelection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductSelection.Controls.Add(this.labelSelectProduct);
            this.panelProductSelection.Controls.Add(this.panelProductGrid);
            this.panelProductSelection.Controls.Add(this.pictureBoxLargeProduct);
            this.panelProductSelection.Controls.Add(this.labelSelectedProductName);
            this.panelProductSelection.Controls.Add(this.labelSelectedProductPrice);
            this.panelProductSelection.Controls.Add(this.labelCurrentStock);
            this.panelProductSelection.Location = new System.Drawing.Point(20, 80);
            this.panelProductSelection.Name = "panelProductSelection";
            this.panelProductSelection.Size = new System.Drawing.Size(520, 420);
            this.panelProductSelection.TabIndex = 1;
            // 
            // labelSelectProduct
            // 
            this.labelSelectProduct.AutoSize = true;
            this.labelSelectProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.labelSelectProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold);
            this.labelSelectProduct.ForeColor = System.Drawing.Color.White;
            this.labelSelectProduct.Location = new System.Drawing.Point(10, 5);
            this.labelSelectProduct.Name = "labelSelectProduct";
            this.labelSelectProduct.Padding = new System.Windows.Forms.Padding(5, 8, 5, 8);
            this.labelSelectProduct.Size = new System.Drawing.Size(141, 38);
            this.labelSelectProduct.TabIndex = 0;
            this.labelSelectProduct.Text = "เลือกสินค้าเพื่อเบิก";
            // 
            // panelProductGrid
            // 
            this.panelProductGrid.AutoScroll = true;
            this.panelProductGrid.BackColor = System.Drawing.Color.White;
            this.panelProductGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProductGrid.Controls.Add(this.flowLayoutPanelProducts);
            this.panelProductGrid.Location = new System.Drawing.Point(10, 43);
            this.panelProductGrid.Name = "panelProductGrid";
            this.panelProductGrid.Size = new System.Drawing.Size(500, 160);
            this.panelProductGrid.TabIndex = 1;
            // 
            // flowLayoutPanelProducts
            // 
            this.flowLayoutPanelProducts.AutoScroll = true;
            this.flowLayoutPanelProducts.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProducts.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelProducts.Name = "flowLayoutPanelProducts";
            this.flowLayoutPanelProducts.Size = new System.Drawing.Size(498, 158);
            this.flowLayoutPanelProducts.TabIndex = 0;
            // 
            // pictureBoxLargeProduct
            // 
            this.pictureBoxLargeProduct.BackColor = System.Drawing.Color.LightGray;
            this.pictureBoxLargeProduct.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLargeProduct.Location = new System.Drawing.Point(10, 213);
            this.pictureBoxLargeProduct.Name = "pictureBoxLargeProduct";
            this.pictureBoxLargeProduct.Size = new System.Drawing.Size(200, 185);
            this.pictureBoxLargeProduct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLargeProduct.TabIndex = 2;
            this.pictureBoxLargeProduct.TabStop = false;
            // 
            // labelSelectedProductName
            // 
            this.labelSelectedProductName.BackColor = System.Drawing.Color.LightGray;
            this.labelSelectedProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelSelectedProductName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.labelSelectedProductName.Location = new System.Drawing.Point(216, 213);
            this.labelSelectedProductName.Name = "labelSelectedProductName";
            this.labelSelectedProductName.Size = new System.Drawing.Size(294, 60);
            this.labelSelectedProductName.TabIndex = 3;
            this.labelSelectedProductName.Text = "ยังไม่เลือกสินค้า";
            this.labelSelectedProductName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSelectedProductPrice
            // 
            this.labelSelectedProductPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.labelSelectedProductPrice.ForeColor = System.Drawing.Color.Red;
            this.labelSelectedProductPrice.Location = new System.Drawing.Point(216, 278);
            this.labelSelectedProductPrice.Name = "labelSelectedProductPrice";
            this.labelSelectedProductPrice.Size = new System.Drawing.Size(294, 50);
            this.labelSelectedProductPrice.TabIndex = 4;
            this.labelSelectedProductPrice.Text = "ราคา : -";
            this.labelSelectedProductPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCurrentStock
            // 
            this.labelCurrentStock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelCurrentStock.ForeColor = System.Drawing.Color.Green;
            this.labelCurrentStock.Location = new System.Drawing.Point(216, 328);
            this.labelCurrentStock.Name = "labelCurrentStock";
            this.labelCurrentStock.Size = new System.Drawing.Size(294, 50);
            this.labelCurrentStock.TabIndex = 5;
            this.labelCurrentStock.Text = "จำนวนคงเหลือ : -";
            this.labelCurrentStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelInputForm
            // 
            this.panelInputForm.BackColor = System.Drawing.Color.White;
            this.panelInputForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInputForm.Controls.Add(this.panelFormContent);
            this.panelInputForm.Location = new System.Drawing.Point(550, 80);
            this.panelInputForm.Name = "panelInputForm";
            this.panelInputForm.Size = new System.Drawing.Size(280, 420);
            this.panelInputForm.TabIndex = 2;
            // 
            // panelFormContent
            // 
            this.panelFormContent.BackColor = System.Drawing.Color.White;
            this.panelFormContent.Controls.Add(this.labelFormTitle);
            this.panelFormContent.Controls.Add(this.groupBoxDateInfo);
            this.panelFormContent.Controls.Add(this.groupBoxQuantityInfo);
            this.panelFormContent.Controls.Add(this.groupBoxReasonInfo);
            this.panelFormContent.Controls.Add(this.panelButtons);
            this.panelFormContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormContent.Location = new System.Drawing.Point(0, 0);
            this.panelFormContent.Name = "panelFormContent";
            this.panelFormContent.Size = new System.Drawing.Size(278, 418);
            this.panelFormContent.TabIndex = 0;
            // 
            // labelFormTitle
            // 
            this.labelFormTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(216)))), ((int)(((byte)(230)))));
            this.labelFormTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelFormTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.labelFormTitle.Location = new System.Drawing.Point(0, 0);
            this.labelFormTitle.Name = "labelFormTitle";
            this.labelFormTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.labelFormTitle.Size = new System.Drawing.Size(278, 30);
            this.labelFormTitle.TabIndex = 4;
            this.labelFormTitle.Text = "วันที่เบิกสินค้า";
            this.labelFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBoxDateInfo
            // 
            this.groupBoxDateInfo.Controls.Add(this.labelDate);
            this.groupBoxDateInfo.Controls.Add(this.dateTimePickerDate);
            this.groupBoxDateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxDateInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.groupBoxDateInfo.Location = new System.Drawing.Point(8, 35);
            this.groupBoxDateInfo.Name = "groupBoxDateInfo";
            this.groupBoxDateInfo.Size = new System.Drawing.Size(262, 70);
            this.groupBoxDateInfo.TabIndex = 0;
            this.groupBoxDateInfo.TabStop = false;
            this.groupBoxDateInfo.Text = "วันที่";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.labelDate.Location = new System.Drawing.Point(8, 18);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(34, 15);
            this.labelDate.TabIndex = 0;
            this.labelDate.Text = "วันที่ :";
            // 
            // dateTimePickerDate
            // 
            this.dateTimePickerDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dateTimePickerDate.Location = new System.Drawing.Point(8, 35);
            this.dateTimePickerDate.Name = "dateTimePickerDate";
            this.dateTimePickerDate.Size = new System.Drawing.Size(246, 21);
            this.dateTimePickerDate.TabIndex = 1;
            // 
            // groupBoxQuantityInfo
            // 
            this.groupBoxQuantityInfo.Controls.Add(this.labelQuantity);
            this.groupBoxQuantityInfo.Controls.Add(this.textBoxQuantity);
            this.groupBoxQuantityInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxQuantityInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.groupBoxQuantityInfo.Location = new System.Drawing.Point(8, 110);
            this.groupBoxQuantityInfo.Name = "groupBoxQuantityInfo";
            this.groupBoxQuantityInfo.Size = new System.Drawing.Size(262, 90);
            this.groupBoxQuantityInfo.TabIndex = 1;
            this.groupBoxQuantityInfo.TabStop = false;
            this.groupBoxQuantityInfo.Text = "จำนวน";
            // 
            // labelQuantity
            // 
            this.labelQuantity.AutoSize = true;
            this.labelQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labelQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.labelQuantity.Location = new System.Drawing.Point(8, 18);
            this.labelQuantity.Name = "labelQuantity";
            this.labelQuantity.Size = new System.Drawing.Size(46, 15);
            this.labelQuantity.TabIndex = 0;
            this.labelQuantity.Text = "จำนวน :";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxQuantity.Location = new System.Drawing.Point(8, 35);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(246, 26);
            this.textBoxQuantity.TabIndex = 1;
            this.textBoxQuantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxReasonInfo
            // 
            this.groupBoxReasonInfo.Controls.Add(this.textBoxReason);
            this.groupBoxReasonInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBoxReasonInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(55)))), ((int)(((byte)(109)))));
            this.groupBoxReasonInfo.Location = new System.Drawing.Point(8, 205);
            this.groupBoxReasonInfo.Name = "groupBoxReasonInfo";
            this.groupBoxReasonInfo.Size = new System.Drawing.Size(262, 100);
            this.groupBoxReasonInfo.TabIndex = 2;
            this.groupBoxReasonInfo.TabStop = false;
            this.groupBoxReasonInfo.Text = "เหตุผลการเบิก";
            // 
            // textBoxReason
            // 
            this.textBoxReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxReason.Location = new System.Drawing.Point(8, 20);
            this.textBoxReason.Multiline = true;
            this.textBoxReason.Name = "textBoxReason";
            this.textBoxReason.Size = new System.Drawing.Size(246, 74);
            this.textBoxReason.TabIndex = 0;
            // 
            // panelButtons
            // 
            this.panelButtons.Controls.Add(this.buttonSubmit);
            this.panelButtons.Controls.Add(this.buttonClear);
            this.panelButtons.Location = new System.Drawing.Point(8, 310);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(262, 50);
            this.panelButtons.TabIndex = 3;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.buttonSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(5, 5);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(120, 40);
            this.buttonSubmit.TabIndex = 0;
            this.buttonSubmit.Text = "✓ เบิกสินค้า";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Click += new System.EventHandler(this.ButtonSubmit_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(34)))));
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(137, 5);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(120, 40);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "✕ ล้างข้อมูล";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // panelDataGrid
            // 
            this.panelDataGrid.BackColor = System.Drawing.Color.White;
            this.panelDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDataGrid.Controls.Add(this.dataGridViewTransactions);
            this.panelDataGrid.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDataGrid.Location = new System.Drawing.Point(0, 505);
            this.panelDataGrid.Name = "panelDataGrid";
            this.panelDataGrid.Size = new System.Drawing.Size(850, 225);
            this.panelDataGrid.TabIndex = 4;
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AllowUserToAddRows = false;
            this.dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.dataGridViewTransactions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTransactions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(160)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransactions.EnableHeadersVisualStyles = false;
            this.dataGridViewTransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.dataGridViewTransactions.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.RowHeadersVisible = false;
            this.dataGridViewTransactions.RowHeadersWidth = 20;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(848, 223);
            this.dataGridViewTransactions.TabIndex = 3;
            // 
            // StockOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(850, 730);
            this.Controls.Add(this.panelDataGrid);
            this.Controls.Add(this.panelInputForm);
            this.Controls.Add(this.panelProductSelection);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เบิกสินค้าออก";
            this.Load += new System.EventHandler(this.StockOut_Load);
            this.panelProductSelection.ResumeLayout(false);
            this.panelProductSelection.PerformLayout();
            this.panelProductGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLargeProduct)).EndInit();
            this.panelInputForm.ResumeLayout(false);
            this.panelFormContent.ResumeLayout(false);
            this.groupBoxDateInfo.ResumeLayout(false);
            this.groupBoxDateInfo.PerformLayout();
            this.groupBoxQuantityInfo.ResumeLayout(false);
            this.groupBoxQuantityInfo.PerformLayout();
            this.groupBoxReasonInfo.ResumeLayout(false);
            this.groupBoxReasonInfo.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelDataGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelProductSelection;
        private System.Windows.Forms.Panel panelInputForm;
        private System.Windows.Forms.Panel panelFormContent;
        private System.Windows.Forms.Label labelFormTitle;
        private System.Windows.Forms.Panel panelDataGrid;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        
        private System.Windows.Forms.Label labelSelectProduct;
        private System.Windows.Forms.Panel panelProductGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProducts;
        private System.Windows.Forms.PictureBox pictureBoxLargeProduct;
        private System.Windows.Forms.Label labelSelectedProductName;
        private System.Windows.Forms.Label labelSelectedProductPrice;
        private System.Windows.Forms.Label labelCurrentStock;
        
        private System.Windows.Forms.GroupBox groupBoxDateInfo;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDate;
        
        private System.Windows.Forms.GroupBox groupBoxQuantityInfo;
        private System.Windows.Forms.Label labelQuantity;
        private System.Windows.Forms.TextBox textBoxQuantity;
        
        private System.Windows.Forms.GroupBox groupBoxReasonInfo;
        private System.Windows.Forms.TextBox textBoxReason;
        
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonClear;
    }
}