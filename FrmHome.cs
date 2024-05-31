using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class FrmHome : Form
    {

        public FrmHome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LbTitle.Text = "Welcome " + Global.User.username + "!";
        }

        private void BtnLists_Click(object sender, EventArgs e)
        {
            Functions.SwitchWindow(new FrmList());
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {

        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmLogin());
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
