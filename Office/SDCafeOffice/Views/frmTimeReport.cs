using SDCafeCommon.DataAccess;
using SDCafeCommon.Model;
using SDCafeCommon.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDCafeOffice.Views
{
    public partial class frmTimeReport : Form
    {
        frmMain FrmMain;
        List<POS_TimeTableModel> timeTables = new List<POS_TimeTableModel>();
        List<POS_LoginUserModel> loginUsers = new List<POS_LoginUserModel>();
        Utility util = new Utility();
        int iSelectedUserId = 0;
        private bool m_blnUnresolved;
        private int m_iSelectedRow;
        private int m_iSelectedId;

        public frmTimeReport(frmMain _frmMain)
        {
            InitializeComponent();
            this.FrmMain = _frmMain;
        }

        private void frmTimeReport_Load(object sender, EventArgs e)
        {
            dgvData_Initialize();
            cbUserName_Initialize();
            dttm_TranStart.Value = DateTime.Now;
            dttm_TranEnd.Value = DateTime.Now;

            dttm_TranStartTime.Format = DateTimePickerFormat.Custom;
            dttm_TranStartTime.CustomFormat = "HH:mm:ss";
            dttm_TranStartTime.Value = Convert.ToDateTime("00:00:00");

            dttm_TranEndTime.Format = DateTimePickerFormat.Custom;
            dttm_TranEndTime.CustomFormat = "HH:mm:ss";
            dttm_TranEndTime.Value = Convert.ToDateTime("23:59:59");

            chkbox_All.Checked = true;
            chkbox_Unresolved.Checked = false;
        }
        private void dgvData_Initialize()
        {
            this.dgvData.AutoSize = false;
            dgvData.Rows.Clear();
            //this.dataGridActivity.AutoGenerateColumns = false;
            //this.dataGridActivity.RowHeadersVisible = false;
            //this.dataGridActivity.MultiSelect = false;
            this.dgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvData.ColumnCount = 8;
            this.dgvData.Columns[0].Name = "User Id";
            this.dgvData.Columns[0].Width = 50;
            this.dgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[1].Name = "User Name";
            this.dgvData.Columns[1].Width = 200;
            this.dgvData.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[2].Name = "Clock-In";
            this.dgvData.Columns[2].Width = 180;
            this.dgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[3].Name = "Clock-Out";
            this.dgvData.Columns[3].Width = 180;
            this.dgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.Columns[4].Name = "Work Hours";
            this.dgvData.Columns[4].Width = 100;
            this.dgvData.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[5].Name = "Hourly Wage";
            this.dgvData.Columns[5].Width = 100;
            this.dgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[6].Name = "Wage Amount";
            this.dgvData.Columns[6].Width = 110;
            this.dgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvData.Columns[7].Name = "ID"; // hidden
            this.dgvData.Columns[7].Width = 0;
            this.dgvData.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgvData.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 14F, GraphicsUnit.Pixel);

            this.dgvData.EnableHeadersVisualStyles = false;
            this.dgvData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 14F, GraphicsUnit.Pixel);
            this.dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue;
            // fix the row height
            dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgvData.AllowUserToResizeRows = false;
            dgvData.RowTemplate.Resizable = DataGridViewTriState.True;
            dgvData.RowTemplate.MinimumHeight = 40;
        }

        private void cbUserName_Initialize()
        {
            UserComboboxItem userComboSource = new UserComboboxItem();

            cb_UserName.Items.Clear();
            DataAccessPOS dbPOS = new DataAccessPOS();
            loginUsers = dbPOS.Get_All_LoginUsers();
            if (loginUsers.Count > 0)
            {
                foreach (var loginUser in loginUsers)
                {
                    userComboSource.Text = loginUser.FirstName + " " + loginUser.LastName;
                    userComboSource.Value = loginUser.Id;
                    cb_UserName.Items.Add(userComboSource);
                }
            }
        }

        private void bt_Query_Click(object sender, EventArgs e)
        {
            dgvData_Initialize();
            DataAccessPOS dbPOS = new DataAccessPOS();
            
            string strStartTime = dttm_TranStart.Value.ToString("yyyy-MM-dd") + " " + dttm_TranStartTime.Value.ToString("HH:mm:ss");
            string strEndTime = dttm_TranEnd.Value.ToString("yyyy-MM-dd") + " " + dttm_TranEndTime.Value.ToString("HH:mm:ss");
            if (iSelectedUserId > 0)
            {
                timeTables = dbPOS.Get_TimeTable_by_Date_UserId(strStartTime, strEndTime, iSelectedUserId, m_blnUnresolved);
            }
            else
            {
                timeTables = dbPOS.Get_TimeTable_by_Date(strStartTime, strEndTime, m_blnUnresolved);
            }
            if (timeTables.Count> 0)
            {
                float fTotalWorkHours = 0;
                float fWorkHours = 0;
                float fTotalWageAmount = 0;
                float fWageAmount = 0;
                foreach (var timeTable in timeTables)
                {
                    fWorkHours = 0;
                    fWageAmount = 0;
                    if ((timeTable.DateTimeStarted.HasValue) && (timeTable.DateTimeFinished.HasValue))
                    {
                        fWorkHours = util.CalculateElapsedHours((DateTime)timeTable.DateTimeStarted, (DateTime)timeTable.DateTimeFinished);
                        fWageAmount = fWorkHours * timeTable.Wage;
                    }
                    this.dgvData.Rows.Add(new String[] { timeTable.UserId.ToString(),
                                                         dbPOS.Get_LoginUser_By_ID(timeTable.UserId)[0].FirstName + ", " + dbPOS.Get_LoginUser_By_ID(timeTable.UserId)[0].LastName,
                                                         timeTable.DateTimeStarted.ToString(),
                                                         timeTable.DateTimeFinished.ToString(),
                                                         fWorkHours.ToString("#,##0.00"),
                                                         timeTable.Wage.ToString("C2"),
                                                         fWageAmount.ToString("C2"),
                                                         timeTable.Id.ToString()

                                });
                    this.dgvData.FirstDisplayedScrollingRowIndex = dgvData.RowCount - 1;
                    fTotalWorkHours = fTotalWorkHours + fWorkHours;
                    fTotalWageAmount = fTotalWageAmount + fWageAmount;
                }
                this.dgvData.Rows.Add(new String[] { "",
                                                         "Total",
                                                         "",
                                                         "",
                                                         fTotalWorkHours.ToString("#,##0.00"),
                                                         "",
                                                         fTotalWageAmount.ToString("C2"),
                                                         ""

                                });
                for (int i = 0; i < dgvData.Columns.Count; i++)
                {
                    this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.BackColor = Color.LightBlue;
                    this.dgvData.Rows[dgvData.RowCount - 2].Cells[i].Style.Font = new System.Drawing.Font(this.dgvData.DefaultCellStyle.Font, FontStyle.Bold);
                }
            }
            txtMessage.Text = "Query Successful!";
        }

        private void cb_UserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_UserName.SelectedIndex >= 0)
            {
                iSelectedUserId = (int)(cb_UserName.SelectedItem as UserComboboxItem).Value;
                chkbox_All.Checked = false;
            }
            else
            {
                iSelectedUserId = 0;
                chkbox_All.Checked = true;
            }
        }

        private void cb_UserName_TextChanged(object sender, EventArgs e)
        {
            if (cb_UserName.SelectedIndex >= 0)
            {
                iSelectedUserId = (int)(cb_UserName.SelectedItem as UserComboboxItem).Value;
                chkbox_All.Checked = false;
            }
            else
            {
                iSelectedUserId = 0;
                chkbox_All.Checked = true;
            }
        }
        private void chkbox_All_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbox_All.Checked)
            {
                iSelectedUserId = 0;
                cb_UserName.SelectionLength = 0;
                cb_UserName.SelectedItem = null;
            }
        }

        private void bt_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
            return;
        }

        private void bt_Excel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "TimeReport_Export_" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                Microsoft.Office.Interop.Excel.Range excelRange;

                app.Visible = false; // true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "Exported from TimeReport";
                // storing header part in Excel  
                worksheet.get_Range("A1", "E1").Merge(false);
                excelRange = worksheet.get_Range("A1", "E1");
                excelRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(Color.LightCoral);
                excelRange.Font.Color = System.Drawing.ColorTranslator.ToOle(Color.DarkBlue);
                excelRange.Font.Size = 20;
                worksheet.Cells[1, 1] = "TIME REPORT";
                worksheet.Cells[1, 6] = "Created :";
                worksheet.Cells[1, 7] = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
                for (int i = 1; i < this.dgvData.Columns.Count; i++)
                {
                    worksheet.Cells[2, i] = this.dgvData.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < this.dgvData.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < this.dgvData.Columns.Count -1 ; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = this.dgvData.Rows[i].Cells[j].Value.ToString();
                    }
                }

                // save the application  
                workbook.SaveAs(sfd.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  
                app.Quit();
            }
        }

        private void chkbox_Unresolved_CheckedChanged(object sender, EventArgs e)
        {
            m_blnUnresolved = chkbox_Unresolved.Checked;
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iSelectedColumn = e.ColumnIndex;
            // If the cell is datetimefinished, then allow update the value
            // Start and Finish time
            if (((iSelectedColumn == 2) || (iSelectedColumn == 3)) && (dgvData.Rows[e.RowIndex].Cells[7].Value != ""))
            {
                if (dgvData.Rows[e.RowIndex].Cells[iSelectedColumn].Value.ToString() == "")
                {
                    dgvData.Rows[e.RowIndex].Cells[iSelectedColumn].Value = DateTime.Now.ToString();
                }
                dgvData.CurrentCell = dgvData.Rows[e.RowIndex].Cells[iSelectedColumn];
                dgvData.ReadOnly = false;
                dgvData.BeginEdit(true);
            }
        }

        private void dgvData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvData.ReadOnly = true;
            dgvData.BeginEdit(false);
            // Update the timetable record with 
            int iSelectedColumn = e.ColumnIndex;
            int iSelectedRow = e.RowIndex;
            int iTimeTableId = 0;
            try
            {
                iTimeTableId = int.Parse((string)dgvData.Rows[iSelectedRow].Cells[7].Value);
            }
            catch (Exception ex)
            {
                iTimeTableId = 0;
            }
            if (iTimeTableId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_TimeTableModel timeTable = new POS_TimeTableModel();
                timeTable = dbPOS.Get_TimeTable_by_Id(iTimeTableId);
                if (iSelectedColumn == 2)
                {
                    timeTable.DateTimeStarted = Convert.ToDateTime(dgvData.Rows[iSelectedRow].Cells[iSelectedColumn].Value);
                }
                else if (iSelectedColumn == 3)
                {
                    timeTable.DateTimeFinished = Convert.ToDateTime(dgvData.Rows[iSelectedRow].Cells[iSelectedColumn].Value);
                }
                dbPOS.Update_TimeTable(timeTable);
                txtMessage.Text = "TimeTable record updated successfully!";
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.CurrentCell.RowIndex >= 0)
            {
                EnableDisableButtons(true);
                // get the selected row
                m_iSelectedRow = dgvData.CurrentCell.RowIndex;
                if (dgvData.Rows[m_iSelectedRow].Cells[7].Value != "")
                    m_iSelectedId = int.Parse(dgvData.Rows[m_iSelectedRow].Cells[7].Value.ToString());
                else
                    m_iSelectedId = 0;
            }
        }

        private void EnableDisableButtons(bool v)
        {
            bt_Print.Enabled = v;
            bt_Exit.Enabled = v;
            bt_Delete.Enabled = v;
            bt_PrintAll.Enabled = v;
        }

        private void bt_Print_Click(object sender, EventArgs e)
        {
            if (m_iSelectedId > 0)
            {
                DataAccessPOS dbPOS = new DataAccessPOS();
                POS_TimeTableModel timeTable = new POS_TimeTableModel();
                timeTable = dbPOS.Get_TimeTable_by_Id(m_iSelectedId);
                if (timeTable.Id == m_iSelectedId)
                {
                    Print_TimeReport(timeTable, true);
                }
            }
        }

        private void Print_TimeReport(POS_TimeTableModel timeTable, bool p_blnIsPrintOnlyOne )
        {
            DataAccessPOS dbPOS = new DataAccessPOS();

            PrintDocument p = new PrintDocument();
            p.PrinterSettings.PrinterName = "EPSON-1";
            Font fntTitle = new Font("Arial", 12, FontStyle.Bold);
            Font fntHeader = new Font("Courier New", 9);
            Font fntFooter = new Font("Courier New", 10, FontStyle.Bold);
            Font fntContents = new Font("Courier New", 8);
            Font fntTotals = new Font("Courier New", 8, FontStyle.Bold);
            Font fntCard = new Font("Consolas", 8);
            SolidBrush brsBlack = new SolidBrush(Color.Black);

            // Construct 2 new StringFormat objects
            StringFormat format1 = new StringFormat(StringFormatFlags.NoClip);
            StringFormat format2 = new StringFormat(format1);

            // Set the LineAlignment and Alignment properties for
            // both StringFormat objects to different values.
            format1.LineAlignment = StringAlignment.Near;
            format1.Alignment = StringAlignment.Center;
            format2.LineAlignment = StringAlignment.Center;
            format2.Alignment = StringAlignment.Near;

            p.PrintPage += delegate (object sender1, PrintPageEventArgs e1)
            {
                string strHeader = "header";
                string strFooter = "footer";
                string strContent = "1234567890123456789012345678901234567890";
                string strLine = "----------------------------------------";
                string strTemp= "";

                int iNextLineYPoint = 0;
                int iLogoHeight = 80;
                int itxtHeight = 12;
                int iheaderHeight = 14;
                int ititleHeight = 17;

                Rectangle txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, ititleHeight));
                //e1.Graphics.DrawRectangle(Pens.Black, txtRect);
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_TITLE")[0].ConfigValue, fntTitle, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + ititleHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR1")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_ADDR2")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_PHONE_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);
                // Print Header ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, iheaderHeight));
                e1.Graphics.DrawString(dbPOS.Get_SysConfig_By_Name("BIZ_REG_NO")[0].ConfigValue, fntHeader, brsBlack, (RectangleF)txtRect, format1);

                strContent = String.Format("{0,-17}", "Issued:" + DateTime.Now.ToString("MM/dd/yyyy hh:mm tt"));
                iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                strContent = String.Format("{0,-17}", "Time Report");
                iNextLineYPoint = iNextLineYPoint + (iheaderHeight * 2);
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                //////////////////////////////////////////////////////////////////////////
                // Print a Line ------------------------------------------------------
                iNextLineYPoint = iNextLineYPoint + (itxtHeight * 1);
                txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                POS_LoginUserModel loginUser = new POS_LoginUserModel();
                List<POS_TimeTableModel> tTables = new List<POS_TimeTableModel>();

                if (p_blnIsPrintOnlyOne)
                {
                    tTables.Add(timeTable);
                }
                else
                {
                    tTables = timeTables;
                }
                foreach(POS_TimeTableModel tTable in tTables)
                {
                    loginUser = dbPOS.Get_LoginUser_By_ID(timeTable.UserId)[0];
                    strContent = String.Format("{0,15}", "Staff Name :") + String.Format("{0,25}", loginUser.FirstName + " " + loginUser.LastName);
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);

                    strContent = String.Format("{0,15}", "Clock In :") + String.Format("{0,25}", tTable.DateTimeStarted.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    strContent = String.Format("{0,15}", "Clock Out :") + String.Format("{0,25}", tTable.DateTimeFinished.Value.ToString("yyyy-MM-dd hh:mm:ss tt"));
                    iNextLineYPoint = iNextLineYPoint + iheaderHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strContent, fntTotals, brsBlack, (RectangleF)txtRect, format2);
                    //////////////////////////////////////////////////////////////////////////
                    // Print a Line ------------------------------------------------------
                    iNextLineYPoint = iNextLineYPoint + itxtHeight;
                    txtRect = new Rectangle(new Point(0, iNextLineYPoint), new Size((int)p.DefaultPageSettings.PrintableArea.Width, itxtHeight));
                    e1.Graphics.DrawString(strLine, fntContents, brsBlack, (RectangleF)txtRect, format2);
                }
            };
            try
            {
                p.Print();
            }
            catch (Exception ex)
            {
                throw new Exception("Exception Occured While Printing", ex);
            }
        }

        private void bt_Delete_Click(object sender, EventArgs e)
        {
            if (m_iSelectedId > 0)
            {
                using (var FrmYesNo = new frmYesNo(FrmMain))
                {
                    FrmYesNo.Set_Title("Delete Time Table");
                    FrmYesNo.Set_Message("Do you really want to delete?");
                    FrmYesNo.StartPosition = FormStartPosition.Manual; // FormStartPosition.CenterScreen; //
                    FrmYesNo.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                              (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); //Screen.PrimaryScreen.Bounds.Location;
                    FrmYesNo.ShowDialog();

                    if (FrmYesNo.bYesNo)
                    {
                        DataAccessPOS dbPOS = new DataAccessPOS();
                        bool blnDeleted = dbPOS.Delete_TimeTable(m_iSelectedId);
                        txtMessage.Text = "TimeTable record deleted successfully!";
                        m_iSelectedId = 0;
                        bt_Query.PerformClick();
                        return;
                    }
                    txtMessage.Text = "TimeTable record deletion canceled!";
                }
            }
            else
            {
                txtMessage.Text = "Please select a valid row!";
            }
        }

        private void bt_PrintAll_Click(object sender, EventArgs e)
        {
            if (timeTables.Count > 0)
                Print_TimeReport(timeTables[0], false);
        }


    }
}
