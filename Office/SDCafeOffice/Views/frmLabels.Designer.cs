namespace SDCafeOffice.Views
{
    partial class frmLabels
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
            this.label8 = new System.Windows.Forms.Label();
            this.txt_ProdSearch = new System.Windows.Forms.TextBox();
            this.lbl_AllProds = new System.Windows.Forms.Label();
            this.dgvDataProd = new System.Windows.Forms.DataGridView();
            this.cb_ProdType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDataSelected = new System.Windows.Forms.DataGridView();
            this.bt_DelOne = new System.Windows.Forms.Button();
            this.bt_AddOne = new System.Windows.Forms.Button();
            this.cb_LabelFormat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bt_Print = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.progressBarGen = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(188, 50);
            this.label8.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 23);
            this.label8.TabIndex = 95;
            this.label8.Text = "Search";
            // 
            // txt_ProdSearch
            // 
            this.txt_ProdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_ProdSearch.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ProdSearch.Location = new System.Drawing.Point(250, 47);
            this.txt_ProdSearch.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_ProdSearch.Name = "txt_ProdSearch";
            this.txt_ProdSearch.Size = new System.Drawing.Size(212, 29);
            this.txt_ProdSearch.TabIndex = 94;
            this.txt_ProdSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_ProdSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_ProdSearch_KeyDown);
            // 
            // lbl_AllProds
            // 
            this.lbl_AllProds.AutoSize = true;
            this.lbl_AllProds.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AllProds.ForeColor = System.Drawing.Color.Blue;
            this.lbl_AllProds.Location = new System.Drawing.Point(8, 53);
            this.lbl_AllProds.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lbl_AllProds.Name = "lbl_AllProds";
            this.lbl_AllProds.Size = new System.Drawing.Size(123, 22);
            this.lbl_AllProds.TabIndex = 93;
            this.lbl_AllProds.Text = "All Products";
            // 
            // dgvDataProd
            // 
            this.dgvDataProd.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataProd.Location = new System.Drawing.Point(12, 84);
            this.dgvDataProd.MultiSelect = false;
            this.dgvDataProd.Name = "dgvDataProd";
            this.dgvDataProd.ReadOnly = true;
            this.dgvDataProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataProd.ShowEditingIcon = false;
            this.dgvDataProd.Size = new System.Drawing.Size(450, 460);
            this.dgvDataProd.TabIndex = 92;
            // 
            // cb_ProdType
            // 
            this.cb_ProdType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cb_ProdType.Font = new System.Drawing.Font("Arial", 14.25F);
            this.cb_ProdType.FormattingEnabled = true;
            this.cb_ProdType.Location = new System.Drawing.Point(152, 9);
            this.cb_ProdType.Name = "cb_ProdType";
            this.cb_ProdType.Size = new System.Drawing.Size(310, 30);
            this.cb_ProdType.TabIndex = 97;
            this.cb_ProdType.SelectedIndexChanged += new System.EventHandler(this.cb_ProdType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 12);
            this.label11.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 22);
            this.label11.TabIndex = 96;
            this.label11.Text = "Product Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(540, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 99;
            this.label1.Text = "Selected Products";
            // 
            // dgvDataSelected
            // 
            this.dgvDataSelected.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvDataSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataSelected.Location = new System.Drawing.Point(546, 84);
            this.dgvDataSelected.MultiSelect = false;
            this.dgvDataSelected.Name = "dgvDataSelected";
            this.dgvDataSelected.ReadOnly = true;
            this.dgvDataSelected.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataSelected.ShowEditingIcon = false;
            this.dgvDataSelected.Size = new System.Drawing.Size(450, 460);
            this.dgvDataSelected.TabIndex = 98;
            // 
            // bt_DelOne
            // 
            this.bt_DelOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.bt_DelOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_DelOne.Location = new System.Drawing.Point(468, 332);
            this.bt_DelOne.Name = "bt_DelOne";
            this.bt_DelOne.Size = new System.Drawing.Size(70, 50);
            this.bt_DelOne.TabIndex = 102;
            this.bt_DelOne.Text = "<";
            this.bt_DelOne.UseVisualStyleBackColor = false;
            this.bt_DelOne.Click += new System.EventHandler(this.bt_DelOne_Click);
            // 
            // bt_AddOne
            // 
            this.bt_AddOne.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_AddOne.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_AddOne.Location = new System.Drawing.Point(468, 276);
            this.bt_AddOne.Name = "bt_AddOne";
            this.bt_AddOne.Size = new System.Drawing.Size(70, 50);
            this.bt_AddOne.TabIndex = 101;
            this.bt_AddOne.Text = ">";
            this.bt_AddOne.UseVisualStyleBackColor = false;
            this.bt_AddOne.Click += new System.EventHandler(this.bt_AddOne_Click);
            // 
            // cb_LabelFormat
            // 
            this.cb_LabelFormat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.cb_LabelFormat.Font = new System.Drawing.Font("Arial", 14.25F);
            this.cb_LabelFormat.FormattingEnabled = true;
            this.cb_LabelFormat.Location = new System.Drawing.Point(627, 585);
            this.cb_LabelFormat.Name = "cb_LabelFormat";
            this.cb_LabelFormat.Size = new System.Drawing.Size(159, 30);
            this.cb_LabelFormat.TabIndex = 104;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(542, 588);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 22);
            this.label2.TabIndex = 103;
            this.label2.Text = "Format";
            // 
            // bt_Print
            // 
            this.bt_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bt_Print.CornerRadius = 30;
            this.bt_Print.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Print.Location = new System.Drawing.Point(795, 574);
            this.bt_Print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Print.Size = new System.Drawing.Size(201, 43);
            this.bt_Print.TabIndex = 105;
            this.bt_Print.Text = "Generate Labels";
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(901, 8);
            this.bt_Exit.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(92, 65);
            this.bt_Exit.TabIndex = 100;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // progressBarGen
            // 
            this.progressBarGen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.progressBarGen.Location = new System.Drawing.Point(12, 550);
            this.progressBarGen.Name = "progressBarGen";
            this.progressBarGen.Size = new System.Drawing.Size(984, 15);
            this.progressBarGen.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarGen.TabIndex = 106;
            // 
            // frmLabels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 631);
            this.Controls.Add(this.progressBarGen);
            this.Controls.Add(this.bt_Print);
            this.Controls.Add(this.cb_LabelFormat);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_DelOne);
            this.Controls.Add(this.bt_AddOne);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDataSelected);
            this.Controls.Add(this.cb_ProdType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_ProdSearch);
            this.Controls.Add(this.lbl_AllProds);
            this.Controls.Add(this.dgvDataProd);
            this.Name = "frmLabels";
            this.Text = "Labels";
            this.Load += new System.EventHandler(this.frmLabels_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_ProdSearch;
        private System.Windows.Forms.Label lbl_AllProds;
        private System.Windows.Forms.DataGridView dgvDataProd;
        private System.Windows.Forms.ComboBox cb_ProdType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDataSelected;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private System.Windows.Forms.Button bt_DelOne;
        private System.Windows.Forms.Button bt_AddOne;
        private System.Windows.Forms.ComboBox cb_LabelFormat;
        private System.Windows.Forms.Label label2;
        private SDCafeCommon.Utilities.CustomButton bt_Print;
        private System.Windows.Forms.ProgressBar progressBarGen;
    }
}