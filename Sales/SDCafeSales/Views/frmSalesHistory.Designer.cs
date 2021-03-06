﻿namespace SDCafeSales.Views
{
    partial class frmSalesHistory
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
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.dttm_TranStart = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TotalSales = new System.Windows.Forms.TextBox();
            this.txt_TotalTips = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_TotalCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_SetVoid = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Query = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ReprintReceipt = new SDCafeCommon.Utilities.CustomButton();
            this.txt_TotalVoidCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_TotalVoidSales = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_TotalSum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_VoidTips = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TipSum = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(13, 89);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(983, 517);
            this.dgvData.TabIndex = 0;
            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);
            // 
            // dttm_TranStart
            // 
            this.dttm_TranStart.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranStart.Location = new System.Drawing.Point(118, 19);
            this.dttm_TranStart.Name = "dttm_TranStart";
            this.dttm_TranStart.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranStart.TabIndex = 1;
            // 
            // dttm_TranEnd
            // 
            this.dttm_TranEnd.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranEnd.Location = new System.Drawing.Point(118, 54);
            this.dttm_TranEnd.Name = "dttm_TranEnd";
            this.dttm_TranEnd.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEnd.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 21;
            this.label5.Text = "Start Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 22;
            this.label1.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 617);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 22);
            this.label2.TabIndex = 37;
            this.label2.Text = "Total Sales :";
            // 
            // txt_TotalSales
            // 
            this.txt_TotalSales.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalSales.Location = new System.Drawing.Point(509, 612);
            this.txt_TotalSales.Name = "txt_TotalSales";
            this.txt_TotalSales.Size = new System.Drawing.Size(186, 29);
            this.txt_TotalSales.TabIndex = 38;
            this.txt_TotalSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_TotalTips
            // 
            this.txt_TotalTips.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalTips.Location = new System.Drawing.Point(810, 613);
            this.txt_TotalTips.Name = "txt_TotalTips";
            this.txt_TotalTips.Size = new System.Drawing.Size(186, 29);
            this.txt_TotalTips.TabIndex = 40;
            this.txt_TotalTips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(701, 617);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "Tip Total :";
            // 
            // txt_TotalCount
            // 
            this.txt_TotalCount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalCount.Location = new System.Drawing.Point(222, 612);
            this.txt_TotalCount.Name = "txt_TotalCount";
            this.txt_TotalCount.Size = new System.Drawing.Size(135, 29);
            this.txt_TotalCount.TabIndex = 42;
            this.txt_TotalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 617);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 22);
            this.label4.TabIndex = 41;
            this.label4.Text = "# of Transactions :";
            // 
            // bt_SetVoid
            // 
            this.bt_SetVoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_SetVoid.CornerRadius = 30;
            this.bt_SetVoid.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_SetVoid.Location = new System.Drawing.Point(553, 14);
            this.bt_SetVoid.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_SetVoid.Name = "bt_SetVoid";
            this.bt_SetVoid.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_SetVoid.Size = new System.Drawing.Size(142, 47);
            this.bt_SetVoid.TabIndex = 43;
            this.bt_SetVoid.Text = "Set Void";
            this.bt_SetVoid.Click += new System.EventHandler(this.bt_SetVoid_Click);
            // 
            // bt_Query
            // 
            this.bt_Query.CornerRadius = 30;
            this.bt_Query.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Query.Location = new System.Drawing.Point(399, 14);
            this.bt_Query.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Query.Size = new System.Drawing.Size(142, 47);
            this.bt_Query.TabIndex = 36;
            this.bt_Query.Text = "Query";
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(854, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 35;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_ReprintReceipt
            // 
            this.bt_ReprintReceipt.CornerRadius = 30;
            this.bt_ReprintReceipt.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_ReprintReceipt.Location = new System.Drawing.Point(703, 14);
            this.bt_ReprintReceipt.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_ReprintReceipt.Name = "bt_ReprintReceipt";
            this.bt_ReprintReceipt.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_ReprintReceipt.Size = new System.Drawing.Size(142, 47);
            this.bt_ReprintReceipt.TabIndex = 23;
            this.bt_ReprintReceipt.Text = "Re-Print";
            this.bt_ReprintReceipt.Click += new System.EventHandler(this.bt_ReprintReceipt_Click);
            // 
            // txt_TotalVoidCount
            // 
            this.txt_TotalVoidCount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalVoidCount.Location = new System.Drawing.Point(222, 647);
            this.txt_TotalVoidCount.Name = "txt_TotalVoidCount";
            this.txt_TotalVoidCount.Size = new System.Drawing.Size(135, 29);
            this.txt_TotalVoidCount.TabIndex = 49;
            this.txt_TotalVoidCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_TotalVoidCount.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 652);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 22);
            this.label6.TabIndex = 48;
            this.label6.Text = "# of Void :";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txt_TotalVoidSales
            // 
            this.txt_TotalVoidSales.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalVoidSales.Location = new System.Drawing.Point(509, 647);
            this.txt_TotalVoidSales.Name = "txt_TotalVoidSales";
            this.txt_TotalVoidSales.Size = new System.Drawing.Size(186, 29);
            this.txt_TotalVoidSales.TabIndex = 45;
            this.txt_TotalVoidSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(379, 652);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 22);
            this.label8.TabIndex = 44;
            this.label8.Text = "Void Total :";
            // 
            // txt_TotalSum
            // 
            this.txt_TotalSum.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalSum.Location = new System.Drawing.Point(509, 682);
            this.txt_TotalSum.Name = "txt_TotalSum";
            this.txt_TotalSum.Size = new System.Drawing.Size(186, 29);
            this.txt_TotalSum.TabIndex = 51;
            this.txt_TotalSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(379, 687);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 22);
            this.label7.TabIndex = 50;
            this.label7.Text = "Sum :";
            // 
            // txt_VoidTips
            // 
            this.txt_VoidTips.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_VoidTips.Location = new System.Drawing.Point(810, 649);
            this.txt_VoidTips.Name = "txt_VoidTips";
            this.txt_VoidTips.Size = new System.Drawing.Size(186, 29);
            this.txt_VoidTips.TabIndex = 53;
            this.txt_VoidTips.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(701, 653);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 22);
            this.label9.TabIndex = 52;
            this.label9.Text = "Void Tips :";
            // 
            // txt_TipSum
            // 
            this.txt_TipSum.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TipSum.Location = new System.Drawing.Point(810, 684);
            this.txt_TipSum.Name = "txt_TipSum";
            this.txt_TipSum.Size = new System.Drawing.Size(186, 29);
            this.txt_TipSum.TabIndex = 55;
            this.txt_TipSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(701, 688);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 22);
            this.label10.TabIndex = 54;
            this.label10.Text = "Tip Sum :";
            // 
            // frmSalesHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 725);
            this.Controls.Add(this.txt_TipSum);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_VoidTips);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_TotalSum);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_TotalVoidCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_TotalVoidSales);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.bt_SetVoid);
            this.Controls.Add(this.txt_TotalCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_TotalTips);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_TotalSales);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_Query);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_ReprintReceipt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dttm_TranEnd);
            this.Controls.Add(this.dttm_TranStart);
            this.Controls.Add(this.dgvData);
            this.Name = "frmSalesHistory";
            this.Text = "frmSalesHistory";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DateTimePicker dttm_TranStart;
        private System.Windows.Forms.DateTimePicker dttm_TranEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private SDCafeCommon.Utilities.CustomButton bt_ReprintReceipt;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Query;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TotalSales;
        private System.Windows.Forms.TextBox txt_TotalTips;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_TotalCount;
        private System.Windows.Forms.Label label4;
        private SDCafeCommon.Utilities.CustomButton bt_SetVoid;
        private System.Windows.Forms.TextBox txt_TotalVoidCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_TotalVoidSales;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_TotalSum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_VoidTips;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TipSum;
        private System.Windows.Forms.Label label10;
    }
}