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
        public string firstName;
        public string lastName;

        public void UpdateUser(int id, string username, string password)
        {
            this.id = id;
            this.username = username;
            this.password = password;
        }

        public void Clear()
        {
            this.id = -1;
            this.username = "";
            this.password = "";
        }
    }
    struct ExpenseList
    {
        public int id;
        public int userId;
        public string name;

        public void UpdateExpenselist(int id, int userId, string name)
        {
            this.id = id;
            this.userId = userId;
            this.name = name;
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

        public void UpdateExpense(int id, int userId, int listId, string name, string tag, double amount, DateTime date)
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
