namespace SDCafeSales.Views
{
    partial class frmSalesCustomer
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
            this.dgv_Orders = new System.Windows.Forms.DataGridView();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.pb_Instruction = new System.Windows.Forms.PictureBox();
            this.txt_Instruction = new System.Windows.Forms.TextBox();
            this.lbl_SubTotal = new System.Windows.Forms.Label();
            this.lbl_TaxTotal = new System.Windows.Forms.Label();
            this.lbl_TotalDue = new System.Windows.Forms.Label();
            this.lbl_ItemCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_ItemCount = new System.Windows.Forms.TextBox();
            this.txt_SubTotal = new System.Windows.Forms.TextBox();
            this.txt_TaxTotal = new System.Windows.Forms.TextBox();
            this.txt_TotalDue = new System.Windows.Forms.TextBox();
            this.bt_Start = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Payment = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Instruction)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Orders
            // 
            this.dgv_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Orders.Location = new System.Drawing.Point(3, 4);
            this.dgv_Orders.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgv_Orders.MultiSelect = false;
            this.dgv_Orders.Name = "dgv_Orders";
            this.dgv_Orders.ReadOnly = true;
            this.dgv_Orders.RowHeadersVisible = false;
            this.dgv_Orders.Size = new System.Drawing.Size(387, 430);
            this.dgv_Orders.TabIndex = 10;
            // 
            // txtMessages
            // 
            this.txtMessages.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtMessages.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessages.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessages.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessages.Location = new System.Drawing.Point(3, 701);
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(997, 26);
            this.txtMessages.TabIndex = 68;
            this.txtMessages.Text = "Messages";
            // 
            // pb_Instruction
            // 
            this.pb_Instruction.Image = global::SDCafeSales.Properties.Resources.CUBE_LOGO2;
            this.pb_Instruction.Location = new System.Drawing.Point(399, 55);
            this.pb_Instruction.Name = "pb_Instruction";
            this.pb_Instruction.Size = new System.Drawing.Size(597, 377);
            this.pb_Instruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Instruction.TabIndex = 78;
            this.pb_Instruction.TabStop = false;
            // 
            // txt_Instruction
            // 
            this.txt_Instruction.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Instruction.Location = new System.Drawing.Point(398, 12);
            this.txt_Instruction.Name = "txt_Instruction";
            this.txt_Instruction.Size = new System.Drawing.Size(601, 32);
            this.txt_Instruction.TabIndex = 80;
            // 
            // lbl_SubTotal
            // 
            this.lbl_SubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_SubTotal.AutoSize = true;
            this.lbl_SubTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_SubTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_SubTotal.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SubTotal.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbl_SubTotal.Location = new System.Drawing.Point(223, 520);
            this.lbl_SubTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_SubTotal.Name = "lbl_SubTotal";
            this.lbl_SubTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_SubTotal.Size = new System.Drawing.Size(159, 32);
            this.lbl_SubTotal.TabIndex = 85;
            this.lbl_SubTotal.Text = "00000000";
            this.lbl_SubTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TaxTotal
            // 
            this.lbl_TaxTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_TaxTotal.AutoSize = true;
            this.lbl_TaxTotal.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TaxTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TaxTotal.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TaxTotal.ForeColor = System.Drawing.Color.Purple;
            this.lbl_TaxTotal.Location = new System.Drawing.Point(223, 582);
            this.lbl_TaxTotal.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TaxTotal.Name = "lbl_TaxTotal";
            this.lbl_TaxTotal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TaxTotal.Size = new System.Drawing.Size(159, 32);
            this.lbl_TaxTotal.TabIndex = 86;
            this.lbl_TaxTotal.Text = "00000000";
            this.lbl_TaxTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_TotalDue
            // 
            this.lbl_TotalDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_TotalDue.AutoSize = true;
            this.lbl_TotalDue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_TotalDue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_TotalDue.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalDue.ForeColor = System.Drawing.Color.Red;
            this.lbl_TotalDue.Location = new System.Drawing.Point(223, 643);
            this.lbl_TotalDue.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TotalDue.Name = "lbl_TotalDue";
            this.lbl_TotalDue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TotalDue.Size = new System.Drawing.Size(159, 32);
            this.lbl_TotalDue.TabIndex = 87;
            this.lbl_TotalDue.Text = "00000000";
            this.lbl_TotalDue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_ItemCount
            // 
            this.lbl_ItemCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_ItemCount.AutoSize = true;
            this.lbl_ItemCount.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ItemCount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_ItemCount.Font = new System.Drawing.Font("Bookman Old Style", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ItemCount.ForeColor = System.Drawing.Color.Blue;
            this.lbl_ItemCount.Location = new System.Drawing.Point(223, 459);
            this.lbl_ItemCount.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ItemCount.Name = "lbl_ItemCount";
            this.lbl_ItemCount.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_ItemCount.Size = new System.Drawing.Size(159, 32);
            this.lbl_ItemCount.TabIndex = 88;
            this.lbl_ItemCount.Text = "00000000";
            this.lbl_ItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(42, 520);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 41);
            this.label1.TabIndex = 81;
            this.label1.Text = "Sub Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Purple;
            this.label2.Location = new System.Drawing.Point(114, 582);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 41);
            this.label2.TabIndex = 82;
            this.label2.Text = "Tax";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(39, 643);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 41);
            this.label3.TabIndex = 83;
            this.label3.Text = "Total Due";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(36, 459);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 41);
            this.label4.TabIndex = 84;
            this.label4.Text = "# of Items";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_ItemCount
            // 
            this.txt_ItemCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ItemCount.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ItemCount.Location = new System.Drawing.Point(210, 459);
            this.txt_ItemCount.Name = "txt_ItemCount";
            this.txt_ItemCount.ReadOnly = true;
            this.txt_ItemCount.Size = new System.Drawing.Size(162, 41);
            this.txt_ItemCount.TabIndex = 89;
            this.txt_ItemCount.Text = "0";
            this.txt_ItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_SubTotal
            // 
            this.txt_SubTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_SubTotal.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SubTotal.Location = new System.Drawing.Point(210, 520);
            this.txt_SubTotal.Name = "txt_SubTotal";
            this.txt_SubTotal.ReadOnly = true;
            this.txt_SubTotal.Size = new System.Drawing.Size(162, 41);
            this.txt_SubTotal.TabIndex = 90;
            this.txt_SubTotal.Text = "0.00";
            this.txt_SubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_SubTotal.TextChanged += new System.EventHandler(this.txt_SubTotal_TextChanged);
            // 
            // txt_TaxTotal
            // 
            this.txt_TaxTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TaxTotal.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaxTotal.Location = new System.Drawing.Point(210, 582);
            this.txt_TaxTotal.Name = "txt_TaxTotal";
            this.txt_TaxTotal.ReadOnly = true;
            this.txt_TaxTotal.Size = new System.Drawing.Size(162, 41);
            this.txt_TaxTotal.TabIndex = 91;
            this.txt_TaxTotal.Text = "0.00";
            this.txt_TaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_TotalDue
            // 
            this.txt_TotalDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TotalDue.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDue.Location = new System.Drawing.Point(210, 643);
            this.txt_TotalDue.Name = "txt_TotalDue";
            this.txt_TotalDue.ReadOnly = true;
            this.txt_TotalDue.Size = new System.Drawing.Size(162, 41);
            this.txt_TotalDue.TabIndex = 92;
            this.txt_TotalDue.Text = "0.00";
            this.txt_TotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.RoyalBlue;
            this.bt_Start.CornerRadius = 5;
            this.bt_Start.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Start.ForeColor = System.Drawing.Color.White;
            this.bt_Start.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Start.Location = new System.Drawing.Point(396, 438);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Start.Size = new System.Drawing.Size(300, 257);
            this.bt_Start.TabIndex = 79;
            this.bt_Start.Text = "Start";
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // bt_Payment
            // 
            this.bt_Payment.BackColor = System.Drawing.Color.DarkGreen;
            this.bt_Payment.CornerRadius = 5;
            this.bt_Payment.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Payment.ForeColor = System.Drawing.Color.White;
            this.bt_Payment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Payment.Location = new System.Drawing.Point(698, 438);
            this.bt_Payment.Name = "bt_Payment";
            this.bt_Payment.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Payment.Size = new System.Drawing.Size(300, 257);
            this.bt_Payment.TabIndex = 77;
            this.bt_Payment.Text = "Confirm / Payment";
            this.bt_Payment.Click += new System.EventHandler(this.bt_Payment_Click);
            // 
            // frmSalesCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.txt_TotalDue);
            this.Controls.Add(this.txt_TaxTotal);
            this.Controls.Add(this.txt_SubTotal);
            this.Controls.Add(this.txt_ItemCount);
            this.Controls.Add(this.lbl_SubTotal);
            this.Controls.Add(this.lbl_TaxTotal);
            this.Controls.Add(this.lbl_TotalDue);
            this.Controls.Add(this.lbl_ItemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_Instruction);
            this.Controls.Add(this.bt_Start);
            this.Controls.Add(this.pb_Instruction);
            this.Controls.Add(this.bt_Payment);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.dgv_Orders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmSalesCustomer";
            this.Text = "frmSalesCustomer";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Instruction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_Orders;
        private System.Windows.Forms.TextBox txtMessages;
        private SDCafeCommon.Utilities.CustomButton bt_Payment;
        private System.Windows.Forms.PictureBox pb_Instruction;
        private SDCafeCommon.Utilities.CustomButton bt_Start;
        private System.Windows.Forms.TextBox txt_Instruction;
        private System.Windows.Forms.Label lbl_SubTotal;
        private System.Windows.Forms.Label lbl_TaxTotal;
        private System.Windows.Forms.Label lbl_TotalDue;
        private System.Windows.Forms.Label lbl_ItemCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_ItemCount;
        private System.Windows.Forms.TextBox txt_SubTotal;
        private System.Windows.Forms.TextBox txt_TaxTotal;
        private System.Windows.Forms.TextBox txt_TotalDue;
    }
}