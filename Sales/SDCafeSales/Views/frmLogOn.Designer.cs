
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
            this.pnlNums = new System.Windows.Forms.Panel();
            this.txtPassCode = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBoxBizTitle = new System.Windows.Forms.TextBox();
            this.bt_ClockIn = new System.Windows.Forms.Button();
            this.bt_ClockOut = new System.Windows.Forms.Button();
            this.listBoxClockInOut = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(48, 682);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(913, 32);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // textBoxBizTitle
            // 
            this.textBoxBizTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxBizTitle.Location = new System.Drawing.Point(65, 95);
            this.textBoxBizTitle.Name = "textBoxBizTitle";
            this.textBoxBizTitle.ReadOnly = true;
            this.textBoxBizTitle.Size = new System.Drawing.Size(873, 62);
            this.textBoxBizTitle.TabIndex = 8;
            this.textBoxBizTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_ClockIn
            // 
            this.bt_ClockIn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_ClockIn.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ClockIn.ForeColor = System.Drawing.Color.Black;
            this.bt_ClockIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ClockIn.Location = new System.Drawing.Point(17, 37);
            this.bt_ClockIn.Name = "bt_ClockIn";
            this.bt_ClockIn.Size = new System.Drawing.Size(180, 59);
            this.bt_ClockIn.TabIndex = 9;
            this.bt_ClockIn.Text = "Clock In";
            this.bt_ClockIn.UseVisualStyleBackColor = false;
            this.bt_ClockIn.Click += new System.EventHandler(this.bt_ClockIn_Click);
            // 
            // bt_ClockOut
            // 
            this.bt_ClockOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_ClockOut.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_ClockOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bt_ClockOut.Location = new System.Drawing.Point(199, 37);
            this.bt_ClockOut.Name = "bt_ClockOut";
            this.bt_ClockOut.Size = new System.Drawing.Size(180, 59);
            this.bt_ClockOut.TabIndex = 10;
            this.bt_ClockOut.Text = "Clock Out";
            this.bt_ClockOut.UseVisualStyleBackColor = false;
            this.bt_ClockOut.Click += new System.EventHandler(this.bt_ClockOut_Click);
            // 
            // listBoxClockInOut
            // 
            this.listBoxClockInOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listBoxClockInOut.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxClockInOut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.listBoxClockInOut.FormattingEnabled = true;
            this.listBoxClockInOut.ItemHeight = 22;
            this.listBoxClockInOut.Location = new System.Drawing.Point(385, 19);
            this.listBoxClockInOut.Name = "listBoxClockInOut";
            this.listBoxClockInOut.Size = new System.Drawing.Size(504, 92);
            this.listBoxClockInOut.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxClockInOut);
            this.groupBox1.Controls.Add(this.bt_ClockOut);
            this.groupBox1.Controls.Add(this.bt_ClockIn);
            this.groupBox1.Location = new System.Drawing.Point(48, 549);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 127);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // frmLogOn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxBizTitle);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtPassCode);
            this.Controls.Add(this.pnlNums);
            this.Controls.Add(this.pictureBoxLogo);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLogOn";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome to Sales Module";
            this.Load += new System.EventHandler(this.frmLogOn_Load);
            this.Shown += new System.EventHandler(this.frmLogOn_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlNums;
        private System.Windows.Forms.TextBox txtPassCode;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TextBox textBoxBizTitle;
        private System.Windows.Forms.Button bt_ClockIn;
        private System.Windows.Forms.Button bt_ClockOut;
        private System.Windows.Forms.ListBox listBoxClockInOut;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

