namespace SDCafeOffice.Views
{
    partial class frmCategory
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
            this.label10 = new System.Windows.Forms.Label();
            this.txt_CategoryID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_CategoryName = new System.Windows.Forms.TextBox();
            this.check_DCException = new System.Windows.Forms.CheckBox();
            this.check_SeparateReport = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Add = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Delete = new SDCafeCommon.Utilities.CustomButton();
            this.SuspendLayout();
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 17);
            this.label10.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 22);
            this.label10.TabIndex = 44;
            this.label10.Text = "Category ID";
            // 
            // txt_CategoryID
            // 
            this.txt_CategoryID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CategoryID.Location = new System.Drawing.Point(200, 14);
            this.txt_CategoryID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_CategoryID.Name = "txt_CategoryID";
            this.txt_CategoryID.Size = new System.Drawing.Size(249, 29);
            this.txt_CategoryID.TabIndex = 43;
            this.txt_CategoryID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "Category Name";
            // 
            // txt_CategoryName
            // 
            this.txt_CategoryName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CategoryName.Location = new System.Drawing.Point(200, 52);
            this.txt_CategoryName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_CategoryName.Name = "txt_CategoryName";
            this.txt_CategoryName.Size = new System.Drawing.Size(249, 29);
            this.txt_CategoryName.TabIndex = 41;
            this.txt_CategoryName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // check_DCException
            // 
            this.check_DCException.AutoSize = true;
            this.check_DCException.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_DCException.Location = new System.Drawing.Point(200, 138);
            this.check_DCException.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_DCException.Name = "check_DCException";
            this.check_DCException.Size = new System.Drawing.Size(151, 26);
            this.check_DCException.TabIndex = 46;
            this.check_DCException.Text = "D/C Exception";
            this.check_DCException.UseVisualStyleBackColor = true;
            // 
            // check_SeparateReport
            // 
            this.check_SeparateReport.AutoSize = true;
            this.check_SeparateReport.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_SeparateReport.Location = new System.Drawing.Point(200, 102);
            this.check_SeparateReport.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_SeparateReport.Name = "check_SeparateReport";
            this.check_SeparateReport.Size = new System.Drawing.Size(185, 26);
            this.check_SeparateReport.TabIndex = 45;
            this.check_SeparateReport.Text = "Separate Report ?";
            this.check_SeparateReport.UseVisualStyleBackColor = true;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(12, 376);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(760, 32);
            this.txtMessage.TabIndex = 73;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(630, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 40;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.CornerRadius = 30;
            this.bt_Save.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Save.Location = new System.Drawing.Point(630, 67);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Save.Size = new System.Drawing.Size(142, 47);
            this.bt_Save.TabIndex = 39;
            this.bt_Save.Text = "Save";
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Add
            // 
            this.bt_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Add.CornerRadius = 30;
            this.bt_Add.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Add.Location = new System.Drawing.Point(630, 124);
            this.bt_Add.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Add.Size = new System.Drawing.Size(142, 47);
            this.bt_Add.TabIndex = 76;
            this.bt_Add.Text = "Add";
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Delete.CornerRadius = 30;
            this.bt_Delete.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Delete.Location = new System.Drawing.Point(630, 181);
            this.bt_Delete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Delete.Size = new System.Drawing.Size(142, 47);
            this.bt_Delete.TabIndex = 77;
            this.bt_Delete.Text = "Delete";
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // frmCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.ControlBox = false;
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.check_DCException);
            this.Controls.Add(this.check_SeparateReport);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_CategoryID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_CategoryName);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.KeyPreview = true;
            this.Name = "frmCategory";
            this.Text = "Category";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_CategoryID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_CategoryName;
        private System.Windows.Forms.CheckBox check_DCException;
        private System.Windows.Forms.CheckBox check_SeparateReport;
        private System.Windows.Forms.TextBox txtMessage;
        private SDCafeCommon.Utilities.CustomButton bt_Add;
        private SDCafeCommon.Utilities.CustomButton bt_Delete;
    }
}