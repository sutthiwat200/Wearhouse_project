namespace Wearhouse
{
    partial class ProductCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Unitlabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.delbtn = new System.Windows.Forms.Button();
            this.editbtn = new System.Windows.Forms.Button();
            this.Pricelabel = new System.Windows.Forms.Label();
            this.Quantitylabel = new System.Windows.Forms.Label();
            this.Namelabel = new System.Windows.Forms.Label();
            this.Idlabel = new System.Windows.Forms.Label();
            this.receiveDateLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.badgeLabel = new System.Windows.Forms.Label();
            this.panelShadow.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panelShadow.Controls.Add(this.panel1);
            this.panelShadow.Location = new System.Drawing.Point(6, 6);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(238, 262);
            this.panelShadow.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.Unitlabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.delbtn);
            this.panel1.Controls.Add(this.editbtn);
            this.panel1.Controls.Add(this.Pricelabel);
            this.panel1.Controls.Add(this.Quantitylabel);
            this.panel1.Controls.Add(this.Namelabel);
            this.panel1.Controls.Add(this.Idlabel);
            this.panel1.Controls.Add(this.receiveDateLabel);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.badgeLabel);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(238, 262);
            this.panel1.TabIndex = 1;
            // 
            // Unitlabel
            // 
            this.Unitlabel.AutoSize = true;
            this.Unitlabel.Location = new System.Drawing.Point(115, 179);
            this.Unitlabel.Name = "Unitlabel";
            this.Unitlabel.Size = new System.Drawing.Size(24, 13);
            this.Unitlabel.TabIndex = 14;
            this.Unitlabel.Text = "pcs";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "ราคา :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "จำนวน :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "ชื่อ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "รหัส :";
            // 
            // delbtn
            // 
            this.delbtn.Location = new System.Drawing.Point(120, 225);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(46, 28);
            this.delbtn.TabIndex = 6;
            this.delbtn.Text = "ลบ";
            this.delbtn.UseVisualStyleBackColor = false;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click_1);
            // 
            // editbtn
            // 
            this.editbtn.Location = new System.Drawing.Point(68, 225);
            this.editbtn.Name = "editbtn";
            this.editbtn.Size = new System.Drawing.Size(51, 28);
            this.editbtn.TabIndex = 5;
            this.editbtn.Text = "แก้ไข";
            this.editbtn.UseVisualStyleBackColor = false;
            this.editbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Pricelabel
            // 
            this.Pricelabel.AutoSize = true;
            this.Pricelabel.Location = new System.Drawing.Point(65, 197);
            this.Pricelabel.Name = "Pricelabel";
            this.Pricelabel.Size = new System.Drawing.Size(31, 13);
            this.Pricelabel.TabIndex = 4;
            this.Pricelabel.Text = "Price";
            // 
            // Quantitylabel
            // 
            this.Quantitylabel.AutoSize = true;
            this.Quantitylabel.Location = new System.Drawing.Point(63, 179);
            this.Quantitylabel.Name = "Quantitylabel";
            this.Quantitylabel.Size = new System.Drawing.Size(46, 13);
            this.Quantitylabel.TabIndex = 3;
            this.Quantitylabel.Text = "Quantity";
            // 
            // Namelabel
            // 
            this.Namelabel.AutoSize = true;
            this.Namelabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Namelabel.Location = new System.Drawing.Point(63, 161);
            this.Namelabel.Name = "Namelabel";
            this.Namelabel.Size = new System.Drawing.Size(39, 15);
            this.Namelabel.TabIndex = 2;
            this.Namelabel.Text = "Name";
            // 
            // Idlabel
            // 
            this.Idlabel.AutoSize = true;
            this.Idlabel.Location = new System.Drawing.Point(65, 133);
            this.Idlabel.Name = "Idlabel";
            this.Idlabel.Size = new System.Drawing.Size(18, 13);
            this.Idlabel.TabIndex = 1;
            this.Idlabel.Text = "ID";
            // 
            // receiveDateLabel
            // 
            this.receiveDateLabel.AutoSize = true;
            this.receiveDateLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.receiveDateLabel.ForeColor = System.Drawing.Color.Gray;
            this.receiveDateLabel.Location = new System.Drawing.Point(70, 108);
            this.receiveDateLabel.Name = "receiveDateLabel";
            this.receiveDateLabel.Size = new System.Drawing.Size(69, 13);
            this.receiveDateLabel.TabIndex = 12;
            this.receiveDateLabel.Text = "dd/MM/yyyy";
            this.receiveDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.receiveDateLabel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(70, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // badgeLabel
            // 
            this.badgeLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            this.badgeLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.badgeLabel.ForeColor = System.Drawing.Color.White;
            this.badgeLabel.Location = new System.Drawing.Point(190, 8);
            this.badgeLabel.Name = "badgeLabel";
            this.badgeLabel.Size = new System.Drawing.Size(40, 20);
            this.badgeLabel.TabIndex = 11;
            this.badgeLabel.Text = "New";
            this.badgeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.badgeLabel.Visible = false;
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.panelShadow);
            this.Name = "ProductCard";
            this.Size = new System.Drawing.Size(247, 278);
            this.Load += new System.EventHandler(this.ProductCard_Load);
            this.panelShadow.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label badgeLabel;
        private System.Windows.Forms.Label Quantitylabel;
        private System.Windows.Forms.Label Namelabel;
        private System.Windows.Forms.Label Idlabel;
        private System.Windows.Forms.Label receiveDateLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button editbtn;
        private System.Windows.Forms.Label Pricelabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Unitlabel;
    }
}
