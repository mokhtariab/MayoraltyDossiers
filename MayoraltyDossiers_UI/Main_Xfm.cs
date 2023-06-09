using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;

namespace MayoraltyDossiers_UI
{
    public partial class Main_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public Main_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqlCmd = new SqlCommand();

        private void Main_Xfm_Load(object sender, EventArgs e)
        {
            SetDataSet_GridViewFiles();
        }

        public string GetDateShamsiFromMiladi(DateTime DateEnter)
        {

            SqlCmd.CommandText = " Select dbo.MiladiToShamsi(Substring('" + DateEnter + "',1,10))";
                
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;

            SqlConn.Open();

            SqlDataReader SDR = SqlCmd.ExecuteReader();
            SDR.Read();
            string StrDate = Convert.ToString( SDR[0] );
            SqlConn.Close();

            return StrDate;
        }
        
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        private void Main_Xfm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("calc.exe");
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\tehran_regionsNew.png");
                //@"D:\Mokhtari\Mayoralty_Dossiers\pic shahrdari\tehran_regionsNew.png");
            }
            catch 
            { }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Process.Start("NotePad");
        }

        public bool PermissionForDeleteFile_User = true;
        private void barBtnItem_EditFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_EditFile();
        }

        private void navBarItem_EditFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_EditFile();
        }

        private void Func_EditFile()
        {
            int Index = gridView1.FocusedRowHandle;
            DataRow row1 = gridView1.GetDataRow(Index);
            if (row1 == null) return;
            
            CrtFile_Xfm cfx = new CrtFile_Xfm();
            cfx.Del_simpleButton.Enabled = PermissionForDeleteFile_User;
            cfx.File_ID = Convert.ToInt32(row1["ID"]);
            #region
            cfx.file_CodeTextEdit.Text = Convert.ToString(row1["File_Code"]);
            cfx.File_StatusCombo.SelectedIndex = Convert.ToInt32(row1["File_Status"]);
            cfx.File_PaperCombo.SelectedIndex = Convert.ToInt32(row1["File_Paper"]);
            cfx.file_NoTextEdit.Text = Convert.ToString(row1["File_No"]);
            cfx.File_DateDate.Text = Convert.ToString(row1["File_Date"]);
            cfx.Crt_TypeCombo.SelectedIndex = Convert.ToInt32(row1["Crt_Type"]);
            cfx.Crt_DateNewDate.Text = Convert.ToString(row1["Crt_DateNew"]);
            cfx.crt_ValidTimeSpinEdit.Value = Convert.ToInt32(row1["Crt_ValidTime"]);
            cfx.Operator_CodeCombo.SelectedIndex = Convert.ToInt32(row1["Operator_Code"]);
            cfx.Person_FnametextEdit.Text = Convert.ToString(row1["Person_FName"]);
            cfx.Person_LNametextEdit.Text = Convert.ToString(row1["Person_LName"]);
            cfx.Main_StreettextEdit.Text = Convert.ToString(row1["Main_Street"]);
            cfx.Side_StreettextEdit.Text = Convert.ToString(row1["Side_Street"]);
            cfx.Main_AlleytextEdit.Text = Convert.ToString(row1["Main_Alley"]);
            cfx.Side_AlleytextEdit.Text = Convert.ToString(row1["Side_Alley"]);
            cfx.House_NotextEdit.Text = Convert.ToString(row1["House_No"]);
            cfx.Use_EarthCombo.SelectedIndex = Convert.ToInt32(row1["Use_Earth"]);
            cfx.Register_PlaktextEdit.Text = Convert.ToString(row1["Register_Plak"]);
            cfx.Parking_DomainCombo.SelectedIndex = Convert.ToInt32(row1["Parking_Domain"]);
            cfx.Closed_SpaceTextEdit.Text = Convert.ToString(row1["Closed_Space"]);
            cfx.Use_SpaceTextEdit.Text = Convert.ToString(row1["Use_Space"]);
            cfx.Struct_TypeCombo.SelectedIndex = Convert.ToInt32(row1["Struct_Type"]);
            cfx.Tree_ExistCombo.SelectedIndex = Convert.ToInt32(row1["Tree_Exist"]);
            cfx.Excess_60TextEdit.Text = Convert.ToString(row1["Excess_60"]);
            cfx.House_HeadTextEdit.Text = Convert.ToString(row1["House_Head"]);
            cfx.Area_ProoftextEdit.Text = Convert.ToString(row1["Area_Proof"]);
            cfx.Area_CorrecttextEdit.Text = Convert.ToString(row1["Area_Correct"]);
            cfx.Area_ExisttextEdit.Text = Convert.ToString(row1["Area_Exist"]);
            cfx.LayerSum_FewtextEdit.Text = Convert.ToString(row1["LayerSum_Few"]);
            cfx.UnderEarth_FewtextEdit.Text = Convert.ToString(row1["UnderEarth_Few"]);
            cfx.Earth_FewtextEdit.Text = Convert.ToString(row1["Earth_Few"]);
            cfx.HighLayer_FewtextEdit.Text = Convert.ToString(row1["HighLayer_Few"]);
            cfx.area_CorrectOKCheckEdit.Checked = Convert.ToBoolean(row1["Area_CorrectOK"]);
            cfx.Area_CorrectExistcombo.SelectedIndex = Convert.ToInt32(row1["Area_CorrectExist"]);
            cfx.FinalType_StructCombo.SelectedIndex = Convert.ToInt32(row1["FinalType_Struct"]);
            cfx.FinalArea_StRoomtextEdit.Text = Convert.ToString(row1["FinalArea_StRoom"]);
            cfx.FinalUnit_StRoomtextEdit.Text = Convert.ToString(row1["FinalUnit_StRoom"]);
            cfx.FinalArea_StairtextEdit.Text = Convert.ToString(row1["FinalArea_Stair"]);
            cfx.FinalUnit_StairtextEdit.Text = Convert.ToString(row1["FinalUnit_Stair"]);
            cfx.FinalArea_ParkingtextEdit.Text = Convert.ToString(row1["FinalArea_Parking"]);
            cfx.FinalUnit_ParkingtextEdit.Text = Convert.ToString(row1["FinalUnit_Parking"]);
            cfx.FinalArea_HousetextEdit.Text = Convert.ToString(row1["FinalArea_Huose"]);
            cfx.FinalUnit_HousetextEdit.Text = Convert.ToString(row1["FinalUnit_Huose"]);
            cfx.FinalArea_BusintextEdit.Text = Convert.ToString(row1["FinalArea_Busin"]);
            cfx.FinalUnit_BusintextEdit.Text = Convert.ToString(row1["FinalUnit_Busin"]);
            cfx.FinalArea_OfficetextEdit.Text = Convert.ToString(row1["FinalArea_Office"]);
            cfx.FinalUnit_OfficetextEdit.Text = Convert.ToString(row1["FinalUnit_Office"]);
            cfx.FinalArea_OthertextEdit.Text = Convert.ToString(row1["FinalArea_Other"]);
            cfx.FinalUnit_OthertextEdit.Text = Convert.ToString(row1["FinalUnit_Other"]);
            cfx.FinalArea_SumtextEdit.Text = Convert.ToString(row1["FinalArea_Sum"]);
            cfx.FinalUnit_SumtextEdit.Text = Convert.ToString(row1["FinalUnit_Sum"]);
            cfx.OprStart_Okcheck.Checked = Convert.ToBoolean(row1["OprStart_OK"]);
            cfx.OprStart_DateDate.Text = Convert.ToString(row1["OprStart_Date"]);
            cfx.VisitorStart_Okcheck.Checked = Convert.ToBoolean(row1["VisitorStart_OK"]);
            cfx.VisitorStart_DateDate.Text = Convert.ToString(row1["VisitorStart_Date"]);
            cfx.VisitorStart_Resultcombo.SelectedIndex = Convert.ToInt32(row1["VisitorStart_Result"]);
            cfx.EngineerStart_OKcheck.Checked = Convert.ToBoolean(row1["EngineerStart_OK"]);
            cfx.EngineerStart_DateDate.Text = Convert.ToString(row1["EngineerStart_Date"]);
            cfx.EngineerStart_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerStart_Result"]);
            cfx.OprExcavation_OKcheck.Checked = Convert.ToBoolean(row1["OprExavation_OK"]);
            cfx.OprExcavation_DateDate.Text = Convert.ToString(row1["OprExavation_Date"]);
            cfx.VisitorExcavation_Okcheck.Checked = Convert.ToBoolean(row1["VisitorExavation_OK"]);
            cfx.VisitorExcavation_DateDate.Text = Convert.ToString(row1["VisitorExavation_Date"]);
            cfx.VisitorExavation_Resultcombo.SelectedIndex = Convert.ToInt32(row1["VisitorExavation_Result"]);
            cfx.EngineerExcavation_OKcheck.Checked = Convert.ToBoolean(row1["EngineerExavation_OK"]);
            cfx.EngineerExcavation_DateDate.Text = Convert.ToString(row1["EngineerExavation_Date"]);
            cfx.EngineerExcavation_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerExavation_Result"]);
            cfx.OprFoundation_Okcheck.Checked = Convert.ToBoolean(row1["OprFondation_OK"]);
            cfx.OprFoundation_DateDate.Text = Convert.ToString(row1["OprFondation_Date"]);
            cfx.VisitorFoundation_Okcheck.Checked = Convert.ToBoolean(row1["VisitorFondation_OK"]);
            cfx.VisitorFoundation_DateDate.Text = Convert.ToString(row1["VisitorFondation_Date"]);
            cfx.VisitorFoundation_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorFondation_Result"]);
            cfx.EngineerFoundation_OKcheck.Checked = Convert.ToBoolean(row1["EngineerFondation_OK"]);
            cfx.EngineerFoundation_DateDate.Text = Convert.ToString(row1["EngineerFondation_Date"]);
            cfx.EngineerFoundation_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerFondation_Result"]);
            cfx.OprRoof1_Okcheck.Checked = Convert.ToBoolean(row1["OprRoof1_OK"]);
            cfx.OprRoof1_DateDate.Text = Convert.ToString(row1["OprRoof1_Date"]);
            cfx.VisitorRoof1_Okcheck.Checked = Convert.ToBoolean(row1["VisitorRoof1_OK"]);
            cfx.VisitorRoof1_DateDate.Text = Convert.ToString(row1["VisitorRoof1_Date"]);
            cfx.VisitorRoof1_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorRoof1_Result"]);
            cfx.EngineerRoof1_OKcheck.Checked = Convert.ToBoolean(row1["EngineerRoof1_OK"]);
            cfx.EngineerRoof1_DateDate.Text = Convert.ToString(row1["EngineerRoof1_Date"]);
            cfx.EngineerRoof1_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerRoof1_Result"]);
            cfx.OprRoof3_Okcheck.Checked = Convert.ToBoolean(row1["OprRoof3_OK"]);
            cfx.OprRoof3_DateDate.Text = Convert.ToString(row1["OprRoof3_Date"]);
            cfx.VisitorRoof3_Okcheck.Checked = Convert.ToBoolean(row1["VisitorRoof3_OK"]);
            cfx.VisitorRoof3_DateDate.Text = Convert.ToString(row1["VisitorRoof3_Date"]);
            cfx.VisitorRoof3_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorRoof3_Result"]);
            cfx.EngineerRoof3_OKcheck.Checked = Convert.ToBoolean(row1["EngineerRoof3_OK"]);
            cfx.EngineerRoof3_DateDate.Text = Convert.ToString(row1["EngineerRoof3_Date"]);
            cfx.EngineerRoof3_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerRoof3_Result"]);
            cfx.OprRoofFinal_Okcheck.Checked = Convert.ToBoolean(row1["OprRoofFinal_OK"]);
            cfx.OprRoofFinal_DateDate.Text = Convert.ToString(row1["OprRoofFinal_Date"]);
            cfx.VisitorRoofFinal_Okcheck.Checked = Convert.ToBoolean(row1["VisitorRoofFinal_OK"]);
            cfx.VisitorRoofFinal_DateDate.Text = Convert.ToString(row1["VisitorRoofFinal_Date"]);
            cfx.VisitorRoofFinal_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorRoofFinal_Result"]);
            cfx.EngineerRoofFinal_OKcheck.Checked = Convert.ToBoolean(row1["EngineerRoofFinal_OK"]);
            cfx.EngineerRoofFinal_DateDate.Text = Convert.ToString(row1["EngineerRoofFinal_Date"]);
            cfx.EngineerRoofFinal_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerRoofFinal_Result"]);
            cfx.OprHard_Okcheck.Checked = Convert.ToBoolean(row1["OprHard_OK"]);
            cfx.OprHard_DateDate.Text = Convert.ToString(row1["OprHard_Date"]);
            cfx.VisitorHard_Okcheck.Checked = Convert.ToBoolean(row1["VisitorHard_OK"]);
            cfx.VisitorHard_DateDate.Text = Convert.ToString(row1["VisitorHard_Date"]);
            cfx.VisitorHard_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorHard_Result"]);
            cfx.EngineerHard_OKcheck.Checked = Convert.ToBoolean(row1["EngineerHard_OK"]);
            cfx.EngineerHard_DateDate.Text = Convert.ToString(row1["EngineerHard_Date"]);
            cfx.EngineerHard_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerHard_Result"]);
            cfx.OprThin_Okcheck.Checked = Convert.ToBoolean(row1["OprThin_OK"]);
            cfx.OprThin_DateDate.Text = Convert.ToString(row1["OprThin_Date"]);
            cfx.VisitorThin_Okcheck.Checked = Convert.ToBoolean(row1["VisitorThin_OK"]);
            cfx.VisitorThin_DateDate.Text = Convert.ToString(row1["VisitorThin_Date"]);
            cfx.VisitorThin_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorThin_Result"]);
            cfx.EngineerThin_OKcheck.Checked = Convert.ToBoolean(row1["EngineerThin_OK"]);
            cfx.EngineerThin_DateDate.Text = Convert.ToString(row1["EngineerThin_Date"]);
            cfx.EngineerThin_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerThin_Result"]);
            cfx.OprFinal_Okcheck.Checked = Convert.ToBoolean(row1["OprFinal_OK"]);
            cfx.OprFinal_DateDate.Text = Convert.ToString(row1["OprFinal_Date"]);
            cfx.VisitorFinal_Okcheck.Checked = Convert.ToBoolean(row1["VisitorFinal_OK"]);
            cfx.VisitorFinal_DateDate.Text = Convert.ToString(row1["VisitorFinal_Date"]);
            cfx.VisitorFinal_ResultCombo.SelectedIndex = Convert.ToInt32(row1["VisitorFinal_Result"]);
            cfx.EngineerFinal_OKcheck.Checked = Convert.ToBoolean(row1["EngineerFinal_OK"]);
            cfx.EngineerFinal_DateDate.Text = Convert.ToString(row1["EngineerFinal_Date"]);
            cfx.EngineerFinal_ResultCombo.SelectedIndex = Convert.ToInt32(row1["EngineerFinal_Result"]);
            cfx.Visitor_ReportMemo.Text = Convert.ToString(row1["Visitor_Report"]);
            cfx.Engineer_ReportMemo.Text = Convert.ToString(row1["Engineer_Report"]);
            cfx.Violation_CutTreeCheck.Checked = Convert.ToBoolean(row1["Violation_CutTree"]);
            cfx.Violation_OverStructCheck.Checked = Convert.ToBoolean(row1["Violation_OverStruct"]);
            cfx.Violation_OverHeight_Check.Checked = Convert.ToBoolean(row1["Violation_OverHeight"]);
            cfx.Violation_NoRuleCheck.Checked = Convert.ToBoolean(row1["Violation_NoRule"]);
            cfx.Violation_LackParkingCheck.Checked = Convert.ToBoolean(row1["Violation_LackParking"]);
            cfx.Violation_NoSpace60Check.Checked = Convert.ToBoolean(row1["Violation_NoSpace60"]);
            cfx.Violation_OverLayerCheck.Checked = Convert.ToBoolean(row1["Violation_OverLayer"]);
            cfx.Violation_ConversionCheck.Checked = Convert.ToBoolean(row1["Violation_Conversion"]);
            cfx.Violation_OverExcavationCheck.Checked = Convert.ToBoolean(row1["Violation_OverExcavation"]);
            cfx.Violation_ChangeLightCheck.Checked = Convert.ToBoolean(row1["Violation_ChangeLight"]);
            cfx.Violation_XchangeMapCheck.Checked = Convert.ToBoolean(row1["Violation_XchangeMap"]);
            cfx.Violation_NoSpace62Check.Checked = Convert.ToBoolean(row1["Violation_NoSpace62"]);
            cfx.Discour1Combo.SelectedIndex = Convert.ToInt32(row1["Discour1"]);
            cfx.Discour1_DateDate.Text = Convert.ToString(row1["Discour1_Date"]);
            cfx.SetDiscur_StepCombo(cfx.Discour1_StepCombo);
            cfx.Discour1_StepCombo.SelectedIndex = Convert.ToInt32(row1["Discour1_Step"]);
            cfx.Discour1_DirectDatedate.Text = Convert.ToString(row1["Discour1_DirectDate"]);
            cfx.Discour1_NoVioDatedate.Text = Convert.ToString(row1["Discour1_NoVioDate"]);
            cfx.Discour2Combo.SelectedIndex = Convert.ToInt32(row1["Discour2"]);
            cfx.Discour2_DateDate.Text = Convert.ToString(row1["Discour2_Date"]);
            cfx.SetDiscur_StepCombo(cfx.Discour2_StepCombo);
            cfx.Discour2_StepCombo.SelectedIndex = Convert.ToInt32(row1["Discour2_Step"]);
            cfx.Discour2_DirectDatedate.Text = Convert.ToString(row1["Discour2_DirectDate"]);
            cfx.Discour2_NoVioDatedate.Text = Convert.ToString(row1["Discour2_NoVioDate"]);
            cfx.Discour3Combo.SelectedIndex = Convert.ToInt32(row1["Discour3"]);
            cfx.Discour3_DateDate.Text = Convert.ToString(row1["Discour3_Date"]);
            cfx.SetDiscur_StepCombo(cfx.Discour3_StepCombo);
            cfx.Discour3_StepCombo.SelectedIndex = Convert.ToInt32(row1["Discour3_Step"]);
            cfx.Discour3_DirectDatedate.Text = Convert.ToString(row1["Discour3_DirectDate"]);
            cfx.Discour3_NoVioDatedate.Text = Convert.ToString(row1["Discour3_NoVioDate"]);
            cfx.Discour4Combo.SelectedIndex = Convert.ToInt32(row1["Discour4"]);
            cfx.Discour4_DateDate.Text = Convert.ToString(row1["Discour4_Date"]);
            cfx.SetDiscur_StepCombo(cfx.Discour4_StepCombo);
            cfx.Discour4_StepCombo.SelectedIndex = Convert.ToInt32(row1["Discour4_Step"]);
            cfx.Discour4_DirectDatedate.Text = Convert.ToString(row1["Discour4_DirectDate"]);
            cfx.Discour4_NoVioDatedate.Text = Convert.ToString(row1["Discour4_NoVioDate"]);
            cfx.Discour5Combo.SelectedIndex = Convert.ToInt32(row1["Discour5"]);
            cfx.Discour5_DateDate.Text = Convert.ToString(row1["Discour5_Date"]);
            cfx.SetDiscur_StepCombo(cfx.Discour5_StepCombo);
            cfx.Discour5_StepCombo.SelectedIndex = Convert.ToInt32(row1["Discour5_Step"]);
            cfx.Discour5_DirectDatedate.Text = Convert.ToString(row1["Discour5_DirectDate"]);
            cfx.Discour5_NoVioDatedate.Text = Convert.ToString(row1["Discour5_NoVioDate"]);
            cfx.Final_ExplainMemo.Text = Convert.ToString(row1["Final_Explain"]);
            #endregion LoadData

            cfx.FileFormInInsertOrEditMode(2);

            SetDataSet_GridViewFiles();
            gridView1.FocusedRowHandle = Index;
        }

        private void barBtnItem_NewFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_InsertFile();
        }

        private void navBarItem_NewFile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_InsertFile();
        }

        public string WhereForSearch;
        private void SetDataSet_GridViewFiles()
        {
/*            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqlCommand SqlCmd = new SqlCommand();*/
            SqlCmd.CommandText = " SELECT * FROM [dbo].[GridCertificate_Vw] "+ WhereForSearch +
                                 "   Order By Operator_Code,Main_Street,Side_Street,Main_Alley,Side_Alley,House_No";
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataAdapter DAdapter = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            DAdapter.SelectCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            DataTable DtTbl = new DataTable();
            try
            {
                DAdapter.Fill(DtTbl);
                gridCertificate_VwGridControl.DataSource = DtTbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

        private void Func_InsertFile()
        {
            CrtFile_Xfm cfx = new CrtFile_Xfm();
            cfx.File_ID = gridView1.FocusedRowHandle;
            cfx.File_DateDate.Text = GetDateShamsiFromMiladi(DateTime.Today);
            cfx.FileFormInInsertOrEditMode(1);
            SetDataSet_GridViewFiles(); 
            gridView1.FocusedRowHandle = cfx.File_ID;
        }

        private void barBtnItem_Backup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_CallTheBackUp();
        }

        private void navBarItem_Backup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_CallTheBackUp();
        }

        private void Func_CallTheBackUp()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files(*.bak)|*.bak";
            if (dlg.ShowDialog() == DialogResult.OK)
                SetBackUpDBAll(dlg.FileName);
        }

        private void SetBackUpDBAll(string PathSaveBackup)
        {
/*            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqlCommand SqlCmd = new SqlCommand();*/
            SqlCmd.CommandText = " BACKUP DATABASE [Mayoralty_Files] TO  DISK = N'" + PathSaveBackup + "' " +
                                 " WITH FORMAT, INIT, NAME = N'Mayoralty_Files-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10 ";
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;

            SqlConn.Open();

            try
            {
                SqlCmd.ExecuteReader();
                MessageBox.Show("عمل پشتيباني با موفقيت انجام شد");
                //GlobalProc.MessageBehin("عمل پشتيباني با موفقيت انجام شد", 3, false, false); //Add Mokhtari 87/04/17
            }
            catch (Exception ex)
            {
                string ex_str = Convert.ToString(ex);
                if (ex_str.IndexOf("Cannot open backup device") > 0)
                    MessageBox.Show("مسير پشتيبانی را عوض کنيد!");
                //GlobalProc.MessageBehin("مسير پشتيبانی را عوض کنيد!", 2, false, false);
                else
                    MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

        private void barBtnItem_Restore_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_CallTheRestore();
        }

        private void navBarItem_Restore_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_CallTheRestore();
        }

        private void Func_CallTheRestore()
        {
            if (MessageBox.Show("آیا نسبت به عمل بازیابی مطمئنید؟", "سامانه شهرسازی نواحی", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "All BackUp Files(*.bak)|*.bak";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SetRestoreDBAll(dlg.FileName);
                    SetDataSet_GridViewFiles();
                }
            }
        }

        private void SetRestoreDBAll(string PathSaveRestore)
        {
            //TSProgressBar.Visible = true;
            //TSProgressBar.Value = 0;
            //TSProgressBar.Value = TSProgressBar.Value + 10;/////

/*            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqlCommand SqlCmd = new SqlCommand();*/

            SqlCmd.CommandText =
                "use master " +
                "ALTER DATABASE [Mayoralty_Files] SET SINGLE_USER WITH ROLLBACK IMMEDIATE " +
                "RESTORE DATABASE [Mayoralty_Files] FROM  DISK = N'" + PathSaveRestore +
                "' WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10";
            //@"' WITH FILE = 1,  NOUNLOAD,  REPLACE, MOVE 'APPSERVER' TO 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\APPSERVER_Data.MDF', " +
            //@"MOVE 'APPSERVER_Log' TO 'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\APPSERVER_Log.LDF' ";
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;

            //TSProgressBar.Value = TSProgressBar.Value + 10;/////

            SqlDataAdapter SDA = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            SDA.UpdateCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            SqlConn.Open();

            //TSProgressBar.Value = TSProgressBar.Value + 20;/////

            try
            {
                SDA.UpdateCommand.ExecuteReader();
                MessageBox.Show("عمل بازيابي با موفقيت انجام شد");
                //GlobalProc.MessageBehin("عمل بازيابي با موفقيت انجام شد", 3, false, false); //Add Mokhtari 87/04/17
            }
            catch (Exception ex)
            {
                string ex_str = Convert.ToString(ex);
                if (ex_str.IndexOf("Cannot open backup device") > 0)
                    MessageBox.Show("مسير بازیابی را عوض کنيد!");
                //GlobalProc.MessageBehin("مسير پشتيبانی را عوض کنيد!", 2, false, false);
                else
                    MessageBox.Show(Convert.ToString(ex));
            }

            //TSProgressBar.Value = TSProgressBar.Value + 30;/////
            SqlConn.Close();

            //TSProgressBar.Visible = false;
        }

        private void barBtnItem_Setting_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_CallSettingForm();
        }

        private void navBarItem_Setting_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_CallSettingForm();
        }

        private void Func_CallSettingForm()
        {
            Setting_Xfm Setting = new Setting_Xfm();
            Setting.ShowDialog();
        }

        private void barBtnItem_Users_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_CallUsersForm();
        }

        private void navBarItem_Users_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Func_CallUsersForm();
        }

        private void Func_CallUsersForm()
        {
            UserList_Xfm UserL = new UserList_Xfm();
            UserL.ShowDialog();
        }

        private void gridCertificate_VwGridControl_DoubleClick(object sender, EventArgs e)
        {
            if (navBarItem_EditFile.Enabled)
            Func_EditFile();
        }

        private void navBarItem_Search_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SearchInGridView();
        }

        private void barBtnItem_SearchFile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SearchInGridView();
        }

        private void SearchInGridView()
        {
            SearchFile_Xfm SFX = new SearchFile_Xfm();
            SFX.ShowDialog();
            WhereForSearch = SFX.StrSql;
            SetDataSet_GridViewFiles();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            WhereForSearch = "";
            SetDataSet_GridViewFiles();
        }

        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            gridCertificate_VwGridControl.ShowPreview();
        }

        private void barBtnItem_AllRep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Load_AllReportForm();
        }

        private void navBarItem_AllRep_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Load_AllReportForm();
        }

        private void Load_AllReportForm()
        {
            RepAllItem_Xfm RAIX = new RepAllItem_Xfm();
            RAIX.ShowDialog();
        }

        private void barBtnItem_StsRep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Load_GraphReportForm();
        }

        private void navBarItem_StsRep_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Load_GraphReportForm();
        }

        private void Load_GraphReportForm()
        {
            RepGraph_Xfm RGX = new RepGraph_Xfm();
            RGX.ShowDialog();
        }

    }
}
/*	
	[ID]
    [File_Paper]  
	[File_No]  
	[File_Date]  
	[Crt_Type] 
	[Crt_DateNew]  
	[Crt_ValidTime]  
	[Operator_Code]  
	[Person_FName]  
	[Person_LName]  
	[Main_Street]  
	[Side_Street]  
	[Main_Alley]  
	[Side_Alley]  
	[House_No]  
	[Mayoralty_Part] 
	[Mayoralty_Sector] 
	[Use_Earth] 
	[Register_Plak]  
	[Parking_Domain] 
	[Closed_Space] 
	[Use_Space] 
	[Struct_Type] 
	[Tree_Exist] 
	[Excess_60] 
	[House_Head]  
	[Area_Proof]  
	[Area_Correct]  
	[Area_Exist]  
	[LayerSum_Few]  
	[UnderEarth_Few]  
	[Earth_Few]  
	[HighLayer_Few]  
	[Area_CorrectOK]  
	[Area_CorrectExist] 
	[FinalArea_StRoom]  
	[FinalUnit_StRoom]  
	[FinalArea_Stair]  
	[FinalUnit_Stair]  
	[FinalArea_Parking]  
	[FinalUnit_Parking]  
	[FinalArea_Huose]  
	[FinalUnit_Huose]  
	[FinalArea_Busin]  
	[FinalUnit_Busin]  
	[FinalArea_Office]  
	[FinalUnit_Office]  
	[FinalArea_Other]  
	[FinalUnit_Other]  
	[FinalArea_Sum]  
	[FinalUnit_Sum]  
	[OprStart_OK]  
	[OprStart_Date]  
	[VisitorStart_OK]  
	[VisitorStart_Date]  
	[VisitorStart_Result]  
	[EngineerStart_OK]  
	[EngineerStart_Date]  
	[EngineerStart_Result]  
	[OprExavation_OK]  
	[OprExavation_Date]  
	[VisitorExavation_OK]  
	[VisitorExavation_Date]  
	[VisitorExavation_Result]  
	[EngineerExavation_OK]  
	[EngineerExavation_Date]  
	[EngineerExavation_Result] 
	[OprFondation_OK]  
	[OprFondation_Date]  
	[VisitorFondation_OK]  
	[VisitorFondation_Date]  
	[VisitorFondation_Result] 
	[EngineerFondation_OK]  
	[EngineerFondation_Date]  
	[EngineerFondation_Result] 
	[OprRoof1_OK]  
	[OprRoof1_Date]  
	[VisitorRoof1_OK]  
	[VisitorRoof1_Date]  
	[VisitorRoof1_Result] 
	[EngineerRoof1_OK]  
	[EngineerRoof1_Date]  
	[EngineerRoof1_Result] 
	[OprRoof3_OK]  
	[OprRoof3_Date]  
	[VisitorRoof3_OK]  
	[VisitorRoof3_Date]  
	[VisitorRoof3_Result] 
	[EngineerRoof3_OK]  
	[EngineerRoof3_Date]  
	[EngineerRoof3_Result] 
	[OprRoofFinal_OK]  
	[OprRoofFinal_Date]  
	[VisitorRoofFinal_OK]  
	[VisitorRoofFinal_Date]  
	[VisitorRoofFinal_Result] 
	[EngineerRoofFinal_OK]  
	[EngineerRoofFinal_Date]  
	[EngineerRoofFinal_Result]  
	[OprHard_OK]  
	[OprHard_Date]  
	[VisitorHard_OK]  
	[VisitorHard_Date]  
	[VisitorHard_Result]  
	[EngineerHard_OK]  
	[EngineerHard_Date]  
	[EngineerHard_Result]  
	[OprThin_OK]  
	[OprThin_Date]  
	[VisitorThin_OK]  
	[VisitorThin_Date]  
	[VisitorThin_Result]  
	[EngineerThin_OK]  
	[EngineerThin_Date]  
	[EngineerThin_Result]  
	[OprFinal_OK]  
	[OprFinal_Date]  
	[VisitorFinal_OK]  
	[VisitorFinal_Date]  
	[VisitorFinal_Result]  
	[EngineerFinal_OK]  
	[EngineerFinal_Date]  
	[EngineerFinal_Result]  
	[Visitor_Report]  
	[Engineer_Report]  
	[Violation_CutTree]  
	[Violation_OverStruct]  
	[Violation_OverHeight]  
	[Violation_NoRule]  
	[Violation_LackParking]  
	[Violation_NoSpace60]  
	[Violation_OverLayer]  
	[Violation_Conversion]  
	[Violation_OverExcavation]  
	[Violation_ChangeLight]  
	[Violation_XchangeMap]  
	[Violation_NoSpace62]  
	[Discour1]  
	[Discour1_Date]  
	[Discour1_Step]  
	[Discour1_DirectDate]  
	[Discour1_NoVioDate]  
	[Discour2]  
	[Discour2_Date]  
	[Discour2_Step]  
	[Discour2_DirectDate]  
	[Discour2_NoVioDate]  
	[Discour3]  
	[Discour3_Date]  
	[Discour3_Step]  
	[Discour3_DirectDate]  
	[Discour3_NoVioDate]  
	[Discour4]  
	[Discour4_Date]  
	[Discour4_Step]  
	[Discour4_DirectDate]  
	[Discour4_NoVioDate]  
	[Discour5]  
	[Discour5_Date]  
	[Discour5_Step]  
	[Discour5_DirectDate]  
	[Discour5_NoVioDate]  
	[Final_Explain] 
 	[Mayoralty_Part] 
	[Mayoralty_Sector]
 */



