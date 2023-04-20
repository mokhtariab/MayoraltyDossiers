using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace MayoraltyDossiers_UI
{
    public partial class SearchFile_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public SearchFile_Xfm()
        {
            InitializeComponent();
        }

        public string StrSql = "";

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SetStrSQL();
            this.Close();
        }

        private void SetStrSQL()
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                if (FileNo_Radio.Checked) StrSql = " Where (File_No Like '%" + file_NoTextEdit.Text + "%') ";
                if (FileCode_Radio.Checked) StrSql = " Where (File_Code Like '%" + file_CodeTextEdit.Text + "%') ";
                if (Opr_Radio.Checked)
                {
                    StrSql = "";
                    if (A_Check.Checked) StrSql = " (Operator_Code = 0) Or";
                    if (B_Check.Checked) StrSql += " (Operator_Code = 1) Or";
                    if (C_Check.Checked) StrSql += " (Operator_Code = 2) Or";
                    if (D_Check.Checked) StrSql += " (Operator_Code = 3) Or";
                    if (E_Check.Checked) StrSql += " (Operator_Code = 4) Or";
                    if (StrSql != "") StrSql = " Where (" + StrSql + " (1<>1) )";
                }
                if (Discure_Radio.Checked)
                {

                    string StrSql1 = "";
                    if (Section_Check.Checked) StrSql1 = " (DiscourUse = 0) Or";
                    if (Citycon_Check.Checked) StrSql1 += " (DiscourUse = 1) Or";
                    if (Viewer_Check.Checked) StrSql1 += " (DiscourUse = 2) Or";
                    if (Money_Check.Checked) StrSql1 += " (DiscourUse = 3) Or";
                    if (StrSql1 != "") StrSql1 = " (" + StrSql1 + " (1<>1) )";

                    StrSql = "";
                    if (Violation_CutTreeCheck.Checked) StrSql += " (Violation_CutTree = 1) And";
                    if (Violation_OverStructCheck.Checked) StrSql += " (Violation_OverStruct = 1) And";
                    if (Violation_OverHeight_Check.Checked) StrSql += " (Violation_OverHeight = 1) And";
                    if (Violation_NoRuleCheck.Checked) StrSql += " (Violation_NoRule = 1) And";
                    if (Violation_LackParkingCheck.Checked) StrSql += " (Violation_LackParking = 1) And";
                    if (Violation_NoSpace60Check.Checked) StrSql += " (Violation_NoSpace60 = 1) And";
                    if (Violation_OverLayerCheck.Checked) StrSql += " (Violation_OverLayer = 1) And";
                    if (Violation_ConversionCheck.Checked) StrSql += " (Violation_Conversion = 1) And";
                    if (Violation_OverExcavationCheck.Checked) StrSql += " (Violation_OverExcavation = 1) And";
                    if (Violation_ChangeLightCheck.Checked) StrSql += " (Violation_ChangeLight = 1) And";
                    if (Violation_XchangeMapCheck.Checked) StrSql += " (Violation_XchangeMap = 1) And";
                    if (Violation_NoSpace62Check.Checked) StrSql += " (Violation_NoSpace62 = 1) And";

                    if ((StrSql != "") & (StrSql1 != "")) StrSql = " Where " + StrSql1 + " And (" + StrSql + " (1=1) )";
                    if ((StrSql == "") & (StrSql1 != "")) StrSql = " Where " + StrSql1;
                    if ((StrSql != "") & (StrSql1 == "")) StrSql = " Where (" + StrSql + " (1=1) )";
                }
                
                if (DelayRep_Radio.Checked)
                {
                    StrSql = " where (DateStepUse_Engineer > 0) ";
                    if (Differ_check.Checked) StrSql = " where (DateStepUse > " + Differ_spinEdit.Value + ")";
                }
            }



            if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
            {

                if (Opr_Check.Checked) StrSql += " (Operator_Code = " + Operator_CodeCombo.SelectedIndex + ") And ";
                if (FilePaper_Check.Checked) StrSql += " (File_Paper = " + FilePaper_Combo.SelectedIndex + ") And ";
                if (AreaCorrectOK_Check.Checked) StrSql += " (Area_CorrectExist = " + Area_CorrectExistcombo.SelectedIndex + ") And ";
                if (StepUse_check.Checked) StrSql += " (StepUse = " + StepUse_combo.SelectedIndex + ") And ";

                if (MStreet_Check.Checked) StrSql += " (Main_Street Like N'%" + Main_StreettextEdit.Text + "%') And ";
                if (SStreet_Check.Checked) StrSql += " (Side_Street Like N'%" + Side_StreettextEdit.Text + "%') And ";
                if (MAlley_Check.Checked) StrSql += " (Main_Alley Like N'%" + Main_AlleytextEdit.Text + "%') And ";
                if (SAlley_Check.Checked) StrSql += " (Side_Alley Like N'%" + Side_AlleytextEdit.Text + "%') And ";
                if (HouseNO_Check.Checked) StrSql += " (House_No Like N'%" + House_NotextEdit.Text + "%') And ";

                if ((DiscourUse_check.Checked) & (radioButton1.Checked)) StrSql += " (DiscourUse in (0,1,2,3)) And ";
                if ((DiscourUse_check.Checked) & (radioButton2.Checked)) StrSql += " (DiscourUse = " + DiscourUse_Combo.SelectedIndex + ") And ";
                if (DiscureStepUse_check.Checked) StrSql += " (DiscourUse_Step = " + DiscureStepUse_Combo.SelectedIndex + ") And ";

                if (StrSql != "") StrSql = " Where " + StrSql + " (1=1) ";
            }
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

        private void DiscureStepUse_check_CheckedChanged(object sender, EventArgs e)
        {
            DiscureStepUse_Combo.Enabled = DiscureStepUse_check.Checked;
        }

        private void StepUse_check_CheckedChanged(object sender, EventArgs e)
        {
            StepUse_combo.Enabled = StepUse_check.Checked;
        }

#endregion

        ComboBoxEdit CBE = new ComboBoxEdit();
        private void FilePaper_Combo_KeyDown(object sender, KeyEventArgs e)
        {
            CBE = (ComboBoxEdit)sender;
            if ((e.KeyValue == Convert.ToInt32( Keys.Delete)))
                CBE.SelectedIndex = -1;
        }

    }
}