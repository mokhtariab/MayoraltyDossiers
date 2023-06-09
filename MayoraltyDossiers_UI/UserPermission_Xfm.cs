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
    public partial class UserPermission_Xfm: DevExpress.XtraEditors.XtraForm
    {
        public UserPermission_Xfm()
        {
            InitializeComponent();
        }

        public int UserIDIndex;
        public SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        public SqlCommand SqlCmd = new SqlCommand();
        public string PerUser;
        
        public void UserPermission_LoadDataAndForm(int EnterId)
        {
            UserIDIndex = EnterId;

            SqlCmd.CommandText = "Select Permission_User From [Mayoralty_Files].[dbo].[tbl_Users] WHERE UserID = " + Convert.ToString(UserIDIndex);
            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection  = SqlConn;

            SqlConn.Open();
            try
            {
                SqlDataReader SDR = SqlCmd.ExecuteReader();
                SDR.Read();
                PerUser = Convert.ToString(SDR[0]);
            }catch 
            { 
            }
            SqlConn.Close();

            if (PerUser == "Admin")
            {
                MessageBox.Show("امکان تغيير در سطح دسترسي کاربر اصلي وجود ندارد!","",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                //GlobalProc.MessageBehin("امکان تغيير در سطح دسترسي کاربر اصلي وجود ندارد!", 3, false, true); 
                return;
            }

            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                checkedListBoxControl1.Items[i].CheckState = CheckState.Checked;

            string M = "";
            for (int i=0; i <= PerUser.Length-1; i++)
            {
                if (PerUser[i].Equals(Convert.ToChar(",")))
                {
                    checkedListBoxControl1.Items[Convert.ToInt32(M)].CheckState = CheckState.Unchecked;
                    M = "";
                }
                else
                {
                    M += PerUser[i];
                }
            }
            ShowDialog();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
        }

        private void UserChange_Xfrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, false);
            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }


        private void barLargeButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                checkedListBoxControl1.Items[i].CheckState = CheckState.Checked;
        }

        private void barLargeButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                checkedListBoxControl1.Items[i].CheckState = CheckState.Unchecked;
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string StrUnCHK = "";
            for (int i = 0; i < checkedListBoxControl1.ItemCount; i++)
                if (checkedListBoxControl1.Items[i].CheckState == CheckState.Unchecked)
                    StrUnCHK += Convert.ToString(i) + ",";

            ////////////////////
            SqlCmd.CommandText = " UPDATE [Mayoralty_Files].[dbo].[tbl_Users] " +
                                 "      SET [Permission_User] = '" + StrUnCHK + "'" +
                                 "  WHERE UserID = " + Convert.ToString(UserIDIndex);

            SqlCmd.CommandType = CommandType.Text;
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();
            try
            {
                SqlCmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Convert.ToString(ex));
            }
            SqlConn.Close();

            //////////////////////

            Close();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

     }
}