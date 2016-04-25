using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RickySQLTools
{
    public partial class frmBase : Form
    {
        public bool closeFlag = false;
        public frmBase()
        {
            InitializeComponent();
        }

        private void frmBase_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSetConfig_Click(object sender, EventArgs e)
        {
            frmSetConfigDialog frm = new frmSetConfigDialog();
            frm.SetConfig += AfterSetConfig;
            frm.ShowDialog();
        }

        protected void SetHideButton(HideButton btn)
        {
            switch (btn)
            {
                case HideButton.SetConfig:
                    btnSetConfig.Visible = false;
                    break;
                default:
                    break;
            }
        }

        protected virtual void AfterSetConfig(object sender, object e) { }
    }
 
}
