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

        int ListID;
        Expense Expense = new Expense();
        List<Expense> ExpenseDeleteList = new List<Expense>();
        List<Expense> ExpenseAddList = new List<Expense>();
        List<Expense> ExpenseUpdateList = new List<Expense>();

        DataTable dt = Global.Database.ExecuteAdapter("SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID");

        public FrmList_Edit()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            UpdateTable();

            UpdateTotalAmount();
            Global.Database.Disconnect();
            CmbExpenseTag_Update();
        }

        private void CmbExpenseTag_Update()
        {
            String Data = "SELECT * FROM tblexpenses WHERE UserID=@UserID AND ListID=@ListID";
            DataTable dt = Global.Database.ExecuteAdapter(Data);
            dt = dt.DefaultView.ToTable(true, "Tag");

            CmbExpenseTag.DataSource = dt;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";

            Global.Database.Disconnect();
        }

        private void DgvTable_Layout(object sender, LayoutEventArgs e)
        {
            String Data = "SELECT * FROM tblexpenses";

            Global.Database.Connect();
            MySqlDataAdapter mda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            MySqlCommand command = new MySqlCommand(Data, Global.Database.connection);
            mda.SelectCommand = command;
            mda.Fill(dt);
            bs.DataSource = dt;
            mda.Update(dt);

            Global.Database.Disconnect();
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
            UpdateTotalAmount();
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
            BtnAdd.Enabled = false;
            BtnSearch.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnDel.Enabled = false;
        }

        void GetValues()
        {
            Expense.id = int.Parse(TxtExpenseID.Text);
            Expense.userId = 0;
            Expense.name = TxtExpenseName.Text;
            Expense.tag = CmbExpenseTag.SelectedItem.ToString();
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.date = DateTime.Now;
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

        private void UpdateTable()
        {
            dt = Global.Database.ExecuteAdapter("SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID");
            DgvTable.DataSource = dt;
            DgvTable.Columns["ListID"].Visible = false;
            DgvTable.Columns["UserID"].Visible = false;


            foreach (DataGridViewColumn column in DgvTable.Columns)
            {
                column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
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
            AddExpense.userId = Global.User.id;
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
            //Expense.id = Global.Database.GetNextIndex("tblexpenses", "ExpenseID");
            Expense.userId = Global.User.id;
            Expense.listId = Global.ExpenseList.id;
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.tag = CmbExpenseTag.SelectedItem.ToString();

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

            MessageBox.Show("Record Inserted Successfully", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ClearValues();
            UpdateTotalAmount();
            UpdateTable();
            BtnAdd.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Expense.id = int.Parse(TxtExpenseID.Text);
                Expense.userId = Global.User.id;
                Expense.name = TxtExpenseName.Text;
                Expense.tag = CmbExpenseTag.SelectedItem.ToString();
                Expense.amount = int.Parse(TxtExpenseAmount.Text.ToString());
                Expense.date = DateTime.Parse(TxtExpenseDate.Text);

                UpdateTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Expense.id = int.Parse(TxtExpenseID.Text);
            Expense.userId = Global.User.id;
            Expense.listId = Global.ExpenseList.id;
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);
            Expense.tag = CmbExpenseTag.SelectedItem.ToString();
            Expense.date = DateTime.Parse(TxtExpenseDate.Text);

            ExpenseUpdateList.Add(Expense);

            TxtExpenseAmount.Clear();
            UpdateTotalAmount();
            UpdateTable();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            Expense.id = int.Parse(TxtExpenseID.Text);
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
                TxtExpenseID.Text = row.Cells[0].Value.ToString();
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

            UpdateTable();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmHome());
        }
    }
}
