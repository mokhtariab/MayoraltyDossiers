namespace MayoraltyDossiers_UI
{
    partial class UserList_Xfm

    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barBtnItem_AccessUser = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBtnItem_DelUser = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBtnItem_EditUser = new DevExpress.XtraBars.BarLargeButtonItem();
            this.barBtnItem_AddUser = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl_Users = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFamily = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPassword = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPermission_User = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Users)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barBtnItem_AddUser,
            this.barBtnItem_AccessUser,
            this.barBtnItem_EditUser,
            this.barBtnItem_DelUser});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_AccessUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_DelUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_EditUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barBtnItem_AddUser, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "منوی کاربران";
            // 
            // barBtnItem_AccessUser
            // 
            this.barBtnItem_AccessUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Left;
            this.barBtnItem_AccessUser.Caption = "تعیین سطح دسترسی";
            this.barBtnItem_AccessUser.Glyph = global::MayoraltyDossiers_UI.Properties.Resources.access;
            this.barBtnItem_AccessUser.Id = 3;
            this.barBtnItem_AccessUser.Name = "barBtnItem_AccessUser";
            this.barBtnItem_AccessUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBtnItem_AccessUser_ItemClick);
            // 
            // barBtnItem_DelUser
            // 
            this.barBtnItem_DelUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnItem_DelUser.Caption = "حذف کاربر";
            this.barBtnItem_DelUser.Glyph = global::MayoraltyDossiers_UI.Properties.Resources.testbed_protocol;
            this.barBtnItem_DelUser.Id = 6;
            this.barBtnItem_DelUser.Name = "barBtnItem_DelUser";
            this.barBtnItem_DelUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem4_ItemClick);
            // 
            // barBtnItem_EditUser
            // 
            this.barBtnItem_EditUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnItem_EditUser.Caption = "ویرایش کاربر";
            this.barBtnItem_EditUser.Glyph = global::MayoraltyDossiers_UI.Properties.Resources.kmenuedit;
            this.barBtnItem_EditUser.Id = 5;
            this.barBtnItem_EditUser.Name = "barBtnItem_EditUser";
            this.barBtnItem_EditUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem3_ItemClick);
            // 
            // barBtnItem_AddUser
            // 
            this.barBtnItem_AddUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barBtnItem_AddUser.Caption = "افزودن کاربر";
            this.barBtnItem_AddUser.Glyph = global::MayoraltyDossiers_UI.Properties.Resources.Community_Help;
            this.barBtnItem_AddUser.Id = 0;
            this.barBtnItem_AddUser.Name = "barBtnItem_AddUser";
            this.barBtnItem_AddUser.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barLargeButtonItem1_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.gridControl_Users);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 58);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(489, 383);
            this.panelControl1.TabIndex = 7;
            // 
            // gridControl_Users
            // 
            this.gridControl_Users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl_Users.EmbeddedNavigator.Name = "";
            this.gridControl_Users.Location = new System.Drawing.Point(12, 10);
            this.gridControl_Users.LookAndFeel.SkinName = "Blue";
            this.gridControl_Users.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl_Users.MainView = this.gridView1;
            this.gridControl_Users.Name = "gridControl_Users";
            this.gridControl_Users.Size = new System.Drawing.Size(465, 362);
            this.gridControl_Users.TabIndex = 7;
            this.gridControl_Users.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl_Users.DoubleClick += new System.EventHandler(this.gridControl_Users_DoubleClick);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView1.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Appearance.Row.Options.UseTextOptions = true;
            this.gridView1.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUserID,
            this.colName,
            this.colFamily,
            this.colUsername,
            this.colPassword,
            this.colCreateDate,
            this.colPermission_User});
            this.gridView1.GridControl = this.gridControl_Users;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colUserID
            // 
            this.colUserID.Caption = "شماره ردیف";
            this.colUserID.FieldName = "UserID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Visible = true;
            this.colUserID.VisibleIndex = 4;
            // 
            // colName
            // 
            this.colName.Caption = "نام";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 3;
            // 
            // colFamily
            // 
            this.colFamily.Caption = "نام فامیل";
            this.colFamily.FieldName = "Family";
            this.colFamily.Name = "colFamily";
            this.colFamily.Visible = true;
            this.colFamily.VisibleIndex = 2;
            // 
            // colUsername
            // 
            this.colUsername.Caption = "نام کاربری";
            this.colUsername.FieldName = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 1;
            // 
            // colPassword
            // 
            this.colPassword.Caption = "Password";
            this.colPassword.FieldName = "Password";
            this.colPassword.Name = "colPassword";
            // 
            // colCreateDate
            // 
            this.colCreateDate.Caption = "تاریخ ایجاد";
            this.colCreateDate.FieldName = "CreateDate";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 0;
            // 
            // colPermission_User
            // 
            this.colPermission_User.Caption = "Permission_User";
            this.colPermission_User.FieldName = "Permission_User";
            this.colPermission_User.Name = "colPermission_User";
            // 
            // UserList_Xfm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 463);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserList_Xfm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست کاربران";
            this.Load += new System.EventHandler(this.UserList_Xfm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl_Users)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnItem_AddUser;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnItem_AccessUser;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnItem_DelUser;
        private DevExpress.XtraBars.BarLargeButtonItem barBtnItem_EditUser;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl_Users;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colFamily;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colPassword;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraGrid.Columns.GridColumn colPermission_User;
    }
}