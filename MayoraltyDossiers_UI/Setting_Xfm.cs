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
    public partial class Setting_Xfm : DevExpress.XtraEditors.XtraForm
    {
        public Setting_Xfm()
        {
            InitializeComponent();
        }

        private void OK_simpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Cancel_simpleButton_Click(object sender, EventArgs e)
        {
            Close();
        }
        
    }
}