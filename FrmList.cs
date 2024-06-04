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
        bool TxtExpenseName_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;
        bool CmbExpenseTag_HasVal = false;
        bool TxtExpenseDate_HasVal = false;

        ExpenseList ActiveList = new ExpenseList();
        Expense Expense = new Expense();

        DataTable dtExpense = new DataTable();
        DataTable dtList = new DataTable();


        public FrmList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            ActiveList.userId = Global.User.id;
            Expense.userId = Global.User.id;

            CmbListName_Update();
        }

        // --------------------------------- FUNCTIONS --------------------------------- //


        void DisableButtons()
        {
            BtnSearch.Enabled = false;
            BtnEdit.Enabled = false;
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

        void UpdateList()
        {
            CmbExpenseTag_Update();
            DgvTable_Update();
            UpdateTotalAmount();
            BtnEdit.Enabled = true;
        }

        private int FindListID(string ListName, int UserID)
        {
            ExpenseList ExpenseList = new ExpenseList();
            ExpenseList.name = ListName;
            ExpenseList.userId = UserID;

            String FindList = "SELECT ListID FROM tbllists WHERE Name = @Name AND UserID = @UserID";
            MySqlDataReader mdr = Global.Database.SearchQuery(FindList, ExpenseList);
            if (mdr.Read())
            {
                ExpenseList.id = mdr.GetInt32(0);
            }

            Global.Database.Disconnect();

            return ExpenseList.id;
        }

        private void dtExpense_Update()
        {
            ActiveList.id = FindListID(CmbListName.Text, Global.User.id);
            String Data = "SELECT * FROM tblexpenses WHERE ListID = @ListID AND UserID = @UserID";
            dtExpense = Global.Database.ExecuteAdapter(Data, ActiveList);
            Global.Database.Disconnect();
        }

        void DgvTable_Update()
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

        void FilterTable()
        {
            if (CmbExpenseTag.Text != "")
            {
                DataView dv = dtExpense.DefaultView;
                dv.RowFilter = string.Format("Tag LIKE '%{0}%'", CmbExpenseTag.Text);
                DgvTable.DataSource = dv.ToTable();
            }
            else
            {
                DgvTable.DataSource = dtExpense;
            }
        }

        private void CmbListName_Update()
        {
            String Data = "SELECT * FROM tbllists WHERE UserID=@UserID";
            dtList = Global.Database.ExecuteAdapter(Data);

            CmbListName.DataSource = dtList;
            CmbListName.DisplayMember = "Name";
            CmbListName.ValueMember = "ListID";

            Global.Database.Disconnect();

            UpdateList();
        }

        private void CmbExpenseTag_Update()
        {
            dtExpense_Update();

            /*
            DataTable dt = dtExpense.Clone();
            DataRow newRow = dt.NewRow();
            newRow["Tag"] = "All";
            dt.Rows.Add(newRow);
            */
            CmbExpenseTag.DataSource = dtExpense;
            CmbExpenseTag.DisplayMember = "Tag";
            CmbExpenseTag.ValueMember = "Tag";
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

        private void CmbExpenseTag_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbExpenseTag.Text != "" && CmbExpenseTag.Text != "All")
            {
                DataView dv = dtExpense.DefaultView;
                dv.RowFilter = string.Format("Tag LIKE '%{0}%'", CmbExpenseTag.Text);
                DgvTable.DataSource = dv.ToTable();
            }
            else
            {
                DgvTable.DataSource = dtExpense;
            }
        }

        // --------------------------------- FORM --------------------------------- //

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Expense.name = TxtExpenseName.Text;
                Expense.tag = CmbExpenseTag.Text;
                Expense.amount = double.Parse(TxtExpenseAmount.Text);
                Expense.date = DateTime.Parse(TxtExpenseDate.Text);

                String Query = "SELECT * FROM tblexpenses WHERE UserID=@UserID AND (ExpenseName=@ExpenseName OR ExpenseTag=@ExpenseTag OR ExpenseAmount=@ExpenseAmount OR ExpenseDate=@ExpenseDate)";
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
                String checkQuery = "SELECT * FROM tbllists WHERE Name=@Name AND UserID=@UserID";
                ExpenseList ExpenseList = new ExpenseList();
                ExpenseList.name = TxtNewList.Text;
                ExpenseList.userId = Global.User.id;

                MySqlDataReader mdr = Global.Database.SearchQuery(checkQuery, ExpenseList);

                if (mdr.Read())
                {
                    MessageBox.Show("List name already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Global.Database.Disconnect();
                    return;
                }
                Global.Database.Disconnect();

                ExpenseList NewList = new ExpenseList();
                NewList.id = Global.Database.GetNextIndex("tbllists", "ListID");
                NewList.userId = Global.User.id;
                NewList.name = TxtNewList.Text;

                String insertQuery = "INSERT INTO tbllists (ListID, Name, UserID) VALUES (@ListID, @Name, @UserID)";
                Global.Database.ExecuteQuery(insertQuery, NewList);

                CmbListName_Update();
                UpdateList();
                TxtNewList.Text = "";
            }
        }

        private void BtnDeleteList_Click(object sender, EventArgs e)
        {
            if (CmbListName.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a list to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult Confirm = MessageBox.Show("Are you sure you want to delete this list?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (Confirm == DialogResult.Yes)
                {
                    ActiveList.id = FindListID(CmbListName.Text, ActiveList.userId);

                    String Query = "DELETE FROM tbllists WHERE ListID=@ListID AND UserID=@UserID";
                    Global.Database.ExecuteQuery(Query, ActiveList);

                    CmbListName_Update();
                    UpdateList();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Global.ExpenseList.UpdateExpenselist(FindListID(CmbListName.Text, Global.User.id), Global.User.id, CmbListName.Text);
            Functions.SwitchWindow(new FrmList_Edit());
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Functions.SwitchWindow(new FrmHome());
        }
    }
}