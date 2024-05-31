﻿using MySql.Data.MySqlClient;
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
                foreach (Form form in Application.OpenForms)
                {
                    form.Close();
                }
                FrmLogin FrmLogin = new FrmLogin();
                FrmLogin.Show();
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
            command.Parameters.AddWithValue("@userID", Schema.userId);
            command.Parameters.AddWithValue("@Name", Schema.name);
            command.Parameters.AddWithValue("@Amount", Schema.amount);
            command.Parameters.AddWithValue("@Date", Schema.date);

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
            command.Parameters.AddWithValue("@userID", Schema.id);
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
    }
}