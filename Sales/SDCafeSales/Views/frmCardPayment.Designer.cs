namespace SDCafeSales.Views
{
    partial class frmCardPayment
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
            this.text_IPADDR = new System.Windows.Forms.TextBox();
            this.text_PortNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_CardData = new System.Windows.Forms.DataGridView();
            this.bt_Connect = new System.Windows.Forms.Button();
            this.bt_Disconnect = new System.Windows.Forms.Button();
            this.bt_Send = new System.Windows.Forms.Button();
            this.text_Data2Send = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_PayPinPad = new SDCafeCommon.Utilities.CustomButton();
            this.bt_PayCash = new SDCafeCommon.Utilities.CustomButton();
            this.lblStation = new System.Windows.Forms.Label();
            this.lblUerName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CardData)).BeginInit();
            this.SuspendLayout();
            // 
            // text_IPADDR
            // 
            this.text_IPADDR.Location = new System.Drawing.Point(517, 134);
            this.text_IPADDR.Name = "text_IPADDR";
            this.text_IPADDR.Size = new System.Drawing.Size(161, 20);
            this.text_IPADDR.TabIndex = 0;
            this.text_IPADDR.Visible = false;
            // 
            // text_PortNo
            // 
            this.text_PortNo.Location = new System.Drawing.Point(362, 134);
            this.text_PortNo.Name = "text_PortNo";
            this.text_PortNo.Size = new System.Drawing.Size(82, 20);
            this.text_PortNo.TabIndex = 1;
            this.text_PortNo.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(460, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP ADDR";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "PORT#";
            this.label2.Visible = false;
            // 
            // dgv_CardData
            // 
            this.dgv_CardData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CardData.Location = new System.Drawing.Point(12, 277);
            this.dgv_CardData.Name = "dgv_CardData";
            this.dgv_CardData.Size = new System.Drawing.Size(658, 63);
            this.dgv_CardData.TabIndex = 4;
            this.dgv_CardData.Visible = false;
            // 
            // bt_Connect
            // 
            this.bt_Connect.Location = new System.Drawing.Point(648, 90);
            this.bt_Connect.Name = "bt_Connect";
            this.bt_Connect.Size = new System.Drawing.Size(102, 40);
            this.bt_Connect.TabIndex = 5;
            this.bt_Connect.Text = "Connect";
            this.bt_Connect.UseVisualStyleBackColor = true;
            this.bt_Connect.Visible = false;
            this.bt_Connect.Click += new System.EventHandler(this.bt_Connect_Click);
            // 
            // bt_Disconnect
            // 
            this.bt_Disconnect.Location = new System.Drawing.Point(648, 131);
            this.bt_Disconnect.Name = "bt_Disconnect";
            this.bt_Disconnect.Size = new System.Drawing.Size(102, 40);
            this.bt_Disconnect.TabIndex = 6;
            this.bt_Disconnect.Text = "Disconnect";
            this.bt_Disconnect.UseVisualStyleBackColor = true;
            this.bt_Disconnect.Visible = false;
            this.bt_Disconnect.Click += new System.EventHandler(this.bt_Disconnect_Click);
            // 
            // bt_Send
            // 
            this.bt_Send.Location = new System.Drawing.Point(648, 44);
            this.bt_Send.Name = "bt_Send";
            this.bt_Send.Size = new System.Drawing.Size(102, 40);
            this.bt_Send.TabIndex = 7;
            this.bt_Send.Text = "Send";
            this.bt_Send.UseVisualStyleBackColor = true;
            this.bt_Send.Visible = false;
            this.bt_Send.Click += new System.EventHandler(this.bt_Send_Click);
            // 
            // text_Data2Send
            // 
            this.text_Data2Send.Location = new System.Drawing.Point(120, 134);
            this.text_Data2Send.Name = "text_Data2Send";
            this.text_Data2Send.Size = new System.Drawing.Size(161, 20);
            this.text_Data2Send.TabIndex = 8;
            this.text_Data2Send.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(13, 210);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(657, 64);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Follow the PinPad Instruction...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAmount
            // 
            this.lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblAmount.Location = new System.Drawing.Point(13, 157);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(657, 46);
            this.lblAmount.TabIndex = 10;
            this.lblAmount.Text = "Amount : $999.99";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.White;
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.Red;
            this.bt_Exit.Location = new System.Drawing.Point(455, 277);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(215, 63);
            this.bt_Exit.TabIndex = 16;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
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
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkOrange;
            this.label3.Location = new System.Drawing.Point(105, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(454, 28);
            this.label3.TabIndex = 20;
            this.label3.Text = "Accept all major Debit and Credit Cards";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_PayPinPad
            // 
            this.bt_PayPinPad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.bt_PayPinPad.CornerRadius = 30;
            this.bt_PayPinPad.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayPinPad.ForeColor = System.Drawing.Color.Black;
            this.bt_PayPinPad.Location = new System.Drawing.Point(12, 277);
            this.bt_PayPinPad.Name = "bt_PayPinPad";
            this.bt_PayPinPad.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayPinPad.Size = new System.Drawing.Size(215, 63);
            this.bt_PayPinPad.TabIndex = 21;
            this.bt_PayPinPad.Text = "Debit / Credit";
            this.bt_PayPinPad.Click += new System.EventHandler(this.bt_PayPinPad_Click);
            // 
            // bt_PayCash
            // 
            this.bt_PayCash.BackColor = System.Drawing.Color.Yellow;
            this.bt_PayCash.CornerRadius = 30;
            this.bt_PayCash.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold);
            this.bt_PayCash.ForeColor = System.Drawing.Color.Black;
            this.bt_PayCash.Location = new System.Drawing.Point(233, 277);
            this.bt_PayCash.Name = "bt_PayCash";
            this.bt_PayCash.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_PayCash.Size = new System.Drawing.Size(215, 63);
            this.bt_PayCash.TabIndex = 22;
            this.bt_PayCash.Text = "Cash";
            this.bt_PayCash.Click += new System.EventHandler(this.bt_PayCash_Click);
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.panel1.BackgroundImage = global::SDCafeSales.Properties.Resources.credit_cards_all;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Location = new System.Drawing.Point(105, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 44);
            this.panel1.TabIndex = 19;
            // 
            // timer2
            // 
            this.timer2.Interval = 2000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmCardPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(682, 376);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_PortNo);
            this.Controls.Add(this.lblUerName);
            this.Controls.Add(this.lblStation);
            this.Controls.Add(this.bt_PayCash);
            this.Controls.Add(this.bt_PayPinPad);
            this.Controls.Add(this.text_Data2Send);
            this.Controls.Add(this.bt_Send);
            this.Controls.Add(this.bt_Disconnect);
            this.Controls.Add(this.bt_Connect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.dgv_CardData);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_IPADDR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardPayment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCardPayment";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmCardPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CardData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox text_IPADDR;
        private System.Windows.Forms.TextBox text_PortNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_CardData;
        private System.Windows.Forms.Button bt_Connect;
        private System.Windows.Forms.Button bt_Disconnect;
        private System.Windows.Forms.Button bt_Send;
        private System.Windows.Forms.TextBox text_Data2Send;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAmount;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private SDCafeCommon.Utilities.CustomButton bt_PayPinPad;
        private SDCafeCommon.Utilities.CustomButton bt_PayCash;
        private System.Windows.Forms.Label lblStation;
        private System.Windows.Forms.Label lblUerName;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer timer1;
    }
}