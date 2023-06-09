using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace MayoraltyDossiers_UI
{
    public partial class CrtFile_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public CrtFile_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqCmd = new SqlCommand();
        public int InsOrEdtFile;
        public int File_ID;
        
        public void FileFormInInsertOrEditMode(int InsertOrEdit)
        {
            if (InsertOrEdit == 1)
            {
                InsOrEdtFile = 1;
                Del_simpleButton.Visible = false;
                this.ShowDialog();
            }

            if (InsertOrEdit == 2)
            {
                InsOrEdtFile = 2;
                this.ShowDialog();
            }
        }

        private void CrtFile_Xfm_Shown(object sender, EventArgs e)
        {
            SetEnDisEnabledComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CrtFile_Xfm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                if ((this.ActiveControl.Parent.Name != "Engineer_ReportMemo") &
                   (this.ActiveControl.Parent.Name != "Visitor_ReportMemo") &
                   (this.ActiveControl.Parent.Name != "Final_ExplainMemo"))
                SelectNextControl(ActiveControl, true, true, true, false);
        }

        #region

        private void SetEnDisEnabledComponent()
        {
            panelControl2.Enabled = OprStart_Okcheck.Checked;
            panelControl3.Enabled = OprExcavation_OKcheck.Checked;
            panelControl4.Enabled = OprFoundation_Okcheck.Checked;
            panelControl5.Enabled = OprRoof1_Okcheck.Checked;
            panelControl6.Enabled = OprRoof3_Okcheck.Checked;
            panelControl7.Enabled = OprRoofFinal_Okcheck.Checked;
            panelControl8.Enabled = OprHard_Okcheck.Checked;
            panelControl9.Enabled = OprThin_Okcheck.Checked;
            panelControl10.Enabled = OprFinal_Okcheck.Checked;

            VisitorStart_DateDate.Enabled = VisitorStart_Okcheck.Checked;
            VisitorStart_Resultcombo.Enabled = VisitorStart_Okcheck.Checked;

            EngineerStart_DateDate.Enabled = EngineerStart_OKcheck.Checked;
            EngineerStart_ResultCombo.Enabled = EngineerStart_OKcheck.Checked;

            VisitorExcavation_DateDate.Enabled = VisitorExcavation_Okcheck.Checked;
            VisitorExavation_Resultcombo.Enabled = VisitorExcavation_Okcheck.Checked;

            EngineerExcavation_DateDate.Enabled = EngineerExcavation_OKcheck.Checked;
            EngineerExcavation_ResultCombo.Enabled = EngineerExcavation_OKcheck.Checked;

            VisitorFoundation_DateDate.Enabled = VisitorFoundation_Okcheck.Checked;
            VisitorFoundation_ResultCombo.Enabled = VisitorFoundation_Okcheck.Checked;

            EngineerFoundation_DateDate.Enabled = EngineerFoundation_OKcheck.Checked;
            EngineerFoundation_ResultCombo.Enabled = EngineerFoundation_OKcheck.Checked;

            VisitorRoof1_DateDate.Enabled = VisitorRoof1_Okcheck.Checked;
            VisitorRoof1_ResultCombo.Enabled = VisitorRoof1_Okcheck.Checked;

            EngineerRoof1_DateDate.Enabled = EngineerRoof1_OKcheck.Checked;
            EngineerRoof1_ResultCombo.Enabled = EngineerRoof1_OKcheck.Checked;

            VisitorRoof3_DateDate.Enabled = VisitorRoof3_Okcheck.Checked;
            VisitorRoof3_ResultCombo.Enabled = VisitorRoof3_Okcheck.Checked;

            EngineerRoof3_DateDate.Enabled = EngineerRoof3_OKcheck.Checked;
            EngineerRoof3_ResultCombo.Enabled = EngineerRoof3_OKcheck.Checked;

            VisitorRoofFinal_DateDate.Enabled = VisitorRoofFinal_Okcheck.Checked;
            VisitorRoofFinal_ResultCombo.Enabled = VisitorRoofFinal_Okcheck.Checked;

            EngineerRoofFinal_DateDate.Enabled = EngineerRoofFinal_OKcheck.Checked;
            EngineerRoofFinal_ResultCombo.Enabled = EngineerRoofFinal_OKcheck.Checked;

            VisitorHard_DateDate.Enabled = VisitorHard_Okcheck.Checked;
            VisitorHard_ResultCombo.Enabled = VisitorHard_Okcheck.Checked;

            EngineerHard_DateDate.Enabled = EngineerHard_OKcheck.Checked;
            EngineerHard_ResultCombo.Enabled = EngineerHard_OKcheck.Checked;

            VisitorThin_DateDate.Enabled = VisitorThin_Okcheck.Checked;
            VisitorThin_ResultCombo.Enabled = VisitorThin_Okcheck.Checked;

            EngineerThin_DateDate.Enabled = EngineerThin_OKcheck.Checked;
            EngineerThin_ResultCombo.Enabled = EngineerThin_OKcheck.Checked;

            VisitorFinal_DateDate.Enabled = VisitorFinal_Okcheck.Checked;
            VisitorFinal_ResultCombo.Enabled = VisitorFinal_Okcheck.Checked;

            EngineerFinal_DateDate.Enabled = EngineerFinal_OKcheck.Checked;
            EngineerFinal_ResultCombo.Enabled = EngineerFinal_OKcheck.Checked;

            Area_CorrectExistcombo.Enabled = area_CorrectOKCheckEdit.Checked;

            panelControl_Tree.Enabled = (Tree_ExistCombo.SelectedIndex == 0);
        }

        private void area_CorrectOKCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            Area_CorrectExistcombo.Enabled = !Area_CorrectExistcombo.Enabled;
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            panelControl2.Enabled = !panelControl2.Enabled;
        }

        private void checkEdit2_CheckedChanged(object sender, EventArgs e)
        {
            panelControl3.Enabled = !panelControl3.Enabled;
        }

        private void checkEdit3_CheckedChanged(object sender, EventArgs e)
        {
            panelControl4.Enabled = !panelControl4.Enabled;
        }

        private void checkEdit4_CheckedChanged(object sender, EventArgs e)
        {
            panelControl5.Enabled = !panelControl5.Enabled;
        }

        private void checkEdit5_CheckedChanged(object sender, EventArgs e)
        {
            panelControl6.Enabled = !panelControl6.Enabled;
        }

        private void checkEdit6_CheckedChanged(object sender, EventArgs e)
        {
            panelControl7.Enabled = !panelControl7.Enabled;
        }

        private void checkEdit7_CheckedChanged(object sender, EventArgs e)
        {
            panelControl8.Enabled = !panelControl8.Enabled;
        }

        private void checkEdit8_CheckedChanged(object sender, EventArgs e)
        {
            panelControl9.Enabled = !panelControl9.Enabled;
        }

        private void checkEdit9_CheckedChanged(object sender, EventArgs e)
        {
            panelControl10.Enabled = !panelControl10.Enabled;
        }

        private void checkEdit18_CheckedChanged(object sender, EventArgs e)
        {
            VisitorStart_DateDate.Enabled = !VisitorStart_DateDate.Enabled;
            VisitorStart_Resultcombo.Enabled = !VisitorStart_Resultcombo.Enabled;
        }

        private void checkEdit27_CheckedChanged(object sender, EventArgs e)
        {
            EngineerStart_DateDate.Enabled = !EngineerStart_DateDate.Enabled;
            EngineerStart_ResultCombo.Enabled = !EngineerStart_ResultCombo.Enabled;
        }

        private void checkEdit11_CheckedChanged(object sender, EventArgs e)
        {
            VisitorExcavation_DateDate.Enabled = !VisitorExcavation_DateDate.Enabled;
            VisitorExavation_Resultcombo.Enabled = !VisitorExavation_Resultcombo.Enabled;
        }

        private void checkEdit10_CheckedChanged(object sender, EventArgs e)
        {
            EngineerExcavation_DateDate.Enabled = !EngineerExcavation_DateDate.Enabled;
            EngineerExcavation_ResultCombo.Enabled = !EngineerExcavation_ResultCombo.Enabled;
        }

        private void checkEdit13_CheckedChanged(object sender, EventArgs e)
        {
            VisitorFoundation_DateDate.Enabled = !VisitorFoundation_DateDate.Enabled;
            VisitorFoundation_ResultCombo.Enabled = !VisitorFoundation_ResultCombo.Enabled;
        }

        private void checkEdit12_CheckedChanged(object sender, EventArgs e)
        {
            EngineerFoundation_DateDate.Enabled = !EngineerFoundation_DateDate.Enabled;
            EngineerFoundation_ResultCombo.Enabled = !EngineerFoundation_ResultCombo.Enabled;
        }

        private void checkEdit15_CheckedChanged(object sender, EventArgs e)
        {
            VisitorRoof1_DateDate.Enabled = !VisitorRoof1_DateDate.Enabled;
            VisitorRoof1_ResultCombo.Enabled = !VisitorRoof1_ResultCombo.Enabled;
        }

        private void checkEdit14_CheckedChanged(object sender, EventArgs e)
        {
            EngineerRoof1_DateDate.Enabled = !EngineerRoof1_DateDate.Enabled;
            EngineerRoof1_ResultCombo.Enabled = !EngineerRoof1_ResultCombo.Enabled;
        }

        private void checkEdit17_CheckedChanged(object sender, EventArgs e)
        {
            VisitorRoof3_DateDate.Enabled = !VisitorRoof3_DateDate.Enabled;
            VisitorRoof3_ResultCombo.Enabled = !VisitorRoof3_ResultCombo.Enabled;
        }

        private void checkEdit16_CheckedChanged(object sender, EventArgs e)
        {
            EngineerRoof3_DateDate.Enabled = !EngineerRoof3_DateDate.Enabled;
            EngineerRoof3_ResultCombo.Enabled = !EngineerRoof3_ResultCombo.Enabled;
        }

        private void checkEdit20_CheckedChanged(object sender, EventArgs e)
        {
            VisitorRoofFinal_DateDate.Enabled = !VisitorRoofFinal_DateDate.Enabled;
            VisitorRoofFinal_ResultCombo.Enabled = !VisitorRoofFinal_ResultCombo.Enabled;
        }

        private void checkEdit19_CheckedChanged(object sender, EventArgs e)
        {
            EngineerRoofFinal_DateDate.Enabled = !EngineerRoofFinal_DateDate.Enabled;
            EngineerRoofFinal_ResultCombo.Enabled = !EngineerRoofFinal_ResultCombo.Enabled;
        }

        private void checkEdit22_CheckedChanged(object sender, EventArgs e)
        {
            VisitorHard_DateDate.Enabled = !VisitorHard_DateDate.Enabled;
            VisitorHard_ResultCombo.Enabled = !VisitorHard_ResultCombo.Enabled;
        }

        private void checkEdit21_CheckedChanged(object sender, EventArgs e)
        {
            EngineerHard_DateDate.Enabled = !EngineerHard_DateDate.Enabled;
            EngineerHard_ResultCombo.Enabled = !EngineerHard_ResultCombo.Enabled;
        }

        private void checkEdit24_CheckedChanged(object sender, EventArgs e)
        {
            VisitorThin_DateDate.Enabled = !VisitorThin_DateDate.Enabled;
            VisitorThin_ResultCombo.Enabled = !VisitorThin_ResultCombo.Enabled;
        }

        private void checkEdit23_CheckedChanged(object sender, EventArgs e)
        {
            EngineerThin_DateDate.Enabled = !EngineerThin_DateDate.Enabled;
            EngineerThin_ResultCombo.Enabled = !EngineerThin_ResultCombo.Enabled;
        }

        private void checkEdit26_CheckedChanged(object sender, EventArgs e)
        {
            VisitorFinal_DateDate.Enabled = !VisitorFinal_DateDate.Enabled;
            VisitorFinal_ResultCombo.Enabled = !VisitorFinal_ResultCombo.Enabled;
        }

        private void checkEdit25_CheckedChanged(object sender, EventArgs e)
        {
            EngineerFinal_DateDate.Enabled = !EngineerFinal_DateDate.Enabled;
            EngineerFinal_ResultCombo.Enabled = !EngineerFinal_ResultCombo.Enabled;
        }

        #endregion EnablesOrDisabledComponents
        
        #region
        DateEdit de = new DateEdit();
        private void crt_DateNewDateEdit_Leave(object sender, EventArgs e)
        {
            de = (DateEdit)sender;
            if (de.Text == "") return;

            int y = de.DateTime.Year;
            int m = de.DateTime.Month;
            int d = de.DateTime.Day;

            if (((y < 1300) | (y > 1420)) |
                ((y % 4 != 3) & (m == 12) & (d == 30)) | ((m >= 7) & (d == 31)))
            {
                //toolTipController1.Active = true;
                de.Focus();
            }
        }

        private void Discour1_StepCombo_Enter(object sender, EventArgs e)
        {
            ComboBoxEdit CBE = new ComboBoxEdit();
            CBE = (ComboBoxEdit)sender;
            SetDiscur_StepCombo(CBE);
        }

        public void SetDiscur_StepCombo(ComboBoxEdit CBE)
        {
            CBE.Properties.Items.Clear();
            CBE.Properties.Items.Add("شروع به کار");
            CBE.Properties.Items.Add("گود برداری");
            CBE.Properties.Items.Add("پی سازی");
            int j = 0;
            if (Convert.ToInt32(UnderEarth_FewtextEdit.Text) > 0)
            {
                j = Convert.ToInt32(UnderEarth_FewtextEdit.Text);
                for (int i = j; i > 0; i--)
                    CBE.Properties.Items.Add("-" + "سقف زیرزمین " + Convert.ToString(i));
            }

            if (Convert.ToInt32(Earth_FewtextEdit.Text) > 0)
            {
                j = Convert.ToInt32(Earth_FewtextEdit.Text);
                for (int i = 1; i <= j; i++)
                    CBE.Properties.Items.Add("سقف همکف " + Convert.ToString(i));
            }

            if (Convert.ToInt32(HighLayer_FewtextEdit.Text) > 0)
            {
                j = Convert.ToInt32(HighLayer_FewtextEdit.Text);
                for (int i = 1; i <= j; i++)
                    CBE.Properties.Items.Add("سقف طبقه " + Convert.ToString(i));
            }

            CBE.Properties.Items.Add("سفت کاری");
            CBE.Properties.Items.Add("نازک کاری");
            CBE.Properties.Items.Add("پایان نازک کاری");
        }

        private void textEdit19_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                LayerSum_FewtextEdit.Text = Convert.ToString(Convert.ToInt32(HighLayer_FewtextEdit.Text) + Convert.ToInt32(Earth_FewtextEdit.Text) + Convert.ToInt32(UnderEarth_FewtextEdit.Text));
            }
            catch
            { }
        }

        private void textEdit31_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                FinalUnit_SumtextEdit.Text = Convert.ToString(Convert.ToDouble(FinalUnit_StRoomtextEdit.Text) + Convert.ToDouble(FinalUnit_StairtextEdit.Text) + Convert.ToDouble(FinalUnit_ParkingtextEdit.Text) +
                                                   Convert.ToDouble(FinalUnit_HousetextEdit.Text) + Convert.ToDouble(FinalUnit_BusintextEdit.Text) + Convert.ToDouble(FinalUnit_OfficetextEdit.Text) +
                                                   Convert.ToDouble(FinalUnit_OthertextEdit.Text));
            }
            catch
            { }
        }

        private void FinalArea_StRoomtextEdit_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                FinalArea_SumtextEdit.Text = Convert.ToString(Convert.ToDouble(FinalArea_StRoomtextEdit.Text) + Convert.ToDouble(FinalArea_StairtextEdit.Text) + Convert.ToDouble(FinalArea_ParkingtextEdit.Text) +
                                             Convert.ToDouble(FinalArea_HousetextEdit.Text) + Convert.ToDouble(FinalArea_BusintextEdit.Text) + Convert.ToDouble(FinalArea_OfficetextEdit.Text) +
                                             Convert.ToDouble(FinalArea_OthertextEdit.Text));
            }
            catch
            { }

        }

        private void textEdit17_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(Area_ProoftextEdit.Text) != Convert.ToDouble(Area_CorrecttextEdit.Text))
                    area_CorrectOKCheckEdit.Checked = true;
                else area_CorrectOKCheckEdit.Checked = false;
            }
            catch { }
        }

        private void Tree_ExistCombo_EditValueChanged(object sender, EventArgs e)
        {
            panelControl_Tree.Enabled = (Tree_ExistCombo.SelectedIndex == 0);
        }

        #endregion EditProcess

        private void Del_simpleButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا به حذف کردن این پرونده اطمینان دارید؟", "سامانه شهرسازی نواحی", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DeleteFileFromDB();
                Close();
            }
        }

        private void DeleteFileFromDB()
        {
//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqConn.Open();

            //SqlCommand SqCmd = new SqlCommand();
            SqCmd.Connection = SqConn;

            //Delete From Certificate Table
            SqCmd.CommandText = 
               "DELETE FROM [Mayoralty_Files].[dbo].[tbl_Certificate] "+
               " Where ID = " + File_ID;

            SqCmd.ExecuteReader();
            SqConn.Close();
        }

        private void OK_simpleButton_Click(object sender, EventArgs e)
        {
            if (InsOrEdtFile == 1)
            {
                if (Operator_CodeCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("کد ناظر محل را وارد نمایید", "سامانه شهرسازی نواحی");
                    return;
                }
                file_CodeTextEdit.Text = SetFileCodeInDB(Operator_CodeCombo.Text);
                if (MessageBox.Show("آیا پرونده جدید ذخیره شود؟", "سامانه شهرسازی نواحی", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    InsertFileInDB();
                    Close();
                }
            }

            if (InsOrEdtFile == 2)
            {
                if (Operator_CodeCombo.SelectedIndex == -1)
                {
                    MessageBox.Show("کد ناظر محل را وارد نمایید", "سامانه شهرسازی نواحی");
                    return;
                }
                string str = file_CodeTextEdit.Text;
                if (Convert.ToString(str[0]) != Operator_CodeCombo.Text)
                  file_CodeTextEdit.Text = SetFileCodeInDB(Operator_CodeCombo.Text);
                if (MessageBox.Show("آیا تغییرات در پرونده ذخیره شوند؟", "سامانه شهرسازی نواحی", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    EditFileInDB();
                    Close();
                }
            }
        }

        private string SetFileCodeInDB(string Code)
        {
//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            //SqlCommand SqCmd = new SqlCommand();

            SqCmd.CommandText = "select cast(substring(File_Code,2,4) as int) as CodeFile into #temp "+
                                 "from tbl_Certificate "+
                                 "where substring(File_Code,1,1)='"+Code+"' "+
                                 "select max(CodeFile)+1 from #temp "+
                                 "drop table #temp ";

            SqCmd.CommandType = CommandType.Text;
            SqCmd.Connection = SqConn;

            SqConn.Open();

            SqlDataReader SDR = SqCmd.ExecuteReader();
            SDR.Read();
            string StrCode = Convert.ToString(SDR[0]);
            if (StrCode.Length == 3) StrCode = "0" + StrCode;
            if (StrCode.Length == 2) StrCode = "00" + StrCode;
            if (StrCode.Length == 1) StrCode = "000" + StrCode;
            if (StrCode == "") StrCode = "0001";
            StrCode = Code + StrCode;
            SqConn.Close();

            return StrCode;
        }

        private void InsertFileInDB()
        {
//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqConn.Open();

//            SqlCommand SqCmd = new SqlCommand();
            SqCmd.Connection = SqConn;

            //Insert In Certificate Table
            SqCmd.CommandText = 
            "INSERT INTO [Mayoralty_Files].[dbo].[tbl_Certificate] "+
                "([File_Code]" +
                ",[File_Status]" +
                ",[File_Paper]" +
                ",[File_No]" +
                ",[File_Date]" +
                ",[Crt_Type]" +
                ",[Crt_DateNew]" +
                ",[Crt_ValidTime]" +
                ",[Operator_Code]" +
                ",[Person_FName]" +
                ",[Person_LName]" +
                ",[Main_Street]" +
                ",[Side_Street]" +
                ",[Main_Alley]" +
                ",[Side_Alley]" +
                ",[House_No]" +
                ",[Mayoralty_Part]" +
                ",[Mayoralty_Sector]" +
                ",[Use_Earth]" +
                ",[Register_Plak]" +
                ",[Parking_Domain]" +
                ",[Closed_Space]" +
                ",[Use_Space]" +
                ",[Struct_Type]" +
                ",[Tree_Exist]" +
                ",[Excess_60]" +
                ",[House_Head]" +
                ",[Area_Proof]" +
                ",[Area_Correct]" +
                ",[Area_Exist]" +
                ",[LayerSum_Few]" +
                ",[UnderEarth_Few]" +
                ",[Earth_Few]" +
                ",[HighLayer_Few]" +
                ",[Area_CorrectOK]" +
                ",[Area_CorrectExist]" +
                ",[FinalType_Struct]"+
                ",[FinalArea_StRoom]" +
                ",[FinalUnit_StRoom]" +
                ",[FinalArea_Stair]" +
                ",[FinalUnit_Stair]" +
                ",[FinalArea_Parking]" +
                ",[FinalUnit_Parking]" +
                ",[FinalArea_Huose]" +
                ",[FinalUnit_Huose]" +
                ",[FinalArea_Busin]" +
                ",[FinalUnit_Busin]" +
                ",[FinalArea_Office]" +
                ",[FinalUnit_Office]" +
                ",[FinalArea_Other]" +
                ",[FinalUnit_Other]" +
                ",[FinalArea_Sum]" +
                ",[FinalUnit_Sum]" +
                ",[OprStart_OK]" +
                ",[OprStart_Date]" +
                ",[VisitorStart_OK]" +
                ",[VisitorStart_Date]" +
                ",[VisitorStart_Result]" +
                ",[EngineerStart_OK]" +
                ",[EngineerStart_Date]" +
                ",[EngineerStart_Result]" +
                ",[OprExavation_OK]" +
                ",[OprExavation_Date]" +
                ",[VisitorExavation_OK]" +
                ",[VisitorExavation_Date]" +
                ",[VisitorExavation_Result]" +
                ",[EngineerExavation_OK]" +
                ",[EngineerExavation_Date]" +
                ",[EngineerExavation_Result]" +
                ",[OprFondation_OK]" +
                ",[OprFondation_Date]" +
                ",[VisitorFondation_OK]" +
                ",[VisitorFondation_Date]" +
                ",[VisitorFondation_Result]" +
                ",[EngineerFondation_OK]" +
                ",[EngineerFondation_Date]" +
                ",[EngineerFondation_Result]" +
                ",[OprRoof1_OK]" +
                ",[OprRoof1_Date]" +
                ",[VisitorRoof1_OK]" +
                ",[VisitorRoof1_Date]" +
                ",[VisitorRoof1_Result]" +
                ",[EngineerRoof1_OK]" +
                ",[EngineerRoof1_Date]" +
                ",[EngineerRoof1_Result]" +
                ",[OprRoof3_OK]" +
                ",[OprRoof3_Date]" +
                ",[VisitorRoof3_OK]" +
                ",[VisitorRoof3_Date]" +
                ",[VisitorRoof3_Result]" +
                ",[EngineerRoof3_OK]" +
                ",[EngineerRoof3_Date]" +
                ",[EngineerRoof3_Result]" +
                ",[OprRoofFinal_OK]" +
                ",[OprRoofFinal_Date]" +
                ",[VisitorRoofFinal_OK]" +
                ",[VisitorRoofFinal_Date]" +
                ",[VisitorRoofFinal_Result]" +
                ",[EngineerRoofFinal_OK]" +
                ",[EngineerRoofFinal_Date]" +
                ",[EngineerRoofFinal_Result]" +
                ",[OprHard_OK]" +
                ",[OprHard_Date]" +
                ",[VisitorHard_OK]" +
                ",[VisitorHard_Date]" +
                ",[VisitorHard_Result]" +
                ",[EngineerHard_OK]" +
                ",[EngineerHard_Date]" +
                ",[EngineerHard_Result]" +
                ",[OprThin_OK]" +
                ",[OprThin_Date]" +
                ",[VisitorThin_OK]" +
                ",[VisitorThin_Date]" +
                ",[VisitorThin_Result]" +
                ",[EngineerThin_OK]" +
                ",[EngineerThin_Date]" +
                ",[EngineerThin_Result]" +
                ",[OprFinal_OK]" +
                ",[OprFinal_Date]" +
                ",[VisitorFinal_OK]" +
                ",[VisitorFinal_Date]" +
                ",[VisitorFinal_Result]" +
                ",[EngineerFinal_OK]" +
                ",[EngineerFinal_Date]" +
                ",[EngineerFinal_Result]" +
                ",[Visitor_Report]" +
                ",[Engineer_Report]" +
                ",[Violation_CutTree]" +
                ",[Violation_OverStruct]" +
                ",[Violation_OverHeight]" +
                ",[Violation_NoRule]" +
                ",[Violation_LackParking]" +
                ",[Violation_NoSpace60]" +
                ",[Violation_OverLayer]" +
                ",[Violation_Conversion]" +
                ",[Violation_OverExcavation]" +
                ",[Violation_ChangeLight]" +
                ",[Violation_XchangeMap]" +
                ",[Violation_NoSpace62]" +
                ",[Discour1]" +
                ",[Discour1_Date]" +
                ",[Discour1_Step]" +
                ",[Discour1_DirectDate]" +
                ",[Discour1_NoVioDate]" +
                ",[Discour2]" +
                ",[Discour2_Date]" +
                ",[Discour2_Step]" +
                ",[Discour2_DirectDate]" +
                ",[Discour2_NoVioDate]" +
                ",[Discour3]" +
                ",[Discour3_Date]" +
                ",[Discour3_Step]" +
                ",[Discour3_DirectDate]" +
                ",[Discour3_NoVioDate]" +
                ",[Discour4]" +
                ",[Discour4_Date]" +
                ",[Discour4_Step]" +
                ",[Discour4_DirectDate]" +
                ",[Discour4_NoVioDate]" +
                ",[Discour5]" +
                ",[Discour5_Date]" +
                ",[Discour5_Step]" +
                ",[Discour5_DirectDate]" +
                ",[Discour5_NoVioDate]" +
                ",[Final_Explain])" +
            "VALUES "+
                "('"+file_CodeTextEdit.Text+"',"+
                Convert.ToString( File_StatusCombo.SelectedIndex )+","+
                Convert.ToString( File_PaperCombo.SelectedIndex )+",'"+
                file_NoTextEdit.Text+"',"+
                "dbo.ShamsiToMiladi('" +File_DateDate.Text+ "')," +
                Convert.ToString( Crt_TypeCombo.SelectedIndex )+","+
                "dbo.ShamsiToMiladi('" + Crt_DateNewDate.Text + "')," +
                Convert.ToString( crt_ValidTimeSpinEdit.Value ) +","+
                Convert.ToString( Operator_CodeCombo.SelectedIndex )+",N'"+
                Person_FnametextEdit.Text +"',N'"+
                Person_LNametextEdit.Text+"',N'"+
                Main_StreettextEdit.Text +"',N'"+ 
                Side_StreettextEdit.Text +"',N'"+
                Main_AlleytextEdit.Text +"',N'"+ 
                Side_AlleytextEdit.Text +"',N'"+ 
                House_NotextEdit.Text +"',4,2,"+
                //Mayoralty_Part, smallint,>,<Mayoralty_Sector, smallint,>
                Convert.ToString( Use_EarthCombo.SelectedIndex ) +",N'"+ 
                Register_PlaktextEdit.Text +"',"+
                Convert.ToString( Parking_DomainCombo.SelectedIndex ) +","+
                Closed_SpaceTextEdit.Text+","+
                Use_SpaceTextEdit.Text+","+ 
                Convert.ToString( Struct_TypeCombo.SelectedIndex )+","+
                Convert.ToString( Tree_ExistCombo.SelectedIndex ) +","+ 
                Excess_60TextEdit.Text +",N'"+
                House_HeadTextEdit.Text +"',"+ 
                Area_ProoftextEdit.Text +","+ 
                Area_CorrecttextEdit.Text +","+ 
                Area_ExisttextEdit.Text +","+ 
                LayerSum_FewtextEdit.Text +","+ 
                UnderEarth_FewtextEdit.Text +","+ 
                Earth_FewtextEdit.Text +","+ 
                HighLayer_FewtextEdit.Text +","+
                Convert.ToString(Convert.ToByte(area_CorrectOKCheckEdit.Checked)) + "," +
                Convert.ToString(Area_CorrectExistcombo.SelectedIndex) + "," +
                Convert.ToString(FinalType_StructCombo.SelectedIndex) + "," +
                FinalArea_StRoomtextEdit.Text +","+ 
                FinalUnit_StRoomtextEdit.Text +","+ 
                FinalArea_StairtextEdit.Text +","+ 
                FinalUnit_StairtextEdit.Text +","+ 
                FinalArea_ParkingtextEdit.Text +","+ 
                FinalUnit_ParkingtextEdit.Text +","+ 
                FinalArea_HousetextEdit.Text +","+ 
                FinalUnit_HousetextEdit.Text +","+ 
                FinalArea_BusintextEdit.Text +","+ 
                FinalUnit_BusintextEdit.Text +","+ 
                FinalArea_OfficetextEdit.Text +","+ 
                FinalUnit_OfficetextEdit.Text +","+ 
                FinalArea_OthertextEdit.Text +","+ 
                FinalUnit_OthertextEdit.Text +","+ 
                FinalArea_SumtextEdit.Text +","+ 
                FinalUnit_SumtextEdit.Text +","+ 
                Convert.ToString( Convert.ToByte(OprStart_Okcheck.Checked) )+","+
                "dbo.ShamsiToMiladi('" + OprStart_DateDate.Text + "')," +
                Convert.ToString( Convert.ToByte(VisitorStart_Okcheck.Checked) )+","+
                "dbo.ShamsiToMiladi('" + VisitorStart_DateDate.Text + "')," +
                Convert.ToString( VisitorStart_Resultcombo.SelectedIndex ) +","+
                Convert.ToString( Convert.ToByte(EngineerStart_OKcheck.Checked) ) +","+
                "dbo.ShamsiToMiladi('" + EngineerStart_DateDate.Text + "')," +
                Convert.ToString( EngineerStart_ResultCombo.SelectedIndex ) +","+
                Convert.ToString( Convert.ToByte(OprExcavation_OKcheck.Checked) ) +","+
                "dbo.ShamsiToMiladi('" + OprExcavation_DateDate.Text + "')," +
                Convert.ToString( Convert.ToByte(VisitorExcavation_Okcheck.Checked) )+","+
                "dbo.ShamsiToMiladi('" + VisitorExcavation_DateDate.Text + "')," +
                Convert.ToString(VisitorExavation_Resultcombo.SelectedIndex) +","+
                Convert.ToString( Convert.ToByte(EngineerExcavation_OKcheck.Checked) )+","+
                "dbo.ShamsiToMiladi('" + EngineerExcavation_DateDate.Text + "')," +
                Convert.ToString(EngineerExcavation_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(OprFoundation_Okcheck.Checked)) +","+
                "dbo.ShamsiToMiladi('" + OprFoundation_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorFoundation_Okcheck.Checked)) +","+
                "dbo.ShamsiToMiladi('" + VisitorFoundation_DateDate.Text + "')," +
                Convert.ToString(VisitorFoundation_ResultCombo.SelectedIndex) + "," +
                Convert.ToString(Convert.ToByte(EngineerFoundation_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerFoundation_DateDate.Text + "')," +
                Convert.ToString(EngineerFoundation_ResultCombo.SelectedIndex) + "," +
                Convert.ToString(Convert.ToByte(OprRoof1_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprRoof1_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorRoof1_Okcheck.Checked)) + "," +
                "dbo.ShamsiToMiladi('" + VisitorRoof1_DateDate.Text + "')," +
                Convert.ToString(VisitorRoof1_ResultCombo.SelectedIndex) + "," +
                Convert.ToString(Convert.ToByte(EngineerRoof1_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerRoof1_DateDate.Text + "')," +
                Convert.ToString(EngineerRoof1_ResultCombo.SelectedIndex) + "," +
                Convert.ToString(Convert.ToByte(OprRoof3_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprRoof3_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorRoof3_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + VisitorRoof3_DateDate.Text + "')," +
                Convert.ToString(VisitorRoof3_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(EngineerRoof3_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerRoof3_DateDate.Text + "')," +
                Convert.ToString(EngineerRoof3_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(OprRoofFinal_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprRoofFinal_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorRoofFinal_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + VisitorRoofFinal_DateDate.Text + "')," +
                Convert.ToString(VisitorRoofFinal_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(EngineerRoofFinal_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerRoofFinal_DateDate.Text + "')," +
                Convert.ToString(EngineerRoofFinal_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(OprHard_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprHard_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorHard_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + VisitorHard_DateDate.Text + "')," +
                Convert.ToString(VisitorHard_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(EngineerHard_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerHard_DateDate.Text + "')," +
                Convert.ToString(EngineerHard_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(OprThin_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprThin_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorThin_Okcheck.Checked)) + "," +
                "dbo.ShamsiToMiladi('" + VisitorThin_DateDate.Text + "')," +
                Convert.ToString(VisitorThin_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(EngineerThin_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerThin_DateDate.Text + "')," +
                Convert.ToString(EngineerThin_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(OprFinal_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + OprFinal_DateDate.Text + "')," +
                Convert.ToString(Convert.ToByte(VisitorFinal_Okcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + VisitorFinal_DateDate.Text + "')," +
                Convert.ToString(VisitorFinal_ResultCombo.SelectedIndex)+","+
                Convert.ToString(Convert.ToByte(EngineerFinal_OKcheck.Checked))+","+
                "dbo.ShamsiToMiladi('" + EngineerFinal_DateDate.Text + "')," +
                Convert.ToString(EngineerFinal_ResultCombo.SelectedIndex)+",N'"+
                Visitor_ReportMemo.Text+"',N'"+
                Engineer_ReportMemo.Text+"',"+
                Convert.ToString(Convert.ToByte(Violation_CutTreeCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_OverStructCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_OverHeight_Check.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_NoRuleCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_LackParkingCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_NoSpace60Check.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_OverLayerCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_ConversionCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_OverExcavationCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_ChangeLightCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_XchangeMapCheck.Checked))+","+
                Convert.ToString(Convert.ToByte(Violation_NoSpace62Check.Checked))+","+
                Convert.ToString(Discour1Combo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour1_DateDate.Text + "')," +
                Convert.ToString(Discour1_StepCombo.SelectedIndex) + "," +
                "dbo.ShamsiToMiladi('" + Discour1_DirectDatedate.Text + "')," +
                "dbo.ShamsiToMiladi('" + Discour1_NoVioDatedate.Text + "')," +
                Convert.ToString(Discour2Combo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour2_DateDate.Text + "')," +
                Convert.ToString(Discour2_StepCombo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour2_DirectDatedate.Text + "')," +
                "dbo.ShamsiToMiladi('" + Discour2_NoVioDatedate.Text + "')," +
                Convert.ToString(Discour3Combo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour3_DateDate.Text + "')," +
                Convert.ToString(Discour3_StepCombo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour3_DirectDatedate.Text + "')," +
                "dbo.ShamsiToMiladi('" + Discour3_NoVioDatedate.Text + "')," +
                Convert.ToString(Discour4Combo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour4_DateDate.Text + "')," +
                Convert.ToString(Discour4_StepCombo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour4_DirectDatedate.Text + "')," +
                "dbo.ShamsiToMiladi('" + Discour4_NoVioDatedate.Text + "')," +
                Convert.ToString(Discour5Combo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour5_DateDate.Text + "')," +
                Convert.ToString(Discour5_StepCombo.SelectedIndex)+","+
                "dbo.ShamsiToMiladi('" + Discour5_DirectDatedate.Text + "')," +
                "dbo.ShamsiToMiladi('" + Discour5_NoVioDatedate.Text + "'),N'" +
                Final_ExplainMemo.Text+"')";

            SqCmd.ExecuteReader();

            SqConn.Close();
        }

        private void EditFileInDB()
        {
//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqConn.Open();

            //SqlCommand SqCmd = new SqlCommand();
            SqCmd.Connection = SqConn;

            //Insert In Certificate Table
            SqCmd.CommandText =
            "Update [Mayoralty_Files].[dbo].[tbl_Certificate] " +
            " Set " +
                " [File_Code]= '" + file_CodeTextEdit.Text + "'" +
                ",[File_Status]=" + Convert.ToString(File_StatusCombo.SelectedIndex) +
                ",[File_Paper]=" + Convert.ToString(File_PaperCombo.SelectedIndex) +
                ",[File_No]= '" + file_NoTextEdit.Text + "'" +
                ",[File_Date]= dbo.ShamsiToMiladi('" + File_DateDate.Text + "')" +
                ",[Crt_Type]= " + Convert.ToString(Crt_TypeCombo.SelectedIndex) +
                ",[Crt_DateNew] = dbo.ShamsiToMiladi('" + Crt_DateNewDate.Text + "')" +
                ",[Crt_ValidTime]= " + Convert.ToString(crt_ValidTimeSpinEdit.Value) +
                ",[Operator_Code]= " + Convert.ToString(Operator_CodeCombo.SelectedIndex) +
                ",[Person_FName]= N'" + Person_FnametextEdit.Text + "'" +
                ",[Person_LName]= N'" + Person_LNametextEdit.Text + "'" +
                ",[Main_Street]= N'" + Main_StreettextEdit.Text + "'" +
                ",[Side_Street]= N'" + Side_StreettextEdit.Text + "'" +
                ",[Main_Alley]= N'" + Main_AlleytextEdit.Text + "'" +
                ",[Side_Alley]= N'" + Side_AlleytextEdit.Text + "'" +
                ",[House_No]= N'" + House_NotextEdit.Text + "'" +
                ",[Mayoralty_Part]=4" + //Mayoralty_Part, smallint
                ",[Mayoralty_Sector]=2" + //Mayoralty_Sector, smallint
                ",[Use_Earth]=" + Convert.ToString(Use_EarthCombo.SelectedIndex) +
                ",[Register_Plak]= N'" + Register_PlaktextEdit.Text + "'" +
                ",[Parking_Domain]= " + Convert.ToString(Parking_DomainCombo.SelectedIndex) +
                ",[Closed_Space]= " + Closed_SpaceTextEdit.Text +
                ",[Use_Space]=" + Use_SpaceTextEdit.Text +
                ",[Struct_Type]=" + Convert.ToString(Struct_TypeCombo.SelectedIndex) +
                ",[Tree_Exist]=" + Convert.ToString(Tree_ExistCombo.SelectedIndex) +
                ",[Excess_60]=" + Excess_60TextEdit.Text +
                ",[House_Head]= N'" + House_HeadTextEdit.Text + "'" +
                ",[Area_Proof]=" + Area_ProoftextEdit.Text +
                ",[Area_Correct]=" + Area_CorrecttextEdit.Text +
                ",[Area_Exist]=" + Area_ExisttextEdit.Text +
                ",[LayerSum_Few]=" + LayerSum_FewtextEdit.Text +
                ",[UnderEarth_Few]=" + UnderEarth_FewtextEdit.Text +
                ",[Earth_Few]=" + Earth_FewtextEdit.Text +
                ",[HighLayer_Few]=" + HighLayer_FewtextEdit.Text +
                ",[Area_CorrectOK]=" + Convert.ToString(Convert.ToByte(area_CorrectOKCheckEdit.Checked)) +
                ",[Area_CorrectExist]=" + Convert.ToString(Area_CorrectExistcombo.SelectedIndex) +
                ",[FinalType_Struct]=" + Convert.ToString(FinalType_StructCombo.SelectedIndex) +
                ",[FinalArea_StRoom]=" + FinalArea_StRoomtextEdit.Text +
                ",[FinalUnit_StRoom]=" + FinalUnit_StRoomtextEdit.Text +
                ",[FinalArea_Stair]=" + FinalArea_StairtextEdit.Text +
                ",[FinalUnit_Stair]=" + FinalUnit_StairtextEdit.Text +
                ",[FinalArea_Parking]=" + FinalArea_ParkingtextEdit.Text +
                ",[FinalUnit_Parking]=" + FinalUnit_ParkingtextEdit.Text +
                ",[FinalArea_Huose]=" + FinalArea_HousetextEdit.Text +
                ",[FinalUnit_Huose]=" + FinalUnit_HousetextEdit.Text +
                ",[FinalArea_Busin]=" + FinalArea_BusintextEdit.Text +
                ",[FinalUnit_Busin]=" + FinalUnit_BusintextEdit.Text +
                ",[FinalArea_Office]=" + FinalArea_OfficetextEdit.Text +
                ",[FinalUnit_Office]=" + FinalUnit_OfficetextEdit.Text +
                ",[FinalArea_Other]=" + FinalArea_OthertextEdit.Text +
                ",[FinalUnit_Other]=" + FinalUnit_OthertextEdit.Text +
                ",[FinalArea_Sum]=" + FinalArea_SumtextEdit.Text +
                ",[FinalUnit_Sum]=" + FinalUnit_SumtextEdit.Text +
                ",[OprStart_OK]=" + Convert.ToString(Convert.ToByte(OprStart_Okcheck.Checked)) +
                ",[OprStart_Date]= dbo.ShamsiToMiladi('" + OprStart_DateDate.Text + "')" +
                ",[VisitorStart_OK]=" + Convert.ToString(Convert.ToByte(VisitorStart_Okcheck.Checked)) +
                ",[VisitorStart_Date]= dbo.ShamsiToMiladi('" + VisitorStart_DateDate.Text + "')" +
                ",[VisitorStart_Result]=" + Convert.ToString(VisitorStart_Resultcombo.SelectedIndex) +
                ",[EngineerStart_OK]=" + Convert.ToString(Convert.ToByte(EngineerStart_OKcheck.Checked)) +
                ",[EngineerStart_Date]= dbo.ShamsiToMiladi('" + EngineerStart_DateDate.Text + "')" +
                ",[EngineerStart_Result]=" + Convert.ToString(EngineerStart_ResultCombo.SelectedIndex) +
                ",[OprExavation_OK]=" + Convert.ToString(Convert.ToByte(OprExcavation_OKcheck.Checked)) +
                ",[OprExavation_Date]= dbo.ShamsiToMiladi('" + OprExcavation_DateDate.Text + "')" +
                ",[VisitorExavation_OK]=" + Convert.ToString(Convert.ToByte(VisitorExcavation_Okcheck.Checked)) +
                ",[VisitorExavation_Date]= dbo.ShamsiToMiladi('" + VisitorExcavation_DateDate.Text + "')" +
                ",[VisitorExavation_Result]=" + Convert.ToString(VisitorExavation_Resultcombo.SelectedIndex) +
                ",[EngineerExavation_OK]=" + Convert.ToString(Convert.ToByte(EngineerExcavation_OKcheck.Checked)) +
                ",[EngineerExavation_Date]= dbo.ShamsiToMiladi('" + EngineerExcavation_DateDate.Text + "')" +
                ",[EngineerExavation_Result]=" + Convert.ToString(EngineerExcavation_ResultCombo.SelectedIndex) +
                ",[OprFondation_OK]=" + Convert.ToString(Convert.ToByte(OprFoundation_Okcheck.Checked)) +
                ",[OprFondation_Date]= dbo.ShamsiToMiladi('" + OprFoundation_DateDate.Text + "')" +
                ",[VisitorFondation_OK]=" + Convert.ToString(Convert.ToByte(VisitorFoundation_Okcheck.Checked)) +
                ",[VisitorFondation_Date]= dbo.ShamsiToMiladi('" + VisitorFoundation_DateDate.Text + "')" +
                ",[VisitorFondation_Result]=" + Convert.ToString(VisitorFoundation_ResultCombo.SelectedIndex) +
                ",[EngineerFondation_OK]=" + Convert.ToString(Convert.ToByte(EngineerFoundation_OKcheck.Checked)) +
                ",[EngineerFondation_Date]= dbo.ShamsiToMiladi('" + EngineerFoundation_DateDate.Text + "')" +
                ",[EngineerFondation_Result]=" + Convert.ToString(EngineerFoundation_ResultCombo.SelectedIndex) +
                ",[OprRoof1_OK]=" + Convert.ToString(Convert.ToByte(OprRoof1_Okcheck.Checked)) +
                ",[OprRoof1_Date]= dbo.ShamsiToMiladi('" + OprRoof1_DateDate.Text + "')" +
                ",[VisitorRoof1_OK]=" + Convert.ToString(Convert.ToByte(VisitorRoof1_Okcheck.Checked)) +
                ",[VisitorRoof1_Date]= dbo.ShamsiToMiladi('" + VisitorRoof1_DateDate.Text + "')" +
                ",[VisitorRoof1_Result]=" + Convert.ToString(VisitorRoof1_ResultCombo.SelectedIndex) +
                ",[EngineerRoof1_OK]=" + Convert.ToString(Convert.ToByte(EngineerRoof1_OKcheck.Checked)) +
                ",[EngineerRoof1_Date]= dbo.ShamsiToMiladi('" + EngineerRoof1_DateDate.Text + "')" +
                ",[EngineerRoof1_Result]=" + Convert.ToString(EngineerRoof1_ResultCombo.SelectedIndex) +
                ",[OprRoof3_OK]=" + Convert.ToString(Convert.ToByte(OprRoof3_Okcheck.Checked)) +
                ",[OprRoof3_Date]= dbo.ShamsiToMiladi('" + OprRoof3_DateDate.Text + "')" +
                ",[VisitorRoof3_OK]=" + Convert.ToString(Convert.ToByte(VisitorRoof3_Okcheck.Checked)) +
                ",[VisitorRoof3_Date]= dbo.ShamsiToMiladi('" + VisitorRoof3_DateDate.Text + "')" +
                ",[VisitorRoof3_Result]=" + Convert.ToString(VisitorRoof3_ResultCombo.SelectedIndex) +
                ",[EngineerRoof3_OK]=" + Convert.ToString(Convert.ToByte(EngineerRoof3_OKcheck.Checked)) +
                ",[EngineerRoof3_Date]= dbo.ShamsiToMiladi('" + EngineerRoof3_DateDate.Text + "')" +
                ",[EngineerRoof3_Result]=" + Convert.ToString(EngineerRoof3_ResultCombo.SelectedIndex) +
                ",[OprRoofFinal_OK]=" + Convert.ToString(Convert.ToByte(OprRoofFinal_Okcheck.Checked)) +
                ",[OprRoofFinal_Date]= dbo.ShamsiToMiladi('" + OprRoofFinal_DateDate.Text + "')" +
                ",[VisitorRoofFinal_OK]=" + Convert.ToString(Convert.ToByte(VisitorRoofFinal_Okcheck.Checked)) +
                ",[VisitorRoofFinal_Date]= dbo.ShamsiToMiladi('" + VisitorRoofFinal_DateDate.Text + "')" +
                ",[VisitorRoofFinal_Result]=" + Convert.ToString(VisitorRoofFinal_ResultCombo.SelectedIndex) +
                ",[EngineerRoofFinal_OK]=" + Convert.ToString(Convert.ToByte(EngineerRoofFinal_OKcheck.Checked)) +
                ",[EngineerRoofFinal_Date]= dbo.ShamsiToMiladi('" + EngineerRoofFinal_DateDate.Text + "')" +
                ",[EngineerRoofFinal_Result]=" + Convert.ToString(EngineerRoofFinal_ResultCombo.SelectedIndex) +
                ",[OprHard_OK]=" + Convert.ToString(Convert.ToByte(OprHard_Okcheck.Checked)) +
                ",[OprHard_Date]= dbo.ShamsiToMiladi('" + OprHard_DateDate.Text + "')" +
                ",[VisitorHard_OK]=" + Convert.ToString(Convert.ToByte(VisitorHard_Okcheck.Checked)) +
                ",[VisitorHard_Date]= dbo.ShamsiToMiladi('" + VisitorHard_DateDate.Text + "')" +
                ",[VisitorHard_Result]=" + Convert.ToString(VisitorHard_ResultCombo.SelectedIndex) +
                ",[EngineerHard_OK]=" + Convert.ToString(Convert.ToByte(EngineerHard_OKcheck.Checked)) +
                ",[EngineerHard_Date]= dbo.ShamsiToMiladi('" + EngineerHard_DateDate.Text + "')" +
                ",[EngineerHard_Result]=" + Convert.ToString(EngineerHard_ResultCombo.SelectedIndex) +
                ",[OprThin_OK]=" + Convert.ToString(Convert.ToByte(OprThin_Okcheck.Checked)) +
                ",[OprThin_Date]= dbo.ShamsiToMiladi('" + OprThin_DateDate.Text + "')" +
                ",[VisitorThin_OK]=" + Convert.ToString(Convert.ToByte(VisitorThin_Okcheck.Checked)) +
                ",[VisitorThin_Date]= dbo.ShamsiToMiladi('" + VisitorThin_DateDate.Text + "')" +
                ",[VisitorThin_Result]=" + Convert.ToString(VisitorThin_ResultCombo.SelectedIndex) +
                ",[EngineerThin_OK]=" + Convert.ToString(Convert.ToByte(EngineerThin_OKcheck.Checked)) +
                ",[EngineerThin_Date]= dbo.ShamsiToMiladi('" + EngineerThin_DateDate.Text + "')" +
                ",[EngineerThin_Result]=" + Convert.ToString(EngineerThin_ResultCombo.SelectedIndex) +
                ",[OprFinal_OK]=" + Convert.ToString(Convert.ToByte(OprFinal_Okcheck.Checked)) +
                ",[OprFinal_Date]= dbo.ShamsiToMiladi('" + OprFinal_DateDate.Text + "')" +
                ",[VisitorFinal_OK]=" + Convert.ToString(Convert.ToByte(VisitorFinal_Okcheck.Checked)) +
                ",[VisitorFinal_Date]= dbo.ShamsiToMiladi('" + VisitorFinal_DateDate.Text + "')" +
                ",[VisitorFinal_Result]=" + Convert.ToString(VisitorFinal_ResultCombo.SelectedIndex) +
                ",[EngineerFinal_OK]=" + Convert.ToString(Convert.ToByte(EngineerFinal_OKcheck.Checked)) +
                ",[EngineerFinal_Date]= dbo.ShamsiToMiladi('" + EngineerFinal_DateDate.Text + "')" +
                ",[EngineerFinal_Result]=" + Convert.ToString(EngineerFinal_ResultCombo.SelectedIndex) +
                ",[Visitor_Report]= N'" + Visitor_ReportMemo.Text + "'" +
                ",[Engineer_Report]= N'" + Engineer_ReportMemo.Text + "'" +
                ",[Violation_CutTree]=" + Convert.ToString(Convert.ToByte(Violation_CutTreeCheck.Checked)) +
                ",[Violation_OverStruct]=" + Convert.ToString(Convert.ToByte(Violation_OverStructCheck.Checked)) +
                ",[Violation_OverHeight]=" + Convert.ToString(Convert.ToByte(Violation_OverHeight_Check.Checked)) +
                ",[Violation_NoRule]=" + Convert.ToString(Convert.ToByte(Violation_NoRuleCheck.Checked)) +
                ",[Violation_LackParking]=" + Convert.ToString(Convert.ToByte(Violation_LackParkingCheck.Checked)) +
                ",[Violation_NoSpace60]=" + Convert.ToString(Convert.ToByte(Violation_NoSpace60Check.Checked)) +
                ",[Violation_OverLayer]=" + Convert.ToString(Convert.ToByte(Violation_OverLayerCheck.Checked)) +
                ",[Violation_Conversion]=" + Convert.ToString(Convert.ToByte(Violation_ConversionCheck.Checked)) +
                ",[Violation_OverExcavation]=" + Convert.ToString(Convert.ToByte(Violation_OverExcavationCheck.Checked)) +
                ",[Violation_ChangeLight]=" + Convert.ToString(Convert.ToByte(Violation_ChangeLightCheck.Checked)) +
                ",[Violation_XchangeMap]=" + Convert.ToString(Convert.ToByte(Violation_XchangeMapCheck.Checked)) +
                ",[Violation_NoSpace62]=" + Convert.ToString(Convert.ToByte(Violation_NoSpace62Check.Checked)) +
                ",[Discour1]=" + Convert.ToString(Discour1Combo.SelectedIndex) +
                ",[Discour1_Date]= dbo.ShamsiToMiladi('" + Discour1_DateDate.Text + "')" +
                ",[Discour1_Step]=" + Convert.ToString(Discour1_StepCombo.SelectedIndex) +
                ",[Discour1_DirectDate]= dbo.ShamsiToMiladi('" + Discour1_DirectDatedate.Text + "')" +
                ",[Discour1_NoVioDate]= dbo.ShamsiToMiladi('" + Discour1_NoVioDatedate.Text + "')" +
                ",[Discour2]=" + Convert.ToString(Discour2Combo.SelectedIndex) +
                ",[Discour2_Date]= dbo.ShamsiToMiladi('" + Discour2_DateDate.Text + "')" +
                ",[Discour2_Step]=" + Convert.ToString(Discour2_StepCombo.SelectedIndex) +
                ",[Discour2_DirectDate]= dbo.ShamsiToMiladi('" + Discour2_DirectDatedate.Text + "')" +
                ",[Discour2_NoVioDate]= dbo.ShamsiToMiladi('" + Discour2_NoVioDatedate.Text + "')" +
                ",[Discour3]=" + Convert.ToString(Discour3Combo.SelectedIndex) +
                ",[Discour3_Date]= dbo.ShamsiToMiladi('" + Discour3_DateDate.Text + "')" +
                ",[Discour3_Step]=" + Convert.ToString(Discour3_StepCombo.SelectedIndex) +
                ",[Discour3_DirectDate]= dbo.ShamsiToMiladi('" + Discour3_DirectDatedate.Text + "')" +
                ",[Discour3_NoVioDate]= dbo.ShamsiToMiladi('" + Discour3_NoVioDatedate.Text + "')" +
                ",[Discour4]=" + Convert.ToString(Discour4Combo.SelectedIndex) +
                ",[Discour4_Date]= dbo.ShamsiToMiladi('" + Discour4_DateDate.Text + "')" +
                ",[Discour4_Step]=" + Convert.ToString(Discour4_StepCombo.SelectedIndex) +
                ",[Discour4_DirectDate]= dbo.ShamsiToMiladi('" + Discour4_DirectDatedate.Text + "')" +
                ",[Discour4_NoVioDate]= dbo.ShamsiToMiladi('" + Discour4_NoVioDatedate.Text + "')" +
                ",[Discour5]=" + Convert.ToString(Discour5Combo.SelectedIndex) +
                ",[Discour5_Date]= dbo.ShamsiToMiladi('" + Discour5_DateDate.Text + "')" +
                ",[Discour5_Step]=" + Discour5_StepCombo.SelectedIndex +
                ",[Discour5_DirectDate]= dbo.ShamsiToMiladi('" + Discour5_DirectDatedate.Text + "')" +
                ",[Discour5_NoVioDate]= dbo.ShamsiToMiladi('" + Discour5_NoVioDatedate.Text + "')" +
                ",[Final_Explain]= N'" + Final_ExplainMemo.Text + "'" +
                " Where ID = " + File_ID;
                
            SqCmd.ExecuteReader();
            SqConn.Close();
        }

        #region
        private void Crt_DateNewDate_Enter(object sender, EventArgs e)
        {
            if (Crt_DateNewDate.Text == "") Crt_DateNewDate.Text = File_DateDate.Text;
        }

        private void OprStart_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprStart_DateDate.Text == "") OprStart_DateDate.Text = Crt_DateNewDate.Text;            
        }

        private void VisitorStart_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorStart_DateDate.Text == "") VisitorStart_DateDate.Text = OprStart_DateDate.Text;            
        }

        private void EngineerStart_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerStart_DateDate.Text == "") EngineerStart_DateDate.Text = VisitorStart_DateDate.Text;            
        }

        private void OprExcavation_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprExcavation_DateDate.Text == "") OprExcavation_DateDate.Text = EngineerStart_DateDate.Text;            
        }

        private void VisitorExcavation_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorExcavation_DateDate.Text == "") VisitorExcavation_DateDate.Text = OprExcavation_DateDate.Text;            
        }

        private void EngineerExcavation_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerExcavation_DateDate.Text == "") EngineerExcavation_DateDate.Text = VisitorExcavation_DateDate.Text;            
        }

        private void OprFoundation_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprFoundation_DateDate.Text == "") OprFoundation_DateDate.Text = EngineerExcavation_DateDate.Text;            
        }

        private void VisitorFoundation_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorFoundation_DateDate.Text == "") VisitorFoundation_DateDate.Text = OprFoundation_DateDate.Text;            
        }

        private void EngineerFoundation_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerFoundation_DateDate.Text == "") EngineerFoundation_DateDate.Text = VisitorFoundation_DateDate.Text;            
        }

        private void OprRoof1_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprRoof1_DateDate.Text == "") OprRoof1_DateDate.Text = EngineerFoundation_DateDate.Text;            
        }

        private void VisitorRoof1_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorRoof1_DateDate.Text == "") VisitorRoof1_DateDate.Text = OprRoof1_DateDate.Text;            
        }

        private void EngineerRoof1_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerRoof1_DateDate.Text == "") EngineerRoof1_DateDate.Text = VisitorRoof1_DateDate.Text;            
        }

        private void OprRoof3_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprRoof3_DateDate.Text == "") OprRoof3_DateDate.Text = EngineerRoof1_DateDate.Text;            
        }

        private void VisitorRoof3_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorRoof3_DateDate.Text == "") VisitorRoof3_DateDate.Text = OprRoof3_DateDate.Text;            
        }

        private void EngineerRoof3_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerRoof3_DateDate.Text == "") EngineerRoof3_DateDate.Text = VisitorRoof3_DateDate.Text;            
        }

        private void OprRoofFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprRoofFinal_DateDate.Text == "") OprRoofFinal_DateDate.Text = EngineerRoof3_DateDate.Text;            
        }

        private void VisitorRoofFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorRoofFinal_DateDate.Text == "") VisitorRoofFinal_DateDate.Text = OprRoofFinal_DateDate.Text;            
        }

        private void EngineerRoofFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerRoofFinal_DateDate.Text == "") EngineerRoofFinal_DateDate.Text = VisitorRoofFinal_DateDate.Text;            
        }

        private void OprHard_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprHard_DateDate.Text == "") OprHard_DateDate.Text = EngineerRoofFinal_DateDate.Text;            
        }

        private void VisitorHard_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorHard_DateDate.Text == "") VisitorHard_DateDate.Text = OprHard_DateDate.Text;            
        }

        private void EngineerHard_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerHard_DateDate.Text == "") EngineerHard_DateDate.Text = VisitorHard_DateDate.Text;            
        }

        private void OprThin_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprThin_DateDate.Text == "") OprThin_DateDate.Text = EngineerHard_DateDate.Text;            
        }

        private void VisitorThin_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorThin_DateDate.Text == "") VisitorThin_DateDate.Text = OprThin_DateDate.Text;            
        }

        private void EngineerThin_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerThin_DateDate.Text == "") EngineerThin_DateDate.Text = VisitorThin_DateDate.Text;            
        }

        private void OprFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (OprFinal_DateDate.Text == "") OprFinal_DateDate.Text = EngineerThin_DateDate.Text;            
        }

        private void VisitorFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (VisitorFinal_DateDate.Text == "") VisitorFinal_DateDate.Text = OprFinal_DateDate.Text;            
        }

        private void EngineerFinal_DateDate_Enter(object sender, EventArgs e)
        {
            if (EngineerFinal_DateDate.Text == "") EngineerFinal_DateDate.Text = VisitorFinal_DateDate.Text;            
        }

        private void Discour1_DateDate_Enter(object sender, EventArgs e)
        {
            if (Discour1_DateDate.Text == "") Discour1_DateDate.Text = Crt_DateNewDate.Text;            
        }

        private void Discour1_DirectDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour1_DirectDatedate.Text == "") Discour1_DirectDatedate.Text = Discour1_DateDate.Text;            
        }

        private void Discour1_NoVioDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour1_NoVioDatedate.Text == "") Discour1_NoVioDatedate.Text = Discour1_DirectDatedate.Text;            
        }

        private void Discour2_DateDate_Enter(object sender, EventArgs e)
        {
            if (Discour2_DateDate.Text == "") Discour2_DateDate.Text = Discour1_DateDate.Text;            
        }

        private void Discour2_DirectDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour2_DirectDatedate.Text == "") Discour2_DirectDatedate.Text = Discour2_DateDate.Text;            
        }

        private void Discour2_NoVioDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour2_NoVioDatedate.Text == "") Discour2_NoVioDatedate.Text = Discour2_DirectDatedate.Text;            
        }

        private void Discour3_DateDate_Enter(object sender, EventArgs e)
        {
            if (Discour3_DateDate.Text == "") Discour3_DateDate.Text = Discour2_DateDate.Text;            
        }

        private void Discour3_DirectDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour3_DirectDatedate.Text == "") Discour3_DirectDatedate.Text = Discour3_DateDate.Text;            
        }

        private void Discour3_NoVioDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour3_NoVioDatedate.Text == "") Discour3_NoVioDatedate.Text = Discour3_DirectDatedate.Text;            
        }

        private void Discour4_DateDate_Enter(object sender, EventArgs e)
        {
            if (Discour4_DateDate.Text == "") Discour4_DateDate.Text = Discour3_DateDate.Text;            
        }

        private void Discour4_DirectDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour4_DirectDatedate.Text == "") Discour4_DirectDatedate.Text = Discour4_DateDate.Text; 
        }

        private void Discour4_NoVioDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour4_NoVioDatedate.Text == "") Discour4_NoVioDatedate.Text = Discour4_DirectDatedate.Text; 
        }

        private void Discour5_DateDate_Enter(object sender, EventArgs e)
        {
            if (Discour5_DateDate.Text == "") Discour5_DateDate.Text = Discour4_DateDate.Text; 
        }

        private void Discour5_DirectDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour5_DirectDatedate.Text == "") Discour5_DirectDatedate.Text = Discour5_DateDate.Text; 
        }

        private void Discour5_NoVioDatedate_Enter(object sender, EventArgs e)
        {
            if (Discour5_NoVioDatedate.Text == "") Discour5_NoVioDatedate.Text = Discour5_DirectDatedate.Text;
        }
        #endregion Set Date

        ComboBoxEdit CBE = new ComboBoxEdit();
        private void File_PaperCombo_KeyDown(object sender, KeyEventArgs e)
        {
            CBE = (ComboBoxEdit)sender;
            if ((e.KeyValue == Convert.ToInt32( Keys.Delete)))
                CBE.SelectedIndex = -1;
        }

        private void Area_ProoftextEdit_Leave(object sender, EventArgs e)
        {
            Area_CorrecttextEdit.Text = Area_ProoftextEdit.Text;
            Area_ExisttextEdit.Text = Area_ProoftextEdit.Text;
        }

    }
}