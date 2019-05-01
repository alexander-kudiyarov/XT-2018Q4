using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

namespace EPAM.Final_DAL
{
    public class PostSQLDao : SQLDao, IPostDao
    {
        public bool New(string text, int threadId, string username, out int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "NewPost");

                this.AddSQLParameter(cmd, "@text", text);

                this.AddSQLParameter(cmd, "@threadId", threadId);

                this.AddSQLParameter(cmd, "@username", username);

                this.AddSQLParameter(cmd, "@publishDate", DateTime.Now);

                id = SQLDao.ErrorCode;

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    try
                    {
                        while (reader.Read())
                        {
                            id = (int)reader["id"];

                            return true;
                        }
                    }
                    catch (InvalidCastException)
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        public bool Edit(int id, string text)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "EditPost");

                this.AddSQLParameter(cmd, "@id", id);

                this.AddSQLParameter(cmd, "@text", text);

                this.AddSQLParameter(cmd, "@editDate", DateTime.Now);

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
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "DeletePost");

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

        public Post Get(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPost");

                this.AddSQLParameter(cmd, "@id", id);

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    while (reader.Read())
                    {
                        var post = new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?);

                        return post;
                    }
                }

                return null;
            }
        }

        public IEnumerable<Post> GetAllByThread(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPostsByThread");

                this.AddSQLParameter(cmd, "@id", id);

                

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    var result = new List<Post>();

                    while (reader.Read())
                    {
                        result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                    }

                    if (result.Count > 0)
                    {
                        return result;
                    }
                }

                return null;
            }
        }

        public IEnumerable<Post> GetAllByUser(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPostsByUser");

                this.AddSQLParameter(cmd, "@id", id);

                if (this.ReadSQLResult(sqlConnection, cmd, out SqlDataReader reader))
                {
                    var result = new List<Post>();

                    while (reader.Read())
                    {
                        result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                    }

                    if (result.Count > 0)
                    {
                        return result;
                    }
                }

                return null;
            }
        }
    }
}