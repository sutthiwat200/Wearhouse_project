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
            this.AddPDBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
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
            this.AddPDBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddPDBtn.Location = new System.Drawing.Point(12, 12);
            this.AddPDBtn.Name = "AddPDBtn";
            this.AddPDBtn.Size = new System.Drawing.Size(87, 27);
            this.AddPDBtn.TabIndex = 0;
            this.AddPDBtn.Text = "เพิ่มสินค้า";
            this.AddPDBtn.UseVisualStyleBackColor = true;
            this.AddPDBtn.Click += new System.EventHandler(this.BackBtn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
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
            this.panel1.Size = new System.Drawing.Size(800, 76);
            this.panel1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(588, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ค้นหา :";
            // 
            // buttonAllProducts
            // 
            this.buttonAllProducts.Location = new System.Drawing.Point(462, 43);
            this.buttonAllProducts.Name = "buttonAllProducts";
            this.buttonAllProducts.Size = new System.Drawing.Size(105, 27);
            this.buttonAllProducts.TabIndex = 7;
            this.buttonAllProducts.Text = "แสดงทั้งหมด";
            this.buttonAllProducts.UseVisualStyleBackColor = true;
            this.buttonAllProducts.Click += new System.EventHandler(this.ButtonAllProducts_Click);
            // 
            // buttonFilterType
            // 
            this.buttonFilterType.Location = new System.Drawing.Point(462, 9);
            this.buttonFilterType.Name = "buttonFilterType";
            this.buttonFilterType.Size = new System.Drawing.Size(105, 27);
            this.buttonFilterType.TabIndex = 6;
            this.buttonFilterType.Text = "กรองประเภท";
            this.buttonFilterType.UseVisualStyleBackColor = true;
            this.buttonFilterType.Click += new System.EventHandler(this.ButtonFilterType_Click);
            // 
            // buttonFilterPrice
            // 
            this.buttonFilterPrice.Location = new System.Drawing.Point(359, 43);
            this.buttonFilterPrice.Name = "buttonFilterPrice";
            this.buttonFilterPrice.Size = new System.Drawing.Size(97, 27);
            this.buttonFilterPrice.TabIndex = 6;
            this.buttonFilterPrice.Text = "กรองราคา";
            this.buttonFilterPrice.UseVisualStyleBackColor = true;
            this.buttonFilterPrice.Click += new System.EventHandler(this.ButtonFilterPrice_Click);
            // 
            // buttonFilterDate
            // 
            this.buttonFilterDate.Location = new System.Drawing.Point(359, 9);
            this.buttonFilterDate.Name = "buttonFilterDate";
            this.buttonFilterDate.Size = new System.Drawing.Size(97, 27);
            this.buttonFilterDate.TabIndex = 6;
            this.buttonFilterDate.Text = "กรองวันที่";
            this.buttonFilterDate.UseVisualStyleBackColor = true;
            this.buttonFilterDate.Click += new System.EventHandler(this.ButtonFilterDate_Click);
            // 
            // searchBox
            // 
            this.searchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchBox.Location = new System.Drawing.Point(640, 16);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(150, 20);
            this.searchBox.TabIndex = 1;
            // 
            // AddTypeBtn
            // 
            this.AddTypeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.AddTypeBtn.Location = new System.Drawing.Point(126, 12);
            this.AddTypeBtn.Name = "AddTypeBtn";
            this.AddTypeBtn.Size = new System.Drawing.Size(87, 27);
            this.AddTypeBtn.TabIndex = 3;
            this.AddTypeBtn.Text = "เพิ่มประเภท";
            this.AddTypeBtn.UseVisualStyleBackColor = true;
            this.AddTypeBtn.Click += new System.EventHandler(this.AddTypeBtn_Click);
            // 
            // showproductpanel
            // 
            this.showproductpanel.BackColor = System.Drawing.Color.Transparent;
            this.showproductpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showproductpanel.Location = new System.Drawing.Point(0, 76);
            this.showproductpanel.Name = "showproductpanel";
            this.showproductpanel.Size = new System.Drawing.Size(800, 374);
            this.showproductpanel.TabIndex = 2;
            // 
            // ProductPages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.showproductpanel);
            this.Controls.Add(this.panel1);
            this.Name = "ProductPages";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProductPages";
            this.Load += new System.EventHandler(this.ProductPages_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddPDBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel showproductpanel;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button AddTypeBtn;
        private System.Windows.Forms.Button buttonFilterDate;
        private System.Windows.Forms.Button buttonFilterPrice;
        private System.Windows.Forms.Button buttonFilterType;
        private System.Windows.Forms.Button buttonAllProducts;
        private System.Windows.Forms.Label label2;
    }
}