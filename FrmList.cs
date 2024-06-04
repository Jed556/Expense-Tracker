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
             CmbListName_Update();
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
            if (TxtExpenseName_HasVal || TxtExpenseAmount_HasVal || CmbExpenseTag_HasVal || TxtExpenseDate_HasVal)
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
            CmbExpenseTag_Update();
            DgvTable_Update();
            BtnEdit.Enabled = true;
        }

        void DgvTable_Update()
        {
            ActiveList.id = CmbListName.SelectedIndex;
            ActiveList.userId = Global.User.id;
            String Data = "SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID";
            dtExpense = Global.Database.ExecuteAdapter(Data, ActiveList);

            DgvTable.DataSource = dtExpense;
            DgvTable.Columns["ExpenseID"].Visible = false;
            DgvTable.Columns["ListID"].Visible = false;
            DgvTable.Columns["UserID"].Visible = false;

            Global.Database.Disconnect();

            foreach (DataGridViewColumn column in DgvTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void CmbListName_Update()
        {
            String Data = "SELECT * FROM tbllists WHERE UserID=@UserID";
            dtList = Global.Database.ExecuteAdapter(Data);

            CmbListName.DataSource = dtList;
            CmbListName.DisplayMember = "Name";
            CmbListName.ValueMember = "ListID";

            //CmbListName.SelectedIndex = 0;

            Global.Database.Disconnect();

            UpdateList();
        }

        private void CmbExpenseTag_Update()
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

                String Query = "INSERT INTO tbllists (ListID, Name, UserID) VALUES (@ListID, @Name, @UserID)";

                Global.Database.ExecuteQuery(Query, NewList);
                UpdateList();
            }
            TxtNewList.Text = "";

            CmbListName_Update();
            UpdateList();
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