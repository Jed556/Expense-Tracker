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
        public int listId;
        public string name;
        public string tag;
        public double amount;
        public DateTime date;

        public void updateExpense(int id, int userId, int listId, string name, string tag, double amount, DateTime date)
        {
            this.id = id;
            this.userId = userId;
            this.listId = listId;
            this.name = name;
            this.tag = tag;
            this.amount = amount;
            this.date = date;
        }
    }
}
