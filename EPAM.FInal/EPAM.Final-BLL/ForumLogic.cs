using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_BLL
{
    public class ForumLogic : IForumLogic
    {
        private IForumDao forumDao;

        public ForumLogic(IForumDao forumDao)
        {
            this.forumDao = forumDao;
        }

        public void NewUser(string username, string password)
        {
            forumDao.NewUser(username, password);
        }

        public void EditUser(string username, string newUsername, string newPassword)
        {
            forumDao.EditUser(username, newUsername, newPassword);
        }

        public void DeleteUser(string username)
        {
            forumDao.DeleteUser(username);
        }

        public IEnumerable<User> GetUsers()
        {
            return forumDao.GetUsers();
        }

        public void NewTopic(string subject, string text)
        {
            forumDao.NewTopic(subject, text);
        }

        public void EditTopic(string subject, string newSubject)
        {
            forumDao.EditTopic(subject, newSubject);
        }

        public void DeleteTopic(string subject)
        {
            forumDao.DeleteTopic(subject);
        }

        public IEnumerable<Topic> GetTopics()
        {
            return forumDao.GetTopics();
        }

        public void NewMessage(string text)
        {
            forumDao.NewMessage(text);
        }

        public void EditMessage(int id, string text)
        {
            forumDao.EditMessage(id, text);
        }

        public void DeleteMessage(int id)
        {
            forumDao.DeleteMessage(id);
        }

        public IEnumerable<Message> GetMessages()
        {
            return forumDao.GetMessages();
        }
    }
}
