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
        // --------------------------------- INITIALIZE --------------------------------- //
        bool TxtExpenseID_HasVal = false;
        bool TxtExpenseName_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;
        bool CmbExpenseTag_HasVal = false;
        bool TxtExpenseDate_HasVal = false;

        ExpenseList NewList = new ExpenseList();
        ExpenseList ActiveList = new ExpenseList();
        Expense Expense = new Expense();

        DataTable dtExpense = new DataTable();
        DataTable dtList = new DataTable();
     

        public FrmList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;  
        }

        private void CmbListName_Layout(object sender, LayoutEventArgs e)
        {
            ActiveList.userId = Global.User.id;
            String Data2 = "SELECT * FROM tbllists WHERE UserID = @UserID";
            dtList = Global.Database.ExecuteAdapter(Data2, ActiveList);

            CmbListName.DataSource = dtList;
            CmbListName.DisplayMember = "ListName";
            CmbListName.ValueMember = "ListID";
        }

        // --------------------------------- FUNCTIONS --------------------------------- //

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

        void UpdateList()
        {
            ActiveList.id = CmbListName.SelectedIndex;
            ActiveList.userId = Global.User.id;
            String Data1 = "SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID";
            dtExpense = Global.Database.ExecuteAdapter(Data1, ActiveList);

            CmbExpenseTag.DataSource = dtExpense;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";

            DgvTable.DataSource = dtExpense;

            Global.Database.Disconnect();

            CmbListName_Layout(null, null);

            BtnEdit.Enabled = true;
        }

        private void CmbExpenseTag_Update(object sender, LayoutEventArgs e)
        {
            ActiveList.id = CmbListName.SelectedIndex;
            ActiveList.userId = Global.User.id;
            String Data = "SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID";
            dtExpense = Global.Database.ExecuteAdapter(Data, ActiveList);

            CmbExpenseTag.DataSource = dtExpense;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";

            Global.Database.Disconnect();
        }

        // --------------------------------- EVENTS --------------------------------- //

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

        private void CmbListName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbListName.SelectedIndex != -1)
            {
                BtnEdit.Enabled = true;
                UpdateList();
            }
            else
            {
                BtnEdit.Enabled = false;
            }
        }

        // --------------------------------- FORM --------------------------------- //

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Expense.id = int.Parse(TxtExpenseID.Text);
                Expense.userId = Global.User.id;
                Expense.name = TxtExpenseName.Text;
                Expense.tag = CmbExpenseTag.Text;
                Expense.amount = double.Parse(TxtExpenseAmount.Text);
                Expense.date = DateTime.Parse(TxtExpenseDate.Text);

                String Query = "SELECT * FROM tblexpenses WHERE UserID=@UserID AND (ExpenseID=@ExpenseID OR ExpenseName=@ExpenseName OR ExpenseTag=@ExpenseTag OR ExpenseAmount=@ExpenseAmount OR ExpenseDate=@ExpenseDate)";
                dtExpense = Global.Database.ExecuteAdapter(Query, Expense);
                DgvTable.DataSource = dtExpense;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCreateList_Click(object sender, EventArgs e)
        {
            if (TxtNewList.Text == "")
            {
                MessageBox.Show("Please add a list name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                NewList.id = Global.Database.GetNextIndex("tbllists", "ListID");
                NewList.userId = Global.User.id;
                NewList.name = TxtNewList.Text;

                String Query = "INSERT INTO tbllists (ListID, Name, UserID) VALUES (@ListId, @Name, @UserID)";

                Global.Database.ExecuteQuery(Query, NewList);
                UpdateList();
            }
            TxtNewList.Text = "";
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Global.ExpenseList.UpdateExpenselist(ActiveList.id, ActiveList.userId, ActiveList.name);
            Functions.SwitchWindow(new FrmList_Edit());
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmHome());
        }
    }
}