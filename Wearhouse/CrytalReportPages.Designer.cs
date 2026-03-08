namespace Wearhouse
{
    partial class CrytalReportPages
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crystalReport11 = new Wearhouse.CrystalReport1();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.labelFrom = new System.Windows.Forms.Label();
            this.labelTo = new System.Windows.Forms.Label();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.labelDateRange = new System.Windows.Forms.Label();
            this.labelProductName = new System.Windows.Forms.Label();
            this.comboBoxProductName = new System.Windows.Forms.ComboBox();
            this.labelProductType = new System.Windows.Forms.Label();
            this.comboBoxProductType = new System.Windows.Forms.ComboBox();
            this.labelTransType = new System.Windows.Forms.Label();
            this.comboBoxTransType = new System.Windows.Forms.ComboBox();
            this.panelFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 130);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 320);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.LightGray;
            this.panelFilter.Controls.Add(this.labelFrom);
            this.panelFilter.Controls.Add(this.labelTo);
            this.panelFilter.Controls.Add(this.dateTimePickerFrom);
            this.panelFilter.Controls.Add(this.dateTimePickerTo);
            this.panelFilter.Controls.Add(this.buttonFilter);
            this.panelFilter.Controls.Add(this.buttonClear);
            this.panelFilter.Controls.Add(this.labelDateRange);
            this.panelFilter.Controls.Add(this.labelProductName);
            this.panelFilter.Controls.Add(this.comboBoxProductName);
            this.panelFilter.Controls.Add(this.labelProductType);
            this.panelFilter.Controls.Add(this.comboBoxProductType);
            this.panelFilter.Controls.Add(this.labelTransType);
            this.panelFilter.Controls.Add(this.comboBoxTransType);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 0);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(800, 130);
            this.panelFilter.TabIndex = 1;
            this.panelFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelFilter_Paint);
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(10, 35);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(57, 13);
            this.labelFrom.TabIndex = 1;
            this.labelFrom.Text = "วันเริ่มต้น:";
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(210, 35);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(51, 13);
            this.labelTo.TabIndex = 3;
            this.labelTo.Text = "วันสิ้นสุด:";
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(75, 35);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(280, 35);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(120, 20);
            this.dateTimePickerTo.TabIndex = 4;
            // 
            // buttonFilter
            // 
            this.buttonFilter.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonFilter.ForeColor = System.Drawing.Color.White;
            this.buttonFilter.Location = new System.Drawing.Point(420, 100);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 5;
            this.buttonFilter.Text = "🔍 กรอง";
            this.buttonFilter.UseVisualStyleBackColor = false;
            this.buttonFilter.Click += new System.EventHandler(this.ButtonFilter_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Gray;
            this.buttonClear.ForeColor = System.Drawing.Color.White;
            this.buttonClear.Location = new System.Drawing.Point(510, 100);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 6;
            this.buttonClear.Text = "🔄 ล้าง";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // labelDateRange
            // 
            this.labelDateRange.AutoSize = true;
            this.labelDateRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.labelDateRange.Location = new System.Drawing.Point(10, 10);
            this.labelDateRange.Name = "labelDateRange";
            this.labelDateRange.Size = new System.Drawing.Size(97, 17);
            this.labelDateRange.TabIndex = 0;
            this.labelDateRange.Text = "กรองตามวันที่:";
            // 
            // labelProductName
            // 
            this.labelProductName.AutoSize = true;
            this.labelProductName.Location = new System.Drawing.Point(410, 35);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(49, 13);
            this.labelProductName.TabIndex = 7;
            this.labelProductName.Text = "ชื่อสินค้า:";
            // 
            // comboBoxProductName
            // 
            this.comboBoxProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductName.FormattingEnabled = true;
            this.comboBoxProductName.Location = new System.Drawing.Point(490, 35);
            this.comboBoxProductName.Name = "comboBoxProductName";
            this.comboBoxProductName.Size = new System.Drawing.Size(150, 21);
            this.comboBoxProductName.TabIndex = 8;
            // 
            // labelProductType
            // 
            this.labelProductType.AutoSize = true;
            this.labelProductType.Location = new System.Drawing.Point(410, 65);
            this.labelProductType.Name = "labelProductType";
            this.labelProductType.Size = new System.Drawing.Size(47, 13);
            this.labelProductType.TabIndex = 9;
            this.labelProductType.Text = "ประเภท:";
            // 
            // comboBoxProductType
            // 
            this.comboBoxProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProductType.FormattingEnabled = true;
            this.comboBoxProductType.Location = new System.Drawing.Point(490, 65);
            this.comboBoxProductType.Name = "comboBoxProductType";
            this.comboBoxProductType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxProductType.TabIndex = 10;
            // 
            // labelTransType
            // 
            this.labelTransType.AutoSize = true;
            this.labelTransType.Location = new System.Drawing.Point(10, 65);
            this.labelTransType.Name = "labelTransType";
            this.labelTransType.Size = new System.Drawing.Size(113, 13);
            this.labelTransType.TabIndex = 11;
            this.labelTransType.Text = "ประเภทการทำรายการ:";
            // 
            // comboBoxTransType
            // 
            this.comboBoxTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTransType.FormattingEnabled = true;
            this.comboBoxTransType.Location = new System.Drawing.Point(129, 62);
            this.comboBoxTransType.Name = "comboBoxTransType";
            this.comboBoxTransType.Size = new System.Drawing.Size(120, 21);
            this.comboBoxTransType.TabIndex = 12;
            // 
            // CrytalReportPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.panelFilter);
            this.Name = "CrytalReportPages";
            this.Text = "CrytalReportPages";
            this.Load += new System.EventHandler(this.CrytalReportPages_Load);
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private CrystalReport1 crystalReport11;
        private System.Windows.Forms.Panel panelFilter;
        private System.Windows.Forms.Label labelDateRange;
        private System.Windows.Forms.Label labelFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.ComboBox comboBoxProductName;
        private System.Windows.Forms.Label labelProductType;
        private System.Windows.Forms.ComboBox comboBoxProductType;
        private System.Windows.Forms.Label labelTransType;
        private System.Windows.Forms.ComboBox comboBoxTransType;
    }
}
