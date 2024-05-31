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

        bool TxtExpenseID_HasVal = false;
        bool TxtExpenseName_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;

        Expense Expense = new Expense();

        public FrmList_Edit()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            String Query = "SELECT * FROM tblexpenses";
            DataTable dt = Global.Database.ExecuteAdapter(Query);
            
            DgvTable.DataSource = dt;
            Global.Database.Disconnect();
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
            TxtExpenseDate.Visible = false;
            lbExpenseDate.Visible = false;

            Expense.id = 0;
            Expense.name = "";
            Expense.tag = "";
            Expense.amount = 0;
            Expense.date = DateTime.Now;
        }
        
        void DisableButtons()
        {
            BtnSave.Enabled = false;
            BtnSearch.Enabled = false;
            BtnUpdate.Enabled = false;
            BtnDel.Enabled = false;
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
            if (TxtExpenseName_HasVal && TxtExpenseAmount_HasVal)
            {
                BtnSave.Enabled = true;
            } else {
                BtnSave.Enabled = false;
            }

            if (TxtExpenseID_HasVal)
            {
                BtnSearch.Enabled = true;
            } else {
                BtnSearch.Enabled = false;
            }

            if (TxtExpenseID_HasVal && TxtExpenseName_HasVal && TxtExpenseAmount_HasVal)
            {
                BtnUpdate.Enabled = true;
            } else {
                BtnUpdate.Enabled = false;
            }

            if (TxtExpenseID_HasVal)
            {
                BtnDel.Enabled = true;
            } else {
                BtnDel.Enabled = false;
            }
        }   

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);

            String Query = "INSERT INTO tblexpenses(ExpenseID, Name, Amount, Date) VALUES (@ID, @Name, @Amount, @Date)";

            Global.Database.ExecuteQuery(Query, Expense);

            MessageBox.Show("Record Inserted Successfully", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ClearValues();
            BtnSave.Enabled = false;
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
                    BtnDel.Enabled = true;
                    TxtExpenseDate.Visible = true;
                    lbExpenseDate.Visible = true;
                }
                else
                {
                    MessageBox.Show("No Data Found", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    BtnDel.Enabled = false;
                }

                Global.Database.Disconnect();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Expense.id = int.Parse(TxtExpenseID.Text);
            Expense.name = TxtExpenseName.Text;
            Expense.amount = double.Parse(TxtExpenseAmount.Text);

            String Query = "UPDATE tblexpenses SET Name=@Name, Amount=@Amount WHERE ExpenseID=@ID";
            Global.Database.ExecuteQuery(Query, Expense);

            MessageBox.Show("Record Updated Successfully");

            TxtExpenseAmount.Clear();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Expense.id = int.Parse(TxtExpenseID.Text);

                String Query = "DELETE FROM tblexpenses WHERE ExpenseID=@ID";
                int output = Global.Database.ExecuteQuery(Query, Expense);

                if (output == 1)
                {
                    MessageBox.Show("Record Deleted Successfully", "Record Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    BtnDel.Enabled = false;
                    MessageBox.Show("Unable to Delete Record", "Record Not Deleted", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                ClearValues();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Global.Database.Disconnect();
            Application.Exit();
        }

        private void TxtDeptID_TextChanged(object sender, EventArgs e)
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

        private void TxtDeptName_TextChanged(object sender, EventArgs e)
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

        private void TxtDeptBudget_TextChanged(object sender, EventArgs e)
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

        private void CmbExpenseTag_Layout(object sender, LayoutEventArgs e)
        {
           String Data = "SELECT * FROM tblexpenses";
           DataTable dt = Global.Database.ExecuteAdapter(Data);

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
    }
}
