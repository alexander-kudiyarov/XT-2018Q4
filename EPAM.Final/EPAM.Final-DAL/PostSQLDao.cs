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
    public class PostSQLDao : SQLDao, IPostDao
    {
        public int New(string text, int threadId, string username)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "NewPost");

                this.AddSQLParameter(cmd, "@text", text);

                this.AddSQLParameter(cmd, "@threadId", threadId);

                this.AddSQLParameter(cmd, "@username", username);

                this.AddSQLParameter(cmd, "@publishDate", DateTime.Now);

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

        public int Edit(int id, string text)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "EditPost");

                this.AddSQLParameter(cmd, "@id", id);

                this.AddSQLParameter(cmd, "@text", text);

                this.AddSQLParameter(cmd, "@editDate", DateTime.Now);

                return ExecuteSQLCommand(sqlConnection, cmd) ? id : errorCode;
            }
        }

        public int Delete(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "DeletePost");

                this.AddSQLParameter(cmd, "@id", id);

                return ExecuteSQLCommand(sqlConnection, cmd) ? id : errorCode;
            }
        }

        public Post Get(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPost");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                Post post = null;

                while (reader.Read())
                {
                    post = new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?);
                }

                return post;
            }
        }

        public IEnumerable<Post> GetAllByThread(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPostsByThread");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<Post>();

                while (reader.Read())
                {
                    result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                }

                return result;
            }
        }

        public IEnumerable<Post> GetAllByUser(int id)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                this.CreateSQLCommand(sqlConnection, out SqlCommand cmd, "GetPostsByUser");

                this.AddSQLParameter(cmd, "@id", id);

                sqlConnection.Open();

                var reader = cmd.ExecuteReader();

                var result = new List<Post>();

                while (reader.Read())
                {
                    result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                }

                return result;
            }
        }
    }
}
