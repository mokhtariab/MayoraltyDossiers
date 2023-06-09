using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace MayoraltyDossiers_UI
{
    public partial class Start_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public Start_Xfm()
        {
            InitializeComponent();
        }

        public SqlConnection SqlConn = new SqlConnection(PublicClass.ConnectionString);
        private SqlCommand SqlCmd = new SqlCommand();
        private string UserPer = "";

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Start_Xfm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.SelectNextControl(this.ActiveControl, true, true, true, false);

            if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UserPer = "";
            int FUFLI = FindUserForLogIn();
            if (FUFLI == 1)
            {
                Main_Xfm mnf = new Main_Xfm();
                if (UserPer != "Admin")
                {
                    string M = "";
                    for (int i = 0; i < UserPer.Length; i++)
                    {
                        if (UserPer[i].Equals(Convert.ToChar(",")))
                        {
                            if (Convert.ToInt32(M) == 0)
                            {
                                mnf.barBtnItem_NewFile.Enabled = false;
                                mnf.barBtn_NewFile.Enabled = false;
                                mnf.navBarItem_NewFile.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 1)
                            {
                                mnf.barBtnItem_EditFile.Enabled = false;
                                mnf.barBtn_EditFile.Enabled = false;
                                mnf.navBarItem_EditFile.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 2)
                                mnf.PermissionForDeleteFile_User = false;
                                
                            if (Convert.ToInt32(M) == 3)
                            {
                                mnf.barBtnItem_AllRep.Enabled = false;
                                mnf.navBarItem_AllRep.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 4)
                            {
                                mnf.barBtnItem_StsRep.Enabled = false;
                                mnf.barBtn_StsRep.Enabled = false;
                                mnf.navBarItem_StsRep.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 5)
                            {
                                mnf.barBtnItem_Users.Enabled = false;
                                mnf.barBtn_Users.Enabled = false;
                                mnf.navBarItem_Users.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 6)
                            {
                                mnf.barBtnItem_Backup.Enabled = false;
                                mnf.barBtn_BackUp.Enabled = false;
                                mnf.navBarItem_Backup.Enabled = false;
                            }
                            if (Convert.ToInt32(M) == 7)
                            {
                                mnf.barBtnItem_Setting.Enabled = false;
                                mnf.navBarItem_Setting.Enabled = false;
                            }
                            M = "";
                        }
                        else
                        {
                            M += UserPer[i];
                        }
                    }
                }
                mnf.Show();
                this.Hide();
            }
            else
                if (FUFLI == 0)
                {
                    MessageBox.Show("نام کاربری و یا رمز ورود اشتباه می باشد!");
                    //MessageBox.Show("äÇã ˜ÇÑÈÑí æ íÇ ÑãÒ æÑæÏ ÇÔÊÈÇå ãí ÈÇÔÏ");
                    //GlobalProc.MessageBehin("äÇã ˜ÇÑÈÑí æ íÇ ÑãÒ æÑæÏ ÇÔÊÈÇå ãí ÈÇÔÏ!", 1, false, false);
                    textEdit_UserName.Focus();
                }
                else
                    if (FUFLI == 2)
                    {
                        InserAdminInSystem();
                        Main_Xfm mnf = new Main_Xfm();
                        mnf.Show();
                        this.Hide();
                    }
        }

        private int FindUserForLogIn()
        {
            SqlCmd.CommandText = " SELECT Count(*) FROM [Mayoralty_Files].[dbo].[tbl_Users] ";
            SqlCmd.Connection = SqlConn;
            SqlConn.Open();
            SqlDataReader SDR = SqlCmd.ExecuteReader();
            SDR.Read();
            if (Convert.ToInt32(SDR[0]) == 0)
            {
                SDR.Close();
                SqlConn.Close();
                return 2;
            }
            SDR.Close();
            SqlConn.Close();

            SqlCmd.CommandText = " SELECT [Username],[Password],[Permission_User] FROM [Mayoralty_Files].[dbo].[tbl_Users] ";

            SqlCmd.Connection = SqlConn;

            SqlConn.Open();

            SqlDataReader SDR_1 = SqlCmd.ExecuteReader();

            while (SDR_1.Read())
            {
                if ((textEdit_UserName.Text == Convert.ToString(SDR_1[0]).Trim()) && (textEdit_Password.Text == Convert.ToString(SDR_1[1]).Trim()))
                {
                    UserPer = Convert.ToString(SDR_1[2]).Trim();
                    SDR_1.Close();
                    SqlConn.Close();
                    return 1;
                }
            }
            SDR_1.Close();
            SqlConn.Close();
            return 0;
        }

        private void InserAdminInSystem()
        {

            SqlCmd.CommandText = " INSERT INTO [Mayoralty_Files].[dbo].[tbl_Users]" +
                                "             ([Name],[Family],[Username],[Password]," +
                                "              [CreateDate],[Permission_User]) " +
                                " VALUES ('admin','admin','admin','','" + DateTime.Now.ToShortDateString() + "','Admin')";
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Opacity = Opacity + 1;
        }

        private void Start_Xfm_Shown(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            CheckOrInstallDB();
        }

        private void Start_Xfm_Load(object sender, EventArgs e)
        {
            if (!Set_RegKey(PublicClass.Key_Name)) 
            {
                MessageBox.Show("This Software Not Registered!! \n Plesae Register This Software.");
                Application.Exit();
            }
            SetLanguageProgram();
        }

        private bool Set_RegKey(string KeyName)
        {
            // Opening the registry key
            RegistryKey CUKey = Registry.CurrentUser.OpenSubKey("Software\\AMProject\\");
            // If the RegistrySubKey doesn't exist -> (null)
            if (CUKey == null) return false;
            if (CUKey.GetValue("Key").Equals(KeyName)) return true;
            return false;
        }

        private void SetLanguageProgram()
        {
            InputLanguage lang = GetFarsiLanguage();
            if (lang == null)
                throw new NotSupportedException("Farsi Language keyboard is not installed.");
            InputLanguage.CurrentInputLanguage = lang;
        }

        private InputLanguage GetFarsiLanguage()
        {
            foreach (InputLanguage lang in InputLanguage.InstalledInputLanguages)
            {
                if ((lang.LayoutName.ToLower() == "farsi")|(lang.LayoutName == "Persian"))
                    return lang;
            }
            return null;
        }

        private void CheckOrInstallDB()
        {
            string ConnectionStr = "Data Source=.\\sqlexpress;Initial Catalog=Mayoralty_Files;Integrated Security=True;";

            SqlConnection SqlConn = new SqlConnection(ConnectionStr);

            try
            {
                SqlConn.Open();
                SqlConn.Close();
            }
            catch
            {
                SqlConnection SqlConn1 = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=master;Integrated Security=True;");
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlConn1;
                SqlCmd.CommandText = "USE [master]" +
                    "CREATE DATABASE [Mayoralty_Files] ON " +
                    "( FILENAME = N'" + Application.StartupPath + @"\ApplicationData\Data\Mayoralty_Files.mdf' )," +
                    "( FILENAME = N'" + Application.StartupPath + @"\ApplicationData\Data\Mayoralty_Files_log.ldf' )" +
                    " FOR ATTACH ";
                try
                {
                    SqlConn1.Open();
                    SqlCmd.ExecuteReader();
                    SqlConn1.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("اتصال دیتا: نصب برنامه به درستی صورت نگرفته است!." + ex.Message);
                    Application.Exit();
                }
            }

        }

    }
}