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
    public class UserLogic : ForumLogic, IUserLogic
    {
        private int minUsernameLength = 3;

        private int maxUsernameLength = 20;

        private int minPasswordLength = 6;

        private IUserDao userDao;

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
            if (username.Length >= minUsernameLength && username.Length <= maxUsernameLength && password.Length >= minPasswordLength)
            {
                if(this.userDao.TryNew(username, password, out int id))
                {
                    log.Info($"New user, ID: {id}, Username: {username}");
                    return true;
                }
            }

            return false;
        }

        public bool Edit(int id, string newUsername, string newPassword)
        {
            if ((newUsername.Length >= minUsernameLength && newUsername.Length <= maxUsernameLength) || newPassword.Length >= minPasswordLength)
            {
                string oldUsername = Get(id).Username;

                if(this.userDao.Edit(id, newUsername, newPassword))
                {
                    if(!string.IsNullOrWhiteSpace(newUsername))
                    {
                        log.Info($"User {oldUsername} change username to {newUsername}");

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
                if(this.userDao.EditRole(id, newRoleId))
                {
                    log.Info($"User {Get(id).Username} get {Get(id).Role} role");

                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (id > 1)
            {
                string username = Get(id).Username;

                if (this.userDao.Delete(id))
                {
                    log.Info($"User {username} deleted");

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
            if(!string.IsNullOrWhiteSpace(username))
            {
                return this.userDao.GetId(username);
            }

            return errorCode;
        }
    }
}
