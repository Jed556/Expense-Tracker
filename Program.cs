using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Test
            //Global.User.id = 1;
            Global.ExpenseList.id = 1;
            //new FrmList().Show();s
            //new FrmList_Edit().Show();

            new FrmLogin().Show();
            Application.Run();
        }
    }
}
