namespace SDCafeSales.Views
{
    partial class frmEditOrderPrice
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
            this.txt_ProductName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_OldAmount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlNums = new System.Windows.Forms.Panel();
            this.txt_NewPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txt_ProductName
            // 
            this.txt_ProductName.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_ProductName.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProductName.Location = new System.Drawing.Point(177, 12);
            this.txt_ProductName.Name = "txt_ProductName";
            this.txt_ProductName.Size = new System.Drawing.Size(304, 32);
            this.txt_ProductName.TabIndex = 8;
            this.txt_ProductName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Product Name";
            // 
            // txt_OldAmount
            // 
            this.txt_OldAmount.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txt_OldAmount.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_OldAmount.Location = new System.Drawing.Point(177, 50);
            this.txt_OldAmount.Name = "txt_OldAmount";
            this.txt_OldAmount.Size = new System.Drawing.Size(304, 32);
            this.txt_OldAmount.TabIndex = 14;
            this.txt_OldAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Amount";
            // 
            // pnlNums
            // 
            this.pnlNums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNums.AutoSize = true;
            this.pnlNums.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlNums.Location = new System.Drawing.Point(22, 136);
            this.pnlNums.Name = "pnlNums";
            this.pnlNums.Size = new System.Drawing.Size(459, 337);
            this.pnlNums.TabIndex = 15;
            // 
            // txt_NewPrice
            // 
            this.txt_NewPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_NewPrice.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_NewPrice.Location = new System.Drawing.Point(177, 88);
            this.txt_NewPrice.Name = "txt_NewPrice";
            this.txt_NewPrice.Size = new System.Drawing.Size(304, 32);
            this.txt_NewPrice.TabIndex = 17;
            this.txt_NewPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(18, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 16;
            this.label1.Text = "New Amount";
            // 
            // frmEditOrderPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 485);
            this.Controls.Add(this.txt_NewPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlNums);
            this.Controls.Add(this.txt_OldAmount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_ProductName);
            this.Controls.Add(this.label2);
            this.Name = "frmEditOrderPrice";
            this.Text = "Edit Amount";
            this.Load += new System.EventHandler(this.frmEditOrderPrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_ProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_OldAmount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnlNums;
        private System.Windows.Forms.TextBox txt_NewPrice;
        private System.Windows.Forms.Label label1;
    }
}