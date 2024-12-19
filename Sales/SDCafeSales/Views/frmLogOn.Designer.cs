
namespace SDCafeSales
{
    partial class frmLogOn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogOn));
            this.pnlNums = new System.Windows.Forms.Panel();
            this.txtPassCode = new System.Windows.Forms.TextBox();
            this.textBoxBizTitle = new System.Windows.Forms.TextBox();
            this.bt_ClockIn = new System.Windows.Forms.Button();
            this.bt_ClockOut = new System.Windows.Forms.Button();
            this.listBoxClockInOut = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblStationName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlNums
            // 
            this.pnlNums.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNums.AutoSize = true;
            this.pnlNums.BackColor = System.Drawing.SystemColors.Desktop;
            this.pnlNums.Location = new System.Drawing.Point(65, 163);
            this.pnlNums.Name = "pnlNums";
            this.pnlNums.Size = new System.Drawing.Size(362, 311);
            this.pnlNums.TabIndex = 1;
            // 
            // txtPassCode
            // 
            this.txtPassCode.BackColor = System.Drawing.Color.Silver;
            this.txtPassCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassCode.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassCode.Location = new System.Drawing.Point(65, 480);
            this.txtPassCode.Multiline = true;
            this.txtPassCode.Name = "txtPassCode";
            this.txtPassCode.PasswordChar = '*';
            this.txtPassCode.Size = new System.Drawing.Size(362, 62);
            this.txtPassCode.TabIndex = 2;
            this.txtPassCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPassCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassCode_KeyDown);
            // 
            // textBoxBizTitle
            // 
            this.textBoxBizTitle.Font = new System.Drawing.Font("Roboto Condensed SemiBold", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBizTitle.Location = new System.Drawing.Point(65, 95);
            this.textBoxBizTitle.Name = "textBoxBizTitle";
            this.textBoxBizTitle.ReadOnly = true;
            this.textBoxBizTitle.Size = new System.Drawing.Size(873, 65);
            this.textBoxBizTitle.TabIndex = 8;
            this.textBoxBizTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_ClockIn
            // 
            this.bt_ClockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_ClockIn.BackgroundImage = global::SDCafeSales.Properties.Resources.clock_In;
            this.bt_ClockIn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ClockIn.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ClockIn.ForeColor = System.Drawing.Color.Black;
            this.bt_ClockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ClockIn.Location = new System.Drawing.Point(81, 36);
            this.bt_ClockIn.Name = "bt_ClockIn";
            this.bt_ClockIn.Size = new System.Drawing.Size(80, 80);
            this.bt_ClockIn.TabIndex = 9;
            this.bt_ClockIn.UseVisualStyleBackColor = false;
            this.bt_ClockIn.Click += new System.EventHandler(this.bt_ClockIn_Click);
            // 
            // bt_ClockOut
            // 
            this.bt_ClockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.bt_ClockOut.BackgroundImage = global::SDCafeSales.Properties.Resources.clock_Out;
            this.bt_ClockOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bt_ClockOut.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ClockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ClockOut.Location = new System.Drawing.Point(185, 36);
            this.bt_ClockOut.Name = "bt_ClockOut";
            this.bt_ClockOut.Size = new System.Drawing.Size(80, 80);
            this.bt_ClockOut.TabIndex = 10;
            this.bt_ClockOut.UseVisualStyleBackColor = false;
            this.bt_ClockOut.Click += new System.EventHandler(this.bt_ClockOut_Click);
            // 
            // listBoxClockInOut
            // 
            this.listBoxClockInOut.BackColor = System.Drawing.Color.DimGray;
            this.listBoxClockInOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxClockInOut.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClockInOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBoxClockInOut.FormattingEnabled = true;
            this.listBoxClockInOut.ItemHeight = 22;
            this.listBoxClockInOut.Location = new System.Drawing.Point(303, 15);
            this.listBoxClockInOut.Name = "listBoxClockInOut";
            this.listBoxClockInOut.Size = new System.Drawing.Size(586, 112);
            this.listBoxClockInOut.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBoxClockInOut);
            this.groupBox1.Controls.Add(this.bt_ClockOut);
            this.groupBox1.Controls.Add(this.bt_ClockIn);
            this.groupBox1.Location = new System.Drawing.Point(48, 549);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 127);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(187, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Clock Out";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(88, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 18);
            this.label1.TabIndex = 12;
            this.label1.Text = "Clock In";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBoxLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxLogo.Location = new System.Drawing.Point(433, 163);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(504, 379);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 6;
            this.pictureBoxLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SDCafeSales.Properties.Resources.TSE_CI_2024;
            this.pictureBox1.Location = new System.Drawing.Point(806, 690);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(48, 690);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(757, 32);
            this.txtMessage.TabIndex = 13;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblStationName
            // 
            this.lblStationName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStationName.AutoSize = true;
            this.lblStationName.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStationName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStationName.Location = new System.Drawing.Point(872, 9);
            this.lblStationName.Name = "lblStationName";
            this.lblStationName.Size = new System.Drawing.Size(124, 25);
            this.lblStationName.TabIndex = 14;
            this.lblStationName.Text = "Station Name";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(731, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Station Name :";
            // 
            // frmLogOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStationName);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxBizTitle);
            this.Controls.Add(this.txtPassCode);
            this.Controls.Add(this.pnlNums);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLogOn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Sales Module";
            this.Load += new System.EventHandler(this.frmLogOn_Load);
            this.Shown += new System.EventHandler(this.frmLogOn_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNums;
        private System.Windows.Forms.TextBox txtPassCode;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxBizTitle;
        private System.Windows.Forms.Button bt_ClockIn;
        private System.Windows.Forms.Button bt_ClockOut;
        private System.Windows.Forms.ListBox listBoxClockInOut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblStationName;
        private System.Windows.Forms.Label label3;
    }
}

