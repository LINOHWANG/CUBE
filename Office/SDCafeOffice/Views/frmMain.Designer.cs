namespace SDCafeOffice
{
    partial class frmMain
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.cb_PType = new System.Windows.Forms.ComboBox();
            this.text_BarCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.text_PName = new System.Windows.Forms.TextBox();
            this.progBarExport = new System.Windows.Forms.ProgressBar();
            this.chk_IsManual = new System.Windows.Forms.CheckBox();
            this.chk_IsMainSales = new System.Windows.Forms.CheckBox();
            this.chk_IsSales = new System.Windows.Forms.CheckBox();
            this.chk_IsAll = new System.Windows.Forms.CheckBox();
            this.bt_Stop = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProductImport = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProductExport = new SDCafeCommon.Utilities.CustomButton();
            this.bt_TimeReport = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Promotion = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SalesReport = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Station = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Tax = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SysConfig = new SDCafeCommon.Utilities.CustomButton();
            this.bt_RFIDTags = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProdType = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_LoginUser = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Product = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(160, 171);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(836, 624);
            this.dgvData.TabIndex = 1;
            this.dgvData.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_CellMouseDoubleClick);
            this.dgvData.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvData_ColumnHeaderMouseClick);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(3, 695);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(1003, 32);
            this.txtMessage.TabIndex = 34;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cb_PType
            // 
            this.cb_PType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_PType.FormattingEnabled = true;
            this.cb_PType.Location = new System.Drawing.Point(160, 75);
            this.cb_PType.Name = "cb_PType";
            this.cb_PType.Size = new System.Drawing.Size(208, 30);
            this.cb_PType.TabIndex = 38;
            this.cb_PType.SelectedIndexChanged += new System.EventHandler(this.cb_PType_SelectedIndexChanged);
            this.cb_PType.TextChanged += new System.EventHandler(this.cb_PType_TextChanged);
            // 
            // text_BarCode
            // 
            this.text_BarCode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.text_BarCode.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_BarCode.Location = new System.Drawing.Point(769, 75);
            this.text_BarCode.Name = "text_BarCode";
            this.text_BarCode.Size = new System.Drawing.Size(227, 29);
            this.text_BarCode.TabIndex = 39;
            this.text_BarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_BarCode_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(666, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "BarCode";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(375, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "PName";
            // 
            // text_PName
            // 
            this.text_PName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_PName.Location = new System.Drawing.Point(456, 75);
            this.text_PName.Name = "text_PName";
            this.text_PName.Size = new System.Drawing.Size(204, 29);
            this.text_PName.TabIndex = 41;
            this.text_PName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.text_PName_KeyPress);
            // 
            // progBarExport
            // 
            this.progBarExport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progBarExport.ForeColor = System.Drawing.SystemColors.ControlText;
            this.progBarExport.Location = new System.Drawing.Point(3, 698);
            this.progBarExport.Name = "progBarExport";
            this.progBarExport.Size = new System.Drawing.Size(1003, 29);
            this.progBarExport.Step = 1;
            this.progBarExport.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progBarExport.TabIndex = 45;
            this.progBarExport.Visible = false;
            // 
            // chk_IsManual
            // 
            this.chk_IsManual.AutoSize = true;
            this.chk_IsManual.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsManual.Location = new System.Drawing.Point(367, 118);
            this.chk_IsManual.Name = "chk_IsManual";
            this.chk_IsManual.Size = new System.Drawing.Size(126, 23);
            this.chk_IsManual.TabIndex = 47;
            this.chk_IsManual.Text = "Manual Price";
            this.chk_IsManual.UseVisualStyleBackColor = true;
            // 
            // chk_IsMainSales
            // 
            this.chk_IsMainSales.AutoSize = true;
            this.chk_IsMainSales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsMainSales.Location = new System.Drawing.Point(524, 118);
            this.chk_IsMainSales.Name = "chk_IsMainSales";
            this.chk_IsMainSales.Size = new System.Drawing.Size(247, 23);
            this.chk_IsMainSales.TabIndex = 48;
            this.chk_IsMainSales.Text = "Show on Main Sales Buttons";
            this.chk_IsMainSales.UseVisualStyleBackColor = true;
            // 
            // chk_IsSales
            // 
            this.chk_IsSales.AutoSize = true;
            this.chk_IsSales.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsSales.Location = new System.Drawing.Point(788, 118);
            this.chk_IsSales.Name = "chk_IsSales";
            this.chk_IsSales.Size = new System.Drawing.Size(183, 23);
            this.chk_IsSales.TabIndex = 49;
            this.chk_IsSales.Text = "Show Sales Buttons";
            this.chk_IsSales.UseVisualStyleBackColor = true;
            // 
            // chk_IsAll
            // 
            this.chk_IsAll.AutoSize = true;
            this.chk_IsAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_IsAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chk_IsAll.Location = new System.Drawing.Point(243, 118);
            this.chk_IsAll.Name = "chk_IsAll";
            this.chk_IsAll.Size = new System.Drawing.Size(47, 23);
            this.chk_IsAll.TabIndex = 51;
            this.chk_IsAll.Text = "All";
            this.chk_IsAll.UseVisualStyleBackColor = true;
            this.chk_IsAll.CheckedChanged += new System.EventHandler(this.chk_IsAll_CheckedChanged);
            // 
            // bt_Stop
            // 
            this.bt_Stop.BackColor = System.Drawing.Color.DarkRed;
            this.bt_Stop.CornerRadius = 30;
            this.bt_Stop.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Stop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bt_Stop.Location = new System.Drawing.Point(352, 698);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Stop.Size = new System.Drawing.Size(295, 29);
            this.bt_Stop.TabIndex = 50;
            this.bt_Stop.Text = "Stop";
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // bt_ProductImport
            // 
            this.bt_ProductImport.BackColor = System.Drawing.Color.Tomato;
            this.bt_ProductImport.CornerRadius = 30;
            this.bt_ProductImport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProductImport.Location = new System.Drawing.Point(12, 224);
            this.bt_ProductImport.Name = "bt_ProductImport";
            this.bt_ProductImport.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_ProductImport.Size = new System.Drawing.Size(142, 47);
            this.bt_ProductImport.TabIndex = 46;
            this.bt_ProductImport.Text = "Prod. Import";
            this.bt_ProductImport.Click += new System.EventHandler(this.bt_ProductImport_Click);
            // 
            // bt_ProductExport
            // 
            this.bt_ProductExport.BackColor = System.Drawing.Color.ForestGreen;
            this.bt_ProductExport.CornerRadius = 30;
            this.bt_ProductExport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProductExport.Location = new System.Drawing.Point(12, 171);
            this.bt_ProductExport.Name = "bt_ProductExport";
            this.bt_ProductExport.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_ProductExport.Size = new System.Drawing.Size(142, 47);
            this.bt_ProductExport.TabIndex = 44;
            this.bt_ProductExport.Text = "Prod. Export";
            this.bt_ProductExport.Click += new System.EventHandler(this.bt_ProductExport_Click);
            // 
            // bt_TimeReport
            // 
            this.bt_TimeReport.BackColor = System.Drawing.Color.Khaki;
            this.bt_TimeReport.CornerRadius = 30;
            this.bt_TimeReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TimeReport.Location = new System.Drawing.Point(12, 436);
            this.bt_TimeReport.Name = "bt_TimeReport";
            this.bt_TimeReport.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_TimeReport.Size = new System.Drawing.Size(142, 47);
            this.bt_TimeReport.TabIndex = 43;
            this.bt_TimeReport.Text = "Time Report";
            this.bt_TimeReport.Click += new System.EventHandler(this.bt_TimeReport_Click);
            // 
            // bt_Promotion
            // 
            this.bt_Promotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_Promotion.CornerRadius = 30;
            this.bt_Promotion.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Promotion.Location = new System.Drawing.Point(12, 277);
            this.bt_Promotion.Name = "bt_Promotion";
            this.bt_Promotion.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Promotion.Size = new System.Drawing.Size(142, 47);
            this.bt_Promotion.TabIndex = 37;
            this.bt_Promotion.Text = "Promotions";
            this.bt_Promotion.Click += new System.EventHandler(this.bt_Promotion_Click);
            // 
            // bt_SalesReport
            // 
            this.bt_SalesReport.BackColor = System.Drawing.Color.DarkGray;
            this.bt_SalesReport.CornerRadius = 30;
            this.bt_SalesReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SalesReport.Location = new System.Drawing.Point(12, 383);
            this.bt_SalesReport.Name = "bt_SalesReport";
            this.bt_SalesReport.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_SalesReport.Size = new System.Drawing.Size(142, 47);
            this.bt_SalesReport.TabIndex = 36;
            this.bt_SalesReport.Text = "Sales Report";
            this.bt_SalesReport.Click += new System.EventHandler(this.bt_SalesReport_Click);
            // 
            // bt_Station
            // 
            this.bt_Station.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_Station.CornerRadius = 30;
            this.bt_Station.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Station.Location = new System.Drawing.Point(456, 12);
            this.bt_Station.Name = "bt_Station";
            this.bt_Station.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Station.Size = new System.Drawing.Size(142, 47);
            this.bt_Station.TabIndex = 35;
            this.bt_Station.Text = "Station";
            this.bt_Station.Click += new System.EventHandler(this.bt_Station_Click);
            // 
            // bt_Tax
            // 
            this.bt_Tax.BackColor = System.Drawing.Color.DarkOrange;
            this.bt_Tax.CornerRadius = 30;
            this.bt_Tax.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Tax.Location = new System.Drawing.Point(308, 12);
            this.bt_Tax.Name = "bt_Tax";
            this.bt_Tax.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Tax.Size = new System.Drawing.Size(142, 47);
            this.bt_Tax.TabIndex = 9;
            this.bt_Tax.Text = "Tax";
            this.bt_Tax.Click += new System.EventHandler(this.bt_Tax_Click);
            // 
            // bt_SysConfig
            // 
            this.bt_SysConfig.BackColor = System.Drawing.Color.Orchid;
            this.bt_SysConfig.CornerRadius = 30;
            this.bt_SysConfig.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SysConfig.Location = new System.Drawing.Point(604, 12);
            this.bt_SysConfig.Name = "bt_SysConfig";
            this.bt_SysConfig.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_SysConfig.Size = new System.Drawing.Size(142, 47);
            this.bt_SysConfig.TabIndex = 8;
            this.bt_SysConfig.Text = "Sys Config";
            this.bt_SysConfig.Click += new System.EventHandler(this.bt_SysConfig_Click);
            // 
            // bt_RFIDTags
            // 
            this.bt_RFIDTags.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bt_RFIDTags.CornerRadius = 30;
            this.bt_RFIDTags.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RFIDTags.Location = new System.Drawing.Point(12, 645);
            this.bt_RFIDTags.Name = "bt_RFIDTags";
            this.bt_RFIDTags.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_RFIDTags.Size = new System.Drawing.Size(142, 47);
            this.bt_RFIDTags.TabIndex = 7;
            this.bt_RFIDTags.Text = "RFID Tags";
            this.bt_RFIDTags.Visible = false;
            this.bt_RFIDTags.Click += new System.EventHandler(this.bt_RFIDTags_Click);
            // 
            // bt_ProdType
            // 
            this.bt_ProdType.BackColor = System.Drawing.Color.GreenYellow;
            this.bt_ProdType.CornerRadius = 30;
            this.bt_ProdType.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProdType.Location = new System.Drawing.Point(12, 65);
            this.bt_ProdType.Name = "bt_ProdType";
            this.bt_ProdType.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_ProdType.Size = new System.Drawing.Size(142, 47);
            this.bt_ProdType.TabIndex = 6;
            this.bt_ProdType.Text = "Prod Type";
            this.bt_ProdType.Click += new System.EventHandler(this.bt_ProdType_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(854, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 5;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_LoginUser
            // 
            this.bt_LoginUser.BackColor = System.Drawing.Color.Khaki;
            this.bt_LoginUser.CornerRadius = 30;
            this.bt_LoginUser.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_LoginUser.Location = new System.Drawing.Point(160, 12);
            this.bt_LoginUser.Name = "bt_LoginUser";
            this.bt_LoginUser.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_LoginUser.Size = new System.Drawing.Size(142, 47);
            this.bt_LoginUser.TabIndex = 4;
            this.bt_LoginUser.Text = "Login Users";
            this.bt_LoginUser.Click += new System.EventHandler(this.bt_LoginUser_Click);
            // 
            // bt_Product
            // 
            this.bt_Product.BackColor = System.Drawing.Color.LightGreen;
            this.bt_Product.CornerRadius = 30;
            this.bt_Product.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Product.Location = new System.Drawing.Point(12, 118);
            this.bt_Product.Name = "bt_Product";
            this.bt_Product.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Product.Size = new System.Drawing.Size(142, 47);
            this.bt_Product.TabIndex = 3;
            this.bt_Product.Text = "Product";
            this.bt_Product.Click += new System.EventHandler(this.bt_Product_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.bt_Stop);
            this.Controls.Add(this.bt_ProductImport);
            this.Controls.Add(this.progBarExport);
            this.Controls.Add(this.bt_ProductExport);
            this.Controls.Add(this.bt_TimeReport);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_PName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_BarCode);
            this.Controls.Add(this.cb_PType);
            this.Controls.Add(this.bt_Promotion);
            this.Controls.Add(this.bt_SalesReport);
            this.Controls.Add(this.bt_Station);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.bt_Tax);
            this.Controls.Add(this.bt_SysConfig);
            this.Controls.Add(this.bt_RFIDTags);
            this.Controls.Add(this.bt_ProdType);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_LoginUser);
            this.Controls.Add(this.bt_Product);
            this.Controls.Add(this.chk_IsSales);
            this.Controls.Add(this.chk_IsMainSales);
            this.Controls.Add(this.chk_IsManual);
            this.Controls.Add(this.chk_IsAll);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmMain";
            this.Text = "Office Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvData;
        private SDCafeCommon.Utilities.CustomButton bt_Product;
        private SDCafeCommon.Utilities.CustomButton bt_LoginUser;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_ProdType;
        private SDCafeCommon.Utilities.CustomButton bt_RFIDTags;
        private SDCafeCommon.Utilities.CustomButton bt_SysConfig;
        private SDCafeCommon.Utilities.CustomButton bt_Tax;
        private System.Windows.Forms.TextBox txtMessage;
        private SDCafeCommon.Utilities.CustomButton bt_Station;
        private SDCafeCommon.Utilities.CustomButton bt_SalesReport;
        private SDCafeCommon.Utilities.CustomButton bt_Promotion;
        private System.Windows.Forms.ComboBox cb_PType;
        private System.Windows.Forms.TextBox text_BarCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_PName;
        private SDCafeCommon.Utilities.CustomButton bt_TimeReport;
        private SDCafeCommon.Utilities.CustomButton bt_ProductExport;
        private System.Windows.Forms.ProgressBar progBarExport;
        private SDCafeCommon.Utilities.CustomButton bt_ProductImport;
        private System.Windows.Forms.CheckBox chk_IsManual;
        private System.Windows.Forms.CheckBox chk_IsMainSales;
        private System.Windows.Forms.CheckBox chk_IsSales;
        private SDCafeCommon.Utilities.CustomButton bt_Stop;
        private System.Windows.Forms.CheckBox chk_IsAll;
    }
}