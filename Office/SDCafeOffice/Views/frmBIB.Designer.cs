namespace SDCafeOffice.Views
{
    partial class frmBIB
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
            this.lbl_SelectedProds = new System.Windows.Forms.Label();
            this.lbl_AllProds = new System.Windows.Forms.Label();
            this.bt_DelAll = new System.Windows.Forms.Button();
            this.bt_DelOne = new System.Windows.Forms.Button();
            this.bt_AddOne = new System.Windows.Forms.Button();
            this.bt_Add_All = new System.Windows.Forms.Button();
            this.dgvDataTo = new System.Windows.Forms.DataGridView();
            this.dgvDataFrom = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ButtonName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_ButtonProdId = new System.Windows.Forms.TextBox();
            this.bt_Save = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_PTypeName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ProdSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_SelectedProds
            // 
            this.lbl_SelectedProds.AutoSize = true;
            this.lbl_SelectedProds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SelectedProds.ForeColor = System.Drawing.Color.Blue;
            this.lbl_SelectedProds.Location = new System.Drawing.Point(547, 140);
            this.lbl_SelectedProds.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_SelectedProds.Name = "lbl_SelectedProds";
            this.lbl_SelectedProds.Size = new System.Drawing.Size(180, 22);
            this.lbl_SelectedProds.TabIndex = 97;
            this.lbl_SelectedProds.Text = "Selected Products";
            // 
            // lbl_AllProds
            // 
            this.lbl_AllProds.AutoSize = true;
            this.lbl_AllProds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AllProds.ForeColor = System.Drawing.Color.Blue;
            this.lbl_AllProds.Location = new System.Drawing.Point(15, 140);
            this.lbl_AllProds.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_AllProds.Name = "lbl_AllProds";
            this.lbl_AllProds.Size = new System.Drawing.Size(95, 22);
            this.lbl_AllProds.TabIndex = 96;
            this.lbl_AllProds.Text = "Products";
            // 
            // bt_DelAll
            // 
            this.bt_DelAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_DelAll.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DelAll.Location = new System.Drawing.Point(475, 436);
            this.bt_DelAll.Name = "bt_DelAll";
            this.bt_DelAll.Size = new System.Drawing.Size(70, 50);
            this.bt_DelAll.TabIndex = 95;
            this.bt_DelAll.Text = "<<";
            this.bt_DelAll.UseVisualStyleBackColor = false;
            this.bt_DelAll.Visible = false;
            // 
            // bt_DelOne
            // 
            this.bt_DelOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_DelOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DelOne.Location = new System.Drawing.Point(475, 380);
            this.bt_DelOne.Name = "bt_DelOne";
            this.bt_DelOne.Size = new System.Drawing.Size(70, 50);
            this.bt_DelOne.TabIndex = 94;
            this.bt_DelOne.Text = "<";
            this.bt_DelOne.UseVisualStyleBackColor = false;
            this.bt_DelOne.Click += new System.EventHandler(this.bt_DelOne_Click);
            // 
            // bt_AddOne
            // 
            this.bt_AddOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_AddOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddOne.Location = new System.Drawing.Point(475, 324);
            this.bt_AddOne.Name = "bt_AddOne";
            this.bt_AddOne.Size = new System.Drawing.Size(70, 50);
            this.bt_AddOne.TabIndex = 93;
            this.bt_AddOne.Text = ">";
            this.bt_AddOne.UseVisualStyleBackColor = false;
            this.bt_AddOne.Click += new System.EventHandler(this.bt_AddOne_Click);
            // 
            // bt_Add_All
            // 
            this.bt_Add_All.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_Add_All.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Add_All.Location = new System.Drawing.Point(475, 268);
            this.bt_Add_All.Name = "bt_Add_All";
            this.bt_Add_All.Size = new System.Drawing.Size(70, 50);
            this.bt_Add_All.TabIndex = 92;
            this.bt_Add_All.Text = ">>";
            this.bt_Add_All.UseVisualStyleBackColor = false;
            this.bt_Add_All.Visible = false;
            // 
            // dgvDataTo
            // 
            this.dgvDataTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataTo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataTo.Location = new System.Drawing.Point(551, 165);
            this.dgvDataTo.MultiSelect = false;
            this.dgvDataTo.Name = "dgvDataTo";
            this.dgvDataTo.ReadOnly = true;
            this.dgvDataTo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataTo.ShowEditingIcon = false;
            this.dgvDataTo.Size = new System.Drawing.Size(450, 427);
            this.dgvDataTo.TabIndex = 91;
            // 
            // dgvDataFrom
            // 
            this.dgvDataFrom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataFrom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataFrom.Location = new System.Drawing.Point(19, 165);
            this.dgvDataFrom.MultiSelect = false;
            this.dgvDataFrom.Name = "dgvDataFrom";
            this.dgvDataFrom.ReadOnly = true;
            this.dgvDataFrom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataFrom.ShowEditingIcon = false;
            this.dgvDataFrom.Size = new System.Drawing.Size(450, 427);
            this.dgvDataFrom.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 95);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 22);
            this.label1.TabIndex = 99;
            this.label1.Text = "Button Name";
            // 
            // txt_ButtonName
            // 
            this.txt_ButtonName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ButtonName.Location = new System.Drawing.Point(164, 92);
            this.txt_ButtonName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ButtonName.Name = "txt_ButtonName";
            this.txt_ButtonName.Size = new System.Drawing.Size(504, 29);
            this.txt_ButtonName.TabIndex = 98;
            this.txt_ButtonName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 56);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 22);
            this.label7.TabIndex = 101;
            this.label7.Text = "Button Prod ID";
            // 
            // txt_ButtonProdId
            // 
            this.txt_ButtonProdId.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ButtonProdId.Location = new System.Drawing.Point(166, 53);
            this.txt_ButtonProdId.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ButtonProdId.Name = "txt_ButtonProdId";
            this.txt_ButtonProdId.ReadOnly = true;
            this.txt_ButtonProdId.Size = new System.Drawing.Size(198, 29);
            this.txt_ButtonProdId.TabIndex = 100;
            this.txt_ButtonProdId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bt_Save
            // 
            this.bt_Save.CornerRadius = 30;
            this.bt_Save.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Save.Location = new System.Drawing.Point(859, 14);
            this.bt_Save.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Save.Name = "bt_Save";
            this.bt_Save.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Save.Size = new System.Drawing.Size(142, 47);
            this.bt_Save.TabIndex = 102;
            this.bt_Save.Text = "Save";
            this.bt_Save.Click += new System.EventHandler(this.bt_Save_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(859, 69);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)((((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft) 
            | SDCafeCommon.Utilities.Corners.BottomRight)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 44);
            this.bt_Exit.TabIndex = 103;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 22);
            this.label2.TabIndex = 105;
            this.label2.Text = "Type Name";
            // 
            // txt_PTypeName
            // 
            this.txt_PTypeName.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PTypeName.Location = new System.Drawing.Point(166, 14);
            this.txt_PTypeName.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_PTypeName.Name = "txt_PTypeName";
            this.txt_PTypeName.ReadOnly = true;
            this.txt_PTypeName.Size = new System.Drawing.Size(198, 29);
            this.txt_PTypeName.TabIndex = 104;
            this.txt_PTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(195, 134);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 23);
            this.label8.TabIndex = 107;
            this.label8.Text = "Search";
            // 
            // txt_ProdSearch
            // 
            this.txt_ProdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ProdSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProdSearch.Location = new System.Drawing.Point(257, 131);
            this.txt_ProdSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ProdSearch.Name = "txt_ProdSearch";
            this.txt_ProdSearch.Size = new System.Drawing.Size(212, 29);
            this.txt_ProdSearch.TabIndex = 106;
            this.txt_ProdSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ProdSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ProdSearch_KeyDown);
            // 
            // frmBIB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 608);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ProdSearch);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_PTypeName);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Save);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_ButtonProdId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_ButtonName);
            this.Controls.Add(this.lbl_SelectedProds);
            this.Controls.Add(this.lbl_AllProds);
            this.Controls.Add(this.bt_DelAll);
            this.Controls.Add(this.bt_DelOne);
            this.Controls.Add(this.bt_AddOne);
            this.Controls.Add(this.bt_Add_All);
            this.Controls.Add(this.dgvDataTo);
            this.Controls.Add(this.dgvDataFrom);
            this.Name = "frmBIB";
            this.Text = "Buttons in Button Setting";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_SelectedProds;
        private System.Windows.Forms.Label lbl_AllProds;
        private System.Windows.Forms.Button bt_DelAll;
        private System.Windows.Forms.Button bt_DelOne;
        private System.Windows.Forms.Button bt_AddOne;
        private System.Windows.Forms.Button bt_Add_All;
        private System.Windows.Forms.DataGridView dgvDataTo;
        private System.Windows.Forms.DataGridView dgvDataFrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ButtonName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_ButtonProdId;
        private SDCafeCommon.Utilities.CustomButton bt_Save;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_PTypeName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ProdSearch;
    }
}