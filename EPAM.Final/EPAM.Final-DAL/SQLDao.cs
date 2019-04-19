using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_DAL
{
    public class SQLDao
    {
        protected static int errorCode = -1;
        private static string dataSource = @"DESKTOP-89VB63U\SQLEXPRESS";
        private static string initialCatalog = @"EPAM.Final.Forum";
        private static bool integratedSecurity = true;

        public static string ConnectionString { get; } = $@"Data Source={dataSource};Initial Catalog={initialCatalog};Integrated Security={integratedSecurity}";

        protected void CreateSQLCommand(SqlConnection sqlConnection, out SqlCommand cmd, string commandText)
        {
            cmd = sqlConnection.CreateCommand();
            cmd.CommandText = commandText;
            cmd.CommandType = CommandType.StoredProcedure;
        }

        protected void AddSQLParameter(SqlCommand cmd, string parameterName, object value)
        {
            var sqlParameter = new SqlParameter(parameterName, value);

            cmd.Parameters.Add(sqlParameter);
        }

        protected bool ExecuteSQLCommand(SqlConnection sqlConnection, SqlCommand cmd)
        {
            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
        }

        protected bool ReadSQLResult(SqlConnection sqlConnection, SqlCommand cmd, out SqlDataReader reader)
        {
            try
            {
                sqlConnection.Open();

                reader = cmd.ExecuteReader();

                return true;
            }
            catch (SqlException)
            {
                reader = null;

                return false;
            }
        }
    }
}
