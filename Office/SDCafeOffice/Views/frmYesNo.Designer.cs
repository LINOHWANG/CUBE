namespace SDCafeOffice.Views
{
    partial class frmYesNo
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
            this.lbl_Message = new System.Windows.Forms.Label();
            this.bt_No = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Yes = new SDCafeCommon.Utilities.CustomButton();
            this.SuspendLayout();
            // 
            // lbl_Message
            // 
            this.lbl_Message.AutoSize = true;
            this.lbl_Message.Location = new System.Drawing.Point(80, 61);
            this.lbl_Message.Name = "lbl_Message";
            this.lbl_Message.Size = new System.Drawing.Size(221, 22);
            this.lbl_Message.TabIndex = 0;
            this.lbl_Message.Text = "Print Customer Copy ?";
            this.lbl_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bt_No
            // 
            this.bt_No.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_No.CornerRadius = 10;
            this.bt_No.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_No.ForeColor = System.Drawing.Color.Black;
            this.bt_No.Location = new System.Drawing.Point(254, 148);
            this.bt_No.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_No.Name = "bt_No";
            this.bt_No.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight)
            | SDCafeCommon.Utilities.Corners.BottomLeft)
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_No.Size = new System.Drawing.Size(146, 56);
            this.bt_No.TabIndex = 63;
            this.bt_No.Text = "No";
            this.bt_No.Click += new System.EventHandler(this.bt_No_Click);
            // 
            // bt_Yes
            // 
            this.bt_Yes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_Yes.CornerRadius = 10;
            this.bt_Yes.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Yes.ForeColor = System.Drawing.Color.Black;
            this.bt_Yes.Location = new System.Drawing.Point(84, 148);
            this.bt_Yes.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Yes.Name = "bt_Yes";
            this.bt_Yes.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight)
            | SDCafeCommon.Utilities.Corners.BottomLeft)
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Yes.Size = new System.Drawing.Size(146, 56);
            this.bt_Yes.TabIndex = 62;
            this.bt_Yes.Text = "YES";
            this.bt_Yes.Click += new System.EventHandler(this.bt_Yes_Click);
            // 
            // frmYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 234);
            this.ControlBox = false;
            this.Controls.Add(this.bt_No);
            this.Controls.Add(this.bt_Yes);
            this.Controls.Add(this.lbl_Message);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYesNo";
            this.ShowIcon = false;
            this.Text = "frmYesNo";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Message;
        private SDCafeCommon.Utilities.CustomButton bt_Yes;
        private SDCafeCommon.Utilities.CustomButton bt_No;
    }
}