namespace SDCafeOffice.Views
{
    partial class frmSalesButton
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
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Rows = new System.Windows.Forms.TextBox();
            this.txt_Cols = new System.Windows.Forms.TextBox();
            this.grpButtonProp = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ProdId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_BackColor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ForeColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_ProdName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_FontName = new System.Windows.Forms.TextBox();
            this.txt_BtnCol = new System.Windows.Forms.TextBox();
            this.txt_BtnRow = new System.Windows.Forms.TextBox();
            this.dgvProds = new System.Windows.Forms.DataGridView();
            this.txt_SearchText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.bt_SetLayout = new SDCafeCommon.Utilities.CustomButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_FontSize = new System.Windows.Forms.TextBox();
            this.chk_Visible = new System.Windows.Forms.CheckBox();
            this.grpButtonProp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Rows";
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.pnlMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMenu.Location = new System.Drawing.Point(397, 14);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(608, 393);
            this.pnlMenu.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Columns";
            // 
            // txt_Rows
            // 
            this.txt_Rows.Location = new System.Drawing.Point(100, 14);
            this.txt_Rows.Name = "txt_Rows";
            this.txt_Rows.Size = new System.Drawing.Size(100, 25);
            this.txt_Rows.TabIndex = 13;
            // 
            // txt_Cols
            // 
            this.txt_Cols.Location = new System.Drawing.Point(100, 40);
            this.txt_Cols.Name = "txt_Cols";
            this.txt_Cols.Size = new System.Drawing.Size(100, 25);
            this.txt_Cols.TabIndex = 14;
            // 
            // grpButtonProp
            // 
            this.grpButtonProp.Controls.Add(this.chk_Visible);
            this.grpButtonProp.Controls.Add(this.label11);
            this.grpButtonProp.Controls.Add(this.txt_FontSize);
            this.grpButtonProp.Controls.Add(this.label10);
            this.grpButtonProp.Controls.Add(this.txt_ProdId);
            this.grpButtonProp.Controls.Add(this.label9);
            this.grpButtonProp.Controls.Add(this.txt_BackColor);
            this.grpButtonProp.Controls.Add(this.label8);
            this.grpButtonProp.Controls.Add(this.txt_ForeColor);
            this.grpButtonProp.Controls.Add(this.label6);
            this.grpButtonProp.Controls.Add(this.txt_ProdName);
            this.grpButtonProp.Controls.Add(this.label5);
            this.grpButtonProp.Controls.Add(this.label4);
            this.grpButtonProp.Controls.Add(this.label3);
            this.grpButtonProp.Controls.Add(this.txt_FontName);
            this.grpButtonProp.Controls.Add(this.txt_BtnCol);
            this.grpButtonProp.Controls.Add(this.txt_BtnRow);
            this.grpButtonProp.Location = new System.Drawing.Point(397, 415);
            this.grpButtonProp.Name = "grpButtonProp";
            this.grpButtonProp.Size = new System.Drawing.Size(608, 147);
            this.grpButtonProp.TabIndex = 16;
            this.grpButtonProp.TabStop = false;
            this.grpButtonProp.Text = "Button Properties";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(403, 26);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Product Id";
            // 
            // txt_ProdId
            // 
            this.txt_ProdId.Location = new System.Drawing.Point(485, 23);
            this.txt_ProdId.Name = "txt_ProdId";
            this.txt_ProdId.Size = new System.Drawing.Size(100, 25);
            this.txt_ProdId.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(208, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Back Color";
            // 
            // txt_BackColor
            // 
            this.txt_BackColor.Location = new System.Drawing.Point(288, 100);
            this.txt_BackColor.Name = "txt_BackColor";
            this.txt_BackColor.Size = new System.Drawing.Size(90, 25);
            this.txt_BackColor.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 20);
            this.label8.TabIndex = 23;
            this.label8.Text = "Fore Color";
            // 
            // txt_ForeColor
            // 
            this.txt_ForeColor.Location = new System.Drawing.Point(101, 99);
            this.txt_ForeColor.Name = "txt_ForeColor";
            this.txt_ForeColor.Size = new System.Drawing.Size(90, 25);
            this.txt_ForeColor.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 21;
            this.label6.Text = "Product";
            // 
            // txt_ProdName
            // 
            this.txt_ProdName.Location = new System.Drawing.Point(82, 24);
            this.txt_ProdName.Name = "txt_ProdName";
            this.txt_ProdName.Size = new System.Drawing.Size(296, 25);
            this.txt_ProdName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 19;
            this.label5.Text = "Font";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "Col";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Row";
            // 
            // txt_FontName
            // 
            this.txt_FontName.Location = new System.Drawing.Point(264, 58);
            this.txt_FontName.Name = "txt_FontName";
            this.txt_FontName.Size = new System.Drawing.Size(186, 25);
            this.txt_FontName.TabIndex = 16;
            // 
            // txt_BtnCol
            // 
            this.txt_BtnCol.Location = new System.Drawing.Point(147, 58);
            this.txt_BtnCol.Name = "txt_BtnCol";
            this.txt_BtnCol.Size = new System.Drawing.Size(44, 25);
            this.txt_BtnCol.TabIndex = 15;
            // 
            // txt_BtnRow
            // 
            this.txt_BtnRow.Location = new System.Drawing.Point(60, 58);
            this.txt_BtnRow.Name = "txt_BtnRow";
            this.txt_BtnRow.Size = new System.Drawing.Size(44, 25);
            this.txt_BtnRow.TabIndex = 14;
            // 
            // dgvProds
            // 
            this.dgvProds.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProds.Location = new System.Drawing.Point(13, 117);
            this.dgvProds.Name = "dgvProds";
            this.dgvProds.Size = new System.Drawing.Size(375, 393);
            this.dgvProds.TabIndex = 19;
            this.dgvProds.DoubleClick += new System.EventHandler(this.dgvProds_DoubleClick);
            // 
            // txt_SearchText
            // 
            this.txt_SearchText.Location = new System.Drawing.Point(100, 86);
            this.txt_SearchText.Name = "txt_SearchText";
            this.txt_SearchText.Size = new System.Drawing.Size(288, 25);
            this.txt_SearchText.TabIndex = 21;
            this.txt_SearchText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_SearchText_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 89);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 20);
            this.label7.TabIndex = 22;
            this.label7.Text = "Search";
            // 
            // bt_Exit
            // 
            this.bt_Exit.Location = new System.Drawing.Point(118, 516);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.Size = new System.Drawing.Size(94, 46);
            this.bt_Exit.TabIndex = 18;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Save
            // 
            this.bt_Save.Location = new System.Drawing.Point(13, 516);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.Size = new System.Drawing.Size(94, 46);
            this.bt_Save.TabIndex = 17;
            this.bt_Save.Text = "Save";
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_SetLayout
            // 
            this.bt_SetLayout.Location = new System.Drawing.Point(206, 17);
            this.bt_SetLayout.Name = "bt_SetLayout";
            this.bt_SetLayout.Size = new System.Drawing.Size(94, 46);
            this.bt_SetLayout.TabIndex = 15;
            this.bt_SetLayout.Text = "Set Layout";
            this.bt_SetLayout.Click += new System.EventHandler(this.bt_SetLayout_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(460, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Font Size";
            // 
            // txt_FontSize
            // 
            this.txt_FontSize.Location = new System.Drawing.Point(541, 56);
            this.txt_FontSize.Name = "txt_FontSize";
            this.txt_FontSize.Size = new System.Drawing.Size(44, 25);
            this.txt_FontSize.TabIndex = 28;
            // 
            // chk_Visible
            // 
            this.chk_Visible.AutoSize = true;
            this.chk_Visible.Location = new System.Drawing.Point(406, 101);
            this.chk_Visible.Name = "chk_Visible";
            this.chk_Visible.Size = new System.Drawing.Size(69, 24);
            this.chk_Visible.TabIndex = 30;
            this.chk_Visible.Text = "Visible";
            this.chk_Visible.UseVisualStyleBackColor = true;
            // 
            // frmSalesButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 574);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_SearchText);
            this.Controls.Add(this.dgvProds);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.grpButtonProp);
            this.Controls.Add(this.bt_SetLayout);
            this.Controls.Add(this.txt_Cols);
            this.Controls.Add(this.txt_Rows);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSalesButton";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSalesButton";
            this.Load += new System.EventHandler(this.frmSalesButton_Load);
            this.grpButtonProp.ResumeLayout(false);
            this.grpButtonProp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProds)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Rows;
        private System.Windows.Forms.TextBox txt_Cols;
        private SDCafeCommon.Utilities.CustomButton bt_SetLayout;
        private System.Windows.Forms.GroupBox grpButtonProp;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FontName;
        private System.Windows.Forms.TextBox txt_BtnCol;
        private System.Windows.Forms.TextBox txt_BtnRow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_ProdName;
        private System.Windows.Forms.DataGridView dgvProds;
        private System.Windows.Forms.TextBox txt_SearchText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_BackColor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ForeColor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ProdId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_FontSize;
        private System.Windows.Forms.CheckBox chk_Visible;
    }
}