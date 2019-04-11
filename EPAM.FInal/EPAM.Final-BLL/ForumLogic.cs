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

        public bool Authentication(string username, string password)
        {
            return this.forumDao.Authentication(username, password);
        }

        public string GetUserRole(string name)
        {
            return this.forumDao.GetUserRole(name);
        }

        public void NewUser(string username, string password)
        {
            forumDao.NewUser(username, password);
        }

        public void EditUser(int id, string newUsername, string newPassword)
        {
            forumDao.EditUser(id, newUsername, newPassword);
        }

        public void DeleteUser(int id)
        {
            forumDao.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            return forumDao.GetUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return forumDao.GetUsers();
        }

        public void NewThread(string username, string subject)
        {
            forumDao.NewThread(username, subject);
        }

        public int GetThreadId(string threadName)
        {
            return forumDao.GetThreadId(threadName);
        }

        public void EditThread(int id, string newSubject)
        {
            forumDao.EditThread(id, newSubject);
        }

        public void DeleteThread(int id)
        {
            forumDao.DeleteThread(id);
        }

        public IEnumerable<Thread> GetThreads()
        {
            return forumDao.GetThreads();
        }

        public IEnumerable<Thread> GetThreadsByUser(int id)
        {
            return forumDao.GetThreadsByUser(id);
        }

        public void NewPost(string text, int threadId, string username)
        {
            forumDao.NewPost(text, threadId, username);
        }

        public void EditPost(int id, string text)
        {
            forumDao.EditPost(id, text);
        }

        public void DeletePost(int id)
        {
            forumDao.DeletePost(id);
        }

        public IEnumerable<Post> GetPostsByThread(int id)
        {
            return forumDao.GetPostsByThread(id);
        }

        public IEnumerable<Post> GetPostsByUser(int id)
        {
            return forumDao.GetPostsByUser(id);
        }

        public Post GetPost(int id)
        {
            return forumDao.GetPost(id);
        }
    }
}
