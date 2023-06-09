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
    public partial class RepAllItem_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public RepAllItem_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqlCmd = new SqlCommand();
        private string WhereSql = "";
        private string OrderStr = "";
        private void SetWhereSQL_OK()
        {
            WhereSql = "";
            OrderStr = "   Order By Operator_Code,Main_Street,Side_Street,Main_Alley,Side_Alley,House_No";
            if (xtraTabControl2.SelectedTabPage == TabPage_OR)
            {
                if (FileNo_Radio.Checked) WhereSql = " Where (File_No Like '%" + file_NoTextEdit.Text + "%') ";
                if (FileCode_Radio.Checked) WhereSql = " Where (File_Code Like '%" + file_CodeTextEdit.Text + "%') ";
                if (Opr_Radio.Checked)
                {
                    WhereSql = "";
                    if (A_Check.Checked) WhereSql = " (Operator_Code = 0) Or";
                    if (B_Check.Checked) WhereSql += " (Operator_Code = 1) Or";
                    if (C_Check.Checked) WhereSql += " (Operator_Code = 2) Or";
                    if (D_Check.Checked) WhereSql += " (Operator_Code = 3) Or";
                    if (E_Check.Checked) WhereSql += " (Operator_Code = 4) Or";
                    if (WhereSql != "") WhereSql = " Where (" + WhereSql + " (1<>1) )";
                }
                if (Discure_Radio.Checked)
                {
                    string WhereSql1 = "";
                    if (Section_Check.Checked) WhereSql1 = " (DiscourUse = 0) Or";
                    if (Citycon_Check.Checked) WhereSql1 += " (DiscourUse = 1) Or";
                    if (Viewer_Check.Checked) WhereSql1 += " (DiscourUse = 2) Or";
                    if (Money_Check.Checked) WhereSql1 += " (DiscourUse = 3) Or";
                    if (WhereSql1 != "") WhereSql1 = " (" + WhereSql1 + " (1<>1) )";

                    WhereSql = "";
                    if (Violation_CutTreeCheck.Checked) WhereSql += " (Violation_CutTree = 1) And";
                    if (Violation_OverStructCheck.Checked) WhereSql += " (Violation_OverStruct = 1) And";
                    if (Violation_OverHeight_Check.Checked) WhereSql += " (Violation_OverHeight = 1) And";
                    if (Violation_NoRuleCheck.Checked) WhereSql += " (Violation_NoRule = 1) And";
                    if (Violation_LackParkingCheck.Checked) WhereSql += " (Violation_LackParking = 1) And";
                    if (Violation_NoSpace60Check.Checked) WhereSql += " (Violation_NoSpace60 = 1) And";
                    if (Violation_OverLayerCheck.Checked) WhereSql += " (Violation_OverLayer = 1) And";
                    if (Violation_ConversionCheck.Checked) WhereSql += " (Violation_Conversion = 1) And";
                    if (Violation_OverExcavationCheck.Checked) WhereSql += " (Violation_OverExcavation = 1) And";
                    if (Violation_ChangeLightCheck.Checked) WhereSql += " (Violation_ChangeLight = 1) And";
                    if (Violation_XchangeMapCheck.Checked) WhereSql += " (Violation_XchangeMap = 1) And";
                    if (Violation_NoSpace62Check.Checked) WhereSql += " (Violation_NoSpace62 = 1) And";

                    if ((WhereSql != "") & (WhereSql1 != "")) WhereSql = " Where " + WhereSql1 + " And (" + WhereSql + " (1=1) )";
                    if ((WhereSql == "") & (WhereSql1 != "")) WhereSql = " Where " + WhereSql1;
                    if ((WhereSql != "") & (WhereSql1 == "")) WhereSql = " Where (" + WhereSql + " (1=1) )";
                }

                if (DelayRep_Radio.Checked)
                {
                    WhereSql = " where ( DateStepUse_Engineer > 0) ";
                    if (Differ_check.Checked) WhereSql = " where (DateStepUse > " + Differ_spinEdit.Value + ")";
                    OrderStr = "   Order By DateStepUse_Engineer DESC ";
                } 
            }



            if (xtraTabControl2.SelectedTabPage == TabPage_AND)
            {

                if (Opr_Check.Checked) WhereSql += " (Operator_Code = " + Operator_CodeCombo.SelectedIndex + ") And ";
                if (FilePaper_Check.Checked) WhereSql += " (File_Paper = " + FilePaper_Combo.SelectedIndex + ") And ";
                if (AreaCorrectOK_Check.Checked) WhereSql += " (Area_CorrectExist = " + Area_CorrectExistcombo.SelectedIndex + ") And ";
                if (StepUse_check.Checked) WhereSql += " (StepUse = " + StepUse_combo.SelectedIndex + ") And ";

                if (MStreet_Check.Checked) WhereSql += " (Main_Street Like N'%" + Main_StreettextEdit.Text + "%') And ";
                if (SStreet_Check.Checked) WhereSql += " (Side_Street Like N'%" + Side_StreettextEdit.Text + "%') And ";
                if (MAlley_Check.Checked) WhereSql += " (Main_Alley Like N'%" + Main_AlleytextEdit.Text + "%') And ";
                if (SAlley_Check.Checked) WhereSql += " (Side_Alley Like N'%" + Side_AlleytextEdit.Text + "%') And ";
                if (HouseNO_Check.Checked) WhereSql += " (House_No Like N'%" + House_NotextEdit.Text + "%') And ";

                if ((DiscourUse_check.Checked) & (radioButton1.Checked)) WhereSql += " (DiscourUse in (0,1,2,3)) And ";
                if ((DiscourUse_check.Checked) & (radioButton2.Checked)) WhereSql += " (DiscourUse = " + DiscourUse_Combo.SelectedIndex + ") And ";
                if (DiscureStepUse_check.Checked) WhereSql += " (DiscourUse_Step = " + DiscureStepUse_Combo.SelectedIndex + ") And ";
                
                if (WhereSql != "") WhereSql = " Where " + WhereSql + " (1=1) ";
            }
        }


        #region
        private void FileNo_Radio_CheckedChanged(object sender, EventArgs e)
        {
            file_NoTextEdit.Enabled = FileNo_Radio.Checked;
        }

        private void FileCode_Radio_CheckedChanged(object sender, EventArgs e)
        {
            file_CodeTextEdit.Enabled = FileCode_Radio.Checked;
        }

        private void Opr_Radio_CheckedChanged(object sender, EventArgs e)
        {
            Opr_groupBox.Enabled = Opr_Radio.Checked;
        }

        private void Discure_Radio_CheckedChanged(object sender, EventArgs e)
        {
            Discure_groupBox.Enabled = Discure_Radio.Checked;
            Violation_groupBox.Enabled = Discure_Radio.Checked;
        }

        private void DelayRep_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            Delay_groupBox.Enabled = DelayRep_Radio.Checked;
        }

        private void FilePaper_Check_CheckedChanged(object sender, EventArgs e)
        {
            FilePaper_Combo.Enabled = FilePaper_Check.Checked;
        }

        private void Opr_Check_CheckedChanged(object sender, EventArgs e)
        {
            Operator_CodeCombo.Enabled = Opr_Check.Checked;
        }

        private void AreaCorrectOK_Check_CheckedChanged(object sender, EventArgs e)
        {
            Area_CorrectExistcombo.Enabled = AreaCorrectOK_Check.Checked;
        }

        private void MStreet_Check_CheckedChanged(object sender, EventArgs e)
        {
            Main_StreettextEdit.Enabled = MStreet_Check.Checked;
        }

        private void SStreet_Check_CheckedChanged(object sender, EventArgs e)
        {
            Side_StreettextEdit.Enabled = SStreet_Check.Checked;
        }

        private void MAlley_Check_CheckedChanged(object sender, EventArgs e)
        {
            Main_AlleytextEdit.Enabled = MAlley_Check.Checked;
        }

        private void SAlley_Check_CheckedChanged(object sender, EventArgs e)
        {
            Side_AlleytextEdit.Enabled = SAlley_Check.Checked;
        }

        private void HouseNO_Check_CheckedChanged(object sender, EventArgs e)
        {
            House_NotextEdit.Enabled = HouseNO_Check.Checked;
        }


        private void DiscourUse_check_CheckedChanged(object sender, EventArgs e)
        {
            panelControl2.Enabled = DiscourUse_check.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            DiscourUse_Combo.Enabled = radioButton2.Checked;
        }

        #endregion


        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetWhereSQL_OK();

//            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            //SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandText = " SELECT * FROM [dbo].[GridCertificate_Vw] " + WhereSql + OrderStr;
                                 
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataAdapter DAdapter = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            DAdapter.SelectCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            DataTable DtTbl = new DataTable();
            try
            {
                DAdapter.Fill(DtTbl);
                Rep_AllItemFile RAIF = new Rep_AllItemFile();
                RAIF.DataSource = DtTbl;
                RAIF.ShowPreviewDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        DateEdit de = new DateEdit();
        private void Crt_DateNew1Date_Leave(object sender, EventArgs e)
        {
            de = (DateEdit)sender;
            if (de.Text == "") return;

            int y = de.DateTime.Year;
            int m = de.DateTime.Month;
            int d = de.DateTime.Day;

            if (((y < 1300) | (y > 1420)) |
                ((y % 4 != 3) & (m == 12) & (d == 30)) | ((m >= 7) & (d == 31)))
                de.Focus();

        }

        private void SearchFile_Xfm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, false);

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();

        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetWhereSQL_OK();

//            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            //SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.CommandText = " SELECT * FROM [dbo].[GridCertificate_Vw] " + WhereSql + OrderStr;
                                 
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataAdapter DAdapter = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            DAdapter.SelectCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            DataTable DtTbl = new DataTable();
            try
            {
                DAdapter.Fill(DtTbl);
                gridControl_REp.DataSource = DtTbl;
                SetColumn_InGrid();
                gridControl_REp.ShowPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

        private void SetColumn_InGrid()
        {
            gridView1.Columns.ColumnByFieldName("File_Code").Visible = (FileCode_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("File_Date").Visible = (FileDate_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("File_No").Visible = (FileNo_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("File_StatusD").Visible = (FileStatus_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("File_PaperD").Visible = (FilePaper_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Crt_TypeD").Visible = (CrtType_Checked.Checked);

            gridView1.Columns.ColumnByFieldName("Crt_DateNew").Visible = (CrtDateNew_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Crt_ValidTime").Visible = (CrtValidTime_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Operator_CodeD").Visible = (Opr_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Person_FName").Visible = (FName_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Person_LName").Visible = (LName_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Main_Street").Visible = (Mstreet_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Side_Street").Visible = (SStreet_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Main_Alley").Visible = (MAlley_Checked.Checked);

            gridView1.Columns.ColumnByFieldName("Side_Alley").Visible = (SAlley_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("House_No").Visible = (Plak_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Use_EarthD").Visible = (UseEarth_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Register_Plak").Visible = (RegPlak_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Parking_DomainD").Visible = (Parking_Checked.Checked);

            gridView1.Columns.ColumnByFieldName("Closed_Space").Visible = (ClosedSpace_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Use_Space").Visible = (UseSpace_Checked.Checked);
            gridView1.Columns.ColumnByFieldName("Struct_TypeD").Visible = (Struct_Checked.Checked);

        }

        ComboBoxEdit CBE = new ComboBoxEdit();
        private void FilePaper_Combo_KeyDown(object sender, KeyEventArgs e)
        {
            CBE = (ComboBoxEdit)sender;
            if ((e.KeyValue == Convert.ToInt32( Keys.Delete)))
                CBE.SelectedIndex = -1;
        }

        private void DiscureStepUse_check_CheckedChanged(object sender, EventArgs e)
        {
            DiscureStepUse_Combo.Enabled = DiscureStepUse_check.Checked;
        }

        private void StepUse_check_CheckedChanged(object sender, EventArgs e)
        {
            StepUse_combo.Enabled = StepUse_check.Checked;
        }

    }

}