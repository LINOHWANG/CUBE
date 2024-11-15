namespace SDCafeSales.Views
{
    partial class frmAddProduct
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
            this.pnlNums = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ProdlName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_UnitlPrice = new System.Windows.Forms.TextBox();
            this.cb_Tax1 = new System.Windows.Forms.CheckBox();
            this.cb_Tax2 = new System.Windows.Forms.CheckBox();
            this.cb_Tax3 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_BarCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pnlNums
            // 
            this.pnlNums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNums.AutoSize = true;
            this.pnlNums.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlNums.Location = new System.Drawing.Point(12, 150);
            this.pnlNums.Name = "pnlNums";
            this.pnlNums.Size = new System.Drawing.Size(459, 352);
            this.pnlNums.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Product Name";
            // 
            // txt_ProdlName
            // 
            this.txt_ProdlName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ProdlName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProdlName.Location = new System.Drawing.Point(164, 41);
            this.txt_ProdlName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ProdlName.Name = "txt_ProdlName";
            this.txt_ProdlName.Size = new System.Drawing.Size(307, 29);
            this.txt_ProdlName.TabIndex = 17;
            this.txt_ProdlName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ProdlName.Click += new System.EventHandler(this.txt_ProductName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 116);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Unit Price";
            // 
            // txt_UnitlPrice
            // 
            this.txt_UnitlPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_UnitlPrice.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_UnitlPrice.Location = new System.Drawing.Point(164, 113);
            this.txt_UnitlPrice.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_UnitlPrice.Name = "txt_UnitlPrice";
            this.txt_UnitlPrice.Size = new System.Drawing.Size(307, 29);
            this.txt_UnitlPrice.TabIndex = 19;
            this.txt_UnitlPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_Tax1
            // 
            this.cb_Tax1.AutoSize = true;
            this.cb_Tax1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Tax1.Location = new System.Drawing.Point(164, 79);
            this.cb_Tax1.Name = "cb_Tax1";
            this.cb_Tax1.Size = new System.Drawing.Size(70, 26);
            this.cb_Tax1.TabIndex = 21;
            this.cb_Tax1.Text = "GST";
            this.cb_Tax1.UseVisualStyleBackColor = true;
            this.cb_Tax1.CheckedChanged += new System.EventHandler(this.cb_tax1_Changed);
            // 
            // cb_Tax2
            // 
            this.cb_Tax2.AutoSize = true;
            this.cb_Tax2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Tax2.Location = new System.Drawing.Point(281, 79);
            this.cb_Tax2.Name = "cb_Tax2";
            this.cb_Tax2.Size = new System.Drawing.Size(68, 26);
            this.cb_Tax2.TabIndex = 22;
            this.cb_Tax2.Text = "PST";
            this.cb_Tax2.UseVisualStyleBackColor = true;
            this.cb_Tax2.CheckedChanged += new System.EventHandler(this.cb_tax2_Changed);
            // 
            // cb_Tax3
            // 
            this.cb_Tax3.AutoSize = true;
            this.cb_Tax3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Tax3.Location = new System.Drawing.Point(403, 79);
            this.cb_Tax3.Name = "cb_Tax3";
            this.cb_Tax3.Size = new System.Drawing.Size(68, 26);
            this.cb_Tax3.TabIndex = 23;
            this.cb_Tax3.Text = "HST";
            this.cb_Tax3.UseVisualStyleBackColor = true;
            this.cb_Tax3.CheckedChanged += new System.EventHandler(this.cb_Tax3_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tax";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 26;
            this.label4.Text = "Bar Code";
            // 
            // txt_BarCode
            // 
            this.txt_BarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_BarCode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BarCode.Location = new System.Drawing.Point(164, 5);
            this.txt_BarCode.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_BarCode.Name = "txt_BarCode";
            this.txt_BarCode.Size = new System.Drawing.Size(307, 29);
            this.txt_BarCode.TabIndex = 25;
            this.txt_BarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmAddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 514);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_BarCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Tax3);
            this.Controls.Add(this.cb_Tax2);
            this.Controls.Add(this.cb_Tax1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_UnitlPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ProdlName);
            this.Controls.Add(this.pnlNums);
            this.Name = "frmAddProduct";
            this.Text = "New Product Entry";
            this.Load += new System.EventHandler(this.frmAddProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNums;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ProdlName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_UnitlPrice;
        private System.Windows.Forms.CheckBox cb_Tax1;
        private System.Windows.Forms.CheckBox cb_Tax2;
        private System.Windows.Forms.CheckBox cb_Tax3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_BarCode;
    }
}