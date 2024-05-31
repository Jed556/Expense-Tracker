﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTracker
{
    public partial class FrmLogin : Form
    {
        string username;
        string password;
        int attempts = 3;
        User tempUser = new User();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            Global.Database.Connect();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {

            if (TxtUsername.Text == "" || TxtPassword.Text == "")
            {
                MessageBox.Show("Please fill in the required fields.");
            }
            else
            {
                tempUser.username = TxtUsername.Text;
                tempUser.password = TxtPassword.Text;

                String Query1 = "SELECT * FROM tblusers WHERE username = @Username";
                MySqlDataReader mdr1 = Global.Database.SearchQuery(Query1, tempUser);

                if (mdr1.Read())
                {
                    Global.Database.Disconnect();
                    String Query2 = "SELECT * FROM tblusers WHERE username = @Username AND password = @Password";
                    MySqlDataReader mdr2 = Global.Database.SearchQuery(Query2, tempUser);

                    if (mdr2.Read())
                    {
                        MessageBox.Show("Login Successful!");
                        Global.User.updateUser(mdr2.GetInt32("id"), mdr2.GetString("username"), mdr2.GetString("password"));
                        FrmHome FrmHome = new FrmHome();
                        FrmHome.Show();
                        this.Hide();
                    }
                    else if (attempts <= 0)
                    {
                        MessageBox.Show("You are requesting too frequently.");
                    }
                    else
                    {
                        MessageBox.Show("Wrong Password!");
                        if (attempts-- > 0)
                        {
                            LbAtt.Visible = true;
                            LbAtt.Text = "Attempts Remaining: " + (attempts).ToString();
                        }
                    }
                    Global.Database.Disconnect();
                }
                else
                {
                    MessageBox.Show("User not Found");
                }
                Global.Database.Disconnect();
            }
        }
    }
}
