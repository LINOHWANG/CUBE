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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesReport));
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
            this.chart_DailyTrend = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bt_DailyTrend = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateThisYear = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateLast3M = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateLastMonth = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateThisMonth = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateThisWeek = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateYesterday = new SDCafeCommon.Utilities.CustomButton();
            this.bt_DateToday = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Excel = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Query = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Print = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Email = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTender)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_DailyTrend)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(12, 154);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(990, 268);
            this.dgvData.TabIndex = 2;
            this.dgvData.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvData_SortCompare);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 61);
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
            this.dttm_TranEnd.Location = new System.Drawing.Point(124, 56);
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
            this.dttm_TranEndTime.Location = new System.Drawing.Point(285, 56);
            this.dttm_TranEndTime.Name = "dttm_TranEndTime";
            this.dttm_TranEndTime.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEndTime.TabIndex = 46;
            // 
            // lblReportType
            // 
            this.lblReportType.AutoSize = true;
            this.lblReportType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportType.ForeColor = System.Drawing.Color.Blue;
            this.lblReportType.Location = new System.Drawing.Point(21, 130);
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
            this.dgvDataTender.Location = new System.Drawing.Point(12, 459);
            this.dgvDataTender.MultiSelect = false;
            this.dgvDataTender.Name = "dgvDataTender";
            this.dgvDataTender.ReadOnly = true;
            this.dgvDataTender.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTender.ShowEditingIcon = false;
            this.dgvDataTender.Size = new System.Drawing.Size(990, 258);
            this.dgvDataTender.TabIndex = 48;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(21, 435);
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
            this.rbRptType.Location = new System.Drawing.Point(449, 24);
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
            this.rbRptItem.Location = new System.Drawing.Point(449, 59);
            this.rbRptItem.Name = "rbRptItem";
            this.rbRptItem.Size = new System.Drawing.Size(93, 26);
            this.rbRptItem.TabIndex = 51;
            this.rbRptItem.TabStop = true;
            this.rbRptItem.Text = "By Item";
            this.rbRptItem.UseVisualStyleBackColor = true;
            this.rbRptItem.CheckedChanged += new System.EventHandler(this.rbRptItem_CheckedChanged);
            // 
            // chart_DailyTrend
            // 
            this.chart_DailyTrend.BackColor = System.Drawing.Color.Silver;
            chartArea1.Name = "ChartArea1";
            this.chart_DailyTrend.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart_DailyTrend.Legends.Add(legend1);
            this.chart_DailyTrend.Location = new System.Drawing.Point(698, 212);
            this.chart_DailyTrend.Name = "chart_DailyTrend";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart_DailyTrend.Series.Add(series1);
            this.chart_DailyTrend.Size = new System.Drawing.Size(990, 585);
            this.chart_DailyTrend.TabIndex = 85;
            this.chart_DailyTrend.Text = "chart1";
            // 
            // bt_DailyTrend
            // 
            this.bt_DailyTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_DailyTrend.CornerRadius = 30;
            this.bt_DailyTrend.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DailyTrend.Location = new System.Drawing.Point(895, 93);
            this.bt_DailyTrend.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DailyTrend.Name = "bt_DailyTrend";
            this.bt_DailyTrend.Size = new System.Drawing.Size(107, 30);
            this.bt_DailyTrend.TabIndex = 84;
            this.bt_DailyTrend.Text = "Daily Trend";
            this.bt_DailyTrend.Click += new System.EventHandler(this.bt_DailyTrend_Click);
            // 
            // bt_DateThisYear
            // 
            this.bt_DateThisYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_DateThisYear.CornerRadius = 30;
            this.bt_DateThisYear.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateThisYear.Location = new System.Drawing.Point(735, 93);
            this.bt_DateThisYear.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateThisYear.Name = "bt_DateThisYear";
            this.bt_DateThisYear.Size = new System.Drawing.Size(107, 30);
            this.bt_DateThisYear.TabIndex = 83;
            this.bt_DateThisYear.Text = "This Year";
            this.bt_DateThisYear.Click += new System.EventHandler(this.bt_DateThisYear_Click);
            // 
            // bt_DateLast3M
            // 
            this.bt_DateLast3M.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_DateLast3M.CornerRadius = 30;
            this.bt_DateLast3M.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateLast3M.Location = new System.Drawing.Point(616, 93);
            this.bt_DateLast3M.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateLast3M.Name = "bt_DateLast3M";
            this.bt_DateLast3M.Size = new System.Drawing.Size(107, 30);
            this.bt_DateLast3M.TabIndex = 82;
            this.bt_DateLast3M.Text = "Last 3 Months";
            this.bt_DateLast3M.Click += new System.EventHandler(this.bt_DateLast3M_Click);
            // 
            // bt_DateLastMonth
            // 
            this.bt_DateLastMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_DateLastMonth.CornerRadius = 30;
            this.bt_DateLastMonth.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateLastMonth.Location = new System.Drawing.Point(497, 93);
            this.bt_DateLastMonth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateLastMonth.Name = "bt_DateLastMonth";
            this.bt_DateLastMonth.Size = new System.Drawing.Size(107, 30);
            this.bt_DateLastMonth.TabIndex = 81;
            this.bt_DateLastMonth.Text = "Last Month";
            this.bt_DateLastMonth.Click += new System.EventHandler(this.bt_DateLastMonth_Click);
            // 
            // bt_DateThisMonth
            // 
            this.bt_DateThisMonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bt_DateThisMonth.CornerRadius = 30;
            this.bt_DateThisMonth.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateThisMonth.Location = new System.Drawing.Point(379, 93);
            this.bt_DateThisMonth.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateThisMonth.Name = "bt_DateThisMonth";
            this.bt_DateThisMonth.Size = new System.Drawing.Size(107, 30);
            this.bt_DateThisMonth.TabIndex = 80;
            this.bt_DateThisMonth.Text = "This Month";
            this.bt_DateThisMonth.Click += new System.EventHandler(this.bt_DateThisMonth_Click);
            // 
            // bt_DateThisWeek
            // 
            this.bt_DateThisWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_DateThisWeek.CornerRadius = 30;
            this.bt_DateThisWeek.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateThisWeek.Location = new System.Drawing.Point(260, 93);
            this.bt_DateThisWeek.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateThisWeek.Name = "bt_DateThisWeek";
            this.bt_DateThisWeek.Size = new System.Drawing.Size(107, 30);
            this.bt_DateThisWeek.TabIndex = 79;
            this.bt_DateThisWeek.Text = "This Week";
            this.bt_DateThisWeek.Click += new System.EventHandler(this.bt_DateThisWeek_Click);
            // 
            // bt_DateYesterday
            // 
            this.bt_DateYesterday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_DateYesterday.CornerRadius = 30;
            this.bt_DateYesterday.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateYesterday.Location = new System.Drawing.Point(141, 93);
            this.bt_DateYesterday.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateYesterday.Name = "bt_DateYesterday";
            this.bt_DateYesterday.Size = new System.Drawing.Size(107, 30);
            this.bt_DateYesterday.TabIndex = 78;
            this.bt_DateYesterday.Text = "Yesterday";
            this.bt_DateYesterday.Click += new System.EventHandler(this.bt_DateYesterday_Click);
            // 
            // bt_DateToday
            // 
            this.bt_DateToday.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_DateToday.CornerRadius = 30;
            this.bt_DateToday.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DateToday.Location = new System.Drawing.Point(22, 93);
            this.bt_DateToday.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_DateToday.Name = "bt_DateToday";
            this.bt_DateToday.Size = new System.Drawing.Size(107, 30);
            this.bt_DateToday.TabIndex = 77;
            this.bt_DateToday.Text = "Today";
            this.bt_DateToday.Click += new System.EventHandler(this.bt_DateToday_Click);
            // 
            // bt_Excel
            // 
            this.bt_Excel.CornerRadius = 30;
            this.bt_Excel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Excel.Location = new System.Drawing.Point(750, 5);
            this.bt_Excel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Excel.Name = "bt_Excel";
            this.bt_Excel.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Excel.Size = new System.Drawing.Size(122, 40);
            this.bt_Excel.TabIndex = 44;
            this.bt_Excel.Text = "Excel";
            this.bt_Excel.Click += new System.EventHandler(this.bt_Excel_Click);
            // 
            // bt_Query
            // 
            this.bt_Query.CornerRadius = 30;
            this.bt_Query.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Query.Location = new System.Drawing.Point(619, 5);
            this.bt_Query.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Query.Size = new System.Drawing.Size(122, 40);
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
            this.bt_Exit.Location = new System.Drawing.Point(880, 5);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(122, 40);
            this.bt_Exit.TabIndex = 42;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Print
            // 
            this.bt_Print.CornerRadius = 30;
            this.bt_Print.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Print.Location = new System.Drawing.Point(619, 49);
            this.bt_Print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Print.Size = new System.Drawing.Size(122, 40);
            this.bt_Print.TabIndex = 41;
            this.bt_Print.Text = "Print";
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // bt_Email
            // 
            this.bt_Email.CornerRadius = 30;
            this.bt_Email.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Email.Location = new System.Drawing.Point(750, 49);
            this.bt_Email.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Email.Name = "bt_Email";
            this.bt_Email.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Email.Size = new System.Drawing.Size(122, 40);
            this.bt_Email.TabIndex = 86;
            this.bt_Email.Text = "Email";
            this.bt_Email.Click += new System.EventHandler(this.bt_Email_Click);
            // 
            // frmSalesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.bt_Email);
            this.Controls.Add(this.chart_DailyTrend);
            this.Controls.Add(this.bt_DailyTrend);
            this.Controls.Add(this.bt_DateThisYear);
            this.Controls.Add(this.bt_DateLast3M);
            this.Controls.Add(this.bt_DateLastMonth);
            this.Controls.Add(this.bt_DateThisMonth);
            this.Controls.Add(this.bt_DateThisWeek);
            this.Controls.Add(this.bt_DateYesterday);
            this.Controls.Add(this.bt_DateToday);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSalesReport";
            this.Text = "Sales Report";
            this.Load += new System.EventHandler(this.frmSalesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTender)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_DailyTrend)).EndInit();
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
        private SDCafeCommon.Utilities.CustomButton bt_DateThisYear;
        private SDCafeCommon.Utilities.CustomButton bt_DateLast3M;
        private SDCafeCommon.Utilities.CustomButton bt_DateLastMonth;
        private SDCafeCommon.Utilities.CustomButton bt_DateThisMonth;
        private SDCafeCommon.Utilities.CustomButton bt_DateThisWeek;
        private SDCafeCommon.Utilities.CustomButton bt_DateYesterday;
        private SDCafeCommon.Utilities.CustomButton bt_DateToday;
        private SDCafeCommon.Utilities.CustomButton bt_DailyTrend;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_DailyTrend;
        private SDCafeCommon.Utilities.CustomButton bt_Email;
    }
}