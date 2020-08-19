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
            this.label3 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.btNumReset = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayCash = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bt_PayAmex = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayMaster = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayVisa = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayDebit = new SDCafeCommon.Utilities.CustomButton();
            this.txt_TipAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.bt_ChangesToTip = new SDCafeCommon.Utilities.CustomButton();
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
            this.pnlNumPad.Size = new System.Drawing.Size(673, 209);
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
            this.bt_50.Size = new System.Drawing.Size(104, 63);
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
            this.bt_100.Location = new System.Drawing.Point(559, 72);
            this.bt_100.Name = "bt_100";
            this.bt_100.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_100.Size = new System.Drawing.Size(104, 63);
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
            this.bt_5.Size = new System.Drawing.Size(104, 63);
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
            this.bt_20.Location = new System.Drawing.Point(449, 141);
            this.bt_20.Name = "bt_20";
            this.bt_20.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_20.Size = new System.Drawing.Size(104, 63);
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
            this.bt_10.Location = new System.Drawing.Point(449, 72);
            this.bt_10.Name = "bt_10";
            this.bt_10.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_10.Size = new System.Drawing.Size(104, 63);
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
            this.btNumSame.Location = new System.Drawing.Point(559, 141);
            this.btNumSame.Name = "btNumSame";
            this.btNumSame.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumSame.Size = new System.Drawing.Size(104, 63);
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
            this.btNum0.Location = new System.Drawing.Point(338, 72);
            this.btNum0.Name = "btNum0";
            this.btNum0.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum0.Size = new System.Drawing.Size(104, 63);
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
            this.btNum9.Location = new System.Drawing.Point(227, 141);
            this.btNum9.Name = "btNum9";
            this.btNum9.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum9.Size = new System.Drawing.Size(104, 63);
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
            this.btNum8.Location = new System.Drawing.Point(116, 141);
            this.btNum8.Name = "btNum8";
            this.btNum8.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum8.Size = new System.Drawing.Size(104, 63);
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
            this.btNum7.Location = new System.Drawing.Point(5, 141);
            this.btNum7.Name = "btNum7";
            this.btNum7.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum7.Size = new System.Drawing.Size(104, 63);
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
            this.btNum6.Location = new System.Drawing.Point(227, 72);
            this.btNum6.Name = "btNum6";
            this.btNum6.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum6.Size = new System.Drawing.Size(104, 63);
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
            this.btNum3.Size = new System.Drawing.Size(104, 63);
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
            this.btNum5.Location = new System.Drawing.Point(116, 72);
            this.btNum5.Name = "btNum5";
            this.btNum5.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum5.Size = new System.Drawing.Size(104, 63);
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
            this.btNum2.Size = new System.Drawing.Size(104, 63);
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
            this.btNum4.Location = new System.Drawing.Point(5, 72);
            this.btNum4.Name = "btNum4";
            this.btNum4.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNum4.Size = new System.Drawing.Size(104, 63);
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
            this.btNum1.Size = new System.Drawing.Size(104, 63);
            this.btNum1.TabIndex = 17;
            this.btNum1.Text = "1";
            this.btNum1.Click += new System.EventHandler(this.btNum1_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(-22, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 53);
            this.label1.TabIndex = 27;
            this.label1.Text = "Due Amount :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_TotalDue
            // 
            this.txt_TotalDue.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_TotalDue.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.txt_TotalDue.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_TotalDue.Location = new System.Drawing.Point(268, 262);
            this.txt_TotalDue.Name = "txt_TotalDue";
            this.txt_TotalDue.ReadOnly = true;
            this.txt_TotalDue.Size = new System.Drawing.Size(197, 41);
            this.txt_TotalDue.TabIndex = 93;
            this.txt_TotalDue.Text = "0.00";
            this.txt_TotalDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_CashAmount
            // 
            this.txt_CashAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_CashAmount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_CashAmount.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.txt_CashAmount.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_CashAmount.Location = new System.Drawing.Point(268, 312);
            this.txt_CashAmount.Name = "txt_CashAmount";
            this.txt_CashAmount.ReadOnly = true;
            this.txt_CashAmount.Size = new System.Drawing.Size(197, 41);
            this.txt_CashAmount.TabIndex = 95;
            this.txt_CashAmount.Text = "0.00";
            this.txt_CashAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.DarkGreen;
            this.label2.Location = new System.Drawing.Point(-22, 306);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 53);
            this.label2.TabIndex = 94;
            this.label2.Text = "Cash :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txt_Changes
            // 
            this.txt_Changes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.txt_Changes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Changes.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.txt_Changes.ForeColor = System.Drawing.Color.DarkRed;
            this.txt_Changes.Location = new System.Drawing.Point(268, 362);
            this.txt_Changes.Name = "txt_Changes";
            this.txt_Changes.ReadOnly = true;
            this.txt_Changes.Size = new System.Drawing.Size(197, 41);
            this.txt_Changes.TabIndex = 97;
            this.txt_Changes.Text = "0.00";
            this.txt_Changes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(-22, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 53);
            this.label3.TabIndex = 96;
            this.label3.Text = "Changes :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTest
            // 
            this.lblTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTest.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTest.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTest.Location = new System.Drawing.Point(-64, 308);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(143, 53);
            this.lblTest.TabIndex = 98;
            this.lblTest.Text = "test";
            this.lblTest.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTest.Visible = false;
            // 
            // btNumReset
            // 
            this.btNumReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btNumReset.CornerRadius = 30;
            this.btNumReset.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNumReset.ForeColor = System.Drawing.Color.Black;
            this.btNumReset.Location = new System.Drawing.Point(250, 462);
            this.btNumReset.Name = "btNumReset";
            this.btNumReset.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumReset.Size = new System.Drawing.Size(197, 63);
            this.btNumReset.TabIndex = 34;
            this.btNumReset.Text = "Reset";
            this.btNumReset.Click += new System.EventHandler(this.btNumReset_Click);
            // 
            // bt_PayCash
            // 
            this.bt_PayCash.BackColor = System.Drawing.Color.Yellow;
            this.bt_PayCash.CornerRadius = 30;
            this.bt_PayCash.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayCash.ForeColor = System.Drawing.Color.Black;
            this.bt_PayCash.Location = new System.Drawing.Point(18, 462);
            this.bt_PayCash.Name = "bt_PayCash";
            this.bt_PayCash.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayCash.Size = new System.Drawing.Size(221, 63);
            this.bt_PayCash.TabIndex = 22;
            this.bt_PayCash.Text = "Cash Payment";
            this.bt_PayCash.Click += new System.EventHandler(this.bt_PayCash_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.White;
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.Red;
            this.bt_Exit.Location = new System.Drawing.Point(453, 462);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(223, 63);
            this.bt_Exit.TabIndex = 16;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bt_PayAmex);
            this.groupBox1.Controls.Add(this.bt_PayMaster);
            this.groupBox1.Controls.Add(this.bt_PayVisa);
            this.groupBox1.Controls.Add(this.bt_PayDebit);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(18, 527);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 103);
            this.groupBox1.TabIndex = 103;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manual Payment";
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
            this.bt_PayAmex.Size = new System.Drawing.Size(150, 63);
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
            this.bt_PayMaster.Size = new System.Drawing.Size(150, 63);
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
            this.bt_PayVisa.Size = new System.Drawing.Size(150, 63);
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
            this.bt_PayDebit.Size = new System.Drawing.Size(150, 63);
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
            this.txt_TipAmount.Location = new System.Drawing.Point(268, 412);
            this.txt_TipAmount.Name = "txt_TipAmount";
            this.txt_TipAmount.ReadOnly = true;
            this.txt_TipAmount.Size = new System.Drawing.Size(197, 41);
            this.txt_TipAmount.TabIndex = 104;
            this.txt_TipAmount.Text = "0.00";
            this.txt_TipAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_TipAmount.Click += new System.EventHandler(this.txt_TipAmount_Click);
            // 
            // label4
            // 
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(-22, 406);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(293, 53);
            this.label4.TabIndex = 105;
            this.label4.Text = "Tip :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bt_ChangesToTip
            // 
            this.bt_ChangesToTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_ChangesToTip.CornerRadius = 30;
            this.bt_ChangesToTip.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ChangesToTip.ForeColor = System.Drawing.Color.DarkRed;
            this.bt_ChangesToTip.Location = new System.Drawing.Point(471, 362);
            this.bt_ChangesToTip.Name = "bt_ChangesToTip";
            this.bt_ChangesToTip.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_ChangesToTip.Size = new System.Drawing.Size(200, 41);
            this.bt_ChangesToTip.TabIndex = 106;
            this.bt_ChangesToTip.Text = "Changes to Tip";
            this.bt_ChangesToTip.Click += new System.EventHandler(this.bt_ChangesToTip_Click);
            // 
            // frmCashPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(696, 642);
            this.ControlBox = false;
            this.Controls.Add(this.bt_ChangesToTip);
            this.Controls.Add(this.txt_TipAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.txt_Changes);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_CashAmount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_TotalDue);
            this.Controls.Add(this.btNumReset);
            this.Controls.Add(this.bt_PayCash);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlNumPad);
            this.Controls.Add(this.lblUerName);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.lblInvoiceNo);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTest;
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
        private System.Windows.Forms.Label label4;
        private SDCafeCommon.Utilities.CustomButton bt_ChangesToTip;
    }
}