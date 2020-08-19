namespace SDCafeOffice.Views
{
    partial class frmSysConfig
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
            this.txt_ConfigID = new System.Windows.Forms.TextBox();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ConfigName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_ConfigValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ConfigDesc = new System.Windows.Forms.TextBox();
            this.check_IsActive = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
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
            this.label10.Size = new System.Drawing.Size(123, 22);
            this.label10.TabIndex = 37;
            this.label10.Text = "SysConfig ID";
            // 
            // txt_ConfigID
            // 
            this.txt_ConfigID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfigID.Location = new System.Drawing.Point(191, 16);
            this.txt_ConfigID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ConfigID.Name = "txt_ConfigID";
            this.txt_ConfigID.Size = new System.Drawing.Size(249, 29);
            this.txt_ConfigID.TabIndex = 36;
            this.txt_ConfigID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.label1.Size = new System.Drawing.Size(121, 22);
            this.label1.TabIndex = 40;
            this.label1.Text = "Config Name";
            // 
            // txt_ConfigName
            // 
            this.txt_ConfigName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfigName.Location = new System.Drawing.Point(191, 55);
            this.txt_ConfigName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ConfigName.Name = "txt_ConfigName";
            this.txt_ConfigName.Size = new System.Drawing.Size(249, 29);
            this.txt_ConfigName.TabIndex = 39;
            this.txt_ConfigName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 97);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 22);
            this.label2.TabIndex = 42;
            this.label2.Text = "Config Value";
            // 
            // txt_ConfigValue
            // 
            this.txt_ConfigValue.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfigValue.Location = new System.Drawing.Point(191, 94);
            this.txt_ConfigValue.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ConfigValue.Name = "txt_ConfigValue";
            this.txt_ConfigValue.Size = new System.Drawing.Size(249, 29);
            this.txt_ConfigValue.TabIndex = 41;
            this.txt_ConfigValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 136);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 22);
            this.label3.TabIndex = 44;
            this.label3.Text = "Config Description";
            // 
            // txt_ConfigDesc
            // 
            this.txt_ConfigDesc.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ConfigDesc.Location = new System.Drawing.Point(191, 133);
            this.txt_ConfigDesc.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ConfigDesc.Name = "txt_ConfigDesc";
            this.txt_ConfigDesc.Size = new System.Drawing.Size(249, 29);
            this.txt_ConfigDesc.TabIndex = 43;
            this.txt_ConfigDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // check_IsActive
            // 
            this.check_IsActive.AutoSize = true;
            this.check_IsActive.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_IsActive.Location = new System.Drawing.Point(191, 183);
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
            // frmSysConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.check_IsActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_ConfigDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ConfigValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ConfigName);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_ConfigID);
            this.Controls.Add(this.bt_Save);
            this.Name = "frmSysConfig";
            this.Text = "frmSysConfig";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ConfigID;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ConfigName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_ConfigValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ConfigDesc;
        private System.Windows.Forms.CheckBox check_IsActive;
        private System.Windows.Forms.TextBox txtMessage;
    }
}