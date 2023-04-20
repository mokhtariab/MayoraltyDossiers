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
    public partial class UserList_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public UserList_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqlCmd = new SqlCommand();

        private void UserList_Xfm_Load(object sender, EventArgs e)
        {
            SetGridViewUser();
        }

        private void SetGridViewUser()
        {
            //SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");

            //SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlConn;

            SqlCmd.CommandText = " SELECT [UserID],[Name],[Family],[Username],[Password],"+
                                 "dbo.MiladiToShamsi(CreateDate) as CreateDate,[Permission_User]"+
                                 " FROM [Mayoralty_Files].[dbo].[tbl_Users] ";
            SqlCmd.CommandType = CommandType.Text;
            
            SqlConn.Open();

            SqlDataAdapter DAdapter = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
            DAdapter.SelectCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

            DataTable DtTbl = new DataTable();
            try
            {
                DAdapter.Fill(DtTbl);
                gridControl_Users.DataSource = DtTbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UserChange_Xfm UCXF = new UserChange_Xfm();
            UCXF.UserID = gridView1.FocusedRowHandle;
            UCXF.UseFormInInsertOrEditMode(1);
            SetGridViewUser();  
            gridView1.FocusedRowHandle = UCXF.UserID; 
        }

        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Func_EditUser();
        }

        private void gridControl_Users_DoubleClick(object sender, EventArgs e)
        {
            Func_EditUser();
        }
        
        private void Func_EditUser()
        {
            int Index = gridView1.FocusedRowHandle;
            DataRow row1 = gridView1.GetDataRow(Index);
            if (row1 == null) return;

            UserChange_Xfm UCXF = new UserChange_Xfm();

            UCXF.textEdit_Name.Text = Convert.ToString(row1["Name"]);
            UCXF.textEdit_Family.Text = Convert.ToString(row1["Family"]);
            UCXF.textEdit_UserName.Text = Convert.ToString(row1["UserName"]);
            UCXF.UserID = Convert.ToInt32(row1["UserID"]);

            UCXF.UseFormInInsertOrEditMode(2);

            SetGridViewUser();
            gridView1.FocusedRowHandle = Index; 
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Index = gridView1.FocusedRowHandle;
            DataRow row1 = gridView1.GetDataRow(Index);

//            SqlConnection SqlConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");

  //          SqlCommand SqlCmd = new SqlCommand();
            SqlCmd.Connection = SqlConn;

            SqlCmd.CommandText =
                "SELECT IsNull(Permission_User,'') FROM [Mayoralty_Files].[dbo].[tbl_Users] WHERE UserID = " + Convert.ToString(row1[0]);
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();

            SqlDataReader SDR = SqlCmd.ExecuteReader();
            SDR.Read();
            if (Convert.ToString(SDR[0]) == "Admin")
                MessageBox.Show("«„ò«‰ Õ–› ò«—»— «’·Ì ÊÃÊœ ‰œ«—œ!");
                //GlobalProc.MessageBehin("«„ò«‰ Õ–› ò«—»— «’·Ì ÊÃÊœ ‰œ«—œ!", 2, false, false); //Add Mokhtari 87/04/17
            else
            {
                SqlConn.Close();
                if (MessageBox.Show("¬Ì« »Â Õ–› ò—œ‰ «Ì‰ ò«—»— „ÿ„∆‰Ìœø", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
                //if (GlobalProc.MessageBehin("¬Ì« »Â Õ–› ò—œ‰ «Ì‰ ò«—»— „ÿ„∆‰Ìœø", 2, true, false)) //Add Mokhtari 87/04/17
                {
                    SqlCmd.CommandText =
                        "DELETE FROM [Mayoralty_Files].[dbo].[tbl_Users] WHERE (IsNull(Permission_User,'') <> 'Admin')And(UserID = " + Convert.ToString(row1[0]) + ")";
                    SqlCmd.CommandType = CommandType.Text;
                    SqlCmd.Connection = SqlConn;

                    SqlDataAdapter SDA = new SqlDataAdapter(SqlCmd.CommandText, SqlConn);
                    SDA.UpdateCommand = new SqlCommand(SqlCmd.CommandText, SqlConn);

                    SqlConn.Open();

                    try
                    {
                        SDA.UpdateCommand.ExecuteReader();
                        MessageBox.Show("ò«—»— „Ê—œ ‰Ÿ— Õ–› ‘œ");
                        //GlobalProc.MessageBehin("ò«—»— „Ê—œ ‰Ÿ— Õ–› ‘œ", 3, false, false); //Add Mokhtari 87/04/17
                        Index--; 
                    }
                    catch (SqlException sqlError)
                    {
                        MessageBox.Show(Convert.ToString(sqlError));
                    }
                }
            }
            SDR.Close();
            SqlConn.Close();

            SetGridViewUser();  
            gridView1.FocusedRowHandle = Index;
        }

        private void barBtnItem_AccessUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int Index = gridView1.FocusedRowHandle;
            DataRow row1 = gridView1.GetDataRow(Index);

            UserPermission_Xfm UPXF = new UserPermission_Xfm();
            UPXF.UserPermission_LoadDataAndForm(Convert.ToInt32(row1[0]));
            SetGridViewUser();  
            gridView1.FocusedRowHandle = Index; 
        }

    }
}