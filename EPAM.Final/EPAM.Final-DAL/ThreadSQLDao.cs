using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

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

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        id = (int)reader["id"];

                        return true;
                    }
                }

                id = SQLDao.ErrorCode;

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

                if (this.ExecuteSQLCommand(sqlConnection, cmd))
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

                if (this.ExecuteSQLCommand(sqlConnection, cmd))
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

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        var thread = new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]);

                        return thread;
                    }
                }

                return null;
            }
        }

        public IEnumerable<Thread> GetAll()
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreads");

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    var result = new List<Thread>();

                    while (reader.Read())
                    {
                        result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                    }

                    if (result.Count > 0)
                    {
                        return result;
                    }
                }

                return null;
            }
        }

        public IEnumerable<Thread> GetAllByUser(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreadsByUser");

                this.AddSQLParameter(cmd, "@id", id);

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    var result = new List<Thread>();

                    while (reader.Read())
                    {
                        result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                    }

                    if(result.Count > 0)
                    {
                        return result;
                    }
                }

                return null;
            }
        }

        public int GetId(string subject)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetThreadId");

                this.AddSQLParameter(cmd, "@subject", subject);

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["id"];

                        return id;
                    }
                }

                return ErrorCode;
            }
        }
    }
}