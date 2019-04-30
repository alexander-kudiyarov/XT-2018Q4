using System.Collections.Generic;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL
{
    public class UserLogic : ForumLogic, IUserLogic
    {
        private readonly int minUsernameLength = 3;

        private readonly int maxUsernameLength = 20;

        private readonly int minPasswordLength = 6;

        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool Authentication(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || password.Length < 4)
            {
                return false;
            }

            return this.userDao.Authentication(username, password);
        }

        public string GetRole(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return this.userDao.GetRole(name);
            }

            return null;
        }

        public bool New(string username, string password)
        {
            if (username.Length >= this.minUsernameLength && username.Length <= this.maxUsernameLength && password.Length >= this.minPasswordLength)
            {
                if (this.userDao.TryNew(username, password, out int id))
                {
                    Log.Info($"New user, ID: {id}, Username: {username}");
                    return true;
                }
            }

            return false;
        }

        public bool Edit(int id, string newUsername, string newPassword)
        {
            if ((newUsername.Length >= this.minUsernameLength && newUsername.Length <= this.maxUsernameLength) || newPassword.Length >= this.minPasswordLength)
            {
                string oldUsername = this.Get(id).Username;

                if (this.userDao.Edit(id, newUsername, newPassword))
                {
                    if (!string.IsNullOrWhiteSpace(newUsername))
                    {
                        Log.Info($"User {oldUsername} change username to {newUsername}");

                        return true;
                    }
                }
            }

            return false;
        }

        public bool EditRole(int id, int newRoleId)
        {
            if (id > 1)
            {
                if (this.userDao.EditRole(id, newRoleId))
                {
                    Log.Info($"User {Get(id).Username} get {Get(id).Role} role");

                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (id > 1)
            {
                string username = this.Get(id).Username;

                if (this.userDao.Delete(id))
                {
                    Log.Info($"User {username} deleted");

                    return true;
                }
            }

            return false;
        }

        public User Get(int id)
        {
            if (id > 0)
            {
                return this.userDao.Get(id);
            }

            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return this.userDao.GetAll();
        }

        public int GetId(string username)
        {
            if (!string.IsNullOrWhiteSpace(username))
            {
                return this.userDao.GetId(username);
            }

            return ForumLogic.ErrorCode;
        }
    }
}