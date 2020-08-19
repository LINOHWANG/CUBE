namespace SDCafeOffice.Views
{
    partial class frmStations
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
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_HostName = new System.Windows.Forms.TextBox();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Station = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_StationName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_IPAddr = new System.Windows.Forms.TextBox();
            this.check_IsActive = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_StationNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_IPS_Port = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(637, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 38;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 19);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 22);
            this.label10.TabIndex = 37;
            this.label10.Text = "HostName";
            // 
            // txt_HostName
            // 
            this.txt_HostName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_HostName.Location = new System.Drawing.Point(191, 16);
            this.txt_HostName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_HostName.Name = "txt_HostName";
            this.txt_HostName.Size = new System.Drawing.Size(249, 29);
            this.txt_HostName.TabIndex = 36;
            this.txt_HostName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Save
            // 
            this.bt_Save.CornerRadius = 30;
            this.bt_Save.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Save.Location = new System.Drawing.Point(637, 67);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Save.Size = new System.Drawing.Size(142, 47);
            this.bt_Save.TabIndex = 35;
            this.bt_Save.Text = "Save";
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 58);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "Station";
            // 
            // txt_Station
            // 
            this.txt_Station.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Station.Location = new System.Drawing.Point(191, 55);
            this.txt_Station.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_Station.Name = "txt_Station";
            this.txt_Station.Size = new System.Drawing.Size(249, 29);
            this.txt_Station.TabIndex = 39;
            this.txt_Station.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "Station Name";
            // 
            // txt_StationName
            // 
            this.txt_StationName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StationName.Location = new System.Drawing.Point(191, 94);
            this.txt_StationName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_StationName.Name = "txt_StationName";
            this.txt_StationName.Size = new System.Drawing.Size(249, 29);
            this.txt_StationName.TabIndex = 41;
            this.txt_StationName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "IPS IP Address";
            // 
            // txt_IPAddr
            // 
            this.txt_IPAddr.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IPAddr.Location = new System.Drawing.Point(191, 173);
            this.txt_IPAddr.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_IPAddr.Name = "txt_IPAddr";
            this.txt_IPAddr.Size = new System.Drawing.Size(249, 29);
            this.txt_IPAddr.TabIndex = 43;
            this.txt_IPAddr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // check_IsActive
            // 
            this.check_IsActive.AutoSize = true;
            this.check_IsActive.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_IsActive.Location = new System.Drawing.Point(191, 255);
            this.check_IsActive.Name = "check_IsActive";
            this.check_IsActive.Size = new System.Drawing.Size(101, 26);
            this.check_IsActive.TabIndex = 45;
            this.check_IsActive.Text = "Is Active";
            this.check_IsActive.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(-2, 382);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(790, 32);
            this.txtMessage.TabIndex = 46;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 22);
            this.label4.TabIndex = 48;
            this.label4.Text = "Station No";
            // 
            // txt_StationNo
            // 
            this.txt_StationNo.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_StationNo.Location = new System.Drawing.Point(191, 134);
            this.txt_StationNo.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_StationNo.Name = "txt_StationNo";
            this.txt_StationNo.Size = new System.Drawing.Size(249, 29);
            this.txt_StationNo.TabIndex = 47;
            this.txt_StationNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 22);
            this.label5.TabIndex = 50;
            this.label5.Text = "IPS Port #";
            // 
            // txt_IPS_Port
            // 
            this.txt_IPS_Port.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_IPS_Port.Location = new System.Drawing.Point(191, 212);
            this.txt_IPS_Port.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_IPS_Port.Name = "txt_IPS_Port";
            this.txt_IPS_Port.Size = new System.Drawing.Size(249, 29);
            this.txt_IPS_Port.TabIndex = 49;
            this.txt_IPS_Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmStations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_IPS_Port);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_StationNo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.check_IsActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_IPAddr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_StationName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_Station);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_HostName);
            this.Controls.Add(this.bt_Save);
            this.Name = "frmStations";
            this.Text = "frmSysConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_HostName;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Station;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_StationName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_IPAddr;
        private System.Windows.Forms.CheckBox check_IsActive;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_StationNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_IPS_Port;
    }
}