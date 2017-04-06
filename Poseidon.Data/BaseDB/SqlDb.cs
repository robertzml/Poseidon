using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Poseidon.Data
{
    public class SqlDb
    {
        #region Method
        public SqlConnection GetConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);
            return conn;
        }

        public SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["sqlserver"].ConnectionString;
            var conn = new SqlConnection(connectionString);
            return conn;
        }
        #endregion //Method
    }
}
