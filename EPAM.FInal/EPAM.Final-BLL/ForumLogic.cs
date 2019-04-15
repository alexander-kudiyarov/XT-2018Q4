using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

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
            this.forumDao.NewUser(username, password);
        }

        public void EditUser(int id, string newUsername, string newPassword, string newRole)
        {
            this.forumDao.EditUser(id, newUsername, newPassword, newRole);
        }

        public void BanUser(int id)
        {
            this.forumDao.BanUser(id);
        }

        public void DeleteUser(int id)
        {
            this.forumDao.DeleteUser(id);
        }

        public User GetUser(int id)
        {
            return this.forumDao.GetUser(id);
        }

        public IEnumerable<User> GetUsers()
        {
            return this.forumDao.GetUsers();
        }

        public void NewThread(string username, string subject)
        {
            this.forumDao.NewThread(username, subject);
        }

        public int GetThreadId(string threadName)
        {
            return this.forumDao.GetThreadId(threadName);
        }

        public void EditThread(int id, string newSubject)
        {
            this.forumDao.EditThread(id, newSubject);
        }

        public void DeleteThread(int id)
        {
            this.forumDao.DeleteThread(id);
        }

        public Thread GetThread(int id)
        {
            return this.forumDao.GetThread(id);
        }

        public IEnumerable<Thread> GetThreads()
        {
            return this.forumDao.GetThreads();
        }

        public IEnumerable<Thread> GetThreadsByUser(int id)
        {
            return this.forumDao.GetThreadsByUser(id);
        }

        public void NewPost(string text, int threadId, string username)
        {
            this.forumDao.NewPost(text, threadId, username);
        }

        public void EditPost(int id, string text)
        {
            this.forumDao.EditPost(id, text);
        }

        public void DeletePost(int id)
        {
            this.forumDao.DeletePost(id);
        }

        public Post GetPost(int id)
        {
            return this.forumDao.GetPost(id);
        }

        public IEnumerable<Post> GetPostsByThread(int id)
        {
            return this.forumDao.GetPostsByThread(id);
        }

        public IEnumerable<Post> GetPostsByUser(int id)
        {
            return this.forumDao.GetPostsByUser(id);
        }
    }
}
