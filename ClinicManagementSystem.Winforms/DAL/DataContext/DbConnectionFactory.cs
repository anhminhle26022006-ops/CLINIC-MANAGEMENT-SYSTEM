using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL.DataContext
{
    public static class DbConnectionFactory
    {
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(
                DbConfig.ConnectionString);
        }
    }
}
