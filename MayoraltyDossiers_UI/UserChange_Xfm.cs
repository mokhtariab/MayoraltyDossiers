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
    public partial class UserChange_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public UserChange_Xfm()
        {
            InitializeComponent();
        }

        private SqlConnection SqConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqCmd = new SqlCommand();

        public int InsOrEdt;
        public int UserID;
        private string User_Name;
        public void UseFormInInsertOrEditMode(int InsertOrEdit)
        {
            if (InsertOrEdit == 1)
            {
                InsOrEdt = 1;
                labelControl6.Visible = false;
                textEdit_PrePass.Visible = false;
                this.ShowDialog();
            }

            if (InsertOrEdit == 2)
            {
                InsOrEdt = 2;
                User_Name = textEdit_UserName.Text;
                this.ShowDialog();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
        }

        private bool InsertUser()
        {
            //string StrConn = Globals.ConnectionString;

//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqConn.Open();

  //          SqlCommand SqCmd = new SqlCommand();
            SqCmd.Connection = SqConn;

            //Search For Username's Duplex
            SqCmd.CommandText = " SELECT Username FROM [Mayoralty_Files].[dbo].[tbl_Users] where Username = N'" + textEdit_UserName.Text + "' ";
            SqlDataReader SDRA = SqCmd.ExecuteReader();
            SDRA.Read();
            try
            {
                if (Convert.ToString( SDRA[0] ) != "") 
                {
                    SDRA.Close();
                    SqCmd.Clone();
                    SqConn.Close();
                    return false;
                }
            }
            catch
            {
                SDRA.Close();
                SqCmd.Clone();
            }


            //Insert In Users Table
            SqCmd.CommandText = " INSERT INTO [Mayoralty_Files].[dbo].[tbl_Users] (" +
                                "[Name],[Family],[Username],[Password],[CreateDate])" +
                                " VALUES (N'" + textEdit_Name.Text +
                                "', N'" + textEdit_Family.Text +
                                "', N'" + textEdit_UserName.Text + "', N'" + textEdit_REEnterPass.Text +
                                "','" + DateTime.Now.ToShortDateString() + "') ";

            SqCmd.ExecuteReader();

            SqConn.Close();
            return true;
        }


        private int EditUser()
        {
            //string StrConn = Globals.ConnectionString;

//            SqlConnection SqConn = new SqlConnection(@"Data Source=B2\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True");
            SqConn.Open();

            //Check PrePassword Entry
            SqlCommand PassCmd = new SqlCommand();
            PassCmd.Connection = SqConn;
            PassCmd.CommandText = " select [Password] from [Mayoralty_Files].[dbo].[tbl_Users] where UserID = " + Convert.ToString(UserID);

            SqlDataReader SDR = PassCmd.ExecuteReader();
            SDR.Read();
            if (textEdit_PrePass.Text != Convert.ToString(SDR[0]).Trim()) {  return 0; }
            SDR.Close();


            //Search For Username's Duplex
            if (textEdit_UserName.Text != User_Name)
            {
                SqlCommand UserNCmd = new SqlCommand();
                UserNCmd.Connection = SqConn;

                UserNCmd.CommandText = " SELECT Username FROM [Mayoralty_Files].[dbo].[tbl_Users] where Username = N'" + textEdit_UserName.Text + "'";
                SqlDataReader SDRA = UserNCmd.ExecuteReader();
                SDRA.Read();
                try
                {
                    if (Convert.ToString(SDRA[0]) != "")
                    {
                        SDRA.Close();
                        SqConn.Close();
                        return 1;
                    }
                }
                catch
                {
                    SDRA.Close();
                }
            }


            //Insert In Users Table
            SqlCommand UpdateCmd = new SqlCommand();
            UpdateCmd.Connection = SqConn;

            UpdateCmd.CommandText = " UPDATE [Mayoralty_Files].[dbo].[tbl_Users]" +
                                    " SET [Name] = N'"+textEdit_Name.Text+"',[Family]=N'" + textEdit_Family.Text +
                                    "',[Username]=N'" + textEdit_UserName.Text + "',[Password]=N'" + textEdit_REEnterPass.Text +
                                    "' " +
                                    " WHERE UserID = " + Convert.ToString(UserID);
            
            UpdateCmd.ExecuteReader();

            SqConn.Close();
            return 2;
        }

        private void UserChange_Xfrm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, false);

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void barLargeButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (textEdit_Name.Text == "")
            {
                MessageBox.Show("نام را وارد نماييد");
                //GlobalProc.MessageBehin("نام را وارد نماييد", 3, false, false); 
                textEdit_Name.Focus();
                return;
            }
            if (textEdit_Family.Text == "")
            {
                MessageBox.Show("نام خانوادگي را وارد نماييد");
                //GlobalProc.MessageBehin("نام خانوادگي را وارد نماييد", 3, false, false); 
                textEdit_Family.Focus();
                return;
            }
            if (textEdit_UserName.Text == "")
            {
                MessageBox.Show("نام کاربري را وارد نماييد");
                //GlobalProc.MessageBehin("نام کاربري را وارد نماييد", 3, false, false); 
                textEdit_UserName.Focus();
                return;
            }
            if (textEdit_REEnterPass.Text != textEdit_NewPass.Text)
            {
                MessageBox.Show("رمزي که دوباره وارد شده اشتباه مي باشد. دوباره آنرا وارد نماييد");
                //GlobalProc.MessageBehin("رمزي که دوباره وارد شده اشتباه مي باشد. دوباره آنرا وارد نماييد", 3, false, true); 
                textEdit_REEnterPass.Focus();
                return;
            }

            if (InsOrEdt == 1)
            {
                if (!InsertUser())
                {
                    MessageBox.Show("نام کاربري تکراري است. دوباره آنرا وارد نماييد");
                    //GlobalProc.MessageBehin("نام کاربري تکراري است. دوباره آنرا وارد نماييد", 3, false, true); 
                    textEdit_UserName.Focus();
                    return;
                }
            }
            if (InsOrEdt == 2)
            {
                int EU = EditUser();
                if (EU == 0)
                {
                    MessageBox.Show("رمز قبلي اشتباه مي باشد. دوباره آنرا وارد نماييد");
                    //GlobalProc.MessageBehin("رمز قبلي اشتباه مي باشد. دوباره آنرا وارد نماييد", 3, false, true); 
                    textEdit_PrePass.Focus();
                    return;
                }
                else
                    if (EU == 1)
                    {
                        MessageBox.Show("نام کاربري تکراري است. دوباره آنرا وارد نماييد");
                        //GlobalProc.MessageBehin("نام کاربري تکراري است. دوباره آنرا وارد نماييد", 3, false, true); 
                        textEdit_UserName.Focus();
                        return;
                    }
            }
            Close();
        }

        private void barLargeButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }


    }
}