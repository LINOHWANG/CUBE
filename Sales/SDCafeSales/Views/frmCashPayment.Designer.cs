namespace SDCafeSales.Views
{
    partial class frmCashPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCashPayment));
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblUerName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlNumPad = new System.Windows.Forms.Panel();
            this.bt_50 = new SDCafeCommon.Utilities.CustomButton();
            this.bt_100 = new SDCafeCommon.Utilities.CustomButton();
            this.bt_5 = new SDCafeCommon.Utilities.CustomButton();
            this.bt_20 = new SDCafeCommon.Utilities.CustomButton();
            this.bt_10 = new SDCafeCommon.Utilities.CustomButton();
            this.btNumSame = new SDCafeCommon.Utilities.CustomButton();
            this.btNum0 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum9 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum8 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum7 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum6 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum3 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum5 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum2 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum4 = new SDCafeCommon.Utilities.CustomButton();
            this.btNum1 = new SDCafeCommon.Utilities.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TotalDue = new System.Windows.Forms.TextBox();
            this.txt_CashAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Changes = new System.Windows.Forms.TextBox();
            this.lbl_Changes = new System.Windows.Forms.Label();
            this.lblPartialPay = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_PayAmex = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayMaster = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayVisa = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayDebit = new SDCafeCommon.Utilities.CustomButton();
            this.txt_TipAmount = new System.Windows.Forms.TextBox();
            this.labelTipOrCard = new System.Windows.Forms.Label();
            this.txt_CardAmount = new System.Windows.Forms.TextBox();
            this.txt_TotalDueUSD = new System.Windows.Forms.TextBox();
            this.lbl_ConvRate = new System.Windows.Forms.Label();
            this.txt_CashAmountUSD = new System.Windows.Forms.TextBox();
            this.lbl_Short = new System.Windows.Forms.Label();
            this.bt_OpenCD = new SDCafeCommon.Utilities.CustomButton();
            this.bt_IPSPayment = new SDCafeCommon.Utilities.CustomButton();
            this.btNumReset = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayCash = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ShowUSD = new SDCafeCommon.Utilities.CustomButton();
            this.bt_ChangesToTip = new SDCafeCommon.Utilities.CustomButton();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CashDue = new System.Windows.Forms.TextBox();
            this.bt_PayCheque = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayCharge = new SDCafeCommon.Utilities.CustomButton();
            this.pnlNumPad.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.ForeColor = System.Drawing.Color.Blue;
            this.lblInvoiceNo.Location = new System.Drawing.Point(458, 9);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(220, 32);
            this.lblInvoiceNo.TabIndex = 18;
            this.lblInvoiceNo.Text = "Invoice";
            this.lblInvoiceNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStation
            // 
            this.lblStation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblStation.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStation.ForeColor = System.Drawing.Color.Blue;
            this.lblStation.Location = new System.Drawing.Point(7, 9);
            this.lblStation.Name = "lblStation";
            this.lblStation.Size = new System.Drawing.Size(220, 32);
            this.lblStation.TabIndex = 23;
            this.lblStation.Text = "Station";
            this.lblStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblUerName
            // 
            this.lblUerName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblUerName.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUerName.ForeColor = System.Drawing.Color.Black;
            this.lblUerName.Location = new System.Drawing.Point(224, 9);
            this.lblUerName.Name = "lblUerName";
            this.lblUerName.Size = new System.Drawing.Size(220, 32);
            this.lblUerName.TabIndex = 24;
            this.lblUerName.Text = "Served by";
            this.lblUerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pnlNumPad
            // 
            this.pnlNumPad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlNumPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNumPad.Controls.Add(this.bt_50);
            this.pnlNumPad.Controls.Add(this.bt_100);
            this.pnlNumPad.Controls.Add(this.bt_5);
            this.pnlNumPad.Controls.Add(this.bt_20);
            this.pnlNumPad.Controls.Add(this.bt_10);
            this.pnlNumPad.Controls.Add(this.btNumSame);
            this.pnlNumPad.Controls.Add(this.btNum0);
            this.pnlNumPad.Controls.Add(this.btNum9);
            this.pnlNumPad.Controls.Add(this.btNum8);
            this.pnlNumPad.Controls.Add(this.btNum7);
            this.pnlNumPad.Controls.Add(this.btNum6);
            this.pnlNumPad.Controls.Add(this.btNum3);
            this.pnlNumPad.Controls.Add(this.btNum5);
            this.pnlNumPad.Controls.Add(this.btNum2);
            this.pnlNumPad.Controls.Add(this.btNum4);
            this.pnlNumPad.Controls.Add(this.btNum1);
            this.pnlNumPad.Location = new System.Drawing.Point(12, 46);
            this.pnlNumPad.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlNumPad.Name = "pnlNumPad";
            this.pnlNumPad.Size = new System.Drawing.Size(673, 173);
            this.pnlNumPad.TabIndex = 26;
            // 
            // bt_50
            // 
            this.bt_50.BackColor = System.Drawing.Color.Silver;
            this.bt_50.CornerRadius = 30;
            this.bt_50.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_50.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_50.Location = new System.Drawing.Point(559, 3);
            this.bt_50.Name = "bt_50";
            this.bt_50.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_50.Size = new System.Drawing.Size(104, 51);
            this.bt_50.TabIndex = 41;
            this.bt_50.Text = "$50";
            this.bt_50.Click += new System.EventHandler(this.bt_50_Click);
            // 
            // bt_100
            // 
            this.bt_100.BackColor = System.Drawing.Color.Silver;
            this.bt_100.CornerRadius = 30;
            this.bt_100.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_100.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_100.Location = new System.Drawing.Point(559, 60);
            this.bt_100.Name = "bt_100";
            this.bt_100.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_100.Size = new System.Drawing.Size(104, 51);
            this.bt_100.TabIndex = 39;
            this.bt_100.Text = "$100";
            this.bt_100.Click += new System.EventHandler(this.bt_100_Click);
            // 
            // bt_5
            // 
            this.bt_5.BackColor = System.Drawing.Color.Silver;
            this.bt_5.CornerRadius = 30;
            this.bt_5.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_5.Location = new System.Drawing.Point(449, 3);
            this.bt_5.Name = "bt_5";
            this.bt_5.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_5.Size = new System.Drawing.Size(104, 51);
            this.bt_5.TabIndex = 38;
            this.bt_5.Text = "$5";
            this.bt_5.Click += new System.EventHandler(this.bt_5_Click);
            // 
            // bt_20
            // 
            this.bt_20.BackColor = System.Drawing.Color.Silver;
            this.bt_20.CornerRadius = 30;
            this.bt_20.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_20.Location = new System.Drawing.Point(449, 117);
            this.bt_20.Name = "bt_20";
            this.bt_20.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_20.Size = new System.Drawing.Size(104, 51);
            this.bt_20.TabIndex = 37;
            this.bt_20.Text = "$20";
            this.bt_20.Click += new System.EventHandler(this.bt_20_Click);
            // 
            // bt_10
            // 
            this.bt_10.BackColor = System.Drawing.Color.Silver;
            this.bt_10.CornerRadius = 30;
            this.bt_10.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_10.Location = new System.Drawing.Point(449, 60);
            this.bt_10.Name = "bt_10";
            this.bt_10.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_10.Size = new System.Drawing.Size(104, 51);
            this.bt_10.TabIndex = 36;
            this.bt_10.Text = "$10";
            this.bt_10.Click += new System.EventHandler(this.bt_10_Click);
            // 
            // btNumSame
            // 
            this.btNumSame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btNumSame.CornerRadius = 30;
            this.btNumSame.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNumSame.ForeColor = System.Drawing.Color.Black;
            this.btNumSame.Location = new System.Drawing.Point(559, 117);
            this.btNumSame.Name = "btNumSame";
            this.btNumSame.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumSame.Size = new System.Drawing.Size(104, 51);
            this.btNumSame.TabIndex = 35;
            this.btNumSame.Text = "Same";
            this.btNumSame.Click += new System.EventHandler(this.btNumSame_Click);
            // 
            // btNum0
            // 
            this.btNum0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum0.CornerRadius = 30;
            this.btNum0.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum0.ForeColor = System.Drawing.Color.Blue;
            this.btNum0.Location = new System.Drawing.Point(338, 60);
            this.btNum0.Name = "btNum0";
            this.btNum0.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum0.Size = new System.Drawing.Size(104, 51);
            this.btNum0.TabIndex = 33;
            this.btNum0.Text = "0";
            this.btNum0.Click += new System.EventHandler(this.btNum0_Click);
            // 
            // btNum9
            // 
            this.btNum9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum9.CornerRadius = 30;
            this.btNum9.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum9.ForeColor = System.Drawing.Color.Blue;
            this.btNum9.Location = new System.Drawing.Point(227, 117);
            this.btNum9.Name = "btNum9";
            this.btNum9.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum9.Size = new System.Drawing.Size(104, 51);
            this.btNum9.TabIndex = 31;
            this.btNum9.Text = "9";
            this.btNum9.Click += new System.EventHandler(this.btNum9_Click);
            // 
            // btNum8
            // 
            this.btNum8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum8.CornerRadius = 30;
            this.btNum8.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum8.ForeColor = System.Drawing.Color.Blue;
            this.btNum8.Location = new System.Drawing.Point(116, 117);
            this.btNum8.Name = "btNum8";
            this.btNum8.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum8.Size = new System.Drawing.Size(104, 51);
            this.btNum8.TabIndex = 30;
            this.btNum8.Text = "8";
            this.btNum8.Click += new System.EventHandler(this.btNum8_Click);
            // 
            // btNum7
            // 
            this.btNum7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum7.CornerRadius = 30;
            this.btNum7.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum7.ForeColor = System.Drawing.Color.Blue;
            this.btNum7.Location = new System.Drawing.Point(5, 117);
            this.btNum7.Name = "btNum7";
            this.btNum7.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum7.Size = new System.Drawing.Size(104, 51);
            this.btNum7.TabIndex = 29;
            this.btNum7.Text = "7";
            this.btNum7.Click += new System.EventHandler(this.btNum7_Click);
            // 
            // btNum6
            // 
            this.btNum6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum6.CornerRadius = 30;
            this.btNum6.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum6.ForeColor = System.Drawing.Color.Blue;
            this.btNum6.Location = new System.Drawing.Point(227, 60);
            this.btNum6.Name = "btNum6";
            this.btNum6.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum6.Size = new System.Drawing.Size(104, 51);
            this.btNum6.TabIndex = 28;
            this.btNum6.Text = "6";
            this.btNum6.Click += new System.EventHandler(this.btNum6_Click);
            // 
            // btNum3
            // 
            this.btNum3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum3.CornerRadius = 30;
            this.btNum3.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum3.ForeColor = System.Drawing.Color.Blue;
            this.btNum3.Location = new System.Drawing.Point(227, 3);
            this.btNum3.Name = "btNum3";
            this.btNum3.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum3.Size = new System.Drawing.Size(104, 51);
            this.btNum3.TabIndex = 19;
            this.btNum3.Text = "3";
            this.btNum3.Click += new System.EventHandler(this.btNum3_Click);
            // 
            // btNum5
            // 
            this.btNum5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum5.CornerRadius = 30;
            this.btNum5.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum5.ForeColor = System.Drawing.Color.Blue;
            this.btNum5.Location = new System.Drawing.Point(116, 60);
            this.btNum5.Name = "btNum5";
            this.btNum5.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum5.Size = new System.Drawing.Size(104, 51);
            this.btNum5.TabIndex = 27;
            this.btNum5.Text = "5";
            this.btNum5.Click += new System.EventHandler(this.btNum5_Click);
            // 
            // btNum2
            // 
            this.btNum2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum2.CornerRadius = 30;
            this.btNum2.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum2.ForeColor = System.Drawing.Color.Blue;
            this.btNum2.Location = new System.Drawing.Point(116, 3);
            this.btNum2.Name = "btNum2";
            this.btNum2.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum2.Size = new System.Drawing.Size(104, 51);
            this.btNum2.TabIndex = 18;
            this.btNum2.Text = "2";
            this.btNum2.Click += new System.EventHandler(this.btNum2_Click);
            // 
            // btNum4
            // 
            this.btNum4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum4.CornerRadius = 30;
            this.btNum4.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum4.ForeColor = System.Drawing.Color.Blue;
            this.btNum4.Location = new System.Drawing.Point(5, 60);
            this.btNum4.Name = "btNum4";
            this.btNum4.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum4.Size = new System.Drawing.Size(104, 51);
            this.btNum4.TabIndex = 26;
            this.btNum4.Text = "4";
            this.btNum4.Click += new System.EventHandler(this.btNum4_Click);
            // 
            // btNum1
            // 
            this.btNum1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btNum1.CornerRadius = 30;
            this.btNum1.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNum1.ForeColor = System.Drawing.Color.Blue;
            this.btNum1.Location = new System.Drawing.Point(5, 3);
            this.btNum1.Name = "btNum1";
            this.btNum1.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum1.Size = new System.Drawing.Size(104, 51);
            this.btNum1.TabIndex = 17;
            this.btNum1.Text = "1";
            this.btNum1.Click += new System.EventHandler(this.btNum1_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(-40, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 42);
            this.label1.TabIndex = 27;
            this.label1.Text = "Due Amount :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_TotalDue
            // 
            this.txt_TotalDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TotalDue.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDue.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_TotalDue.Location = new System.Drawing.Point(250, 275);
            this.txt_TotalDue.Name = "txt_TotalDue";
            this.txt_TotalDue.ReadOnly = true;
            this.txt_TotalDue.Size = new System.Drawing.Size(197, 39);
            this.txt_TotalDue.TabIndex = 93;
            this.txt_TotalDue.Text = "0.00";
            this.txt_TotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CashAmount
            // 
            this.txt_CashAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_CashAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CashAmount.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CashAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_CashAmount.Location = new System.Drawing.Point(250, 369);
            this.txt_CashAmount.Name = "txt_CashAmount";
            this.txt_CashAmount.ReadOnly = true;
            this.txt_CashAmount.Size = new System.Drawing.Size(197, 39);
            this.txt_CashAmount.TabIndex = 95;
            this.txt_CashAmount.Text = "0.00";
            this.txt_CashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(-40, 369);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 36);
            this.label2.TabIndex = 94;
            this.label2.Text = "Cash :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Changes
            // 
            this.txt_Changes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_Changes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Changes.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Changes.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_Changes.Location = new System.Drawing.Point(250, 416);
            this.txt_Changes.Name = "txt_Changes";
            this.txt_Changes.ReadOnly = true;
            this.txt_Changes.Size = new System.Drawing.Size(197, 39);
            this.txt_Changes.TabIndex = 97;
            this.txt_Changes.Text = "0.00";
            this.txt_Changes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Changes
            // 
            this.lbl_Changes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Changes.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Changes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_Changes.Location = new System.Drawing.Point(-40, 416);
            this.lbl_Changes.Name = "lbl_Changes";
            this.lbl_Changes.Size = new System.Drawing.Size(293, 36);
            this.lbl_Changes.TabIndex = 96;
            this.lbl_Changes.Text = "Changes :";
            this.lbl_Changes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPartialPay
            // 
            this.lblPartialPay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblPartialPay.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartialPay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPartialPay.Location = new System.Drawing.Point(8, 280);
            this.lblPartialPay.Name = "lblPartialPay";
            this.lblPartialPay.Size = new System.Drawing.Size(124, 41);
            this.lblPartialPay.TabIndex = 98;
            this.lblPartialPay.Text = "test";
            this.lblPartialPay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblPartialPay.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_PayAmex);
            this.groupBox1.Controls.Add(this.bt_PayMaster);
            this.groupBox1.Controls.Add(this.bt_PayVisa);
            this.groupBox1.Controls.Add(this.bt_PayDebit);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 626);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 114);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Card Manual Payment";
            // 
            // bt_PayAmex
            // 
            this.bt_PayAmex.BackColor = System.Drawing.Color.BlueViolet;
            this.bt_PayAmex.CornerRadius = 30;
            this.bt_PayAmex.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayAmex.ForeColor = System.Drawing.Color.White;
            this.bt_PayAmex.Location = new System.Drawing.Point(489, 25);
            this.bt_PayAmex.Name = "bt_PayAmex";
            this.bt_PayAmex.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayAmex.Size = new System.Drawing.Size(150, 42);
            this.bt_PayAmex.TabIndex = 106;
            this.bt_PayAmex.Text = "Amex";
            this.bt_PayAmex.Click += new System.EventHandler(this.bt_PayAmex_Click);
            // 
            // bt_PayMaster
            // 
            this.bt_PayMaster.BackColor = System.Drawing.Color.BlueViolet;
            this.bt_PayMaster.CornerRadius = 30;
            this.bt_PayMaster.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayMaster.ForeColor = System.Drawing.Color.White;
            this.bt_PayMaster.Location = new System.Drawing.Point(333, 25);
            this.bt_PayMaster.Name = "bt_PayMaster";
            this.bt_PayMaster.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayMaster.Size = new System.Drawing.Size(150, 42);
            this.bt_PayMaster.TabIndex = 105;
            this.bt_PayMaster.Text = "Master";
            this.bt_PayMaster.Click += new System.EventHandler(this.bt_PayMaster_Click);
            // 
            // bt_PayVisa
            // 
            this.bt_PayVisa.BackColor = System.Drawing.Color.BlueViolet;
            this.bt_PayVisa.CornerRadius = 30;
            this.bt_PayVisa.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayVisa.ForeColor = System.Drawing.Color.White;
            this.bt_PayVisa.Location = new System.Drawing.Point(177, 25);
            this.bt_PayVisa.Name = "bt_PayVisa";
            this.bt_PayVisa.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayVisa.Size = new System.Drawing.Size(150, 42);
            this.bt_PayVisa.TabIndex = 104;
            this.bt_PayVisa.Text = "Visa";
            this.bt_PayVisa.Click += new System.EventHandler(this.bt_PayVisa_Click);
            // 
            // bt_PayDebit
            // 
            this.bt_PayDebit.BackColor = System.Drawing.Color.BlueViolet;
            this.bt_PayDebit.CornerRadius = 30;
            this.bt_PayDebit.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayDebit.ForeColor = System.Drawing.Color.White;
            this.bt_PayDebit.Location = new System.Drawing.Point(21, 25);
            this.bt_PayDebit.Name = "bt_PayDebit";
            this.bt_PayDebit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayDebit.Size = new System.Drawing.Size(150, 42);
            this.bt_PayDebit.TabIndex = 103;
            this.bt_PayDebit.Text = "Debit";
            this.bt_PayDebit.Click += new System.EventHandler(this.bt_PayDebit_Click);
            // 
            // txt_TipAmount
            // 
            this.txt_TipAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_TipAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TipAmount.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.txt_TipAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_TipAmount.Location = new System.Drawing.Point(250, 463);
            this.txt_TipAmount.Name = "txt_TipAmount";
            this.txt_TipAmount.ReadOnly = true;
            this.txt_TipAmount.Size = new System.Drawing.Size(197, 41);
            this.txt_TipAmount.TabIndex = 104;
            this.txt_TipAmount.Text = "0.00";
            this.txt_TipAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_TipAmount.Visible = false;
            this.txt_TipAmount.Click += new System.EventHandler(this.txt_TipAmount_Click);
            // 
            // labelTipOrCard
            // 
            this.labelTipOrCard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelTipOrCard.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTipOrCard.ForeColor = System.Drawing.Color.Black;
            this.labelTipOrCard.Location = new System.Drawing.Point(-40, 465);
            this.labelTipOrCard.Name = "labelTipOrCard";
            this.labelTipOrCard.Size = new System.Drawing.Size(293, 36);
            this.labelTipOrCard.TabIndex = 105;
            this.labelTipOrCard.Text = "Card :";
            this.labelTipOrCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_CardAmount
            // 
            this.txt_CardAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.txt_CardAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CardAmount.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CardAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_CardAmount.Location = new System.Drawing.Point(250, 463);
            this.txt_CardAmount.Name = "txt_CardAmount";
            this.txt_CardAmount.ReadOnly = true;
            this.txt_CardAmount.Size = new System.Drawing.Size(197, 39);
            this.txt_CardAmount.TabIndex = 107;
            this.txt_CardAmount.Text = "0.00";
            this.txt_CardAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_TotalDueUSD
            // 
            this.txt_TotalDueUSD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TotalDueUSD.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TotalDueUSD.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_TotalDueUSD.Location = new System.Drawing.Point(471, 275);
            this.txt_TotalDueUSD.Name = "txt_TotalDueUSD";
            this.txt_TotalDueUSD.ReadOnly = true;
            this.txt_TotalDueUSD.Size = new System.Drawing.Size(197, 39);
            this.txt_TotalDueUSD.TabIndex = 110;
            this.txt_TotalDueUSD.Text = "0.00";
            this.txt_TotalDueUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_ConvRate
            // 
            this.lbl_ConvRate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_ConvRate.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.lbl_ConvRate.ForeColor = System.Drawing.Color.DarkGreen;
            this.lbl_ConvRate.Location = new System.Drawing.Point(250, 216);
            this.lbl_ConvRate.Name = "lbl_ConvRate";
            this.lbl_ConvRate.Size = new System.Drawing.Size(197, 53);
            this.lbl_ConvRate.TabIndex = 111;
            this.lbl_ConvRate.Text = "Rate :";
            this.lbl_ConvRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_CashAmountUSD
            // 
            this.txt_CashAmountUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_CashAmountUSD.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CashAmountUSD.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CashAmountUSD.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_CashAmountUSD.Location = new System.Drawing.Point(471, 369);
            this.txt_CashAmountUSD.Name = "txt_CashAmountUSD";
            this.txt_CashAmountUSD.ReadOnly = true;
            this.txt_CashAmountUSD.Size = new System.Drawing.Size(197, 39);
            this.txt_CashAmountUSD.TabIndex = 112;
            this.txt_CashAmountUSD.Text = "0.00";
            this.txt_CashAmountUSD.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lbl_Short
            // 
            this.lbl_Short.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lbl_Short.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Short.ForeColor = System.Drawing.Color.Yellow;
            this.lbl_Short.Location = new System.Drawing.Point(453, 410);
            this.lbl_Short.Name = "lbl_Short";
            this.lbl_Short.Size = new System.Drawing.Size(180, 53);
            this.lbl_Short.TabIndex = 114;
            this.lbl_Short.Text = "< Short";
            this.lbl_Short.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // bt_OpenCD
            // 
            this.bt_OpenCD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_OpenCD.CornerRadius = 30;
            this.bt_OpenCD.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_OpenCD.ForeColor = System.Drawing.Color.Black;
            this.bt_OpenCD.Location = new System.Drawing.Point(18, 221);
            this.bt_OpenCD.Name = "bt_OpenCD";
            this.bt_OpenCD.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_OpenCD.Size = new System.Drawing.Size(150, 52);
            this.bt_OpenCD.TabIndex = 113;
            this.bt_OpenCD.Text = "Open C/D";
            this.bt_OpenCD.Click += new System.EventHandler(this.bt_OpenCD_Click);
            // 
            // bt_IPSPayment
            // 
            this.bt_IPSPayment.BackColor = System.Drawing.Color.MidnightBlue;
            this.bt_IPSPayment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bt_IPSPayment.BackgroundImage")));
            this.bt_IPSPayment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_IPSPayment.CornerRadius = 5;
            this.bt_IPSPayment.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_IPSPayment.ForeColor = System.Drawing.Color.White;
            this.bt_IPSPayment.Location = new System.Drawing.Point(39, 699);
            this.bt_IPSPayment.Name = "bt_IPSPayment";
            this.bt_IPSPayment.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_IPSPayment.Size = new System.Drawing.Size(618, 35);
            this.bt_IPSPayment.TabIndex = 108;
            this.bt_IPSPayment.Text = "Card Terminal Pay ( Changes Amount to Card Terminal )";
            this.bt_IPSPayment.Visible = false;
            this.bt_IPSPayment.Click += new System.EventHandler(this.bt_IPSPayment_Click);
            // 
            // btNumReset
            // 
            this.btNumReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btNumReset.CornerRadius = 30;
            this.btNumReset.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNumReset.ForeColor = System.Drawing.Color.Black;
            this.btNumReset.Location = new System.Drawing.Point(526, 568);
            this.btNumReset.Name = "btNumReset";
            this.btNumReset.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumReset.Size = new System.Drawing.Size(150, 52);
            this.btNumReset.TabIndex = 34;
            this.btNumReset.Text = "Reset";
            this.btNumReset.Click += new System.EventHandler(this.btNumReset_Click);
            // 
            // bt_PayCash
            // 
            this.bt_PayCash.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_PayCash.CornerRadius = 30;
            this.bt_PayCash.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayCash.ForeColor = System.Drawing.Color.Black;
            this.bt_PayCash.Location = new System.Drawing.Point(18, 510);
            this.bt_PayCash.Name = "bt_PayCash";
            this.bt_PayCash.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayCash.Size = new System.Drawing.Size(190, 110);
            this.bt_PayCash.TabIndex = 22;
            this.bt_PayCash.Text = "Cash";
            this.bt_PayCash.Click += new System.EventHandler(this.bt_PayCash_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.White;
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.Red;
            this.bt_Exit.Location = new System.Drawing.Point(526, 510);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(150, 52);
            this.bt_Exit.TabIndex = 16;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_ShowUSD
            // 
            this.bt_ShowUSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_ShowUSD.CornerRadius = 10;
            this.bt_ShowUSD.Font = new System.Drawing.Font("Arial Black", 14F, System.Drawing.FontStyle.Bold);
            this.bt_ShowUSD.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bt_ShowUSD.Location = new System.Drawing.Point(471, 224);
            this.bt_ShowUSD.Name = "bt_ShowUSD";
            this.bt_ShowUSD.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ShowUSD.Size = new System.Drawing.Size(205, 41);
            this.bt_ShowUSD.TabIndex = 109;
            this.bt_ShowUSD.Text = "USD (US$)";
            this.bt_ShowUSD.Click += new System.EventHandler(this.bt_ShowUSD_Click);
            // 
            // bt_ChangesToTip
            // 
            this.bt_ChangesToTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_ChangesToTip.CornerRadius = 30;
            this.bt_ChangesToTip.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ChangesToTip.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_ChangesToTip.Location = new System.Drawing.Point(471, 470);
            this.bt_ChangesToTip.Name = "bt_ChangesToTip";
            this.bt_ChangesToTip.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ChangesToTip.Size = new System.Drawing.Size(200, 41);
            this.bt_ChangesToTip.TabIndex = 106;
            this.bt_ChangesToTip.Text = "Changes to Tip";
            this.bt_ChangesToTip.Visible = false;
            this.bt_ChangesToTip.Click += new System.EventHandler(this.bt_ChangesToTip_Click);
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(-40, 319);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 39);
            this.label3.TabIndex = 115;
            this.label3.Text = "Cash Due :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_CashDue
            // 
            this.txt_CashDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CashDue.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CashDue.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_CashDue.Location = new System.Drawing.Point(250, 322);
            this.txt_CashDue.Name = "txt_CashDue";
            this.txt_CashDue.ReadOnly = true;
            this.txt_CashDue.Size = new System.Drawing.Size(197, 39);
            this.txt_CashDue.TabIndex = 116;
            this.txt_CashDue.Text = "0.00";
            this.txt_CashDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // bt_PayCheque
            // 
            this.bt_PayCheque.BackColor = System.Drawing.Color.Goldenrod;
            this.bt_PayCheque.CornerRadius = 30;
            this.bt_PayCheque.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayCheque.ForeColor = System.Drawing.Color.Black;
            this.bt_PayCheque.Location = new System.Drawing.Point(214, 510);
            this.bt_PayCheque.Name = "bt_PayCheque";
            this.bt_PayCheque.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayCheque.Size = new System.Drawing.Size(190, 52);
            this.bt_PayCheque.TabIndex = 117;
            this.bt_PayCheque.Text = "Cheque";
            this.bt_PayCheque.Click += new System.EventHandler(this.bt_PayCheque_Click);
            // 
            // bt_PayCharge
            // 
            this.bt_PayCharge.BackColor = System.Drawing.Color.NavajoWhite;
            this.bt_PayCharge.CornerRadius = 30;
            this.bt_PayCharge.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayCharge.ForeColor = System.Drawing.Color.Black;
            this.bt_PayCharge.Location = new System.Drawing.Point(214, 568);
            this.bt_PayCharge.Name = "bt_PayCharge";
            this.bt_PayCharge.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayCharge.Size = new System.Drawing.Size(190, 52);
            this.bt_PayCharge.TabIndex = 118;
            this.bt_PayCharge.Text = "Charge";
            this.bt_PayCharge.Click += new System.EventHandler(this.bt_PayCharge_Click);
            // 
            // frmCashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(698, 744);
            this.ControlBox = false;
            this.Controls.Add(this.bt_PayCharge);
            this.Controls.Add(this.bt_PayCheque);
            this.Controls.Add(this.txt_CashDue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Short);
            this.Controls.Add(this.bt_OpenCD);
            this.Controls.Add(this.txt_CashAmountUSD);
            this.Controls.Add(this.txt_TotalDueUSD);
            this.Controls.Add(this.bt_IPSPayment);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_Changes);
            this.Controls.Add(this.lbl_Changes);
            this.Controls.Add(this.txt_CashAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TotalDue);
            this.Controls.Add(this.btNumReset);
            this.Controls.Add(this.bt_PayCash);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CardAmount);
            this.Controls.Add(this.labelTipOrCard);
            this.Controls.Add(this.bt_ShowUSD);
            this.Controls.Add(this.lblPartialPay);
            this.Controls.Add(this.pnlNumPad);
            this.Controls.Add(this.lblUerName);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.bt_ChangesToTip);
            this.Controls.Add(this.txt_TipAmount);
            this.Controls.Add(this.lbl_ConvRate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCashPayment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCardPayment";
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmCashPayment_Activated);
            this.Load += new System.EventHandler(this.frmCashPayment_Load);
            this.pnlNumPad.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label lblInvoiceNo;
        private SDCafeCommon.Utilities.CustomButton bt_PayCash;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblUerName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel pnlNumPad;
        private SDCafeCommon.Utilities.CustomButton btNumSame;
        private SDCafeCommon.Utilities.CustomButton btNumReset;
        private SDCafeCommon.Utilities.CustomButton btNum0;
        private SDCafeCommon.Utilities.CustomButton btNum9;
        private SDCafeCommon.Utilities.CustomButton btNum8;
        private SDCafeCommon.Utilities.CustomButton btNum7;
        private SDCafeCommon.Utilities.CustomButton btNum6;
        private SDCafeCommon.Utilities.CustomButton btNum3;
        private SDCafeCommon.Utilities.CustomButton btNum5;
        private SDCafeCommon.Utilities.CustomButton btNum2;
        private SDCafeCommon.Utilities.CustomButton btNum4;
        private SDCafeCommon.Utilities.CustomButton btNum1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TotalDue;
        private System.Windows.Forms.TextBox txt_CashAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Changes;
        private System.Windows.Forms.Label lbl_Changes;
        private System.Windows.Forms.Label lblPartialPay;
        private SDCafeCommon.Utilities.CustomButton bt_50;
        private SDCafeCommon.Utilities.CustomButton bt_100;
        private SDCafeCommon.Utilities.CustomButton bt_5;
        private SDCafeCommon.Utilities.CustomButton bt_20;
        private SDCafeCommon.Utilities.CustomButton bt_10;
        private System.Windows.Forms.GroupBox groupBox1;
        private SDCafeCommon.Utilities.CustomButton bt_PayAmex;
        private SDCafeCommon.Utilities.CustomButton bt_PayMaster;
        private SDCafeCommon.Utilities.CustomButton bt_PayVisa;
        private SDCafeCommon.Utilities.CustomButton bt_PayDebit;
        private System.Windows.Forms.TextBox txt_TipAmount;
        private System.Windows.Forms.Label labelTipOrCard;
        private SDCafeCommon.Utilities.CustomButton bt_ChangesToTip;
        private System.Windows.Forms.TextBox txt_CardAmount;
        private SDCafeCommon.Utilities.CustomButton bt_IPSPayment;
        private SDCafeCommon.Utilities.CustomButton bt_ShowUSD;
        private System.Windows.Forms.TextBox txt_TotalDueUSD;
        private System.Windows.Forms.Label lbl_ConvRate;
        private System.Windows.Forms.TextBox txt_CashAmountUSD;
        private SDCafeCommon.Utilities.CustomButton bt_OpenCD;
        private System.Windows.Forms.Label lbl_Short;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CashDue;
        private SDCafeCommon.Utilities.CustomButton bt_PayCheque;
        private SDCafeCommon.Utilities.CustomButton bt_PayCharge;
    }
}