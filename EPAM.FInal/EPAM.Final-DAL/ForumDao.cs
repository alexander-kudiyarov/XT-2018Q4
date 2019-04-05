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
        static string connectionString = @"Data Source=DESKTOP-89VB63U\SQLEXPRESS;Initial Catalog=MyTraining;Integrated Security=True";

        public void NewUser(string username, string password)
        {
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                var cmd = sqlConnection.CreateCommand();

                cmd.CommandText = "New User";
                cmd.CommandType = CommandType.StoredProcedure;

                var usernameParameter = new SqlParameter("@username", username);
                cmd.Parameters.Add(usernameParameter);

                var passwordParameter = new SqlParameter("@password", password);
                cmd.Parameters.Add(passwordParameter);
            }
        }

        public void EditUser(string username, string newUsername, string newPassword)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void NewTopic(string subject, string text)
        {
            throw new NotImplementedException();
        }

        public void EditTopic(string subject, string newSubject)
        {
            throw new NotImplementedException();
        }

        public void DeleteTopic(string subject)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Topic> GetTopics()
        {
            throw new NotImplementedException();
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
