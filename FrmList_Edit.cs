using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using MySql.Data.MySqlClient;
using ExpenseTracker;
using System.Data.SqlClient;



namespace ExpenseTracker
{
    public partial class FrmList_Edit : Form
    {
        // --------------------------------- INITIALIZE --------------------------------- //

        bool TxtExpenseID_HasVal = false;
        bool TxtExpenseName_HasVal = false;
        bool TxtExpensetag_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;
        bool TxtExpenseDate_HasVal = false;

        Expense Expense = new Expense();
        ExpenseList ActiveList = new ExpenseList();
        List<Expense> ExpenseDeleteList = new List<Expense>();
        List<Expense> ExpenseAddList = new List<Expense>();
        List<Expense> ExpenseUpdateList = new List<Expense>();
        DataTable dtExpense = new DataTable();

        public FrmList_Edit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ActiveList.userId = Global.ExpenseList.userId;
            ActiveList.id = Global.ExpenseList.id;

            DgvTable_Update();
            UpdateTotalAmount();
            CmbExpenseTag_Update();
        }

        private void CmbExpenseTag_Update()
        {
            DataTable dt = new DataTable();
            dtExpense_Update();
            dt = dtExpense.DefaultView.ToTable(true, "Tag");

            CmbExpenseTag.DataSource = dtExpense;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";
        }

        // --------------------------------- FUNCTIONS --------------------------------- //

        void ClearValues()
        {
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
            BtnAdd.Enabled = false;
            BtnSearch.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnDel.Enabled = false;
        }

        void CheckEnable()
        {
            if (TxtExpenseName_HasVal && TxtExpenseAmount_HasVal)
            {
                BtnAdd.Enabled = true;
            }
            else
            {
                BtnAdd.Enabled = false;
            }

            if (TxtExpenseID_HasVal)
            {
                BtnSearch.Enabled = true;
            }
            else
            {
                BtnSearch.Enabled = false;
            }

            if (TxtExpenseID_HasVal && TxtExpenseName_HasVal && TxtExpenseAmount_HasVal)
            {
                BtnUpdate.Enabled = true;
            }
            else
            {
                BtnUpdate.Enabled = false;
            }

            if (TxtExpenseID_HasVal)
            {
                BtnDel.Enabled = true;
            }
            else
            {
                BtnDel.Enabled = false;
            }
        }

        private void UpdateTotalAmount()
        {
            double TotalAmount = 0;

            foreach (DataGridViewRow row in DgvTable.Rows)
            {
                if (!row.IsNewRow)
                    TotalAmount += double.Parse(row.Cells[5].Value.ToString());
            }

            TxtTotalAmount.Text = TotalAmount.ToString();
        }

        private void dtExpense_Update()
        {
            String Data = "SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID";
            dtExpense = Global.Database.ExecuteAdapter(Data, ActiveList);
            Global.Database.Disconnect();
        }

        private void DgvTable_Update()
        {
            dtExpense_Update();
            DgvTable.DataSource = dtExpense;
            DgvTable.Columns["ExpenseID"].Visible = false;
            DgvTable.Columns["ListID"].Visible = false;
            DgvTable.Columns["UserID"].Visible = false;

            foreach (DataGridViewColumn column in DgvTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        // --------------------------------- EVENTS --------------------------------- //


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

        private void TxtExpenseAmount_TextChanged(object sender, EventArgs e)
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

        private void DgvTable_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            Expense DelExpense = new Expense();
            DelExpense.id = int.Parse(e.Row.Cells[0].Value.ToString());
            DelExpense.userId = int.Parse(e.Row.Cells[1].Value.ToString());
            DelExpense.listId = int.Parse(e.Row.Cells[2].Value.ToString());

            ExpenseDeleteList.Add(DelExpense);
            UpdateTotalAmount();
        }

        private void DgvTable_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            Expense AddExpense = new Expense();
            AddExpense.id = Global.Database.GetNextIndex("tblexpenses", "ExpenseID");
            AddExpense.userId = Global.ExpenseList.userId;
            AddExpense.listId = Global.ExpenseList.id;

            ExpenseAddList.Add(AddExpense);
            UpdateTotalAmount();
        }

        private void DgvTable_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Expense UpdateExpense = new Expense();
            UpdateExpense.id = int.Parse(DgvTable.Rows[e.RowIndex].Cells[0].Value.ToString());
            UpdateExpense.userId = int.Parse(DgvTable.Rows[e.RowIndex].Cells[1].Value.ToString());
            UpdateExpense.listId = int.Parse(DgvTable.Rows[e.RowIndex].Cells[2].Value.ToString());
            UpdateExpense.name = DgvTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            UpdateExpense.tag = DgvTable.Rows[e.RowIndex].Cells[4].Value.ToString();
            UpdateExpense.amount = double.Parse(DgvTable.Rows[e.RowIndex].Cells[5].Value.ToString());
            UpdateExpense.date = DateTime.Parse(DgvTable.Rows[e.RowIndex].Cells[6].Value.ToString());

            ExpenseUpdateList.Add(UpdateExpense);
            UpdateTotalAmount();
        }

        // --------------------------------- FORM --------------------------------- //


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Expense.id = Global.Database.GetNextIndex("tblexpenses", "ExpenseID");
            Expense.listId = Global.ExpenseList.id;
            Expense.userId = Global.ExpenseList.userId;
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.tag = CmbExpenseTag.Text;

            String Query = "INSERT INTO tblexpenses(ListID, UserID, Name, Tag, Amount, Date) VALUES (@ListID, @UserID, @Name, @Tag, @Amount, @Date)";

            if (TxtExpenseDate.Text != "")
            {
                Expense.date = DateTime.Parse(TxtExpenseDate.Text);
            }
            else
            {
                Expense.date = DateTime.Now;
            }

            Global.Database.ExecuteQuery(Query, Expense);

            ClearValues();
            UpdateTotalAmount();
            DgvTable_Update();
            BtnAdd.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Expense.userId = Global.User.id;
                Expense.name = TxtExpenseName.Text;
                Expense.tag = CmbExpenseTag.Text;
                Expense.amount = int.Parse(TxtExpenseAmount.Text.ToString());
                Expense.date = DateTime.Parse(TxtExpenseDate.Text);

                DgvTable_Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Expense.userId = Global.User.id;
            Expense.listId = Global.ExpenseList.id;
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.tag = CmbExpenseTag.Text;
            Expense.date = DateTime.Parse(TxtExpenseDate.Text);

            ExpenseUpdateList.Add(Expense);

            TxtExpenseAmount.Clear();
            UpdateTotalAmount();
            DgvTable_Update();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            Expense.userId = Global.User.id;
            Expense.listId = Global.ExpenseList.id;
            ExpenseDeleteList.Add(Expense);

            


            ClearValues();
            UpdateTotalAmount();
        }

        private void DgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = this.DgvTable.Rows[e.RowIndex];

            if (e.RowIndex >= 0 && !row.IsNewRow)
            {
                TxtExpenseName.Text = row.Cells[3].Value.ToString();
                CmbExpenseTag.Text = row.Cells[4].Value.ToString();
                TxtExpenseAmount.Text = row.Cells[5].Value.ToString();
                TxtExpenseDate.Text = DateTime.Parse(row.Cells[6].Value.ToString()).ToShortDateString();
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            String Query;

            foreach (DataGridViewRow row in DgvTable.Rows)
            {
                Query = "UPDATE tblexpenses SET Name=@Name, Tag=@Tag, Amount=@Amount, Date=@Date WHERE ExpenseID=@ID AND UserID=@UserID AND ListID=@ListID";
                if (!row.IsNewRow)
                {
                    Expense.id = int.Parse(row.Cells[0].Value.ToString());
                    Expense.userId = int.Parse(row.Cells[1].Value.ToString());
                    Expense.listId = int.Parse(row.Cells[2].Value.ToString());
                    Expense.name = row.Cells[3].Value.ToString();
                    Expense.tag = row.Cells[4].Value.ToString();
                    Expense.amount = double.Parse(row.Cells[5].Value.ToString());
                    Expense.date = DateTime.Parse(row.Cells[6].Value.ToString());

                    Global.Database.ExecuteQuery(Query, Expense);
                }

                UpdateTotalAmount();
            }

            foreach (Expense expense in ExpenseDeleteList)
            {
                Query = "DELETE FROM tblexpenses WHERE ExpenseID=@ID AND UserID=@UserID AND ListID=@ListID";
                Global.Database.ExecuteQuery(Query, expense);
            }

            foreach (Expense expense in ExpenseAddList)
            {
                Query = "INSERT INTO tblexpenses(ListID, UserID, Name, Amount, Date) VALUES (@ListID, @UserID, @Name, @Amount, @Date)";

                if (TxtExpenseDate.Text != "")
                {
                    Expense.date = DateTime.Parse(TxtExpenseDate.Text);
                }
                else
                {
                    Expense.date = DateTime.Now;
                }

                Global.Database.ExecuteQuery(Query, expense);
            }

            foreach (Expense expense in ExpenseUpdateList)
            {
                Query = "UPDATE tblexpenses SET Name=@Name, Tag=@Tag, Amount=@Amount, Date=@Date WHERE ExpenseID=@ID AND UserID=@UserID AND ListID=@ListID";
                Global.Database.ExecuteQuery(Query, expense);
            }

            DgvTable_Update();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmList());
        }
    }
}
