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

        public bool Connect()
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
                return true;
            }

            return false;
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
            if (Connect()) return null;
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
            if (Connect()) return null;
            MySqlDataAdapter mda = new MySqlDataAdapter();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.userId);
            command.Parameters.AddWithValue("@ListID", Schema.listId);
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
            if (Connect()) return null;
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
            if (Connect()) return 0;

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
            if (Connect()) return 0;

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@UserID", Schema.userId);
            command.Parameters.AddWithValue("@ListID", Schema.name);
            command.Parameters.AddWithValue("@Name", Schema.name);

            int success = command.ExecuteNonQuery();

            Disconnect();

            return success;
        }

        public int ExecuteQuery(String Query, User Schema)
        {
            if (Connect()) return 0;

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
            if (Connect()) return null;

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
            if (Connect()) return null;

            MySqlCommand command = new MySqlCommand(Query, this.connection);
            command.Parameters.AddWithValue("@ID", Schema.id);
            command.Parameters.AddWithValue("@Username", Schema.username);
            command.Parameters.AddWithValue("@Password", Schema.password);

            MySqlDataReader mdr = command.ExecuteReader();

            return mdr;
        }

        public int GetNextIndex(string Table, string IDName)
        {
            if (Connect()) return 0;

            string query = $"SELECT {IDName} FROM {Table} ORDER BY {IDName}";
            MySqlCommand command = new MySqlCommand(query, connection);

            MySqlDataReader reader = command.ExecuteReader();

            int expectedIndex = 0;
            while (reader.Read())
            {
                int currentIndex = reader.GetInt32(0);
                if (currentIndex != expectedIndex) break;

                expectedIndex++;
            }

            reader.Close();
            Disconnect();

            return expectedIndex;
        }
    }
}