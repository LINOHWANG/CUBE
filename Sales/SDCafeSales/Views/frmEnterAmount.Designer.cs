namespace SDCafeSales.Views
{
    partial class frmEnterAmount
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
            this.pnlNumPad = new System.Windows.Forms.Panel();
            this.txt_Amount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.bt_Process = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.btNumClear = new SDCafeCommon.Utilities.CustomButton();
            this.btNumDelete = new SDCafeCommon.Utilities.CustomButton();
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
            this.lblTest = new System.Windows.Forms.Label();
            this.pnlNumPad.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlNumPad
            // 
            this.pnlNumPad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.pnlNumPad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNumPad.Controls.Add(this.btNumClear);
            this.pnlNumPad.Controls.Add(this.btNumDelete);
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
            this.pnlNumPad.Location = new System.Drawing.Point(15, 148);
            this.pnlNumPad.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlNumPad.Name = "pnlNumPad";
            this.pnlNumPad.Size = new System.Drawing.Size(451, 209);
            this.pnlNumPad.TabIndex = 27;
            // 
            // txt_Amount
            // 
            this.txt_Amount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Amount.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.txt_Amount.ForeColor = System.Drawing.Color.DarkBlue;
            this.txt_Amount.Location = new System.Drawing.Point(269, 96);
            this.txt_Amount.Name = "txt_Amount";
            this.txt_Amount.ReadOnly = true;
            this.txt_Amount.Size = new System.Drawing.Size(197, 41);
            this.txt_Amount.TabIndex = 95;
            this.txt_Amount.Text = "0.00";
            this.txt_Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(19, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 53);
            this.label1.TabIndex = 94;
            this.label1.Text = "Amount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTitle.Font = new System.Drawing.Font("Arial Black", 21.75F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(19, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(447, 81);
            this.lblTitle.TabIndex = 96;
            this.lblTitle.Text = "Title";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_Process
            // 
            this.bt_Process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_Process.CornerRadius = 30;
            this.bt_Process.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Process.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.bt_Process.Location = new System.Drawing.Point(15, 365);
            this.bt_Process.Name = "bt_Process";
            this.bt_Process.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Process.Size = new System.Drawing.Size(295, 62);
            this.bt_Process.TabIndex = 98;
            this.bt_Process.Text = "Process";
            this.bt_Process.Click += new System.EventHandler(this.bt_Process_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.Red;
            this.bt_Exit.Location = new System.Drawing.Point(316, 365);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(150, 62);
            this.bt_Exit.TabIndex = 97;
            this.bt_Exit.Text = "Cancel";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // btNumClear
            // 
            this.btNumClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btNumClear.CornerRadius = 30;
            this.btNumClear.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNumClear.ForeColor = System.Drawing.Color.Blue;
            this.btNumClear.Location = new System.Drawing.Point(337, 141);
            this.btNumClear.Name = "btNumClear";
            this.btNumClear.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumClear.Size = new System.Drawing.Size(104, 63);
            this.btNumClear.TabIndex = 35;
            this.btNumClear.Text = "CLR";
            this.btNumClear.Click += new System.EventHandler(this.btNumClear_Click);
            // 
            // btNumDelete
            // 
            this.btNumDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btNumDelete.CornerRadius = 30;
            this.btNumDelete.Font = new System.Drawing.Font("Arial Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNumDelete.ForeColor = System.Drawing.Color.Blue;
            this.btNumDelete.Location = new System.Drawing.Point(337, 3);
            this.btNumDelete.Name = "btNumDelete";
            this.btNumDelete.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.btNumDelete.Size = new System.Drawing.Size(104, 63);
            this.btNumDelete.TabIndex = 34;
            this.btNumDelete.Text = "DEL";
            this.btNumDelete.Click += new System.EventHandler(this.btNumDelete_Click);
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
            // lblTest
            // 
            this.lblTest.BackColor = System.Drawing.Color.Transparent;
            this.lblTest.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblTest.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTest.Location = new System.Drawing.Point(346, -5);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(140, 53);
            this.lblTest.TabIndex = 99;
            this.lblTest.Text = "Amount";
            this.lblTest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmEnterAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(481, 441);
            this.ControlBox = false;
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.bt_Process);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txt_Amount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlNumPad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmEnterAmount";
            this.Text = "frmEnterAmount";
            this.Load += new System.EventHandler(this.frmEnterAmount_Load);
            this.pnlNumPad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNumPad;
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
        private System.Windows.Forms.TextBox txt_Amount;
        private System.Windows.Forms.Label label1;
        private SDCafeCommon.Utilities.CustomButton btNumDelete;
        private System.Windows.Forms.Label lblTitle;
        private SDCafeCommon.Utilities.CustomButton btNumClear;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Process;
        private System.Windows.Forms.Label lblTest;
    }
}