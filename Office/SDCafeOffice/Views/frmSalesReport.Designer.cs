namespace SDCafeOffice.Views
{
    partial class frmSalesReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dttm_TranEnd = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranStart = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranStartTime = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblReportType = new System.Windows.Forms.Label();
            this.dgvDataTender = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.rbRptType = new System.Windows.Forms.RadioButton();
            this.rbRptItem = new System.Windows.Forms.RadioButton();
            this.bt_Excel = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Query = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Print = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTender)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 144);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(990, 317);
            this.dgvData.TabIndex = 2;
            this.dgvData.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvData_SortCompare);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 72);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 39;
            this.label5.Text = "Start Date";
            // 
            // dttm_TranEnd
            // 
            this.dttm_TranEnd.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranEnd.Location = new System.Drawing.Point(124, 67);
            this.dttm_TranEnd.Name = "dttm_TranEnd";
            this.dttm_TranEnd.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEnd.TabIndex = 38;
            // 
            // dttm_TranStart
            // 
            this.dttm_TranStart.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranStart.Location = new System.Drawing.Point(124, 21);
            this.dttm_TranStart.Name = "dttm_TranStart";
            this.dttm_TranStart.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranStart.TabIndex = 37;
            // 
            // dttm_TranStartTime
            // 
            this.dttm_TranStartTime.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dttm_TranStartTime.Location = new System.Drawing.Point(285, 21);
            this.dttm_TranStartTime.Name = "dttm_TranStartTime";
            this.dttm_TranStartTime.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranStartTime.TabIndex = 45;
            // 
            // dttm_TranEndTime
            // 
            this.dttm_TranEndTime.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dttm_TranEndTime.Location = new System.Drawing.Point(285, 67);
            this.dttm_TranEndTime.Name = "dttm_TranEndTime";
            this.dttm_TranEndTime.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEndTime.TabIndex = 46;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.Blue;
            this.lblReportType.Location = new System.Drawing.Point(21, 119);
            this.lblReportType.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblReportType.Name = "lblReportType";
            this.lblReportType.Size = new System.Drawing.Size(215, 22);
            this.lblReportType.TabIndex = 47;
            this.lblReportType.Text = "Sales Summary by Type";
            // 
            // dgvDataTender
            // 
            this.dgvDataTender.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataTender.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTender.Location = new System.Drawing.Point(12, 495);
            this.dgvDataTender.MultiSelect = false;
            this.dgvDataTender.Name = "dgvDataTender";
            this.dgvDataTender.ReadOnly = true;
            this.dgvDataTender.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTender.ShowEditingIcon = false;
            this.dgvDataTender.Size = new System.Drawing.Size(990, 222);
            this.dgvDataTender.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(21, 470);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(315, 22);
            this.label3.TabIndex = 49;
            this.label3.Text = "Collection Summary by Tender Type";
            // 
            // rbRptType
            // 
            this.rbRptType.AutoSize = true;
            this.rbRptType.Font = new System.Drawing.Font("Arial", 14.25F);
            this.rbRptType.Location = new System.Drawing.Point(481, 24);
            this.rbRptType.Name = "rbRptType";
            this.rbRptType.Size = new System.Drawing.Size(97, 26);
            this.rbRptType.TabIndex = 50;
            this.rbRptType.TabStop = true;
            this.rbRptType.Text = "By Type";
            this.rbRptType.UseVisualStyleBackColor = true;
            this.rbRptType.CheckedChanged += new System.EventHandler(this.rbRptType_CheckedChanged);
            // 
            // rbRptItem
            // 
            this.rbRptItem.AutoSize = true;
            this.rbRptItem.Font = new System.Drawing.Font("Arial", 14.25F);
            this.rbRptItem.Location = new System.Drawing.Point(481, 70);
            this.rbRptItem.Name = "rbRptItem";
            this.rbRptItem.Size = new System.Drawing.Size(93, 26);
            this.rbRptItem.TabIndex = 51;
            this.rbRptItem.TabStop = true;
            this.rbRptItem.Text = "By Item";
            this.rbRptItem.UseVisualStyleBackColor = true;
            this.rbRptItem.CheckedChanged += new System.EventHandler(this.rbRptItem_CheckedChanged);
            // 
            // bt_Excel
            // 
            this.bt_Excel.CornerRadius = 30;
            this.bt_Excel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Excel.Location = new System.Drawing.Point(860, 67);
            this.bt_Excel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Excel.Name = "bt_Excel";
            this.bt_Excel.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Excel.Size = new System.Drawing.Size(142, 47);
            this.bt_Excel.TabIndex = 44;
            this.bt_Excel.Text = "Excel";
            this.bt_Excel.Click += new System.EventHandler(this.bt_Excel_Click);
            // 
            // bt_Query
            // 
            this.bt_Query.CornerRadius = 30;
            this.bt_Query.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Query.Location = new System.Drawing.Point(709, 12);
            this.bt_Query.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Query.Size = new System.Drawing.Size(142, 47);
            this.bt_Query.TabIndex = 43;
            this.bt_Query.Text = "Query";
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(860, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 42;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Print
            // 
            this.bt_Print.CornerRadius = 30;
            this.bt_Print.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Print.Location = new System.Drawing.Point(709, 67);
            this.bt_Print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Print.Size = new System.Drawing.Size(142, 47);
            this.bt_Print.TabIndex = 41;
            this.bt_Print.Text = "Print";
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.rbRptItem);
            this.Controls.Add(this.rbRptType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvDataTender);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.dttm_TranEndTime);
            this.Controls.Add(this.dttm_TranStartTime);
            this.Controls.Add(this.bt_Excel);
            this.Controls.Add(this.bt_Query);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Print);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dttm_TranEnd);
            this.Controls.Add(this.dttm_TranStart);
            this.Controls.Add(this.dgvData);
            this.Name = "frmSalesReport";
            this.Text = "frmSalesReport";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData;
        private SDCafeCommon.Utilities.CustomButton bt_Query;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Print;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dttm_TranEnd;
        private System.Windows.Forms.DateTimePicker dttm_TranStart;
        private SDCafeCommon.Utilities.CustomButton bt_Excel;
        private System.Windows.Forms.DateTimePicker dttm_TranStartTime;
        private System.Windows.Forms.DateTimePicker dttm_TranEndTime;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.DataGridView dgvDataTender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbRptType;
        private System.Windows.Forms.RadioButton rbRptItem;
    }
}