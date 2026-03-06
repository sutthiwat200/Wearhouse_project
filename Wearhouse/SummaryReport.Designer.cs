namespace Wearhouse
{
    partial class SummaryReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SummaryReport));
            this.panelFilter = new System.Windows.Forms.Panel();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTransType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelSummary = new System.Windows.Forms.Panel();
            this.labelSummary = new System.Windows.Forms.Label();
            this.dataGridViewReport = new System.Windows.Forms.DataGridView();
            this.panelFilter.SuspendLayout();
            this.panelSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).BeginInit();
            this.SuspendLayout();
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFilter.Controls.Add(this.buttonExport);
            this.panelFilter.Controls.Add(this.buttonFilter);
            this.panelFilter.Controls.Add(this.label4);
            this.panelFilter.Controls.Add(this.comboBoxTransType);
            this.panelFilter.Controls.Add(this.label3);
            this.panelFilter.Controls.Add(this.comboBoxProduct);
            this.panelFilter.Controls.Add(this.label2);
            this.panelFilter.Controls.Add(this.dateTimePickerTo);
            this.panelFilter.Controls.Add(this.label1);
            this.panelFilter.Controls.Add(this.dateTimePickerFrom);
            this.panelFilter.Location = new System.Drawing.Point(12, 43);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(776, 130);
            this.panelFilter.TabIndex = 1;
            // 
            // buttonExport
            // 
            this.buttonExport.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonExport.ForeColor = System.Drawing.Color.White;
            this.buttonExport.Location = new System.Drawing.Point(680, 85);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(85, 35);
            this.buttonExport.TabIndex = 9;
            this.buttonExport.Text = "📊 ส่งออก";
            this.buttonExport.UseVisualStyleBackColor = false;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.ForestGreen;
            this.buttonFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Location = new System.Drawing.Point(580, 85);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(85, 35);
            this.buttonFilter.TabIndex = 8;
            this.buttonFilter.Text = "🔍 กรอง";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(310, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "ประเภท :";
            // 
            // comboBoxTransType
            // 
            this.comboBoxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxTransType.FormattingEnabled = true;
            this.comboBoxTransType.Items.AddRange(new object[] {
            "ทั้งหมด",
            "รับสินค้าเข้า",
            "เบิกสินค้าออก"});
            this.comboBoxTransType.Location = new System.Drawing.Point(385, 68);
            this.comboBoxTransType.Name = "comboBoxTransType";
            this.comboBoxTransType.Size = new System.Drawing.Size(140, 26);
            this.comboBoxTransType.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(15, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "สินค้า :";
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(81, 68);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(200, 26);
            this.comboBoxProduct.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(310, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "ถึงวันที่ :";
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePickerTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePickerTo.Location = new System.Drawing.Point(378, 15);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(190, 24);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "จากวันที่ :";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dateTimePickerFrom.Location = new System.Drawing.Point(91, 15);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(190, 24);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.labelTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(358, 31);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "📊 รายงานการเคลื่อนไหวสินค้า";
            // 
            // panelSummary
            // 
            this.panelSummary.BackColor = System.Drawing.Color.LightCyan;
            this.panelSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSummary.Controls.Add(this.labelSummary);
            this.panelSummary.Location = new System.Drawing.Point(12, 180);
            this.panelSummary.Name = "panelSummary";
            this.panelSummary.Size = new System.Drawing.Size(776, 60);
            this.panelSummary.TabIndex = 2;
            // 
            // labelSummary
            // 
            this.labelSummary.AutoSize = true;
            this.labelSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.labelSummary.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.labelSummary.Location = new System.Drawing.Point(15, 15);
            this.labelSummary.Name = "labelSummary";
            this.labelSummary.Size = new System.Drawing.Size(0, 18);
            this.labelSummary.TabIndex = 0;
            // 
            // dataGridViewReport
            // 
            this.dataGridViewReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dataGridViewReport.Location = new System.Drawing.Point(12, 246);
            this.dataGridViewReport.Name = "dataGridViewReport";
            this.dataGridViewReport.RowHeadersVisible = false;
            this.dataGridViewReport.Size = new System.Drawing.Size(776, 192);
            this.dataGridViewReport.TabIndex = 3;
            // 
            // SummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewReport);
            this.Controls.Add(this.panelSummary);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SummaryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายงานการเคลื่อนไหวสินค้า";
            this.Load += new System.EventHandler(this.SummaryReport_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.panelSummary.ResumeLayout(false);
            this.panelSummary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTransType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panelSummary;
        private System.Windows.Forms.Label labelSummary;
        private System.Windows.Forms.DataGridView dataGridViewReport;
    }
}