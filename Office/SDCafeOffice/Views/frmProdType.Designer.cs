﻿namespace SDCafeOffice.Views
{
    partial class frmProdType
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
            this.txt_TypeID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TypeName = new System.Windows.Forms.TextBox();
            this.check_Restaurant = new System.Windows.Forms.CheckBox();
            this.check_Liquor = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.check_Donation = new System.Windows.Forms.CheckBox();
            this.check_Discount = new System.Windows.Forms.CheckBox();
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
            this.label10.Size = new System.Drawing.Size(77, 22);
            this.label10.TabIndex = 44;
            this.label10.Text = "Type ID";
            // 
            // txt_TypeID
            // 
            this.txt_TypeID.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TypeID.Location = new System.Drawing.Point(200, 14);
            this.txt_TypeID.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_TypeID.Name = "txt_TypeID";
            this.txt_TypeID.Size = new System.Drawing.Size(249, 29);
            this.txt_TypeID.TabIndex = 43;
            this.txt_TypeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 22);
            this.label1.TabIndex = 42;
            this.label1.Text = "Type Name";
            // 
            // txt_TypeName
            // 
            this.txt_TypeName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_TypeName.Location = new System.Drawing.Point(200, 52);
            this.txt_TypeName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_TypeName.Name = "txt_TypeName";
            this.txt_TypeName.Size = new System.Drawing.Size(249, 29);
            this.txt_TypeName.TabIndex = 41;
            this.txt_TypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // check_Restaurant
            // 
            this.check_Restaurant.AutoSize = true;
            this.check_Restaurant.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Restaurant.Location = new System.Drawing.Point(200, 138);
            this.check_Restaurant.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_Restaurant.Name = "check_Restaurant";
            this.check_Restaurant.Size = new System.Drawing.Size(120, 26);
            this.check_Restaurant.TabIndex = 46;
            this.check_Restaurant.Text = "Restaurant";
            this.check_Restaurant.UseVisualStyleBackColor = true;
            // 
            // check_Liquor
            // 
            this.check_Liquor.AutoSize = true;
            this.check_Liquor.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Liquor.Location = new System.Drawing.Point(200, 102);
            this.check_Liquor.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_Liquor.Name = "check_Liquor";
            this.check_Liquor.Size = new System.Drawing.Size(98, 26);
            this.check_Liquor.TabIndex = 45;
            this.check_Liquor.Text = "Liquor ?";
            this.check_Liquor.UseVisualStyleBackColor = true;
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
            // check_Donation
            // 
            this.check_Donation.AutoSize = true;
            this.check_Donation.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Donation.Location = new System.Drawing.Point(200, 174);
            this.check_Donation.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_Donation.Name = "check_Donation";
            this.check_Donation.Size = new System.Drawing.Size(220, 26);
            this.check_Donation.TabIndex = 74;
            this.check_Donation.Text = "Batch Donation Type ?";
            this.check_Donation.UseVisualStyleBackColor = true;
            // 
            // check_Discount
            // 
            this.check_Discount.AutoSize = true;
            this.check_Discount.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Discount.Location = new System.Drawing.Point(200, 210);
            this.check_Discount.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.check_Discount.Name = "check_Discount";
            this.check_Discount.Size = new System.Drawing.Size(219, 26);
            this.check_Discount.TabIndex = 75;
            this.check_Discount.Text = "Batch Discount Type ?";
            this.check_Discount.UseVisualStyleBackColor = true;
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
            // frmProdType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.check_Discount);
            this.Controls.Add(this.check_Donation);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.check_Restaurant);
            this.Controls.Add(this.check_Liquor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_TypeID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_TypeName);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.KeyPreview = true;
            this.Name = "frmProdType";
            this.Text = "frmProdType";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_TypeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TypeName;
        private System.Windows.Forms.CheckBox check_Restaurant;
        private System.Windows.Forms.CheckBox check_Liquor;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.CheckBox check_Donation;
        private System.Windows.Forms.CheckBox check_Discount;
        private SDCafeCommon.Utilities.CustomButton bt_Add;
        private SDCafeCommon.Utilities.CustomButton bt_Delete;
    }
}