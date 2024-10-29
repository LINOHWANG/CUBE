namespace SDCafeSales.Views
{
    partial class frmSalesMain
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SubTotal = new System.Windows.Forms.TextBox();
            this.txt_TaxTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_TotalDue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelectedMenu = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.pnlPType = new System.Windows.Forms.Panel();
            this.bt_SetPPL = new SDCafeCommon.Utilities.CustomButton();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQTY = new System.Windows.Forms.TextBox();
            this.txtAmtEach = new System.Windows.Forms.TextBox();
            this.textNow = new System.Windows.Forms.TextBox();
            this.timerSetTime = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_SetIOneDollarDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetITwoDollarDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetIThreeDollarDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_EditPrice = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetReturn = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ManualPrice = new SDCafeCommon.Utilities.CustomButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbl_TypePages = new System.Windows.Forms.Label();
            this.pnlSideBar = new System.Windows.Forms.Panel();
            this.bt_RecallOrder = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SaveOrder = new SDCafeCommon.Utilities.CustomButton();
            this.bt_OpenCashDrawer = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SalesHistory = new SDCafeCommon.Utilities.CustomButton();
            this.bt_HideSideBar = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Start = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ShowAllMenuItem = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SalesCustomer = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Stop = new SDCafeCommon.Utilities.CustomButton();
            this.lbl_ProdPages = new System.Windows.Forms.Label();
            this.txtBarCode = new System.Windows.Forms.TextBox();
            this.lblBarCode2 = new System.Windows.Forms.Label();
            this.timerExtendBar = new System.Windows.Forms.Timer(this.components);
            this.bt_Plus = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Minus = new SDCafeCommon.Utilities.CustomButton();
            this.bt_cashPayment = new SDCafeCommon.Utilities.CustomButton();
            this.bt_AutoReceipt = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetQTY = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetItemDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_OpenCashDrawer1 = new SDCafeCommon.Utilities.CustomButton();
            this.bt_VoidAll = new SDCafeCommon.Utilities.CustomButton();
            this.bt_TypePageDown = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProdPageUp = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ProdPageDown = new SDCafeCommon.Utilities.CustomButton();
            this.bt_TypePageUp = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PrintInvoice = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Void = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ShowSideBar = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Payment = new SDCafeCommon.Utilities.CustomButton();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.bt_NumTypeToggle = new SDCafeCommon.Utilities.CustomButton();
            this.bt_LastReprint = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).BeginInit();
            this.pnlPType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnlSideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_Orders
            // 
            this.dgv_Orders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Orders.Location = new System.Drawing.Point(5, 4);
            this.dgv_Orders.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dgv_Orders.Name = "dgv_Orders";
            this.dgv_Orders.ReadOnly = true;
            this.dgv_Orders.RowHeadersVisible = false;
            this.dgv_Orders.Size = new System.Drawing.Size(387, 432);
            this.dgv_Orders.TabIndex = 7;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Location = new System.Drawing.Point(395, 4);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(608, 393);
            this.pnlMenu.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(10, 532);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Sub Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_SubTotal
            // 
            this.txt_SubTotal.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SubTotal.Location = new System.Drawing.Point(111, 525);
            this.txt_SubTotal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_SubTotal.Name = "txt_SubTotal";
            this.txt_SubTotal.ReadOnly = true;
            this.txt_SubTotal.Size = new System.Drawing.Size(110, 35);
            this.txt_SubTotal.TabIndex = 10;
            this.txt_SubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_TaxTotal
            // 
            this.txt_TaxTotal.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TaxTotal.Location = new System.Drawing.Point(111, 563);
            this.txt_TaxTotal.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_TaxTotal.Name = "txt_TaxTotal";
            this.txt_TaxTotal.ReadOnly = true;
            this.txt_TaxTotal.Size = new System.Drawing.Size(110, 35);
            this.txt_TaxTotal.TabIndex = 12;
            this.txt_TaxTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.NavajoWhite;
            this.label2.Location = new System.Drawing.Point(64, 570);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 22);
            this.label2.TabIndex = 11;
            this.label2.Text = "Tax";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_TotalDue
            // 
            this.txt_TotalDue.BackColor = System.Drawing.Color.Yellow;
            this.txt_TotalDue.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDue.Location = new System.Drawing.Point(111, 602);
            this.txt_TotalDue.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_TotalDue.Name = "txt_TotalDue";
            this.txt_TotalDue.ReadOnly = true;
            this.txt_TotalDue.Size = new System.Drawing.Size(110, 35);
            this.txt_TotalDue.TabIndex = 14;
            this.txt_TotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(10, 609);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 22);
            this.label3.TabIndex = 13;
            this.label3.Text = "Total Due";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSelectedMenu
            // 
            this.txtSelectedMenu.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtSelectedMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSelectedMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedMenu.ForeColor = System.Drawing.SystemColors.Info;
            this.txtSelectedMenu.Location = new System.Drawing.Point(4, 699);
            this.txtSelectedMenu.Name = "txtSelectedMenu";
            this.txtSelectedMenu.Size = new System.Drawing.Size(877, 26);
            this.txtSelectedMenu.TabIndex = 19;
            this.txtSelectedMenu.Text = "Messages";
            // 
            // txtCount
            // 
            this.txtCount.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCount.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCount.ForeColor = System.Drawing.SystemColors.Info;
            this.txtCount.Location = new System.Drawing.Point(111, 487);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(110, 35);
            this.txtCount.TabIndex = 20;
            this.txtCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(402, 460);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(252, 98);
            this.listView1.TabIndex = 21;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(660, 441);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(221, 117);
            this.listView2.TabIndex = 22;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label4.Location = new System.Drawing.Point(9, 491);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 22);
            this.label4.TabIndex = 23;
            this.label4.Text = "# of Items";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlPType
            // 
            this.pnlPType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlPType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPType.Controls.Add(this.bt_SetPPL);
            this.pnlPType.Location = new System.Drawing.Point(395, 399);
            this.pnlPType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlPType.Name = "pnlPType";
            this.pnlPType.Size = new System.Drawing.Size(608, 159);
            this.pnlPType.TabIndex = 9;
            // 
            // bt_SetPPL
            // 
            this.bt_SetPPL.BackColor = System.Drawing.Color.Silver;
            this.bt_SetPPL.CornerRadius = 20;
            this.bt_SetPPL.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetPPL.ForeColor = System.Drawing.Color.Black;
            this.bt_SetPPL.Location = new System.Drawing.Point(-57, -12);
            this.bt_SetPPL.Name = "bt_SetPPL";
            this.bt_SetPPL.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetPPL.Size = new System.Drawing.Size(93, 38);
            this.bt_SetPPL.TabIndex = 33;
            this.bt_SetPPL.Text = "Set Guests";
            this.bt_SetPPL.Visible = false;
            this.bt_SetPPL.Click += new System.EventHandler(this.bt_SetPPL_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label5.Location = new System.Drawing.Point(160, 446);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 29);
            this.label5.TabIndex = 25;
            this.label5.Text = "QTY";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // txtQTY
            // 
            this.txtQTY.BackColor = System.Drawing.SystemColors.Info;
            this.txtQTY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQTY.Font = new System.Drawing.Font("Arial Narrow", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQTY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtQTY.Location = new System.Drawing.Point(154, 442);
            this.txtQTY.Name = "txtQTY";
            this.txtQTY.Size = new System.Drawing.Size(136, 38);
            this.txtQTY.TabIndex = 26;
            this.txtQTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQTY.Click += new System.EventHandler(this.txtQTY_Click);
            // 
            // txtAmtEach
            // 
            this.txtAmtEach.BackColor = System.Drawing.SystemColors.Info;
            this.txtAmtEach.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmtEach.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmtEach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAmtEach.Location = new System.Drawing.Point(-7, 399);
            this.txtAmtEach.Name = "txtAmtEach";
            this.txtAmtEach.Size = new System.Drawing.Size(90, 35);
            this.txtAmtEach.TabIndex = 34;
            this.txtAmtEach.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtAmtEach.Visible = false;
            this.txtAmtEach.Click += new System.EventHandler(this.txtAmtEach_Click);
            // 
            // textNow
            // 
            this.textNow.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textNow.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textNow.ForeColor = System.Drawing.SystemColors.Info;
            this.textNow.Location = new System.Drawing.Point(819, 699);
            this.textNow.Name = "textNow";
            this.textNow.Size = new System.Drawing.Size(184, 26);
            this.textNow.TabIndex = 48;
            this.textNow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timerSetTime
            // 
            this.timerSetTime.Enabled = true;
            this.timerSetTime.Interval = 1000;
            this.timerSetTime.Tick += new System.EventHandler(this.timerSetTime_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.bt_SetIOneDollarDiscount);
            this.panel1.Controls.Add(this.bt_SetITwoDollarDiscount);
            this.panel1.Controls.Add(this.bt_SetIThreeDollarDiscount);
            this.panel1.Controls.Add(this.bt_EditPrice);
            this.panel1.Controls.Add(this.bt_SetReturn);
            this.panel1.Controls.Add(this.bt_ManualPrice);
            this.panel1.Location = new System.Drawing.Point(227, 483);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(164, 158);
            this.panel1.TabIndex = 49;
            // 
            // bt_SetIOneDollarDiscount
            // 
            this.bt_SetIOneDollarDiscount.BackColor = System.Drawing.Color.White;
            this.bt_SetIOneDollarDiscount.CornerRadius = 20;
            this.bt_SetIOneDollarDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetIOneDollarDiscount.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_SetIOneDollarDiscount.Location = new System.Drawing.Point(5, 4);
            this.bt_SetIOneDollarDiscount.Name = "bt_SetIOneDollarDiscount";
            this.bt_SetIOneDollarDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetIOneDollarDiscount.Size = new System.Drawing.Size(75, 47);
            this.bt_SetIOneDollarDiscount.TabIndex = 47;
            this.bt_SetIOneDollarDiscount.Text = "$1 Disc";
            this.bt_SetIOneDollarDiscount.Click += new System.EventHandler(this.bt_SetIOneDollarDiscount_Click);
            // 
            // bt_SetITwoDollarDiscount
            // 
            this.bt_SetITwoDollarDiscount.BackColor = System.Drawing.Color.White;
            this.bt_SetITwoDollarDiscount.CornerRadius = 20;
            this.bt_SetITwoDollarDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetITwoDollarDiscount.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_SetITwoDollarDiscount.Location = new System.Drawing.Point(5, 54);
            this.bt_SetITwoDollarDiscount.Name = "bt_SetITwoDollarDiscount";
            this.bt_SetITwoDollarDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetITwoDollarDiscount.Size = new System.Drawing.Size(75, 47);
            this.bt_SetITwoDollarDiscount.TabIndex = 46;
            this.bt_SetITwoDollarDiscount.Text = "$2 Disc";
            this.bt_SetITwoDollarDiscount.Click += new System.EventHandler(this.bt_SetITwoDollarDiscount_Click);
            // 
            // bt_SetIThreeDollarDiscount
            // 
            this.bt_SetIThreeDollarDiscount.BackColor = System.Drawing.Color.White;
            this.bt_SetIThreeDollarDiscount.CornerRadius = 20;
            this.bt_SetIThreeDollarDiscount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetIThreeDollarDiscount.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_SetIThreeDollarDiscount.Location = new System.Drawing.Point(5, 104);
            this.bt_SetIThreeDollarDiscount.Name = "bt_SetIThreeDollarDiscount";
            this.bt_SetIThreeDollarDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetIThreeDollarDiscount.Size = new System.Drawing.Size(75, 47);
            this.bt_SetIThreeDollarDiscount.TabIndex = 45;
            this.bt_SetIThreeDollarDiscount.Text = "$3 Disc";
            this.bt_SetIThreeDollarDiscount.Click += new System.EventHandler(this.bt_SetIThreeDollarDiscount_Click);
            // 
            // bt_EditPrice
            // 
            this.bt_EditPrice.BackColor = System.Drawing.Color.White;
            this.bt_EditPrice.CornerRadius = 20;
            this.bt_EditPrice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_EditPrice.ForeColor = System.Drawing.Color.Black;
            this.bt_EditPrice.Location = new System.Drawing.Point(84, 4);
            this.bt_EditPrice.Name = "bt_EditPrice";
            this.bt_EditPrice.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_EditPrice.Size = new System.Drawing.Size(75, 47);
            this.bt_EditPrice.TabIndex = 42;
            this.bt_EditPrice.Text = "Edit Amount";
            this.bt_EditPrice.Click += new System.EventHandler(this.bt_EditPrice_Click);
            // 
            // bt_SetReturn
            // 
            this.bt_SetReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_SetReturn.CornerRadius = 20;
            this.bt_SetReturn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetReturn.ForeColor = System.Drawing.Color.Black;
            this.bt_SetReturn.Location = new System.Drawing.Point(83, 104);
            this.bt_SetReturn.Name = "bt_SetReturn";
            this.bt_SetReturn.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetReturn.Size = new System.Drawing.Size(75, 47);
            this.bt_SetReturn.TabIndex = 40;
            this.bt_SetReturn.Text = "Set Return";
            this.bt_SetReturn.Click += new System.EventHandler(this.bt_SetReturn_Click);
            // 
            // bt_ManualPrice
            // 
            this.bt_ManualPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_ManualPrice.CornerRadius = 20;
            this.bt_ManualPrice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.bt_ManualPrice.ForeColor = System.Drawing.Color.Black;
            this.bt_ManualPrice.Location = new System.Drawing.Point(83, 54);
            this.bt_ManualPrice.Name = "bt_ManualPrice";
            this.bt_ManualPrice.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ManualPrice.Size = new System.Drawing.Size(75, 47);
            this.bt_ManualPrice.TabIndex = 41;
            this.bt_ManualPrice.Text = "Manual Item";
            this.bt_ManualPrice.Click += new System.EventHandler(this.bt_ManualPrice_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(4, 483);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 158);
            this.panel2.TabIndex = 50;
            // 
            // lbl_TypePages
            // 
            this.lbl_TypePages.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TypePages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_TypePages.Location = new System.Drawing.Point(677, 570);
            this.lbl_TypePages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TypePages.Name = "lbl_TypePages";
            this.lbl_TypePages.Size = new System.Drawing.Size(57, 19);
            this.lbl_TypePages.TabIndex = 55;
            this.lbl_TypePages.Text = "Pages";
            this.lbl_TypePages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSideBar
            // 
            this.pnlSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlSideBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSideBar.Controls.Add(this.bt_RecallOrder);
            this.pnlSideBar.Controls.Add(this.bt_SaveOrder);
            this.pnlSideBar.Controls.Add(this.bt_OpenCashDrawer);
            this.pnlSideBar.Controls.Add(this.bt_SalesHistory);
            this.pnlSideBar.Controls.Add(this.bt_HideSideBar);
            this.pnlSideBar.Controls.Add(this.bt_Exit);
            this.pnlSideBar.Controls.Add(this.bt_Start);
            this.pnlSideBar.Controls.Add(this.bt_ShowAllMenuItem);
            this.pnlSideBar.Controls.Add(this.bt_SalesCustomer);
            this.pnlSideBar.Controls.Add(this.bt_Stop);
            this.pnlSideBar.Location = new System.Drawing.Point(862, 4);
            this.pnlSideBar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlSideBar.Name = "pnlSideBar";
            this.pnlSideBar.Size = new System.Drawing.Size(145, 689);
            this.pnlSideBar.TabIndex = 58;
            // 
            // bt_RecallOrder
            // 
            this.bt_RecallOrder.BackColor = System.Drawing.Color.White;
            this.bt_RecallOrder.CornerRadius = 5;
            this.bt_RecallOrder.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_RecallOrder.ForeColor = System.Drawing.Color.Black;
            this.bt_RecallOrder.Location = new System.Drawing.Point(13, 176);
            this.bt_RecallOrder.Name = "bt_RecallOrder";
            this.bt_RecallOrder.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_RecallOrder.Size = new System.Drawing.Size(116, 47);
            this.bt_RecallOrder.TabIndex = 67;
            this.bt_RecallOrder.Text = "Recall Order";
            this.bt_RecallOrder.Click += new System.EventHandler(this.bt_RecallOrder_Click);
            // 
            // bt_SaveOrder
            // 
            this.bt_SaveOrder.BackColor = System.Drawing.Color.White;
            this.bt_SaveOrder.CornerRadius = 5;
            this.bt_SaveOrder.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_SaveOrder.ForeColor = System.Drawing.Color.Black;
            this.bt_SaveOrder.Location = new System.Drawing.Point(13, 123);
            this.bt_SaveOrder.Name = "bt_SaveOrder";
            this.bt_SaveOrder.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SaveOrder.Size = new System.Drawing.Size(116, 47);
            this.bt_SaveOrder.TabIndex = 66;
            this.bt_SaveOrder.Text = "Save Order";
            this.bt_SaveOrder.Click += new System.EventHandler(this.bt_SaveOrder_Click);
            // 
            // bt_OpenCashDrawer
            // 
            this.bt_OpenCashDrawer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_OpenCashDrawer.CornerRadius = 5;
            this.bt_OpenCashDrawer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_OpenCashDrawer.ForeColor = System.Drawing.Color.Black;
            this.bt_OpenCashDrawer.Location = new System.Drawing.Point(13, 60);
            this.bt_OpenCashDrawer.Name = "bt_OpenCashDrawer";
            this.bt_OpenCashDrawer.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_OpenCashDrawer.Size = new System.Drawing.Size(116, 47);
            this.bt_OpenCashDrawer.TabIndex = 65;
            this.bt_OpenCashDrawer.Text = "Open C/D";
            this.bt_OpenCashDrawer.Click += new System.EventHandler(this.bt_OpenCashDrawer_Click);
            // 
            // bt_SalesHistory
            // 
            this.bt_SalesHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_SalesHistory.CornerRadius = 5;
            this.bt_SalesHistory.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SalesHistory.ForeColor = System.Drawing.Color.Black;
            this.bt_SalesHistory.Location = new System.Drawing.Point(13, 7);
            this.bt_SalesHistory.Name = "bt_SalesHistory";
            this.bt_SalesHistory.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SalesHistory.Size = new System.Drawing.Size(116, 47);
            this.bt_SalesHistory.TabIndex = 64;
            this.bt_SalesHistory.Text = "Sales History";
            this.bt_SalesHistory.Click += new System.EventHandler(this.bt_SalesHistory_Click);
            // 
            // bt_HideSideBar
            // 
            this.bt_HideSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_HideSideBar.CornerRadius = 20;
            this.bt_HideSideBar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_HideSideBar.ForeColor = System.Drawing.Color.Black;
            this.bt_HideSideBar.Location = new System.Drawing.Point(3, 599);
            this.bt_HideSideBar.Name = "bt_HideSideBar";
            this.bt_HideSideBar.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_HideSideBar.Size = new System.Drawing.Size(134, 29);
            this.bt_HideSideBar.TabIndex = 63;
            this.bt_HideSideBar.Text = "Hide Side Bar >>";
            this.bt_HideSideBar.Click += new System.EventHandler(this.bt_HideSideBar_Click_1);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 5;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Exit.Location = new System.Drawing.Point(13, 637);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(116, 47);
            this.bt_Exit.TabIndex = 61;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click_1);
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.Blue;
            this.bt_Start.CornerRadius = 5;
            this.bt_Start.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Start.ForeColor = System.Drawing.Color.White;
            this.bt_Start.Location = new System.Drawing.Point(13, 486);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Start.Size = new System.Drawing.Size(116, 47);
            this.bt_Start.TabIndex = 59;
            this.bt_Start.Text = "Scan";
            this.bt_Start.Visible = false;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click_1);
            // 
            // bt_ShowAllMenuItem
            // 
            this.bt_ShowAllMenuItem.BackColor = System.Drawing.Color.White;
            this.bt_ShowAllMenuItem.CornerRadius = 5;
            this.bt_ShowAllMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ShowAllMenuItem.ForeColor = System.Drawing.Color.Black;
            this.bt_ShowAllMenuItem.Location = new System.Drawing.Point(13, 537);
            this.bt_ShowAllMenuItem.Name = "bt_ShowAllMenuItem";
            this.bt_ShowAllMenuItem.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ShowAllMenuItem.Size = new System.Drawing.Size(116, 47);
            this.bt_ShowAllMenuItem.TabIndex = 58;
            this.bt_ShowAllMenuItem.Text = "Show All Menu (Popularity)";
            this.bt_ShowAllMenuItem.Click += new System.EventHandler(this.bt_ShowAllMenuItem_Click_1);
            // 
            // bt_SalesCustomer
            // 
            this.bt_SalesCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_SalesCustomer.CornerRadius = 5;
            this.bt_SalesCustomer.Enabled = false;
            this.bt_SalesCustomer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SalesCustomer.ForeColor = System.Drawing.Color.Black;
            this.bt_SalesCustomer.Location = new System.Drawing.Point(13, 60);
            this.bt_SalesCustomer.Name = "bt_SalesCustomer";
            this.bt_SalesCustomer.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SalesCustomer.Size = new System.Drawing.Size(116, 47);
            this.bt_SalesCustomer.TabIndex = 57;
            this.bt_SalesCustomer.Text = "Show Customer Order Screen";
            this.bt_SalesCustomer.Visible = false;
            this.bt_SalesCustomer.Click += new System.EventHandler(this.bt_SalesCustomer_Click);
            // 
            // bt_Stop
            // 
            this.bt_Stop.BackColor = System.Drawing.Color.DarkRed;
            this.bt_Stop.CornerRadius = 5;
            this.bt_Stop.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Stop.ForeColor = System.Drawing.Color.White;
            this.bt_Stop.Location = new System.Drawing.Point(13, 539);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Stop.Size = new System.Drawing.Size(116, 47);
            this.bt_Stop.TabIndex = 60;
            this.bt_Stop.Text = "Stop";
            this.bt_Stop.Visible = false;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click_1);
            // 
            // lbl_ProdPages
            // 
            this.lbl_ProdPages.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProdPages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_ProdPages.Location = new System.Drawing.Point(472, 572);
            this.lbl_ProdPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ProdPages.Name = "lbl_ProdPages";
            this.lbl_ProdPages.Size = new System.Drawing.Size(57, 19);
            this.lbl_ProdPages.TabIndex = 61;
            this.lbl_ProdPages.Text = "Pages";
            this.lbl_ProdPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBarCode
            // 
            this.txtBarCode.BackColor = System.Drawing.SystemColors.Info;
            this.txtBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBarCode.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBarCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBarCode.Location = new System.Drawing.Point(578, 604);
            this.txtBarCode.Name = "txtBarCode";
            this.txtBarCode.Size = new System.Drawing.Size(278, 35);
            this.txtBarCode.TabIndex = 68;
            this.txtBarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBarCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBarCode_KeyPress);
            // 
            // lblBarCode2
            // 
            this.lblBarCode2.AutoSize = true;
            this.lblBarCode2.Font = new System.Drawing.Font("IDAutomationHC39M", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCode2.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblBarCode2.Location = new System.Drawing.Point(497, 611);
            this.lblBarCode2.Name = "lblBarCode2";
            this.lblBarCode2.Size = new System.Drawing.Size(75, 25);
            this.lblBarCode2.TabIndex = 73;
            this.lblBarCode2.Text = "123456789";
            // 
            // timerExtendBar
            // 
            this.timerExtendBar.Interval = 5000;
            this.timerExtendBar.Tick += new System.EventHandler(this.timerExtendBar_Tick);
            // 
            // bt_Plus
            // 
            this.bt_Plus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Plus.CornerRadius = 20;
            this.bt_Plus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Plus.ForeColor = System.Drawing.Color.Blue;
            this.bt_Plus.Location = new System.Drawing.Point(2, 439);
            this.bt_Plus.Name = "bt_Plus";
            this.bt_Plus.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Plus.Size = new System.Drawing.Size(70, 42);
            this.bt_Plus.TabIndex = 75;
            this.bt_Plus.Text = "Plus (+)";
            this.bt_Plus.Click += new System.EventHandler(this.bt_Plus_Click);
            // 
            // bt_Minus
            // 
            this.bt_Minus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Minus.CornerRadius = 20;
            this.bt_Minus.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Minus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_Minus.Location = new System.Drawing.Point(78, 439);
            this.bt_Minus.Name = "bt_Minus";
            this.bt_Minus.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Minus.Size = new System.Drawing.Size(70, 42);
            this.bt_Minus.TabIndex = 74;
            this.bt_Minus.Text = "Minus (-)";
            this.bt_Minus.Click += new System.EventHandler(this.bt_Minus_Click);
            // 
            // bt_cashPayment
            // 
            this.bt_cashPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_cashPayment.CornerRadius = 5;
            this.bt_cashPayment.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_cashPayment.ForeColor = System.Drawing.Color.White;
            this.bt_cashPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_cashPayment.Location = new System.Drawing.Point(877, 645);
            this.bt_cashPayment.Name = "bt_cashPayment";
            this.bt_cashPayment.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_cashPayment.Size = new System.Drawing.Size(126, 47);
            this.bt_cashPayment.TabIndex = 71;
            this.bt_cashPayment.Text = "Manual / Cash Pay";
            this.bt_cashPayment.Click += new System.EventHandler(this.bt_cashPayment_Click);
            // 
            // bt_AutoReceipt
            // 
            this.bt_AutoReceipt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_AutoReceipt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bt_AutoReceipt.CornerRadius = 5;
            this.bt_AutoReceipt.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_AutoReceipt.ForeColor = System.Drawing.Color.Black;
            this.bt_AutoReceipt.ImageIndex = 0;
            this.bt_AutoReceipt.Location = new System.Drawing.Point(535, 645);
            this.bt_AutoReceipt.Name = "bt_AutoReceipt";
            this.bt_AutoReceipt.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_AutoReceipt.Size = new System.Drawing.Size(100, 47);
            this.bt_AutoReceipt.TabIndex = 69;
            this.bt_AutoReceipt.Text = "Receipt";
            this.bt_AutoReceipt.Click += new System.EventHandler(this.bt_AutoReceipt_Click);
            // 
            // bt_SetQTY
            // 
            this.bt_SetQTY.BackColor = System.Drawing.Color.Silver;
            this.bt_SetQTY.CornerRadius = 20;
            this.bt_SetQTY.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetQTY.ForeColor = System.Drawing.Color.Black;
            this.bt_SetQTY.Location = new System.Drawing.Point(296, 440);
            this.bt_SetQTY.Name = "bt_SetQTY";
            this.bt_SetQTY.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetQTY.Size = new System.Drawing.Size(95, 42);
            this.bt_SetQTY.TabIndex = 27;
            this.bt_SetQTY.Text = "Set QTY";
            this.bt_SetQTY.Click += new System.EventHandler(this.bt_SetQTY_Click);
            // 
            // bt_SetItemDiscount
            // 
            this.bt_SetItemDiscount.BackColor = System.Drawing.Color.White;
            this.bt_SetItemDiscount.CornerRadius = 5;
            this.bt_SetItemDiscount.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetItemDiscount.ForeColor = System.Drawing.Color.Maroon;
            this.bt_SetItemDiscount.Location = new System.Drawing.Point(216, 645);
            this.bt_SetItemDiscount.Name = "bt_SetItemDiscount";
            this.bt_SetItemDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetItemDiscount.Size = new System.Drawing.Size(100, 47);
            this.bt_SetItemDiscount.TabIndex = 67;
            this.bt_SetItemDiscount.Text = "Item Disc(%)";
            this.bt_SetItemDiscount.Click += new System.EventHandler(this.bt_SetItemDiscount_Click);
            // 
            // bt_OpenCashDrawer1
            // 
            this.bt_OpenCashDrawer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_OpenCashDrawer1.CornerRadius = 5;
            this.bt_OpenCashDrawer1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_OpenCashDrawer1.ForeColor = System.Drawing.Color.Black;
            this.bt_OpenCashDrawer1.Location = new System.Drawing.Point(641, 645);
            this.bt_OpenCashDrawer1.Name = "bt_OpenCashDrawer1";
            this.bt_OpenCashDrawer1.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_OpenCashDrawer1.Size = new System.Drawing.Size(100, 47);
            this.bt_OpenCashDrawer1.TabIndex = 66;
            this.bt_OpenCashDrawer1.Text = "Open C/D";
            this.bt_OpenCashDrawer1.Click += new System.EventHandler(this.bt_OpenCashDrawer1_Click);
            // 
            // bt_VoidAll
            // 
            this.bt_VoidAll.BackColor = System.Drawing.Color.DarkRed;
            this.bt_VoidAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_VoidAll.CornerRadius = 5;
            this.bt_VoidAll.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_VoidAll.ForeColor = System.Drawing.Color.White;
            this.bt_VoidAll.Location = new System.Drawing.Point(110, 645);
            this.bt_VoidAll.Name = "bt_VoidAll";
            this.bt_VoidAll.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_VoidAll.Size = new System.Drawing.Size(100, 47);
            this.bt_VoidAll.TabIndex = 56;
            this.bt_VoidAll.Text = "Void All";
            this.bt_VoidAll.Click += new System.EventHandler(this.bt_VoidAll_Click);
            // 
            // bt_TypePageDown
            // 
            this.bt_TypePageDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_TypePageDown.CornerRadius = 20;
            this.bt_TypePageDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TypePageDown.ForeColor = System.Drawing.Color.Black;
            this.bt_TypePageDown.Location = new System.Drawing.Point(734, 560);
            this.bt_TypePageDown.Name = "bt_TypePageDown";
            this.bt_TypePageDown.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_TypePageDown.Size = new System.Drawing.Size(70, 40);
            this.bt_TypePageDown.TabIndex = 54;
            this.bt_TypePageDown.Text = "Type >";
            this.bt_TypePageDown.Click += new System.EventHandler(this.bt_TypePageDown_Click);
            // 
            // bt_ProdPageUp
            // 
            this.bt_ProdPageUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_ProdPageUp.CornerRadius = 20;
            this.bt_ProdPageUp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProdPageUp.ForeColor = System.Drawing.Color.Black;
            this.bt_ProdPageUp.Location = new System.Drawing.Point(399, 560);
            this.bt_ProdPageUp.Name = "bt_ProdPageUp";
            this.bt_ProdPageUp.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ProdPageUp.Size = new System.Drawing.Size(70, 40);
            this.bt_ProdPageUp.TabIndex = 51;
            this.bt_ProdPageUp.Text = "< Prod";
            this.bt_ProdPageUp.Click += new System.EventHandler(this.bt_ProdPageUp_Click);
            // 
            // bt_ProdPageDown
            // 
            this.bt_ProdPageDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_ProdPageDown.CornerRadius = 20;
            this.bt_ProdPageDown.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProdPageDown.ForeColor = System.Drawing.Color.Black;
            this.bt_ProdPageDown.Location = new System.Drawing.Point(529, 560);
            this.bt_ProdPageDown.Name = "bt_ProdPageDown";
            this.bt_ProdPageDown.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ProdPageDown.Size = new System.Drawing.Size(70, 40);
            this.bt_ProdPageDown.TabIndex = 52;
            this.bt_ProdPageDown.Text = "Prod >";
            this.bt_ProdPageDown.Click += new System.EventHandler(this.bt_ProdPageDown_Click);
            // 
            // bt_TypePageUp
            // 
            this.bt_TypePageUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_TypePageUp.CornerRadius = 20;
            this.bt_TypePageUp.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TypePageUp.ForeColor = System.Drawing.Color.Black;
            this.bt_TypePageUp.Location = new System.Drawing.Point(607, 560);
            this.bt_TypePageUp.Name = "bt_TypePageUp";
            this.bt_TypePageUp.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_TypePageUp.Size = new System.Drawing.Size(70, 40);
            this.bt_TypePageUp.TabIndex = 53;
            this.bt_TypePageUp.Text = "< Type";
            this.bt_TypePageUp.Click += new System.EventHandler(this.bt_TypePageUp_Click);
            // 
            // bt_SetDiscount
            // 
            this.bt_SetDiscount.BackColor = System.Drawing.Color.White;
            this.bt_SetDiscount.CornerRadius = 5;
            this.bt_SetDiscount.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetDiscount.ForeColor = System.Drawing.Color.Maroon;
            this.bt_SetDiscount.Location = new System.Drawing.Point(323, 645);
            this.bt_SetDiscount.Name = "bt_SetDiscount";
            this.bt_SetDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetDiscount.Size = new System.Drawing.Size(100, 47);
            this.bt_SetDiscount.TabIndex = 43;
            this.bt_SetDiscount.Text = "Discount(%)";
            this.bt_SetDiscount.Click += new System.EventHandler(this.bt_SetDiscount_Click);
            // 
            // bt_PrintInvoice
            // 
            this.bt_PrintInvoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bt_PrintInvoice.CornerRadius = 5;
            this.bt_PrintInvoice.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_PrintInvoice.ForeColor = System.Drawing.Color.Black;
            this.bt_PrintInvoice.Location = new System.Drawing.Point(429, 626);
            this.bt_PrintInvoice.Name = "bt_PrintInvoice";
            this.bt_PrintInvoice.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PrintInvoice.Size = new System.Drawing.Size(100, 47);
            this.bt_PrintInvoice.TabIndex = 28;
            this.bt_PrintInvoice.Text = "Invoice";
            this.bt_PrintInvoice.Visible = false;
            this.bt_PrintInvoice.Click += new System.EventHandler(this.bt_PrintInvoice_Click);
            // 
            // bt_Void
            // 
            this.bt_Void.BackColor = System.Drawing.Color.DarkRed;
            this.bt_Void.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_Void.CornerRadius = 5;
            this.bt_Void.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Void.ForeColor = System.Drawing.Color.White;
            this.bt_Void.Location = new System.Drawing.Point(4, 646);
            this.bt_Void.Name = "bt_Void";
            this.bt_Void.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Void.Size = new System.Drawing.Size(100, 47);
            this.bt_Void.TabIndex = 24;
            this.bt_Void.Text = "Void Item";
            this.bt_Void.Click += new System.EventHandler(this.bt_Void_Click);
            // 
            // bt_ShowSideBar
            // 
            this.bt_ShowSideBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_ShowSideBar.CornerRadius = 20;
            this.bt_ShowSideBar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ShowSideBar.ForeColor = System.Drawing.Color.Black;
            this.bt_ShowSideBar.Location = new System.Drawing.Point(862, 606);
            this.bt_ShowSideBar.Name = "bt_ShowSideBar";
            this.bt_ShowSideBar.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ShowSideBar.Size = new System.Drawing.Size(134, 29);
            this.bt_ShowSideBar.TabIndex = 60;
            this.bt_ShowSideBar.Text = "<< Show Side Bar";
            this.bt_ShowSideBar.Click += new System.EventHandler(this.bt_ShowSideBar_Click_1);
            // 
            // bt_Payment
            // 
            this.bt_Payment.BackColor = System.Drawing.Color.MidnightBlue;
            this.bt_Payment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bt_Payment.CornerRadius = 5;
            this.bt_Payment.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Payment.ForeColor = System.Drawing.Color.White;
            this.bt_Payment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_Payment.Location = new System.Drawing.Point(747, 645);
            this.bt_Payment.Name = "bt_Payment";
            this.bt_Payment.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Payment.Size = new System.Drawing.Size(126, 47);
            this.bt_Payment.TabIndex = 16;
            this.bt_Payment.Text = "Card Pay";
            this.bt_Payment.Click += new System.EventHandler(this.bt_Payment_Click);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Font = new System.Drawing.Font("Arial Narrow", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarCode.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.lblBarCode.Location = new System.Drawing.Point(398, 611);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(102, 23);
            this.lblBarCode.TabIndex = 72;
            this.lblBarCode.Text = "Bar Code >>";
            // 
            // bt_NumTypeToggle
            // 
            this.bt_NumTypeToggle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_NumTypeToggle.CornerRadius = 20;
            this.bt_NumTypeToggle.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_NumTypeToggle.ForeColor = System.Drawing.Color.Black;
            this.bt_NumTypeToggle.Location = new System.Drawing.Point(810, 559);
            this.bt_NumTypeToggle.Name = "bt_NumTypeToggle";
            this.bt_NumTypeToggle.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_NumTypeToggle.Size = new System.Drawing.Size(193, 40);
            this.bt_NumTypeToggle.TabIndex = 77;
            this.bt_NumTypeToggle.Text = "Num";
            this.bt_NumTypeToggle.Click += new System.EventHandler(this.bt_NumTypeToggle_Click);
            // 
            // bt_LastReprint
            // 
            this.bt_LastReprint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bt_LastReprint.CornerRadius = 5;
            this.bt_LastReprint.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.bt_LastReprint.ForeColor = System.Drawing.Color.Black;
            this.bt_LastReprint.Location = new System.Drawing.Point(429, 646);
            this.bt_LastReprint.Name = "bt_LastReprint";
            this.bt_LastReprint.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_LastReprint.Size = new System.Drawing.Size(100, 47);
            this.bt_LastReprint.TabIndex = 78;
            this.bt_LastReprint.Text = "Reprint Last Tran";
            this.bt_LastReprint.Click += new System.EventHandler(this.bt_LastReprint_Click);
            // 
            // frmSalesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.bt_LastReprint);
            this.Controls.Add(this.pnlSideBar);
            this.Controls.Add(this.bt_NumTypeToggle);
            this.Controls.Add(this.bt_Plus);
            this.Controls.Add(this.bt_Minus);
            this.Controls.Add(this.lblBarCode2);
            this.Controls.Add(this.lblBarCode);
            this.Controls.Add(this.bt_cashPayment);
            this.Controls.Add(this.bt_AutoReceipt);
            this.Controls.Add(this.txtBarCode);
            this.Controls.Add(this.bt_SetQTY);
            this.Controls.Add(this.txtQTY);
            this.Controls.Add(this.bt_SetItemDiscount);
            this.Controls.Add(this.bt_OpenCashDrawer1);
            this.Controls.Add(this.lbl_ProdPages);
            this.Controls.Add(this.bt_VoidAll);
            this.Controls.Add(this.bt_TypePageDown);
            this.Controls.Add(this.bt_ProdPageUp);
            this.Controls.Add(this.bt_ProdPageDown);
            this.Controls.Add(this.bt_TypePageUp);
            this.Controls.Add(this.lbl_TypePages);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textNow);
            this.Controls.Add(this.bt_SetDiscount);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txt_TotalDue);
            this.Controls.Add(this.txt_TaxTotal);
            this.Controls.Add(this.txt_SubTotal);
            this.Controls.Add(this.txtAmtEach);
            this.Controls.Add(this.bt_PrintInvoice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bt_Void);
            this.Controls.Add(this.pnlPType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtSelectedMenu);
            this.Controls.Add(this.bt_Payment);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.dgv_Orders);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.bt_ShowSideBar);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmSalesMain";
            this.Text = "Sales Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSalesMain_Closing);
            this.Load += new System.EventHandler(this.frmSalesMain_Load);
            this.Shown += new System.EventHandler(this.frmSalesMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Orders)).EndInit();
            this.pnlPType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pnlSideBar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_Orders;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SubTotal;
        private System.Windows.Forms.TextBox txt_TaxTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_TotalDue;
        private System.Windows.Forms.Label label3;
        private SDCafeCommon.Utilities.CustomButton bt_Payment;
        private System.Windows.Forms.TextBox txtSelectedMenu;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel pnlPType;
        private SDCafeCommon.Utilities.CustomButton bt_Void;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQTY;
        private SDCafeCommon.Utilities.CustomButton bt_SetQTY;
        private SDCafeCommon.Utilities.CustomButton bt_PrintInvoice;
        private SDCafeCommon.Utilities.CustomButton bt_SetPPL;
        private System.Windows.Forms.TextBox txtAmtEach;
        private SDCafeCommon.Utilities.CustomButton bt_SetReturn;
        private SDCafeCommon.Utilities.CustomButton bt_ManualPrice;
        private SDCafeCommon.Utilities.CustomButton bt_EditPrice;
        private SDCafeCommon.Utilities.CustomButton bt_SetDiscount;
        private SDCafeCommon.Utilities.CustomButton bt_SetIOneDollarDiscount;
        private SDCafeCommon.Utilities.CustomButton bt_SetITwoDollarDiscount;
        private SDCafeCommon.Utilities.CustomButton bt_SetIThreeDollarDiscount;
        private System.Windows.Forms.TextBox textNow;
        private System.Windows.Forms.Timer timerSetTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private SDCafeCommon.Utilities.CustomButton bt_TypePageDown;
        private SDCafeCommon.Utilities.CustomButton bt_ProdPageUp;
        private SDCafeCommon.Utilities.CustomButton bt_ProdPageDown;
        private SDCafeCommon.Utilities.CustomButton bt_TypePageUp;
        private System.Windows.Forms.Label lbl_TypePages;
        private SDCafeCommon.Utilities.CustomButton bt_VoidAll;
        private SDCafeCommon.Utilities.CustomButton bt_SalesCustomer;
        private System.Windows.Forms.Panel pnlSideBar;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Stop;
        private SDCafeCommon.Utilities.CustomButton bt_Start;
        private SDCafeCommon.Utilities.CustomButton bt_ShowAllMenuItem;
        private SDCafeCommon.Utilities.CustomButton bt_HideSideBar;
        private SDCafeCommon.Utilities.CustomButton bt_ShowSideBar;
        private SDCafeCommon.Utilities.CustomButton bt_SalesHistory;
        private System.Windows.Forms.Label lbl_ProdPages;
        private SDCafeCommon.Utilities.CustomButton bt_OpenCashDrawer;
        private SDCafeCommon.Utilities.CustomButton bt_OpenCashDrawer1;
        private SDCafeCommon.Utilities.CustomButton bt_SetItemDiscount;
        private SDCafeCommon.Utilities.CustomButton bt_RecallOrder;
        private SDCafeCommon.Utilities.CustomButton bt_SaveOrder;
        private System.Windows.Forms.TextBox txtBarCode;
        private SDCafeCommon.Utilities.CustomButton bt_AutoReceipt;
        private SDCafeCommon.Utilities.CustomButton bt_cashPayment;
        private System.Windows.Forms.Label lblBarCode2;
        private System.Windows.Forms.Timer timerExtendBar;
        private SDCafeCommon.Utilities.CustomButton bt_Minus;
        private SDCafeCommon.Utilities.CustomButton bt_Plus;
        private System.Windows.Forms.Label lblBarCode;
        private SDCafeCommon.Utilities.CustomButton bt_NumTypeToggle;
        private SDCafeCommon.Utilities.CustomButton bt_LastReprint;
    }
}

