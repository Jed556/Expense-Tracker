using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class FrmList : Form
    {
        bool TxtExpenseID_HasVal = false;
        bool TxtExpenseName_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;
        bool CmbExpenseTag_HasVal = false;
        bool TxtExpenseDate_HasVal = false;

        Expense Expense = new Expense();

        DataTable dt = Global.Database.ExecuteAdapter("SELECT * FROM tblexpenses WHERE ListID = @ListID && UserID = @UserID");


        public FrmList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        void Clear()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    (control as TextBox).Clear();
                }
            }

            ClearValues();
        }

        void ClearValues()
        {
            TxtExpenseID.Clear();
            TxtExpenseName.Clear();
            CmbExpenseTag.SelectedIndex = -1;
            TxtExpenseAmount.Clear();
            TxtExpenseDate.Clear();

            Expense.id = 0;
            Expense.name = "";
            Expense.tag = "";
            Expense.amount = 0;
            Expense.date = DateTime.Now;
        }

        void DisableButtons()
        {
            BtnSearch.Enabled = false;
            BtnEdit.Enabled = false;
        }

        void GetValues()
        {
            Expense.id = int.Parse(TxtExpenseID.Text);
            Expense.userId = 0;
            Expense.name = TxtExpenseName.Text;
            Expense.tag = CmbExpenseTag.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.date = DateTime.Now;
        }

        void CheckEnable()
        {
            if (TxtExpenseID_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }
            if (TxtExpenseName_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }
            if (TxtExpenseAmount_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }
            if (CmbExpenseTag_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }
            if (TxtExpenseDate_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Expense.id = int.Parse(TxtExpenseID.Text);

                String Query = "SELECT * FROM tblexpenses WHERE ExpenseID=@ID";
                MySqlDataReader mdr = Global.Database.SearchQuery(Query, Expense);

                if (mdr.Read())
                {
                    TxtExpenseID.Text = mdr.GetInt32("ExpenseID").ToString();
                    TxtExpenseName.Text = mdr.GetString("Name");
                    TxtExpenseAmount.Text = mdr.GetDouble("Amount").ToString();
                    CmbExpenseTag.Text = mdr.GetString("Tag");
                    TxtExpenseDate.Text = mdr.GetDateTime("Date").ToString("dd/MM/yyyy");
                    BtnEdit.Enabled = true;
                }
                else
                {
                    MessageBox.Show("No Data Found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnEdit.Enabled = false;
                }

                Global.Database.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtExpenseID_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpenseID.Text != "")
            {
                TxtExpenseID_HasVal = true;
            }
            else
            {
                TxtExpenseID_HasVal = false;
            }

            CheckEnable();
        }

        private void TxtExpenseName_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpenseName.Text != "")
            {
                TxtExpenseName_HasVal = true;
            }
            else
            {
                TxtExpenseName_HasVal = false;
            }

            CheckEnable();
        }

        private void TxtExpense_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpenseAmount.Text != "")
            {
                TxtExpenseAmount_HasVal = true;
            }
            else
            {
                TxtExpenseAmount_HasVal = false;
            }

            CheckEnable();
        }

        private void CmbExpenseTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbExpenseTag.SelectedIndex != -1)
            {
                CmbExpenseTag_HasVal = true;
            }
            else
            {
                CmbExpenseTag_HasVal = false;
            }

            CheckEnable();
        }

        private void TxtExpenseDate_TextChanged(object sender, EventArgs e)
        {
            if (TxtExpenseDate.Text != "")
            {
                TxtExpenseDate_HasVal = true;
            }
            else
            {
                TxtExpenseDate_HasVal = false;
            }

            CheckEnable();
        }

        private void CmbExpenseTag_Layout(object sender, LayoutEventArgs e)
        {
            String Data = "SELECT * FROM tblexpenses";
            DataTable dt = Global.Database.ExecuteAdapter(Data);

            CmbExpenseTag.DataSource = dt;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";

            Global.Database.Disconnect();
        }

        private void BtnCreateList_Click(object sender, EventArgs e)
        {

        }

        private void CmbListName_Layout(object sender, LayoutEventArgs e)
        {

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            String Data = "SELECT * FROM tbllists";
            DataTable dt = Global.Database.ExecuteAdapter(Data);

            CmbExpenseTag.DataSource = dt;
            CmbExpenseTag.DisplayMember = "Name";
            CmbExpenseTag.ValueMember = "ListID";

            Global.Database.Disconnect();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmHome());
        }
    }
}
