using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    struct User
    {
        public int id;
        public string username;
        public string password;

        public void updateUser(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }
    }

    struct Expense
    {
        public int id;
        public int userId;
        public string name;
        public string tag;
        public double amount;
        public DateTime date;

        public void updateExpense(int id, string name, string tag, double amount, DateTime date, int userId)
        {
            this.id = id;
            this.userId = userId;
            this.name = name;
            this.tag = tag;
            this.amount = amount;
            this.date = date;
        }
    }
}
