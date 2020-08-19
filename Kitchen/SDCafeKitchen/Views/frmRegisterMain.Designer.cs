namespace SDCafeKitchen.Views
{
    partial class frmRegisterMain
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
            this.checkedListBoxAntenna = new System.Windows.Forms.CheckedListBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_Start = new System.Windows.Forms.Button();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.bt_Stop = new System.Windows.Forms.Button();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bt_Exit = new System.Windows.Forms.Button();
            this.pnlPType = new System.Windows.Forms.Panel();
            this.lbl_TypePages = new System.Windows.Forms.Label();
            this.textCount = new System.Windows.Forms.TextBox();
            this.txtSelectedMenu = new System.Windows.Forms.TextBox();
            this.bt_UnSelectAll = new System.Windows.Forms.Button();
            this.bt_ProdPageDown = new System.Windows.Forms.Button();
            this.bt_TypePageDown = new System.Windows.Forms.Button();
            this.bt_TypePageUp = new System.Windows.Forms.Button();
            this.bt_ProdPageUp = new System.Windows.Forms.Button();
            this.lbl_ProdPages = new System.Windows.Forms.Label();
            this.txt_DiscountRate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bt_SetDiscount = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetDonation = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PrintInventory = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ShowAllMenuItem = new SDCafeCommon.Utilities.CustomButton();
            this.bt_AddProduct = new SDCafeCommon.Utilities.CustomButton();
            this.bt_AddPType = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Refresh = new SDCafeCommon.Utilities.CustomButton();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_SetStockEqual = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PrintLabel = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PrintOneLabel = new SDCafeCommon.Utilities.CustomButton();
            this.timerPrtLblButton = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // checkedListBoxAntenna
            // 
            this.checkedListBoxAntenna.FormattingEnabled = true;
            this.checkedListBoxAntenna.Location = new System.Drawing.Point(159, 600);
            this.checkedListBoxAntenna.Name = "checkedListBoxAntenna";
            this.checkedListBoxAntenna.Size = new System.Drawing.Size(141, 79);
            this.checkedListBoxAntenna.TabIndex = 18;
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
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(589, 376);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(404, 165);
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Standard";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Tag type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Serial num";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Read Cnt";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Antenna No";
            // 
            // bt_Start
            // 
            this.bt_Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_Start.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bt_Start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_Start.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Start.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Start.ForeColor = System.Drawing.Color.Black;
            this.bt_Start.Location = new System.Drawing.Point(12, 12);
            this.bt_Start.Name = "bt_Start";
            this.bt_Start.Size = new System.Drawing.Size(57, 40);
            this.bt_Start.TabIndex = 20;
            this.bt_Start.Text = "Start";
            this.bt_Start.UseVisualStyleBackColor = false;
            this.bt_Start.Click += new System.EventHandler(this.bt_Start_Click);
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(134, 600);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(141, 79);
            this.checkedListBox2.TabIndex = 18;
            this.checkedListBox2.Visible = false;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(422, 554);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(290, 20);
            this.txtCount.TabIndex = 22;
            // 
            // bt_Stop
            // 
            this.bt_Stop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_Stop.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bt_Stop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_Stop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Stop.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Stop.ForeColor = System.Drawing.Color.Maroon;
            this.bt_Stop.Location = new System.Drawing.Point(72, 12);
            this.bt_Stop.Name = "bt_Stop";
            this.bt_Stop.Size = new System.Drawing.Size(56, 40);
            this.bt_Stop.TabIndex = 23;
            this.bt_Stop.Text = "Stop";
            this.bt_Stop.UseVisualStyleBackColor = false;
            this.bt_Stop.Click += new System.EventHandler(this.bt_Stop_Click);
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMenu.Location = new System.Drawing.Point(140, 12);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(856, 358);
            this.pnlMenu.TabIndex = 25;
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.Black;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listView2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.ForeColor = System.Drawing.Color.White;
            this.listView2.FullRowSelect = true;
            this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(140, 583);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(856, 102);
            this.listView2.TabIndex = 27;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Standard";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Tag type";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Serial num";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "DTTM";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Applied Food Item";
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_Exit.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bt_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.Location = new System.Drawing.Point(12, 670);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(116, 47);
            this.bt_Exit.TabIndex = 28;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.UseVisualStyleBackColor = false;
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // pnlPType
            // 
            this.pnlPType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlPType.Location = new System.Drawing.Point(140, 376);
            this.pnlPType.Name = "pnlPType";
            this.pnlPType.Size = new System.Drawing.Size(856, 165);
            this.pnlPType.TabIndex = 26;
            // 
            // lbl_TypePages
            // 
            this.lbl_TypePages.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TypePages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_TypePages.Location = new System.Drawing.Point(810, 550);
            this.lbl_TypePages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_TypePages.Name = "lbl_TypePages";
            this.lbl_TypePages.Size = new System.Drawing.Size(73, 24);
            this.lbl_TypePages.TabIndex = 57;
            this.lbl_TypePages.Text = "Pages";
            this.lbl_TypePages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textCount
            // 
            this.textCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textCount.Location = new System.Drawing.Point(812, 691);
            this.textCount.Name = "textCount";
            this.textCount.Size = new System.Drawing.Size(184, 26);
            this.textCount.TabIndex = 59;
            this.textCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSelectedMenu
            // 
            this.txtSelectedMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelectedMenu.Location = new System.Drawing.Point(140, 691);
            this.txtSelectedMenu.Name = "txtSelectedMenu";
            this.txtSelectedMenu.Size = new System.Drawing.Size(663, 26);
            this.txtSelectedMenu.TabIndex = 58;
            // 
            // bt_UnSelectAll
            // 
            this.bt_UnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_UnSelectAll.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.bt_UnSelectAll.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_UnSelectAll.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_UnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_UnSelectAll.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_UnSelectAll.ForeColor = System.Drawing.Color.Black;
            this.bt_UnSelectAll.Location = new System.Drawing.Point(12, 58);
            this.bt_UnSelectAll.Name = "bt_UnSelectAll";
            this.bt_UnSelectAll.Size = new System.Drawing.Size(116, 31);
            this.bt_UnSelectAll.TabIndex = 63;
            this.bt_UnSelectAll.Text = "UnSelect";
            this.bt_UnSelectAll.UseVisualStyleBackColor = false;
            this.bt_UnSelectAll.Click += new System.EventHandler(this.bt_UnSelectAll_Click);
            // 
            // bt_ProdPageDown
            // 
            this.bt_ProdPageDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_ProdPageDown.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProdPageDown.ForeColor = System.Drawing.Color.Maroon;
            this.bt_ProdPageDown.Location = new System.Drawing.Point(322, 547);
            this.bt_ProdPageDown.Name = "bt_ProdPageDown";
            this.bt_ProdPageDown.Size = new System.Drawing.Size(94, 32);
            this.bt_ProdPageDown.TabIndex = 66;
            this.bt_ProdPageDown.Text = "Prod Down >";
            this.bt_ProdPageDown.UseVisualStyleBackColor = false;
            this.bt_ProdPageDown.Click += new System.EventHandler(this.bt_ProdPageDown_Click);
            // 
            // bt_TypePageDown
            // 
            this.bt_TypePageDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_TypePageDown.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TypePageDown.ForeColor = System.Drawing.Color.Maroon;
            this.bt_TypePageDown.Location = new System.Drawing.Point(882, 548);
            this.bt_TypePageDown.Name = "bt_TypePageDown";
            this.bt_TypePageDown.Size = new System.Drawing.Size(94, 32);
            this.bt_TypePageDown.TabIndex = 67;
            this.bt_TypePageDown.Text = "Type Down >";
            this.bt_TypePageDown.UseVisualStyleBackColor = false;
            this.bt_TypePageDown.Click += new System.EventHandler(this.bt_TypePageDown_Click);
            // 
            // bt_TypePageUp
            // 
            this.bt_TypePageUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_TypePageUp.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_TypePageUp.ForeColor = System.Drawing.Color.Maroon;
            this.bt_TypePageUp.Location = new System.Drawing.Point(718, 548);
            this.bt_TypePageUp.Name = "bt_TypePageUp";
            this.bt_TypePageUp.Size = new System.Drawing.Size(94, 32);
            this.bt_TypePageUp.TabIndex = 68;
            this.bt_TypePageUp.Text = "< Type Up";
            this.bt_TypePageUp.UseVisualStyleBackColor = false;
            this.bt_TypePageUp.Click += new System.EventHandler(this.bt_TypePageUp_Click);
            // 
            // bt_ProdPageUp
            // 
            this.bt_ProdPageUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_ProdPageUp.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ProdPageUp.ForeColor = System.Drawing.Color.Maroon;
            this.bt_ProdPageUp.Location = new System.Drawing.Point(159, 548);
            this.bt_ProdPageUp.Name = "bt_ProdPageUp";
            this.bt_ProdPageUp.Size = new System.Drawing.Size(94, 32);
            this.bt_ProdPageUp.TabIndex = 69;
            this.bt_ProdPageUp.Text = "< Prod Up";
            this.bt_ProdPageUp.UseVisualStyleBackColor = false;
            this.bt_ProdPageUp.Click += new System.EventHandler(this.bt_ProdPageUp_Click);
            // 
            // lbl_ProdPages
            // 
            this.lbl_ProdPages.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ProdPages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lbl_ProdPages.Location = new System.Drawing.Point(250, 550);
            this.lbl_ProdPages.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_ProdPages.Name = "lbl_ProdPages";
            this.lbl_ProdPages.Size = new System.Drawing.Size(73, 24);
            this.lbl_ProdPages.TabIndex = 70;
            this.lbl_ProdPages.Text = "Pages";
            this.lbl_ProdPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_DiscountRate
            // 
            this.txt_DiscountRate.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_DiscountRate.Location = new System.Drawing.Point(12, 322);
            this.txt_DiscountRate.Name = "txt_DiscountRate";
            this.txt_DiscountRate.Size = new System.Drawing.Size(87, 26);
            this.txt_DiscountRate.TabIndex = 74;
            this.txt_DiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_DiscountRate.Click += new System.EventHandler(this.txt_DiscountRate_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(8, 300);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 75;
            this.label1.Text = "Discount Rate";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_SetDiscount
            // 
            this.bt_SetDiscount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_SetDiscount.CornerRadius = 5;
            this.bt_SetDiscount.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_SetDiscount.Location = new System.Drawing.Point(12, 354);
            this.bt_SetDiscount.Name = "bt_SetDiscount";
            this.bt_SetDiscount.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetDiscount.Size = new System.Drawing.Size(116, 42);
            this.bt_SetDiscount.TabIndex = 72;
            this.bt_SetDiscount.Text = "Set All Discount";
            this.bt_SetDiscount.Click += new System.EventHandler(this.bt_SetDiscount_Click);
            // 
            // bt_SetDonation
            // 
            this.bt_SetDonation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_SetDonation.CornerRadius = 5;
            this.bt_SetDonation.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetDonation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_SetDonation.Location = new System.Drawing.Point(12, 402);
            this.bt_SetDonation.Name = "bt_SetDonation";
            this.bt_SetDonation.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetDonation.Size = new System.Drawing.Size(116, 42);
            this.bt_SetDonation.TabIndex = 71;
            this.bt_SetDonation.Text = "Set All Donation";
            this.bt_SetDonation.Click += new System.EventHandler(this.bt_SetDonation_Click);
            // 
            // bt_PrintInventory
            // 
            this.bt_PrintInventory.BackColor = System.Drawing.Color.DimGray;
            this.bt_PrintInventory.CornerRadius = 5;
            this.bt_PrintInventory.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PrintInventory.ForeColor = System.Drawing.Color.White;
            this.bt_PrintInventory.Location = new System.Drawing.Point(12, 617);
            this.bt_PrintInventory.Name = "bt_PrintInventory";
            this.bt_PrintInventory.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PrintInventory.Size = new System.Drawing.Size(116, 47);
            this.bt_PrintInventory.TabIndex = 65;
            this.bt_PrintInventory.Text = "Print Inventory";
            this.bt_PrintInventory.Click += new System.EventHandler(this.bt_PrintInventory_Click);
            // 
            // bt_ShowAllMenuItem
            // 
            this.bt_ShowAllMenuItem.BackColor = System.Drawing.Color.White;
            this.bt_ShowAllMenuItem.CornerRadius = 5;
            this.bt_ShowAllMenuItem.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ShowAllMenuItem.ForeColor = System.Drawing.Color.Black;
            this.bt_ShowAllMenuItem.Location = new System.Drawing.Point(12, 564);
            this.bt_ShowAllMenuItem.Name = "bt_ShowAllMenuItem";
            this.bt_ShowAllMenuItem.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ShowAllMenuItem.Size = new System.Drawing.Size(116, 47);
            this.bt_ShowAllMenuItem.TabIndex = 64;
            this.bt_ShowAllMenuItem.Text = "Show All Menu (Popularity)";
            this.bt_ShowAllMenuItem.Click += new System.EventHandler(this.bt_ShowAllMenuItem_Click);
            // 
            // bt_AddProduct
            // 
            this.bt_AddProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_AddProduct.CornerRadius = 10;
            this.bt_AddProduct.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddProduct.ForeColor = System.Drawing.Color.Black;
            this.bt_AddProduct.Location = new System.Drawing.Point(12, 452);
            this.bt_AddProduct.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_AddProduct.Name = "bt_AddProduct";
            this.bt_AddProduct.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_AddProduct.Size = new System.Drawing.Size(116, 47);
            this.bt_AddProduct.TabIndex = 62;
            this.bt_AddProduct.Text = "Add / Update Product";
            this.bt_AddProduct.Click += new System.EventHandler(this.bt_AddProduct_Click);
            // 
            // bt_AddPType
            // 
            this.bt_AddPType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_AddPType.CornerRadius = 10;
            this.bt_AddPType.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddPType.ForeColor = System.Drawing.Color.Black;
            this.bt_AddPType.Location = new System.Drawing.Point(12, 509);
            this.bt_AddPType.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_AddPType.Name = "bt_AddPType";
            this.bt_AddPType.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_AddPType.Size = new System.Drawing.Size(116, 47);
            this.bt_AddPType.TabIndex = 61;
            this.bt_AddPType.Text = "Add / Update Type";
            this.bt_AddPType.Click += new System.EventHandler(this.bt_AddPType_Click);
            // 
            // bt_Refresh
            // 
            this.bt_Refresh.BackColor = System.Drawing.Color.Gray;
            this.bt_Refresh.CornerRadius = 10;
            this.bt_Refresh.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.bt_Refresh.Location = new System.Drawing.Point(12, 97);
            this.bt_Refresh.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Refresh.Name = "bt_Refresh";
            this.bt_Refresh.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Refresh.Size = new System.Drawing.Size(116, 45);
            this.bt_Refresh.TabIndex = 40;
            this.bt_Refresh.Text = "Refresh";
            this.bt_Refresh.Click += new System.EventHandler(this.bt_Refresh_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label2.Location = new System.Drawing.Point(98, 324);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 24);
            this.label2.TabIndex = 76;
            this.label2.Text = "%";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_SetStockEqual
            // 
            this.bt_SetStockEqual.BackColor = System.Drawing.Color.White;
            this.bt_SetStockEqual.CornerRadius = 5;
            this.bt_SetStockEqual.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_SetStockEqual.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_SetStockEqual.Location = new System.Drawing.Point(12, 150);
            this.bt_SetStockEqual.Name = "bt_SetStockEqual";
            this.bt_SetStockEqual.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_SetStockEqual.Size = new System.Drawing.Size(116, 45);
            this.bt_SetStockEqual.TabIndex = 77;
            this.bt_SetStockEqual.Text = "Unsold Inventory Reset";
            this.bt_SetStockEqual.Click += new System.EventHandler(this.bt_SetStockEqual_Click);
            // 
            // bt_PrintLabel
            // 
            this.bt_PrintLabel.BackColor = System.Drawing.Color.DimGray;
            this.bt_PrintLabel.CornerRadius = 5;
            this.bt_PrintLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PrintLabel.ForeColor = System.Drawing.Color.White;
            this.bt_PrintLabel.Location = new System.Drawing.Point(12, 201);
            this.bt_PrintLabel.Name = "bt_PrintLabel";
            this.bt_PrintLabel.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PrintLabel.Size = new System.Drawing.Size(116, 45);
            this.bt_PrintLabel.TabIndex = 78;
            this.bt_PrintLabel.Text = "Print Labels";
            this.bt_PrintLabel.Click += new System.EventHandler(this.bt_PrintLabel_Click);
            // 
            // bt_PrintOneLabel
            // 
            this.bt_PrintOneLabel.BackColor = System.Drawing.Color.DimGray;
            this.bt_PrintOneLabel.CornerRadius = 5;
            this.bt_PrintOneLabel.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PrintOneLabel.ForeColor = System.Drawing.Color.White;
            this.bt_PrintOneLabel.Location = new System.Drawing.Point(12, 252);
            this.bt_PrintOneLabel.Name = "bt_PrintOneLabel";
            this.bt_PrintOneLabel.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PrintOneLabel.Size = new System.Drawing.Size(116, 45);
            this.bt_PrintOneLabel.TabIndex = 79;
            this.bt_PrintOneLabel.Text = "Print One Label";
            this.bt_PrintOneLabel.Click += new System.EventHandler(this.bt_PrintOneLabel_Click);
            // 
            // timerPrtLblButton
            // 
            this.timerPrtLblButton.Tick += new System.EventHandler(this.On_timerPrtLblButton);
            // 
            // frmRegisterMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.bt_PrintOneLabel);
            this.Controls.Add(this.bt_PrintLabel);
            this.Controls.Add(this.bt_SetStockEqual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_DiscountRate);
            this.Controls.Add(this.bt_SetDiscount);
            this.Controls.Add(this.bt_SetDonation);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.bt_ProdPageUp);
            this.Controls.Add(this.lbl_ProdPages);
            this.Controls.Add(this.bt_TypePageUp);
            this.Controls.Add(this.bt_TypePageDown);
            this.Controls.Add(this.bt_ProdPageDown);
            this.Controls.Add(this.bt_PrintInventory);
            this.Controls.Add(this.bt_ShowAllMenuItem);
            this.Controls.Add(this.bt_UnSelectAll);
            this.Controls.Add(this.bt_AddProduct);
            this.Controls.Add(this.bt_AddPType);
            this.Controls.Add(this.textCount);
            this.Controls.Add(this.txtSelectedMenu);
            this.Controls.Add(this.lbl_TypePages);
            this.Controls.Add(this.pnlPType);
            this.Controls.Add(this.bt_Refresh);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.checkedListBox2);
            this.Controls.Add(this.bt_Stop);
            this.Controls.Add(this.bt_Start);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.checkedListBoxAntenna);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmRegisterMain";
            this.Text = "Register/Inventory Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_Closing);
            this.Load += new System.EventHandler(this.frmRegisterMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAntenna;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button bt_Start;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button bt_Stop;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.Button bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Refresh;
        private System.Windows.Forms.Panel pnlPType;
        private System.Windows.Forms.Label lbl_TypePages;
        private System.Windows.Forms.TextBox textCount;
        private System.Windows.Forms.TextBox txtSelectedMenu;
        private SDCafeCommon.Utilities.CustomButton bt_AddPType;
        private SDCafeCommon.Utilities.CustomButton bt_AddProduct;
        private System.Windows.Forms.Button bt_UnSelectAll;
        private SDCafeCommon.Utilities.CustomButton bt_ShowAllMenuItem;
        private SDCafeCommon.Utilities.CustomButton bt_PrintInventory;
        private System.Windows.Forms.Button bt_ProdPageDown;
        private System.Windows.Forms.Button bt_TypePageDown;
        private System.Windows.Forms.Button bt_TypePageUp;
        private System.Windows.Forms.Button bt_ProdPageUp;
        private System.Windows.Forms.Label lbl_ProdPages;
        private SDCafeCommon.Utilities.CustomButton bt_SetDonation;
        private SDCafeCommon.Utilities.CustomButton bt_SetDiscount;
        private System.Windows.Forms.TextBox txt_DiscountRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SDCafeCommon.Utilities.CustomButton bt_SetStockEqual;
        private SDCafeCommon.Utilities.CustomButton bt_PrintLabel;
        private SDCafeCommon.Utilities.CustomButton bt_PrintOneLabel;
        private System.Windows.Forms.Timer timerPrtLblButton;
    }
}