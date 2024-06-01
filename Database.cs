using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    class Database
    {

        private String connectionString = "";
        public MySqlConnection connection;

        public Database(String connectionString)
        {
            this.connectionString = connectionString;
            connection = new MySqlConnection(connectionString);
        }

        public void Connect()
        {
            try
            {
                if (this.connection.State == ConnectionState.Closed)
                {
                    this.connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Connnecting to Database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Disconnect()
        {
            if (this.connection.State == ConnectionState.Open)
            {
                this.connection.Close();
            }
        }

        public DataTable ExecuteAdapter(String Query)
        {
            Connect();
            MySqlDataAdapter mda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@UserID", Global.User.id);
            command.Parameters.AddWithValue("@ListID", Global.ExpenseList.id);

            mda.SelectCommand = command;
            mda.Fill(dt);
            bs.DataSource = dt;

            return dt;
        }

        public DataTable ExecuteAdapter(String Query, Expense Schema)
        {
            Connect();
            MySqlDataAdapter mda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.userId);
            command.Parameters.AddWithValue("@ListID", Schema.userId);
            command.Parameters.AddWithValue("@Name", Schema.name);
            command.Parameters.AddWithValue("@Tag", Schema.tag);
            command.Parameters.AddWithValue("@Amount", Schema.amount);
            command.Parameters.AddWithValue("@Date", Schema.date);

            mda.SelectCommand = command;
            mda.Fill(dt);
            bs.DataSource = dt;

            return dt;
        }

        public DataTable ExecuteAdapter(String Query, ExpenseList Schema)
        {
            Connect();
            MySqlDataAdapter mda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ListID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.id);

            mda.SelectCommand = command;
            mda.Fill(dt);
            bs.DataSource = dt;

            return dt;
        }

        public int ExecuteQuery(String Query, Expense Schema)
        {
            Connect();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.userId);
            command.Parameters.AddWithValue("@ListID", Schema.userId);
            command.Parameters.AddWithValue("@Name", Schema.name);
            command.Parameters.AddWithValue("@Tag", Schema.tag);
            command.Parameters.AddWithValue("@Amount", Schema.amount);
            command.Parameters.AddWithValue("@Date", Schema.date);

            int success = command.ExecuteNonQuery();

            Disconnect();

            return success;
        }

        public int ExecuteQuery(String Query, ExpenseList Schema)
        {
            Connect();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.userId);
            command.Parameters.AddWithValue("@Name", Schema.name);

            int success = command.ExecuteNonQuery();

            Disconnect();

            return success;
        }

        public int ExecuteQuery(String Query, User Schema)
        {
            Connect();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@Username", Schema.username);
            command.Parameters.AddWithValue("@Password", Schema.password);

            int success = command.ExecuteNonQuery();

            Disconnect();

            return success;
        }

        public MySqlDataReader SearchQuery(String Query, Expense Schema)
        {
            Connect();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.id);
            command.Parameters.AddWithValue("@Name", Schema.name);
            command.Parameters.AddWithValue("@Amount", Schema.amount);
            command.Parameters.AddWithValue("@Date", Schema.date);

            MySqlDataReader mdr = command.ExecuteReader();

            return mdr;
        }

        public MySqlDataReader SearchQuery(String Query, User Schema)
        {
            Connect();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@Username", Schema.username);
            command.Parameters.AddWithValue("@Password", Schema.password);

            MySqlDataReader mdr = command.ExecuteReader();

            return mdr;
        }

        public int GetNextIndex(string Table, string IDName)
        {
            Connect();

            string query = "SELECT @IDName FROM @Table ORDER BY @IDName";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@IDName", IDName);
            command.Parameters.AddWithValue("@Table", Table);

            MySqlDataReader reader = command.ExecuteReader();

            int expectedIndex = 1;
            while (reader.Read())
            {
                int currentIndex = reader.GetInt32(0);
                if (currentIndex != expectedIndex)
                {
                    break;
                }
                expectedIndex++;
            }

            reader.Close();
            Disconnect();

            return expectedIndex;
        }
    }
}