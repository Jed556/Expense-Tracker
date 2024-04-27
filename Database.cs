using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEnterpriseSystem
{
    class Database
    {
        public String connectionString;
        public Database()
        {
            connectionString = "datasource=localhost;port=3306;Initial Catalog='expensetracker';username=root;password=";
        }
    }
}
