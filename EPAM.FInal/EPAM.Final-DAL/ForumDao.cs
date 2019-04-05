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
    public class ForumDao : IForumDao
    {
        static string connectionString = @"Data Source=DESKTOP-89VB63U\SQLEXPRESS;Initial Catalog=EPAM.Final.Forum;Integrated Security=True";

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

                    var isAdminParameter = new SqlParameter("@isAdmin", false);
                    cmd.Parameters.Add(isAdminParameter);

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

        public void EditUser(string username, string newUsername, string newPassword)
        {
            if(!string.IsNullOrWhiteSpace(username) && (!string.IsNullOrWhiteSpace(newUsername) || !string.IsNullOrWhiteSpace(newPassword)))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var usernameParameter = new SqlParameter("@username", username);
                    cmd.Parameters.Add(usernameParameter);


                    if(!string.IsNullOrWhiteSpace(newUsername))
                    {
                        var newUsernameParameter = new SqlParameter("@newUsername", newUsername);
                        cmd.Parameters.Add(newUsernameParameter);
                    }
                    else
                    {
                        var newUsernameParameter = new SqlParameter("@newUsername", DBNull.Value);
                        cmd.Parameters.Add(newUsernameParameter);
                    }
                    
                    if(!string.IsNullOrWhiteSpace(newPassword))
                    {
                        var newPasswordParameter = new SqlParameter("@newPassword", newPassword);
                        cmd.Parameters.Add(newPasswordParameter);
                    }
                    else
                    {
                        var newPasswordParameter = new SqlParameter("@newPassword", DBNull.Value);
                        cmd.Parameters.Add(newPasswordParameter);
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

        public void DeleteUser(string username)
        {
            if(!string.IsNullOrWhiteSpace(username))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeleteUser";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var usernameParameter = new SqlParameter("@username", username);
                    cmd.Parameters.Add(usernameParameter);

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

        public IEnumerable<User> GetUsers()
        {
            var result = new List<User>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetUsers";
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new User((string)reader["username"], (string)reader["password"], (bool)reader["isAdmin"]));
                }

                return result;
            }
        }

        public void NewTopic(string username, string subject)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(subject))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "NewTopic";
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

        public void EditTopic(string subject, string newSubject)
        {
            if (!string.IsNullOrWhiteSpace(subject) && !string.IsNullOrWhiteSpace(newSubject))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "EditTopic";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var subjectParameter = new SqlParameter("@subject", subject);
                    cmd.Parameters.Add(subjectParameter);

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

        public void DeleteTopic(string subject)
        {
            if (!string.IsNullOrWhiteSpace(subject))
            {
                using (var sqlConnection = new SqlConnection(connectionString))
                {
                    var cmd = sqlConnection.CreateCommand();

                    cmd.CommandText = "DeleteTopic";
                    cmd.CommandType = CommandType.StoredProcedure;

                    var subjectParameter = new SqlParameter("@subject", subject);
                    cmd.Parameters.Add(subjectParameter);

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

        public IEnumerable<Topic> GetTopics()
        {
            var result = new List<Topic>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetTopics";
                cmd.CommandType = CommandType.Text;
                sqlConnection.Open();
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Topic((string)reader["subject"], (string)reader["startedBy"], (DateTime)reader["lastMessage"]));
                }

                return result;
            }
        }

        public IEnumerable<Topic> GetTopics(string username)
        {
            var result = new List<Topic>();
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();
                cmd.CommandText = "GetTopicsByUser";
                cmd.CommandType = CommandType.StoredProcedure;

                var usernameParameter = new SqlParameter("@username", username);
                cmd.Parameters.Add(usernameParameter);

                sqlConnection.Open();

                cmd.ExecuteNonQuery();

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Topic((string)reader["subject"], (string)reader["startedBy"], (DateTime)reader["lastMessage"]));
                }

                return result;
            }
        }

        public void NewMessage(string text)
        {
            throw new NotImplementedException();
        }

        public void EditMessage(int id, string text)
        {
            throw new NotImplementedException();
        }

        public void DeleteMessage(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessages()
        {
            throw new NotImplementedException();
        }
    }
}
