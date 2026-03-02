namespace Wearhouse
{
    partial class suppplierPage
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
            this.panelInput = new System.Windows.Forms.Panel();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSupplierName = new System.Windows.Forms.TextBox();
            this.labelId = new System.Windows.Forms.Label();
            this.textBoxSupplierId = new System.Windows.Forms.TextBox();
            this.dataGridViewSupplier = new System.Windows.Forms.DataGridView();
            this.supplieridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suppliernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplieraddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.supplierBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wearhouseDataSet = new Wearhouse.wearhouseDataSet();
            this.labelTitle = new System.Windows.Forms.Label();
            this.supplierTableAdapter = new Wearhouse.wearhouseDataSetTableAdapters.supplierTableAdapter();
            this.panelInput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wearhouseDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // panelInput
            // 
            this.panelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInput.Controls.Add(this.buttonClear);
            this.panelInput.Controls.Add(this.buttonAdd);
            this.panelInput.Controls.Add(this.label3);
            this.panelInput.Controls.Add(this.textBoxPhone);
            this.panelInput.Controls.Add(this.label2);
            this.panelInput.Controls.Add(this.textBoxAddress);
            this.panelInput.Controls.Add(this.label1);
            this.panelInput.Controls.Add(this.textBoxSupplierName);
            this.panelInput.Controls.Add(this.labelId);
            this.panelInput.Controls.Add(this.textBoxSupplierId);
            this.panelInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInput.Location = new System.Drawing.Point(0, 34);
            this.panelInput.Name = "panelInput";
            this.panelInput.Size = new System.Drawing.Size(800, 114);
            this.panelInput.TabIndex = 1;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(706, 8);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(60, 30);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "ล้าง";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(630, 8);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 30);
            this.buttonAdd.TabIndex = 8;
            this.buttonAdd.Text = "เพิ่ม";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(410, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "โทรศัพท์ :";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(468, 8);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(150, 20);
            this.textBoxPhone.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "ที่อยู่ :";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(72, 36);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(345, 40);
            this.textBoxAddress.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "ชื่อ :";
            // 
            // textBoxSupplierName
            // 
            this.textBoxSupplierName.Location = new System.Drawing.Point(205, 8);
            this.textBoxSupplierName.Name = "textBoxSupplierName";
            this.textBoxSupplierName.Size = new System.Drawing.Size(200, 20);
            this.textBoxSupplierName.TabIndex = 3;
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(15, 12);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(32, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "รหัส :";
            // 
            // textBoxSupplierId
            // 
            this.textBoxSupplierId.Enabled = false;
            this.textBoxSupplierId.Location = new System.Drawing.Point(60, 8);
            this.textBoxSupplierId.Name = "textBoxSupplierId";
            this.textBoxSupplierId.Size = new System.Drawing.Size(80, 20);
            this.textBoxSupplierId.TabIndex = 1;
            // 
            // dataGridViewSupplier
            // 
            this.dataGridViewSupplier.AllowUserToAddRows = false;
            this.dataGridViewSupplier.AutoGenerateColumns = false;
            this.dataGridViewSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.supplieridDataGridViewTextBoxColumn,
            this.suppliernameDataGridViewTextBoxColumn,
            this.supplieraddressDataGridViewTextBoxColumn,
            this.supplierphoneDataGridViewTextBoxColumn,
            this.Column1,
            this.Column2});
            this.dataGridViewSupplier.DataSource = this.supplierBindingSource;
            this.dataGridViewSupplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSupplier.Location = new System.Drawing.Point(0, 148);
            this.dataGridViewSupplier.Name = "dataGridViewSupplier";
            this.dataGridViewSupplier.RowHeadersVisible = false;
            this.dataGridViewSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSupplier.Size = new System.Drawing.Size(800, 302);
            this.dataGridViewSupplier.TabIndex = 2;
            this.dataGridViewSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewSupplier_CellClick);
            this.dataGridViewSupplier.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSupplier_CellContentClick);
            // 
            // supplieridDataGridViewTextBoxColumn
            // 
            this.supplieridDataGridViewTextBoxColumn.DataPropertyName = "supplier_id";
            this.supplieridDataGridViewTextBoxColumn.HeaderText = "รหัส";
            this.supplieridDataGridViewTextBoxColumn.Name = "supplieridDataGridViewTextBoxColumn";
            this.supplieridDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // suppliernameDataGridViewTextBoxColumn
            // 
            this.suppliernameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.suppliernameDataGridViewTextBoxColumn.DataPropertyName = "supplier_name";
            this.suppliernameDataGridViewTextBoxColumn.HeaderText = "ชื่อ";
            this.suppliernameDataGridViewTextBoxColumn.Name = "suppliernameDataGridViewTextBoxColumn";
            // 
            // supplieraddressDataGridViewTextBoxColumn
            // 
            this.supplieraddressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.supplieraddressDataGridViewTextBoxColumn.DataPropertyName = "supplier_address";
            this.supplieraddressDataGridViewTextBoxColumn.HeaderText = "ที่อยู่";
            this.supplieraddressDataGridViewTextBoxColumn.Name = "supplieraddressDataGridViewTextBoxColumn";
            // 
            // supplierphoneDataGridViewTextBoxColumn
            // 
            this.supplierphoneDataGridViewTextBoxColumn.DataPropertyName = "supplier_phone";
            this.supplierphoneDataGridViewTextBoxColumn.HeaderText = "โทรศัพท์";
            this.supplierphoneDataGridViewTextBoxColumn.Name = "supplierphoneDataGridViewTextBoxColumn";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "แก้ไข";
            this.Column1.Name = "Column1";
            this.Column1.Text = "แก้ไข";
            this.Column1.UseColumnTextForButtonValue = true;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ลบ";
            this.Column2.Name = "Column2";
            this.Column2.Text = "ลบ";
            this.Column2.UseColumnTextForButtonValue = true;
            this.Column2.Width = 70;
            // 
            // supplierBindingSource
            // 
            this.supplierBindingSource.DataMember = "supplier";
            this.supplierBindingSource.DataSource = this.wearhouseDataSet;
            // 
            // wearhouseDataSet
            // 
            this.wearhouseDataSet.DataSetName = "wearhouseDataSet";
            this.wearhouseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.labelTitle.Size = new System.Drawing.Size(207, 34);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "จัดการซัพพลายเออร์";
            // 
            // supplierTableAdapter
            // 
            this.supplierTableAdapter.ClearBeforeFill = true;
            // 
            // suppplierPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewSupplier);
            this.Controls.Add(this.panelInput);
            this.Controls.Add(this.labelTitle);
            this.Name = "suppplierPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Supplier Management";
            this.Load += new System.EventHandler(this.suppplierPage_Load);
            this.panelInput.ResumeLayout(false);
            this.panelInput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wearhouseDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInput;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.TextBox textBoxSupplierId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSupplierName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.DataGridView dataGridViewSupplier;
        private System.Windows.Forms.Label labelTitle;
        private wearhouseDataSet wearhouseDataSet;
        private System.Windows.Forms.BindingSource supplierBindingSource;
        private wearhouseDataSetTableAdapters.supplierTableAdapter supplierTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn suppliernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplieraddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierphoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn Column1;
        private System.Windows.Forms.DataGridViewButtonColumn Column2;
    }
}
