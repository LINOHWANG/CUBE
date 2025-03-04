namespace SDCafeOffice.Views
{
    partial class frmPromotion
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PromoName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_PromoType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_PromoValue1 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PromoQTY1 = new System.Windows.Forms.TextBox();
            this.dttm_PromoStart = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dttm_PromoEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvDataFrom = new System.Windows.Forms.DataGridView();
            this.dgvDataTo = new System.Windows.Forms.DataGridView();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_PromoID = new System.Windows.Forms.TextBox();
            this.bt_Add_All = new System.Windows.Forms.Button();
            this.bt_AddOne = new System.Windows.Forms.Button();
            this.bt_DelAll = new System.Windows.Forms.Button();
            this.bt_DelOne = new System.Windows.Forms.Button();
            this.lbl_AllProds = new System.Windows.Forms.Label();
            this.lbl_SelectedProds = new System.Windows.Forms.Label();
            this.bt_Delete = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Add = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.txt_ProdSearch = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_PromoValue2 = new System.Windows.Forms.TextBox();
            this.txt_PromoQTY2 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Promotion Name";
            // 
            // txt_PromoName
            // 
            this.txt_PromoName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoName.Location = new System.Drawing.Point(194, 47);
            this.txt_PromoName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoName.Name = "txt_PromoName";
            this.txt_PromoName.Size = new System.Drawing.Size(353, 29);
            this.txt_PromoName.TabIndex = 4;
            this.txt_PromoName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 89);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Promotion Type";
            // 
            // cb_PromoType
            // 
            this.cb_PromoType.Font = new System.Drawing.Font("Arial", 14.25F);
            this.cb_PromoType.FormattingEnabled = true;
            this.cb_PromoType.Location = new System.Drawing.Point(194, 84);
            this.cb_PromoType.Name = "cb_PromoType";
            this.cb_PromoType.Size = new System.Drawing.Size(198, 30);
            this.cb_PromoType.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(387, 129);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 22);
            this.label3.TabIndex = 35;
            this.label3.Text = "Each Promo Price";
            // 
            // txt_PromoValue1
            // 
            this.txt_PromoValue1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_PromoValue1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoValue1.Location = new System.Drawing.Point(576, 126);
            this.txt_PromoValue1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoValue1.Name = "txt_PromoValue1";
            this.txt_PromoValue1.Size = new System.Drawing.Size(121, 29);
            this.txt_PromoValue1.TabIndex = 34;
            this.txt_PromoValue1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_PromoValue1.TextChanged += new System.EventHandler(this.txt_PromoValue_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(387, 165);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 22);
            this.label4.TabIndex = 37;
            this.label4.Text = "Matching QTY";
            // 
            // txt_PromoQTY1
            // 
            this.txt_PromoQTY1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoQTY1.Location = new System.Drawing.Point(576, 161);
            this.txt_PromoQTY1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoQTY1.Name = "txt_PromoQTY1";
            this.txt_PromoQTY1.Size = new System.Drawing.Size(121, 29);
            this.txt_PromoQTY1.TabIndex = 36;
            this.txt_PromoQTY1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dttm_PromoStart
            // 
            this.dttm_PromoStart.CalendarFont = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttm_PromoStart.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttm_PromoStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_PromoStart.Location = new System.Drawing.Point(194, 124);
            this.dttm_PromoStart.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dttm_PromoStart.Name = "dttm_PromoStart";
            this.dttm_PromoStart.Size = new System.Drawing.Size(151, 29);
            this.dttm_PromoStart.TabIndex = 38;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 129);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 22);
            this.label5.TabIndex = 39;
            this.label5.Text = "Promo Start Date";
            // 
            // dttm_PromoEnd
            // 
            this.dttm_PromoEnd.CalendarFont = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttm_PromoEnd.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dttm_PromoEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_PromoEnd.Location = new System.Drawing.Point(194, 161);
            this.dttm_PromoEnd.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.dttm_PromoEnd.Name = "dttm_PromoEnd";
            this.dttm_PromoEnd.Size = new System.Drawing.Size(151, 29);
            this.dttm_PromoEnd.TabIndex = 40;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 165);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 22);
            this.label6.TabIndex = 41;
            this.label6.Text = "Promo End Date";
            // 
            // dgvDataFrom
            // 
            this.dgvDataFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFrom.Location = new System.Drawing.Point(14, 231);
            this.dgvDataFrom.MultiSelect = false;
            this.dgvDataFrom.Name = "dgvDataFrom";
            this.dgvDataFrom.ReadOnly = true;
            this.dgvDataFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataFrom.ShowEditingIcon = false;
            this.dgvDataFrom.Size = new System.Drawing.Size(450, 448);
            this.dgvDataFrom.TabIndex = 42;
            // 
            // dgvDataTo
            // 
            this.dgvDataTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTo.Location = new System.Drawing.Point(546, 231);
            this.dgvDataTo.MultiSelect = false;
            this.dgvDataTo.Name = "dgvDataTo";
            this.dgvDataTo.ReadOnly = true;
            this.dgvDataTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTo.ShowEditingIcon = false;
            this.dgvDataTo.Size = new System.Drawing.Size(450, 448);
            this.dgvDataTo.TabIndex = 43;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(14, 685);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(982, 32);
            this.txtMessage.TabIndex = 74;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 22);
            this.label7.TabIndex = 83;
            this.label7.Text = "Promotion ID";
            // 
            // txt_PromoID
            // 
            this.txt_PromoID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoID.Location = new System.Drawing.Point(194, 8);
            this.txt_PromoID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoID.Name = "txt_PromoID";
            this.txt_PromoID.ReadOnly = true;
            this.txt_PromoID.Size = new System.Drawing.Size(198, 29);
            this.txt_PromoID.TabIndex = 82;
            this.txt_PromoID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Add_All
            // 
            this.bt_Add_All.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Add_All.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Add_All.Location = new System.Drawing.Point(470, 355);
            this.bt_Add_All.Name = "bt_Add_All";
            this.bt_Add_All.Size = new System.Drawing.Size(70, 50);
            this.bt_Add_All.TabIndex = 84;
            this.bt_Add_All.Text = ">>";
            this.bt_Add_All.UseVisualStyleBackColor = false;
            this.bt_Add_All.Visible = false;
            this.bt_Add_All.Click += new System.EventHandler(this.bt_Add_All_Click);
            // 
            // bt_AddOne
            // 
            this.bt_AddOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_AddOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddOne.Location = new System.Drawing.Point(470, 411);
            this.bt_AddOne.Name = "bt_AddOne";
            this.bt_AddOne.Size = new System.Drawing.Size(70, 50);
            this.bt_AddOne.TabIndex = 85;
            this.bt_AddOne.Text = ">";
            this.bt_AddOne.UseVisualStyleBackColor = false;
            this.bt_AddOne.Click += new System.EventHandler(this.bt_AddOne_Click);
            // 
            // bt_DelAll
            // 
            this.bt_DelAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_DelAll.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DelAll.Location = new System.Drawing.Point(470, 523);
            this.bt_DelAll.Name = "bt_DelAll";
            this.bt_DelAll.Size = new System.Drawing.Size(70, 50);
            this.bt_DelAll.TabIndex = 87;
            this.bt_DelAll.Text = "<<";
            this.bt_DelAll.UseVisualStyleBackColor = false;
            this.bt_DelAll.Visible = false;
            this.bt_DelAll.Click += new System.EventHandler(this.bt_DelAll_Click);
            // 
            // bt_DelOne
            // 
            this.bt_DelOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_DelOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DelOne.Location = new System.Drawing.Point(470, 467);
            this.bt_DelOne.Name = "bt_DelOne";
            this.bt_DelOne.Size = new System.Drawing.Size(70, 50);
            this.bt_DelOne.TabIndex = 86;
            this.bt_DelOne.Text = "<";
            this.bt_DelOne.UseVisualStyleBackColor = false;
            this.bt_DelOne.Click += new System.EventHandler(this.bt_DelOne_Click);
            // 
            // lbl_AllProds
            // 
            this.lbl_AllProds.AutoSize = true;
            this.lbl_AllProds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AllProds.ForeColor = System.Drawing.Color.Blue;
            this.lbl_AllProds.Location = new System.Drawing.Point(10, 206);
            this.lbl_AllProds.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_AllProds.Name = "lbl_AllProds";
            this.lbl_AllProds.Size = new System.Drawing.Size(123, 22);
            this.lbl_AllProds.TabIndex = 88;
            this.lbl_AllProds.Text = "All Products";
            // 
            // lbl_SelectedProds
            // 
            this.lbl_SelectedProds.AutoSize = true;
            this.lbl_SelectedProds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectedProds.ForeColor = System.Drawing.Color.Blue;
            this.lbl_SelectedProds.Location = new System.Drawing.Point(542, 206);
            this.lbl_SelectedProds.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_SelectedProds.Name = "lbl_SelectedProds";
            this.lbl_SelectedProds.Size = new System.Drawing.Size(180, 22);
            this.lbl_SelectedProds.TabIndex = 89;
            this.lbl_SelectedProds.Text = "Selected Products";
            // 
            // bt_Delete
            // 
            this.bt_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Delete.CornerRadius = 30;
            this.bt_Delete.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Delete.Location = new System.Drawing.Point(793, 8);
            this.bt_Delete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Delete.Size = new System.Drawing.Size(92, 68);
            this.bt_Delete.TabIndex = 81;
            this.bt_Delete.Text = "Delete";
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Add.CornerRadius = 30;
            this.bt_Add.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Add.Location = new System.Drawing.Point(603, 11);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Add.Size = new System.Drawing.Size(92, 65);
            this.bt_Add.TabIndex = 80;
            this.bt_Add.Text = "Add";
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(894, 8);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(92, 68);
            this.bt_Exit.TabIndex = 79;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.CornerRadius = 30;
            this.bt_Save.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Save.Location = new System.Drawing.Point(698, 8);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Save.Size = new System.Drawing.Size(92, 68);
            this.bt_Save.TabIndex = 78;
            this.bt_Save.Text = "Save";
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // txt_ProdSearch
            // 
            this.txt_ProdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ProdSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProdSearch.Location = new System.Drawing.Point(252, 200);
            this.txt_ProdSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ProdSearch.Name = "txt_ProdSearch";
            this.txt_ProdSearch.Size = new System.Drawing.Size(212, 29);
            this.txt_ProdSearch.TabIndex = 90;
            this.txt_ProdSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ProdSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ProdSearch_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(190, 203);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 23);
            this.label8.TabIndex = 91;
            this.label8.Text = "Search";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(581, 99);
            this.label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(116, 22);
            this.label9.TabIndex = 92;
            this.label9.Text = "Condition 1";
            // 
            // txt_PromoValue2
            // 
            this.txt_PromoValue2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.txt_PromoValue2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoValue2.Location = new System.Drawing.Point(709, 126);
            this.txt_PromoValue2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoValue2.Name = "txt_PromoValue2";
            this.txt_PromoValue2.Size = new System.Drawing.Size(121, 29);
            this.txt_PromoValue2.TabIndex = 93;
            this.txt_PromoValue2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txt_PromoQTY2
            // 
            this.txt_PromoQTY2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PromoQTY2.Location = new System.Drawing.Point(709, 161);
            this.txt_PromoQTY2.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PromoQTY2.Name = "txt_PromoQTY2";
            this.txt_PromoQTY2.Size = new System.Drawing.Size(121, 29);
            this.txt_PromoQTY2.TabIndex = 94;
            this.txt_PromoQTY2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(714, 99);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(116, 22);
            this.label10.TabIndex = 95;
            this.label10.Text = "Condition 2";
            // 
            // frmPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_PromoQTY2);
            this.Controls.Add(this.txt_PromoValue2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ProdSearch);
            this.Controls.Add(this.lbl_SelectedProds);
            this.Controls.Add(this.lbl_AllProds);
            this.Controls.Add(this.bt_DelAll);
            this.Controls.Add(this.bt_DelOne);
            this.Controls.Add(this.bt_AddOne);
            this.Controls.Add(this.bt_Add_All);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_PromoID);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.dgvDataTo);
            this.Controls.Add(this.dgvDataFrom);
            this.Controls.Add(this.dttm_PromoStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dttm_PromoEnd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_PromoQTY1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_PromoValue1);
            this.Controls.Add(this.cb_PromoType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_PromoName);
            this.Name = "frmPromotion";
            this.Text = "Advanced Promotion Setting";
            this.Load += new System.EventHandler(this.frmPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PromoName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_PromoType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_PromoValue1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PromoQTY1;
        private System.Windows.Forms.DateTimePicker dttm_PromoStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dttm_PromoEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvDataFrom;
        private System.Windows.Forms.DataGridView dgvDataTo;
        private System.Windows.Forms.TextBox txtMessage;
        private SDCafeCommon.Utilities.CustomButton bt_Delete;
        private SDCafeCommon.Utilities.CustomButton bt_Add;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_PromoID;
        private System.Windows.Forms.Button bt_Add_All;
        private System.Windows.Forms.Button bt_AddOne;
        private System.Windows.Forms.Button bt_DelAll;
        private System.Windows.Forms.Button bt_DelOne;
        private System.Windows.Forms.Label lbl_AllProds;
        private System.Windows.Forms.Label lbl_SelectedProds;
        private System.Windows.Forms.TextBox txt_ProdSearch;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_PromoValue2;
        private System.Windows.Forms.TextBox txt_PromoQTY2;
        private System.Windows.Forms.Label label10;
    }
}