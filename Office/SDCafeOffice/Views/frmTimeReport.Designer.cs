
namespace SDCafeOffice.Views
{
    partial class frmTimeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTimeReport));
            this.dttm_TranEndTime = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranStartTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dttm_TranEnd = new System.Windows.Forms.DateTimePicker();
            this.dttm_TranStart = new System.Windows.Forms.DateTimePicker();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbox_All = new System.Windows.Forms.CheckBox();
            this.cb_UserName = new System.Windows.Forms.ComboBox();
            this.chkbox_Unresolved = new System.Windows.Forms.CheckBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_PrintAll = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Delete = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Update = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Excel = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Query = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Exit = new SDCafeCommon.Utilities.CustomButton();
            this.bt_Print = new SDCafeCommon.Utilities.CustomButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // dttm_TranEndTime
            // 
            this.dttm_TranEndTime.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dttm_TranEndTime.Location = new System.Drawing.Point(279, 57);
            this.dttm_TranEndTime.Name = "dttm_TranEndTime";
            this.dttm_TranEndTime.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEndTime.TabIndex = 52;
            // 
            // dttm_TranStartTime
            // 
            this.dttm_TranStartTime.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dttm_TranStartTime.Location = new System.Drawing.Point(279, 22);
            this.dttm_TranStartTime.Name = "dttm_TranStartTime";
            this.dttm_TranStartTime.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranStartTime.TabIndex = 51;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 50;
            this.label1.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 22);
            this.label5.TabIndex = 49;
            this.label5.Text = "Start Date";
            // 
            // dttm_TranEnd
            // 
            this.dttm_TranEnd.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranEnd.Location = new System.Drawing.Point(118, 57);
            this.dttm_TranEnd.Name = "dttm_TranEnd";
            this.dttm_TranEnd.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranEnd.TabIndex = 48;
            // 
            // dttm_TranStart
            // 
            this.dttm_TranStart.Font = new System.Drawing.Font("Arial", 14.25F);
            this.dttm_TranStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dttm_TranStart.Location = new System.Drawing.Point(118, 22);
            this.dttm_TranStart.Name = "dttm_TranStart";
            this.dttm_TranStart.Size = new System.Drawing.Size(155, 29);
            this.dttm_TranStart.TabIndex = 47;
            // 
            // dgvData
            // 
            this.dgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvData.Location = new System.Drawing.Point(9, 160);
            this.dgvData.MultiSelect = false;
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowEditingIcon = false;
            this.dgvData.Size = new System.Drawing.Size(990, 532);
            this.dgvData.TabIndex = 57;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            this.dgvData.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEndEdit);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 95);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 22);
            this.label2.TabIndex = 58;
            this.label2.Text = "Login User";
            // 
            // chkbox_All
            // 
            this.chkbox_All.AutoSize = true;
            this.chkbox_All.Font = new System.Drawing.Font("Arial", 14.25F);
            this.chkbox_All.Location = new System.Drawing.Point(118, 128);
            this.chkbox_All.Name = "chkbox_All";
            this.chkbox_All.Size = new System.Drawing.Size(105, 26);
            this.chkbox_All.TabIndex = 59;
            this.chkbox_All.Text = "All Users";
            this.chkbox_All.UseVisualStyleBackColor = true;
            this.chkbox_All.CheckedChanged += new System.EventHandler(this.chkbox_All_CheckedChanged);
            // 
            // cb_UserName
            // 
            this.cb_UserName.Font = new System.Drawing.Font("Arial", 14.25F);
            this.cb_UserName.FormattingEnabled = true;
            this.cb_UserName.Location = new System.Drawing.Point(118, 92);
            this.cb_UserName.Name = "cb_UserName";
            this.cb_UserName.Size = new System.Drawing.Size(316, 30);
            this.cb_UserName.TabIndex = 60;
            this.cb_UserName.SelectedIndexChanged += new System.EventHandler(this.cb_UserName_SelectedIndexChanged);
            this.cb_UserName.TextChanged += new System.EventHandler(this.cb_UserName_TextChanged);
            // 
            // chkbox_Unresolved
            // 
            this.chkbox_Unresolved.AutoSize = true;
            this.chkbox_Unresolved.Font = new System.Drawing.Font("Arial", 14.25F);
            this.chkbox_Unresolved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chkbox_Unresolved.Location = new System.Drawing.Point(279, 128);
            this.chkbox_Unresolved.Name = "chkbox_Unresolved";
            this.chkbox_Unresolved.Size = new System.Drawing.Size(151, 26);
            this.chkbox_Unresolved.TabIndex = 61;
            this.chkbox_Unresolved.Text = "All Unresolved";
            this.chkbox_Unresolved.UseVisualStyleBackColor = true;
            this.chkbox_Unresolved.CheckedChanged += new System.EventHandler(this.chkbox_Unresolved_CheckedChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtMessage.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ForeColor = System.Drawing.SystemColors.Info;
            this.txtMessage.Location = new System.Drawing.Point(9, 698);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(990, 32);
            this.txtMessage.TabIndex = 63;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(544, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 20);
            this.label3.TabIndex = 66;
            this.label3.Text = "Double Click Clock-In/Out Dates Columns to Update !";
            // 
            // bt_PrintAll
            // 
            this.bt_PrintAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bt_PrintAll.CornerRadius = 30;
            this.bt_PrintAll.Enabled = false;
            this.bt_PrintAll.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_PrintAll.Location = new System.Drawing.Point(703, 62);
            this.bt_PrintAll.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_PrintAll.Name = "bt_PrintAll";
            this.bt_PrintAll.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_PrintAll.Size = new System.Drawing.Size(142, 47);
            this.bt_PrintAll.TabIndex = 65;
            this.bt_PrintAll.Text = "Print All";
            this.bt_PrintAll.Click += new System.EventHandler(this.bt_PrintAll_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.bt_Delete.CornerRadius = 30;
            this.bt_Delete.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Delete.Location = new System.Drawing.Point(548, 62);
            this.bt_Delete.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Delete.Size = new System.Drawing.Size(142, 47);
            this.bt_Delete.TabIndex = 64;
            this.bt_Delete.Text = "Delete";
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Update
            // 
            this.bt_Update.CornerRadius = 30;
            this.bt_Update.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Update.Location = new System.Drawing.Point(857, 62);
            this.bt_Update.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Update.Name = "bt_Update";
            this.bt_Update.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Update.Size = new System.Drawing.Size(142, 47);
            this.bt_Update.TabIndex = 62;
            this.bt_Update.Text = "Update";
            this.bt_Update.Visible = false;
            // 
            // bt_Excel
            // 
            this.bt_Excel.CornerRadius = 30;
            this.bt_Excel.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Excel.Location = new System.Drawing.Point(857, 62);
            this.bt_Excel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Excel.Name = "bt_Excel";
            this.bt_Excel.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Excel.Size = new System.Drawing.Size(142, 47);
            this.bt_Excel.TabIndex = 56;
            this.bt_Excel.Text = "Excel";
            this.bt_Excel.Click += new System.EventHandler(this.bt_Excel_Click);
            // 
            // bt_Query
            // 
            this.bt_Query.CornerRadius = 30;
            this.bt_Query.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Query.Location = new System.Drawing.Point(548, 14);
            this.bt_Query.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Query.Name = "bt_Query";
            this.bt_Query.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Query.Size = new System.Drawing.Size(142, 47);
            this.bt_Query.TabIndex = 55;
            this.bt_Query.Text = "Query";
            this.bt_Query.Click += new System.EventHandler(this.bt_Query_Click);
            // 
            // bt_Exit
            // 
            this.bt_Exit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bt_Exit.CornerRadius = 30;
            this.bt_Exit.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.bt_Exit.ForeColor = System.Drawing.Color.White;
            this.bt_Exit.Location = new System.Drawing.Point(854, 12);
            this.bt_Exit.Name = "bt_Exit";
            this.bt_Exit.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Exit.Size = new System.Drawing.Size(142, 47);
            this.bt_Exit.TabIndex = 54;
            this.bt_Exit.Text = "Exit";
            this.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            // 
            // bt_Print
            // 
            this.bt_Print.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.bt_Print.CornerRadius = 30;
            this.bt_Print.Enabled = false;
            this.bt_Print.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bt_Print.Location = new System.Drawing.Point(702, 14);
            this.bt_Print.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.bt_Print.Name = "bt_Print";
            this.bt_Print.RoundCorners = ((SDCafeCommon.Utilities.Corners)(((SDCafeCommon.Utilities.Corners.TopLeft | SDCafeCommon.Utilities.Corners.TopRight) 
            | SDCafeCommon.Utilities.Corners.BottomLeft)));
            this.bt_Print.Size = new System.Drawing.Size(142, 47);
            this.bt_Print.TabIndex = 53;
            this.bt_Print.Text = "Print Selected";
            this.bt_Print.Click += new System.EventHandler(this.bt_Print_Click);
            // 
            // frmTimeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bt_PrintAll);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.bt_Update);
            this.Controls.Add(this.chkbox_Unresolved);
            this.Controls.Add(this.cb_UserName);
            this.Controls.Add(this.chkbox_All);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.bt_Excel);
            this.Controls.Add(this.bt_Query);
            this.Controls.Add(this.bt_Exit);
            this.Controls.Add(this.bt_Print);
            this.Controls.Add(this.dttm_TranEndTime);
            this.Controls.Add(this.dttm_TranStartTime);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dttm_TranEnd);
            this.Controls.Add(this.dttm_TranStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTimeReport";
            this.Text = "Time Report";
            this.Load += new System.EventHandler(this.frmTimeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dttm_TranEndTime;
        private System.Windows.Forms.DateTimePicker dttm_TranStartTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dttm_TranEnd;
        private System.Windows.Forms.DateTimePicker dttm_TranStart;
        private SDCafeCommon.Utilities.CustomButton bt_Excel;
        private SDCafeCommon.Utilities.CustomButton bt_Query;
        private SDCafeCommon.Utilities.CustomButton bt_Exit;
        private SDCafeCommon.Utilities.CustomButton bt_Print;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkbox_All;
        private System.Windows.Forms.ComboBox cb_UserName;
        private System.Windows.Forms.CheckBox chkbox_Unresolved;
        private SDCafeCommon.Utilities.CustomButton bt_Update;
        private System.Windows.Forms.TextBox txtMessage;
        private SDCafeCommon.Utilities.CustomButton bt_Delete;
        private SDCafeCommon.Utilities.CustomButton bt_PrintAll;
        private System.Windows.Forms.Label label3;
    }
}