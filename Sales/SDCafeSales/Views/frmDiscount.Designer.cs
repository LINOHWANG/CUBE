namespace SDCafeSales.Views
{
    partial class frmDiscount
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
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_50Percent = new SDCafeCommon.Utilities.CustomButton();
            this.bt_30Percent = new SDCafeCommon.Utilities.CustomButton();
            this.bt_20Percent = new SDCafeCommon.Utilities.CustomButton();
            this.bt_10Percent = new SDCafeCommon.Utilities.CustomButton();
            this.bt_05Percent = new SDCafeCommon.Utilities.CustomButton();
            this.bt_100Percent = new SDCafeCommon.Utilities.CustomButton();
            this.SuspendLayout();
            // 
            // txt_Amount
            // 
            this.txt_Amount.Location = new System.Drawing.Point(148, 23);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.Size = new System.Drawing.Size(174, 32);
            this.txt_Amount.TabIndex = 0;
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Amount";
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 5;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(345, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(116, 47);
            this.bt_Exit.TabIndex = 62;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_50Percent
            // 
            this.bt_50Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_50Percent.CornerRadius = 20;
            this.bt_50Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_50Percent.ForeColor = System.Drawing.Color.Black;
            this.bt_50Percent.Location = new System.Drawing.Point(37, 364);
            this.bt_50Percent.Name = "bt_50Percent";
            this.bt_50Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_50Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_50Percent.TabIndex = 52;
            this.bt_50Percent.Text = "50%";
            this.bt_50Percent.Click += new System.EventHandler(this.bt_50Percent_Click);
            // 
            // bt_30Percent
            // 
            this.bt_30Percent.BackColor = System.Drawing.Color.White;
            this.bt_30Percent.CornerRadius = 20;
            this.bt_30Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_30Percent.ForeColor = System.Drawing.Color.Black;
            this.bt_30Percent.Location = new System.Drawing.Point(37, 291);
            this.bt_30Percent.Name = "bt_30Percent";
            this.bt_30Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_30Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_30Percent.TabIndex = 51;
            this.bt_30Percent.Text = "30%";
            this.bt_30Percent.Click += new System.EventHandler(this.bt_30Percent_Click);
            // 
            // bt_20Percent
            // 
            this.bt_20Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_20Percent.CornerRadius = 20;
            this.bt_20Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_20Percent.ForeColor = System.Drawing.Color.Black;
            this.bt_20Percent.Location = new System.Drawing.Point(37, 218);
            this.bt_20Percent.Name = "bt_20Percent";
            this.bt_20Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_20Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_20Percent.TabIndex = 50;
            this.bt_20Percent.Text = "20%";
            this.bt_20Percent.Click += new System.EventHandler(this.bt_20Percent_Click);
            // 
            // bt_10Percent
            // 
            this.bt_10Percent.BackColor = System.Drawing.Color.White;
            this.bt_10Percent.CornerRadius = 20;
            this.bt_10Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_10Percent.ForeColor = System.Drawing.Color.Black;
            this.bt_10Percent.Location = new System.Drawing.Point(37, 145);
            this.bt_10Percent.Name = "bt_10Percent";
            this.bt_10Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_10Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_10Percent.TabIndex = 49;
            this.bt_10Percent.Text = "10%";
            this.bt_10Percent.Click += new System.EventHandler(this.bt_10Percent_Click);
            // 
            // bt_05Percent
            // 
            this.bt_05Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_05Percent.CornerRadius = 20;
            this.bt_05Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_05Percent.ForeColor = System.Drawing.Color.Black;
            this.bt_05Percent.Location = new System.Drawing.Point(37, 72);
            this.bt_05Percent.Name = "bt_05Percent";
            this.bt_05Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_05Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_05Percent.TabIndex = 48;
            this.bt_05Percent.Text = "5%";
            this.bt_05Percent.Click += new System.EventHandler(this.bt_05Percent_Click);
            // 
            // bt_100Percent
            // 
            this.bt_100Percent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_100Percent.CornerRadius = 20;
            this.bt_100Percent.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_100Percent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_100Percent.Location = new System.Drawing.Point(37, 437);
            this.bt_100Percent.Name = "bt_100Percent";
            this.bt_100Percent.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_100Percent.Size = new System.Drawing.Size(424, 67);
            this.bt_100Percent.TabIndex = 63;
            this.bt_100Percent.Text = "100%";
            this.bt_100Percent.Click += new System.EventHandler(this.bt_100Percent_Click);
            // 
            // frmDiscount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 526);
            this.ControlBox = false;
            this.Controls.Add(this.bt_100Percent);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_50Percent);
            this.Controls.Add(this.bt_30Percent);
            this.Controls.Add(this.bt_20Percent);
            this.Controls.Add(this.bt_10Percent);
            this.Controls.Add(this.bt_05Percent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Amount);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDiscount";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Set Discount";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.Label label1;
        private SDCafeCommon.Utilities.CustomButton bt_05Percent;
        private SDCafeCommon.Utilities.CustomButton bt_10Percent;
        private SDCafeCommon.Utilities.CustomButton bt_20Percent;
        private SDCafeCommon.Utilities.CustomButton bt_30Percent;
        private SDCafeCommon.Utilities.CustomButton bt_50Percent;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_100Percent;
    }
}