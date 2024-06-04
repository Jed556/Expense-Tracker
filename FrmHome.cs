using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class FrmHome : Form
    {
        // --------------------------------- INITIALIZE --------------------------------- //

        public FrmHome()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LbTitle.Text = "Welcome " + Global.User.username + "!";
        }

        // --------------------------------- FORM --------------------------------- //

        private void BtnLists_Click(object sender, EventArgs e)
        {
            Functions.SwitchWindow(new FrmList());

        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {

        }
         
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            string tempFilePath = Path.Combine(Path.GetTempPath(), "ExpenseTracker.exe");

            using (var client = new HttpClient())
            {
                //var contentBytes =  client.GetByteArrayAsync("https://github.com/user/repo/releases/download/v1.0/myapp.exe");
                //File.WriteAllBytesAsync(tempFilePath, contentBytes);
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmLogin());
            Global.User.Clear();
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {

        }
    }
}
