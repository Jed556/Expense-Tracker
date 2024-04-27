using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyEnterpriseSystem
{
    public partial class FrmLogin : Form
    {
        Database objDB = new Database();
        MySqlConnection connection;
        MySqlCommand command;

        string username;
        string password;
        int counter = 0;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
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

        MySqlDataReader SearchQuery(MySqlConnection connection, String Query)
        {
            //Connect(connection);

            command = new MySqlCommand(Query, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
          
            MySqlDataReader mdr = command.ExecuteReader();

            return mdr;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            if (TxtUsername.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Please fill in the required fields.");
            }
            else
            {
                username = TxtUsername.Text;
                password = TxtPassword.Text;

                connection.Open();
                String Query = "SELECT * FROM tblLogin WHERE username = @username AND password = @password";
                MySqlDataReader mdr1 = SearchQuery(connection, Query);
                connection.Close();
                connection.Open();
                MySqlDataReader mdr2 = SearchQuery(connection, Query);
                connection.Close();
                String Query2 = "SELECT * FROM tblLogin WHERE username = @username AND password = @password";

            if (mdr1.Read())
            {
                MessageBox.Show("Login Successful!");
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Hide();
            }
            else if (counter == 3)
            { 
                MessageBox.Show("You have reached the maximum number of attempts.");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Login Failed!");
                counter++;
                if (counter >= 1)
                {          
                    LbAtt.Visible = true;
                    LbAtt.Text = "Attempts Remaining: " + (3 - counter).ToString();
                }
            }

            
            }
        }
    }
}
