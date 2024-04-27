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



namespace MyEnterpriseSystem
{
    public partial class FrmMain : Form
    {
        int expenseId = 0;
        String expenseName;
        double expenseAmount;

        bool TxtExpenseID_HasVal = false;
        bool TxtExpenseName_HasVal = false;
        bool TxtExpenseAmount_HasVal = false;

        Database objDB = new Database();
        MySqlConnection connection;
        MySqlCommand command;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            connection = new MySqlConnection(objDB.connectionString);
        }

        void Connect(MySqlConnection connection)
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
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

            expenseId = 0;
            expenseName = "";
            expenseAmount = 0;
        }

        void ClearValues()
        {
            TxtExpenseID.Clear();
            TxtExpenseName.Clear();
            TxtExpenseAmount.Clear();
            TxtExpenseDate.Visible = false;
            lbExpenseDate.Visible = false;
            TxtExpenseDate.Clear();
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
            expenseId = int.Parse(TxtExpenseID.Text);
            expenseName = TxtExpenseName.Text;
            expenseAmount = double.Parse(TxtExpenseAmount.Text);
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

        int ExecuteQuery(MySqlConnection connection, String Query)
        {
            Connect(connection);

            command = new MySqlCommand(Query, connection);
            command.Parameters.AddWithValue("@expenseID", expenseId);
            command.Parameters.AddWithValue("@expenseName", expenseName);
            command.Parameters.AddWithValue("@expenseAmount", expenseAmount);
            command.Parameters.AddWithValue("@expenseDate", DateTime.Today);

            int success = command.ExecuteNonQuery();

            connection.Close();

            return success;
        }

        MySqlDataReader SearchQuery(MySqlConnection connection, String Query)
        {
            Connect(connection);

            command = new MySqlCommand(Query, connection);
            command.Parameters.AddWithValue("@expenseID", expenseId);
            command.Parameters.AddWithValue("@expenseName", expenseName);
            command.Parameters.AddWithValue("@expenseAmount", expenseAmount);

            MySqlDataReader mdr = command.ExecuteReader();

            return mdr;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            expenseName = TxtExpenseName.Text;
            expenseAmount = double.Parse(TxtExpenseAmount.Text);

            String insertQuery = "INSERT INTO tblexpenses(ExpenseID, Name, Amount, Date) VALUES (@expenseID,@expenseName,@expenseAmount, @expenseDate)";

            ExecuteQuery(connection, insertQuery);

            MessageBox.Show("Record Inserted Successfully", "Record Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ClearValues();
            BtnSave.Enabled = false;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                expenseId = int.Parse(TxtExpenseID.Text);
                MySqlDataReader mdr;

                String searchQuery = "SELECT * FROM tblexpenses WHERE ExpenseID=@expenseID";

                mdr = SearchQuery(connection, searchQuery);

                if (mdr.Read())
                {
                    TxtExpenseName.Text = mdr.GetString("Name");
                    TxtExpenseAmount.Text = mdr.GetDouble("Amount").ToString();
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

                connection.Close();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            expenseId = int.Parse(TxtExpenseID.Text);
            expenseName = TxtExpenseName.Text;
            expenseAmount = double.Parse(TxtExpenseAmount.Text);

            String updateQuery = "UPDATE tblexpenses SET Name=@expenseName, Amount=@expenseAmount WHERE ExpenseID=@expenseID";

            ExecuteQuery(connection, updateQuery);

            MessageBox.Show("Record Updated Successfully");

            TxtExpenseAmount.Clear();
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                expenseId = int.Parse(TxtExpenseID.Text);

                String deleteQuery = "DELETE FROM tblexpenses WHERE ExpenseID=@expenseID";

                int output = ExecuteQuery(connection, deleteQuery);

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
    }
}
