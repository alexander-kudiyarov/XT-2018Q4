using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Final_Entities;

namespace EPAM.Final_DAL.Interfaces
{
    public interface IForumDao
    {
        bool Authentication(string username, string password);

        string[] GetUserRoles(string name);

        bool NewUser(string username, string password);

        void EditUser(int id, string newUsername, string newPassword);

        void EditUserRole(int userId, int newRoleId);

        void DeleteUser(int id);

        User GetUser(int id);

        IEnumerable<User> GetUsers();

        int GetUserId(string username);

        bool NewThread(string username, string subject);

        int GetThreadId(string threadName);

        void EditThread(int id, string newSubject);

        void DeleteThread(int id);

        Thread GetThread(int id);

        IEnumerable<Thread> GetThreads();

        IEnumerable<Thread> GetThreadsByUser(int id);

        void NewPost(string text, int threadId, string username);

        void EditPost(int id, string text);

        void DeletePost(int id);

        Post GetPost(int id);

        IEnumerable<Post> GetPostsByThread(int id);

        IEnumerable<Post> GetPostsByUser(int id);
    }
}
