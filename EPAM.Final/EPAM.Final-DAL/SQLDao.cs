using System.Configuration;
using System.Data;
using System.Data.SqlClient;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace EPAM.Final_DAL
{
    public abstract class SQLDao
    {
        protected static int ErrorCode { get; } = -1;

        protected static log4net.ILog Log { get; } = LogHelper.GetLogger();

        protected static string ConnectionString { get; } = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;

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
            catch (SqlException exc)
            {
                Log.Error(exc.Message);

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
            catch (SqlException exc)
            {
                Log.Error(exc.Message);

                reader = null;

                return false;
            }
        }
    }
}