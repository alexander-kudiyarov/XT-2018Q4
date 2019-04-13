using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EPAM.Final_DAL
{
    public class ForumDao : IForumDao
    {
        static string connectionString = @"Data Source=DESKTOP-89VB63U\SQLEXPRESS;Initial Catalog=EPAM.Final.Forum;Integrated Security=True";

        public bool Authentication(string username, string password)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string savedPassword;

                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "Authentication";
                cmd.CommandType = CommandType.StoredProcedure;

                var usernameParameter = new SqlParameter("@username", username);
                cmd.Parameters.Add(usernameParameter);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    savedPassword = (string)reader["password"];
                    if(savedPassword.Equals(password))
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public string GetUserRole(string username)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                string role;
                
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetRole";
                cmd.CommandType = CommandType.StoredProcedure;

                var usernameParameter = new SqlParameter("@username", username);
                cmd.Parameters.Add(usernameParameter);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    role = (string)reader["role"];
                    return role;
                }

                return string.Empty;
            }
        }

        public void NewUser(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "NewUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var usernameParameter = new SqlParameter("@username", username);
                    cmd.Parameters.Add(usernameParameter);

                    var passwordParameter = new SqlParameter("@password", password);
                    cmd.Parameters.Add(passwordParameter);

                    var roleParameter = new SqlParameter("@role", "user");
                    cmd.Parameters.Add(roleParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public void EditUser(int id, string newUsername, string newPassword, string newRole)
        {
            if (id > 0 && (!string.IsNullOrWhiteSpace(newUsername) || !string.IsNullOrWhiteSpace(newPassword) || !string.IsNullOrWhiteSpace(newRole)))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);


                    if (!string.IsNullOrWhiteSpace(newUsername))
                    {
                        var newUsernameParameter = new SqlParameter("@newUsername", newUsername);
                        cmd.Parameters.Add(newUsernameParameter);
                    }
                    else
                    {
                        var newUsernameParameter = new SqlParameter("@newUsername", DBNull.Value);
                        cmd.Parameters.Add(newUsernameParameter);
                    }

                    if (!string.IsNullOrWhiteSpace(newPassword))
                    {
                        var newPasswordParameter = new SqlParameter("@newPassword", newPassword);
                        cmd.Parameters.Add(newPasswordParameter);
                    }
                    else
                    {
                        var newPasswordParameter = new SqlParameter("@newPassword", DBNull.Value);
                        cmd.Parameters.Add(newPasswordParameter);
                    }

                    if (!string.IsNullOrWhiteSpace(newRole))
                    {
                        var newRoleParameter = new SqlParameter("@newRole", newRole);
                        cmd.Parameters.Add(newRoleParameter);
                    }
                    else
                    {
                        var newRoleParameter = new SqlParameter("@newRole", DBNull.Value);
                        cmd.Parameters.Add(newRoleParameter);
                    }

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public void DeleteUser(int id)
        {
            if (id > 0)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeleteUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public User GetUser(int id)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var idParameter = new SqlParameter("@id", id);
                cmd.Parameters.Add(idParameter);

                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new User((int)reader["id"], (string)reader["username"], (string)reader["password"], (string)reader["role"]);
                }

                return null;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            var result = new List<User>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetUsers";
                cmd.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new User((int)reader["id"], (string)reader["username"], (string)reader["password"], (string)reader["role"]));
                }

                return result;
            }
        }

        public void NewThread(string username, string subject)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(subject))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "NewThread";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var usernameParameter = new SqlParameter("@username", username);
                    cmd.Parameters.Add(usernameParameter);

                    var subjectParameter = new SqlParameter("@subject", subject);
                    cmd.Parameters.Add(subjectParameter);

                    var lastMessageParameter = new SqlParameter("@lastMessage", DateTime.Now);
                    cmd.Parameters.Add(lastMessageParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public int GetThreadId(string threadName)
        {
            int id;
            if(!string.IsNullOrWhiteSpace(threadName))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "GetThreadId";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var threadNameParameter = new SqlParameter("@threadName", threadName);
                    cmd.Parameters.Add(threadNameParameter);

                    sqlConnection.Open();
                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        id = (int)reader["id"];
                        return id;
                    }

                }
            }

            return -1;
        }

        public void EditThread(int id, string newSubject)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(newSubject))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditThread";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    var newSubjectParameter = new SqlParameter("@newSubject", newSubject);
                    cmd.Parameters.Add(newSubjectParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public void DeleteThread(int id)
        {
            if (id > 0)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeleteThread";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public Thread GetThread(int id)
        {
            if (id > 0)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    Thread thread;
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "GetThread";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        thread = new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]);
                        return thread;
                    }
                }
            }

            return null;
        }

        public IEnumerable<Thread> GetThreads()
        {
            var result = new List<Thread>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetThreads";
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                }
                return result;
            }
        }

        public IEnumerable<Thread> GetThreadsByUser(int id)
        {
            if (id > 0)
            {
                var result = new List<Thread>();
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "GetThreadsByUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Thread((int)reader["threadId"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["lastMessage"]));
                    }

                    return result;
                }
            }

            return null;
        }

        public void NewPost(string text, int threadId, string username)
        {
            if (threadId > 0 && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(text))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "NewPost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var textParameter = new SqlParameter("@text", text);
                    cmd.Parameters.Add(textParameter);

                    var threadIdParameter = new SqlParameter("@threadId", threadId);
                    cmd.Parameters.Add(threadIdParameter);

                    var usernameParameter = new SqlParameter("@username", username);
                    cmd.Parameters.Add(usernameParameter);

                    var publishDateParameter = new SqlParameter("@publishDate", DateTime.Now);
                    cmd.Parameters.Add(publishDateParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public void EditPost(int id, string text)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(text))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditPost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    var textParameter = new SqlParameter("@text", text);
                    cmd.Parameters.Add(textParameter);

                    var editDateParameter = new SqlParameter("@editDate", DateTime.Now);
                    cmd.Parameters.Add(editDateParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public void DeletePost(int id)
        {
            if (id > 0)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeletePost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
        }

        public Post GetPost(int id)
        {
            if (id > 0)
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    Post post;
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "GetPost";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        post = new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?);
                        return post;
                    }
                }
            }

            return null;
        }

        public IEnumerable<Post> GetPostsByThread(int id)
        {
            if (id > 0)
            {
                var result = new List<Post>();
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "GetPostsByThread";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                    }

                    return result;
                }
            }

            return null;
        }

        public IEnumerable<Post> GetPostsByUser(int id)
        {
            if (id > 0)
            {
                var result = new List<Post>();
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();
                    cmd.CommandText = "GetPostsByUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var idParameter = new SqlParameter("@id", id);
                    cmd.Parameters.Add(idParameter);

                    sqlConnection.Open();

                    cmd.ExecuteNonQuery();

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(new Post((int)reader["postId"], (string)reader["text"], (string)reader["subject"], (string)reader["username"], (int)reader["userId"], (DateTime)reader["publishDate"], reader["editDate"] as DateTime?));
                    }

                    return result;
                }
            }

            return null;
        }
    }
}