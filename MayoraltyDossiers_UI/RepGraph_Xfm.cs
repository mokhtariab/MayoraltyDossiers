using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using DevExpress.XtraCharts.Wizard;
using System.Data.SqlClient;

namespace MayoraltyDossiers_UI
{
    public partial class RepGraph_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public RepGraph_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqlCmd = new SqlCommand();

        private void UserChange_Xfrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, false);

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Rep_BuildStep rbs = new Rep_BuildStep();
            //rbs.xrChart1.Series[0].DataSource=;
            //rbs.xrChart1.Series[0].ArgumentDataMember =;
            DevExpress.XtraCharts.Wizard.ChartWizard b = new ChartWizard(rbs.xrChart1);
            b.ShowDialog();
            try
            {
                rbs.ShowPreviewDialog();
            }
            catch { }
            /*SqlCmd.CommandText = " select stepuse,count(stepuse)countstep "+
                                 " from dbo.GridCertificate_Vw  group by stepuse";
                                 
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataAdapter DAdapter = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            DAdapter.SelectCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            DataTable DtTbl = new DataTable();
            try
            {
                DAdapter.Fill(DtTbl);
                            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();*/
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Rep_DiscureStep rds = new Rep_DiscureStep();
            DevExpress.XtraCharts.Wizard.ChartWizard b = new ChartWizard(rds.xrChart1);
            b.ShowDialog();
            rds.ShowPreviewDialog();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Rep_DiscureUse rdu = new Rep_DiscureUse();
            DevExpress.XtraCharts.Wizard.ChartWizard b = new ChartWizard(rdu.xrChart1);
            b.ShowDialog();
            rdu.ShowPreviewDialog();
        }


    }
}