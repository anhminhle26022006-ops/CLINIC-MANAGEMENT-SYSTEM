using System;

namespace DAL.DataContext
{
    public static class SchemaHelper
    {
        public static bool TableExists(string tableName)
        {
            try
            {
                object result = DatabaseHelper.ExecuteScalar(
                    "SELECT COUNT(*) FROM sys.objects WHERE object_id = OBJECT_ID(@TableName) AND type in (N'U')",
                    new Microsoft.Data.SqlClient.SqlParameter[]
                    {
                        new Microsoft.Data.SqlClient.SqlParameter("@TableName", "dbo." + tableName)
                    });
                return Convert.ToInt32(result) > 0;
            }
            catch
            {
                return false;
            }
        }

        public static bool ColumnExists(string tableName, string columnName)
        {
            try
            {
                object result = DatabaseHelper.ExecuteScalar(
                    "SELECT COL_LENGTH(@TableName, @ColumnName)",
                    new Microsoft.Data.SqlClient.SqlParameter[]
                    {
                        new Microsoft.Data.SqlClient.SqlParameter("@TableName", "dbo." + tableName),
                        new Microsoft.Data.SqlClient.SqlParameter("@ColumnName", columnName)
                    });
                return result != null && result != DBNull.Value;
            }
            catch
            {
                return false;
            }
        }
    }
}
