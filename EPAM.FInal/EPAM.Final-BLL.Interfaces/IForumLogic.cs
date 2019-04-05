using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_BLL.Interfaces
{
    public interface IForumLogic
    {
        void NewUser(string username, string password);

        void EditUser(string username, string newUsername, string newPassword);

        void DeleteUser(string username);

        IEnumerable<User> GetUsers();

        void NewTopic(string subject, string text);

        void EditTopic(string subject, string newSubject);

        void DeleteTopic(string subject);

        IEnumerable<Topic> GetTopics();

        void NewMessage(string text);

        void EditMessage(int id, string text);

        void DeleteMessage(int id);

        IEnumerable<Message> GetMessages();
    }
}
