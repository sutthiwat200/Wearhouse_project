namespace Wearhouse
{
    partial class ProductPages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductPages));
            this.AddPDBtn = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.backBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAllProducts = new System.Windows.Forms.Button();
            this.buttonFilterType = new System.Windows.Forms.Button();
            this.buttonFilterPrice = new System.Windows.Forms.Button();
            this.buttonFilterDate = new System.Windows.Forms.Button();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.AddTypeBtn = new System.Windows.Forms.Button();
            this.showproductpanel = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddPDBtn
            // 
            this.AddPDBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(97)))), ((int)(((byte)(176)))));
            this.AddPDBtn.FlatAppearance.BorderSize = 0;
            this.AddPDBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddPDBtn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddPDBtn.ForeColor = System.Drawing.Color.White;
            this.AddPDBtn.Location = new System.Drawing.Point(18, 44);
            this.AddPDBtn.Name = "AddPDBtn";
            this.AddPDBtn.Size = new System.Drawing.Size(140, 40);
            this.AddPDBtn.TabIndex = 0;
            this.AddPDBtn.Text = "+ เพิ่มสินค้า";
            this.AddPDBtn.UseVisualStyleBackColor = false;
            this.AddPDBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(14, 8);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(120, 32);
            this.titleLabel.TabIndex = 9;
            this.titleLabel.Text = "หน้าสินค้า";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.backBtn);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.buttonAllProducts);
            this.panel1.Controls.Add(this.buttonFilterType);
            this.panel1.Controls.Add(this.buttonFilterPrice);
            this.panel1.Controls.Add(this.buttonFilterDate);
            this.panel1.Controls.Add(this.searchBox);
            this.panel1.Controls.Add(this.AddTypeBtn);
            this.panel1.Controls.Add(this.AddPDBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 96);
            this.panel1.TabIndex = 1;
            // 
            // backBtn
            // 
            this.backBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backBtn.BackColor = System.Drawing.Color.White;
            this.backBtn.FlatAppearance.BorderSize = 0;
            this.backBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.backBtn.Location = new System.Drawing.Point(762, 3);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(60, 32);
            this.backBtn.TabIndex = 13;
            this.backBtn.Text = "ย้อนกลับ";
            this.backBtn.UseVisualStyleBackColor = false;
            this.backBtn.Click += new System.EventHandler(this.BackBtn_Return_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label2.Location = new System.Drawing.Point(593, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "ค้นหา :";
            // 
            // buttonAllProducts
            // 
            this.buttonAllProducts.BackColor = System.Drawing.Color.White;
            this.buttonAllProducts.FlatAppearance.BorderSize = 0;
            this.buttonAllProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAllProducts.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonAllProducts.Location = new System.Drawing.Point(452, 52);
            this.buttonAllProducts.Name = "buttonAllProducts";
            this.buttonAllProducts.Size = new System.Drawing.Size(110, 32);
            this.buttonAllProducts.TabIndex = 7;
            this.buttonAllProducts.Text = "แสดงทั้งหมด";
            this.buttonAllProducts.UseVisualStyleBackColor = false;
            this.buttonAllProducts.Click += new System.EventHandler(this.ButtonAllProducts_Click);
            // 
            // buttonFilterType
            // 
            this.buttonFilterType.BackColor = System.Drawing.Color.White;
            this.buttonFilterType.FlatAppearance.BorderSize = 0;
            this.buttonFilterType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilterType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonFilterType.Location = new System.Drawing.Point(452, 9);
            this.buttonFilterType.Name = "buttonFilterType";
            this.buttonFilterType.Size = new System.Drawing.Size(110, 32);
            this.buttonFilterType.TabIndex = 6;
            this.buttonFilterType.Text = "กรองประเภท";
            this.buttonFilterType.UseVisualStyleBackColor = false;
            this.buttonFilterType.Click += new System.EventHandler(this.ButtonFilterType_Click);
            // 
            // buttonFilterPrice
            // 
            this.buttonFilterPrice.BackColor = System.Drawing.Color.White;
            this.buttonFilterPrice.FlatAppearance.BorderSize = 0;
            this.buttonFilterPrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilterPrice.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonFilterPrice.Location = new System.Drawing.Point(332, 52);
            this.buttonFilterPrice.Name = "buttonFilterPrice";
            this.buttonFilterPrice.Size = new System.Drawing.Size(110, 32);
            this.buttonFilterPrice.TabIndex = 6;
            this.buttonFilterPrice.Text = "กรองราคา";
            this.buttonFilterPrice.UseVisualStyleBackColor = false;
            this.buttonFilterPrice.Click += new System.EventHandler(this.ButtonFilterPrice_Click);
            // 
            // buttonFilterDate
            // 
            this.buttonFilterDate.BackColor = System.Drawing.Color.White;
            this.buttonFilterDate.FlatAppearance.BorderSize = 0;
            this.buttonFilterDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFilterDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonFilterDate.Location = new System.Drawing.Point(332, 9);
            this.buttonFilterDate.Name = "buttonFilterDate";
            this.buttonFilterDate.Size = new System.Drawing.Size(110, 32);
            this.buttonFilterDate.TabIndex = 6;
            this.buttonFilterDate.Text = "กรองวันที่";
            this.buttonFilterDate.UseVisualStyleBackColor = false;
            this.buttonFilterDate.Click += new System.EventHandler(this.ButtonFilterDate_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.searchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.searchBox.Location = new System.Drawing.Point(638, 44);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(160, 23);
            this.searchBox.TabIndex = 1;
            // 
            // AddTypeBtn
            // 
            this.AddTypeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(97)))), ((int)(((byte)(176)))));
            this.AddTypeBtn.FlatAppearance.BorderSize = 0;
            this.AddTypeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AddTypeBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.AddTypeBtn.ForeColor = System.Drawing.Color.White;
            this.AddTypeBtn.Location = new System.Drawing.Point(166, 44);
            this.AddTypeBtn.Name = "AddTypeBtn";
            this.AddTypeBtn.Size = new System.Drawing.Size(140, 40);
            this.AddTypeBtn.TabIndex = 3;
            this.AddTypeBtn.Text = "เพิ่มประเภท";
            this.AddTypeBtn.UseVisualStyleBackColor = false;
            this.AddTypeBtn.Click += new System.EventHandler(this.AddTypeBtn_Click);
            // 
            // showproductpanel
            // 
            this.showproductpanel.BackColor = System.Drawing.Color.Transparent;
            this.showproductpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showproductpanel.Location = new System.Drawing.Point(0, 96);
            this.showproductpanel.Name = "showproductpanel";
            this.showproductpanel.Size = new System.Drawing.Size(825, 515);
            this.showproductpanel.TabIndex = 2;
            this.showproductpanel.Paint += new System.Windows.Forms.PaintEventHandler(this.showproductpanel_Paint);
            // 
            // ProductPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 611);
            this.Controls.Add(this.showproductpanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ProductPages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "หน้าสินค้า";
            this.Load += new System.EventHandler(this.ProductPages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPDBtn;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel showproductpanel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button AddTypeBtn;
        private System.Windows.Forms.Button buttonFilterDate;
        private System.Windows.Forms.Button buttonFilterPrice;
        private System.Windows.Forms.Button buttonFilterType;
        private System.Windows.Forms.Button buttonAllProducts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button backBtn;
    }
}