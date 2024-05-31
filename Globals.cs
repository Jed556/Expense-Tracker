using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTracker
{
    internal static class Global
    {
        public static User User = new User();
        public static Database Database = new Database("datasource=localhost;port=3306;Initial Catalog='expensetracker';username=root;password=");
    }


}
