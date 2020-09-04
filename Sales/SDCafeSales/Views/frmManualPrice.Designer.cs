namespace SDCafeSales.Views
{
    partial class frmManualPrice
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
            this.txt_ManualName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ManualPrice = new System.Windows.Forms.TextBox();
            this.cb_Tax1 = new System.Windows.Forms.CheckBox();
            this.cb_Tax2 = new System.Windows.Forms.CheckBox();
            this.cb_Tax3 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlNums
            // 
            this.pnlNums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNums.AutoSize = true;
            this.pnlNums.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlNums.Location = new System.Drawing.Point(12, 153);
            this.pnlNums.Name = "pnlNums";
            this.pnlNums.Size = new System.Drawing.Size(459, 347);
            this.pnlNums.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Manual Item Name";
            // 
            // txt_ManualName
            // 
            this.txt_ManualName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ManualName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ManualName.Location = new System.Drawing.Point(15, 44);
            this.txt_ManualName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ManualName.Name = "txt_ManualName";
            this.txt_ManualName.Size = new System.Drawing.Size(456, 29);
            this.txt_ManualName.TabIndex = 17;
            this.txt_ManualName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ManualName.Click += new System.EventHandler(this.txt_ManualName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 20;
            this.label2.Text = "Price";
            // 
            // txt_ManualPrice
            // 
            this.txt_ManualPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ManualPrice.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ManualPrice.Location = new System.Drawing.Point(127, 116);
            this.txt_ManualPrice.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ManualPrice.Name = "txt_ManualPrice";
            this.txt_ManualPrice.Size = new System.Drawing.Size(344, 29);
            this.txt_ManualPrice.TabIndex = 19;
            this.txt_ManualPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_Tax1
            // 
            this.cb_Tax1.AutoSize = true;
            this.cb_Tax1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Tax1.Location = new System.Drawing.Point(127, 82);
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
            this.cb_Tax2.Location = new System.Drawing.Point(264, 82);
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
            this.cb_Tax3.Location = new System.Drawing.Point(403, 82);
            this.cb_Tax3.Name = "cb_Tax3";
            this.cb_Tax3.Size = new System.Drawing.Size(68, 26);
            this.cb_Tax3.TabIndex = 23;
            this.cb_Tax3.Text = "HST";
            this.cb_Tax3.UseVisualStyleBackColor = true;
            this.cb_Tax3.Visible = false;
            this.cb_Tax3.CheckedChanged += new System.EventHandler(this.cb_Tax3_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 82);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 22);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tax";
            // 
            // frmManualPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 512);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_Tax3);
            this.Controls.Add(this.cb_Tax2);
            this.Controls.Add(this.cb_Tax1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ManualPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ManualName);
            this.Controls.Add(this.pnlNums);
            this.Name = "frmManualPrice";
            this.Text = "Manual Item Entry";
            this.Load += new System.EventHandler(this.frmManualPrice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNums;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ManualName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ManualPrice;
        private System.Windows.Forms.CheckBox cb_Tax1;
        private System.Windows.Forms.CheckBox cb_Tax2;
        private System.Windows.Forms.CheckBox cb_Tax3;
        private System.Windows.Forms.Label label3;
    }
}