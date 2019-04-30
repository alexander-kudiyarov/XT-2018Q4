using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_DAL
{
    public class ThreadSQLDao : SQLDao, IThreadDao
    {
        public bool TryNew(string username, string subject, out int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "NewThread");

                this.AddSQLParameter(cmd, "@username", username);

                this.AddSQLParameter(cmd, "@subject", subject);

                this.AddSQLParameter(cmd, "@lastMessage", DateTime.Now);

                if (ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];

                        return true;
                    }
                }

                id = errorCode;

                return false;
            }
        }

        public bool Edit(int id, string newSubject)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "EditThread");

                this.AddSQLParameter(cmd, "@id", id);

                this.AddSQLParameter(cmd, "@newSubject", newSubject);

                if(ExecuteSQLCommand(sqlConnection, cmd))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "DeleteThread");

                this.AddSQLParameter(cmd, "@id", id);

                if (ExecuteSQLCommand(sqlConnection, cmd))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Thread Get(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThread");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                Thread thread = null;

                while (reader.Read())
                {
                    thread = new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]);
                }

                return thread;
            }
        }

        public IEnumerable<Thread> GetAll()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreads");

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<Thread>();

                while (reader.Read())
                {
                    result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                }

                return result;
            }
        }

        public IEnumerable<Thread> GetAllByUser(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreadsByUser");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<Thread>();

                while (reader.Read())
                {
                    result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                }

                return result;
            }
        }

        public int GetId(string subject)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreadId");

                this.AddSQLParameter(cmd, "@subject", subject);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                int id = errorCode;

                while (reader.Read())
                {
                    id = (int)reader["id"];
                }

                return id;
            }
        }
    }
}
