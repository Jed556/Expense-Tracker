using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public static class Functions {
        public static void SwitchWindow(Form newForm)
        {
            List<Form> openForms = new List<Form>();
            foreach (Form form in Application.OpenForms)
                if (form.Name != newForm.Name)
                openForms.Add(form);

            foreach (Form form in openForms)
            {
                form.Close();
            }

            newForm.Show();
        }
    }
}
