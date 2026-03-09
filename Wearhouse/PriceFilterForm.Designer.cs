namespace Wearhouse
{
    partial class PriceFilterForm
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
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelMinPrice = new System.Windows.Forms.Label();
            this.textBoxMinPrice = new System.Windows.Forms.TextBox();
            this.labelMaxPrice = new System.Windows.Forms.Label();
            this.textBoxMaxPrice = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelCurrency1 = new System.Windows.Forms.Label();
            this.labelCurrency2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(107, 20);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "กรองตามราคา";
            // 
            // labelMinPrice
            // 
            this.labelMinPrice.AutoSize = true;
            this.labelMinPrice.Location = new System.Drawing.Point(12, 50);
            this.labelMinPrice.Name = "labelMinPrice";
            this.labelMinPrice.Size = new System.Drawing.Size(79, 13);
            this.labelMinPrice.TabIndex = 1;
            this.labelMinPrice.Text = "ราคาน้อยสุด:";
            // 
            // textBoxMinPrice
            // 
            this.textBoxMinPrice.Location = new System.Drawing.Point(100, 47);
            this.textBoxMinPrice.Name = "textBoxMinPrice";
            this.textBoxMinPrice.Size = new System.Drawing.Size(120, 20);
            this.textBoxMinPrice.TabIndex = 2;
            this.textBoxMinPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // labelMaxPrice
            // 
            this.labelMaxPrice.AutoSize = true;
            this.labelMaxPrice.Location = new System.Drawing.Point(12, 90);
            this.labelMaxPrice.Name = "labelMaxPrice";
            this.labelMaxPrice.Size = new System.Drawing.Size(79, 13);
            this.labelMaxPrice.TabIndex = 3;
            this.labelMaxPrice.Text = "ราคามากสุด:";
            // 
            // textBoxMaxPrice
            // 
            this.textBoxMaxPrice.Location = new System.Drawing.Point(100, 87);
            this.textBoxMaxPrice.Name = "textBoxMaxPrice";
            this.textBoxMaxPrice.Size = new System.Drawing.Size(120, 20);
            this.textBoxMaxPrice.TabIndex = 4;
            this.textBoxMaxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonOK.ForeColor = System.Drawing.Color.White;
            this.buttonOK.Location = new System.Drawing.Point(100, 130);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "ตกลง";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.Gray;
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(185, 130);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "ยกเลิก";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelCurrency1
            // 
            this.labelCurrency1.AutoSize = true;
            this.labelCurrency1.Location = new System.Drawing.Point(226, 50);
            this.labelCurrency1.Name = "labelCurrency1";
            this.labelCurrency1.Size = new System.Drawing.Size(37, 13);
            this.labelCurrency1.TabIndex = 7;
            this.labelCurrency1.Text = "บาท";
            // 
            // labelCurrency2
            // 
            this.labelCurrency2.AutoSize = true;
            this.labelCurrency2.Location = new System.Drawing.Point(226, 90);
            this.labelCurrency2.Name = "labelCurrency2";
            this.labelCurrency2.Size = new System.Drawing.Size(37, 13);
            this.labelCurrency2.TabIndex = 8;
            this.labelCurrency2.Text = "บาท";
            // 
            // PriceFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 165);
            this.Controls.Add(this.labelCurrency2);
            this.Controls.Add(this.labelCurrency1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxMaxPrice);
            this.Controls.Add(this.labelMaxPrice);
            this.Controls.Add(this.textBoxMinPrice);
            this.Controls.Add(this.labelMinPrice);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PriceFilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กรองตามราคา";
            this.Load += new System.EventHandler(this.PriceFilterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelMinPrice;
        private System.Windows.Forms.TextBox textBoxMinPrice;
        private System.Windows.Forms.Label labelMaxPrice;
        private System.Windows.Forms.TextBox textBoxMaxPrice;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelCurrency1;
        private System.Windows.Forms.Label labelCurrency2;
    }
}
