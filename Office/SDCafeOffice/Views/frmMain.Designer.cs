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
            this.bt_Tax = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SysConfig = new SDCafeCommon.Utilities.CustomButton();
            this.bt_RFIDTags = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProdType = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_LoginUser = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Product = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Station = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SalesReport = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData
            // 
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(160, 65);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(836, 624);
            this.dgvData.TabIndex = 1;
            this.dgvData.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dgvData_MouseClick);
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
            this.bt_SysConfig.Location = new System.Drawing.Point(456, 12);
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
            this.bt_RFIDTags.BackColor = System.Drawing.Color.LightGreen;
            this.bt_RFIDTags.CornerRadius = 30;
            this.bt_RFIDTags.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_RFIDTags.Location = new System.Drawing.Point(12, 118);
            this.bt_RFIDTags.Name = "bt_RFIDTags";
            this.bt_RFIDTags.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_RFIDTags.Size = new System.Drawing.Size(142, 47);
            this.bt_RFIDTags.TabIndex = 7;
            this.bt_RFIDTags.Text = "RFID Tags";
            this.bt_RFIDTags.Click += new System.EventHandler(this.bt_RFIDTags_Click);
            // 
            // bt_ProdType
            // 
            this.bt_ProdType.BackColor = System.Drawing.Color.LightGreen;
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
            this.bt_Product.Location = new System.Drawing.Point(12, 12);
            this.bt_Product.Name = "bt_Product";
            this.bt_Product.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Product.Size = new System.Drawing.Size(142, 47);
            this.bt_Product.TabIndex = 3;
            this.bt_Product.Text = "Product";
            this.bt_Product.Click += new System.EventHandler(this.bt_Product_Click);
            // 
            // bt_Station
            // 
            this.bt_Station.BackColor = System.Drawing.Color.LightGreen;
            this.bt_Station.CornerRadius = 30;
            this.bt_Station.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Station.Location = new System.Drawing.Point(12, 171);
            this.bt_Station.Name = "bt_Station";
            this.bt_Station.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Station.Size = new System.Drawing.Size(142, 47);
            this.bt_Station.TabIndex = 35;
            this.bt_Station.Text = "Station";
            this.bt_Station.Click += new System.EventHandler(this.bt_Station_Click);
            // 
            // bt_SalesReport
            // 
            this.bt_SalesReport.BackColor = System.Drawing.Color.DarkGray;
            this.bt_SalesReport.CornerRadius = 30;
            this.bt_SalesReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SalesReport.Location = new System.Drawing.Point(12, 642);
            this.bt_SalesReport.Name = "bt_SalesReport";
            this.bt_SalesReport.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_SalesReport.Size = new System.Drawing.Size(142, 47);
            this.bt_SalesReport.TabIndex = 36;
            this.bt_SalesReport.Text = "Sales Report";
            this.bt_SalesReport.Click += new System.EventHandler(this.bt_SalesReport_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
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
            this.Controls.Add(this.dgvData);
            this.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.Name = "frmMain";
            this.Text = "frmMain";
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
    }
}