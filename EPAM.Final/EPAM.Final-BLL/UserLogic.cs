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
        private IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool Authentication(string username, string password)
        {
            if (!string.IsNullOrWhiteSpace(username) || password.Length < 4)
            {
                return false;
            }

            return this.userDao.Authentication(username, password);
        }

        public string[] GetRoles(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return this.userDao.GetRoles(name);
        }

        public int New(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || password.Length < 4)
            {
                return errorCode;
            }

            return this.userDao.New(username, password);
        }

        public int Edit(int id, string newUsername, string newPassword)
        {
            if (id > 1 && (!string.IsNullOrWhiteSpace(newUsername) || !string.IsNullOrWhiteSpace(newPassword)))
            {
                return this.userDao.Edit(id, newUsername, newPassword);
            }

            return errorCode;
        }

        public int EditRole(int userId, int newRoleId)
        {
            if (userId > 1)
            {
                return this.userDao.EditRole(userId, newRoleId);
            }

            return errorCode;
        }

        public int Delete(int id)
        {
            if (id > 1)
            {
                return this.userDao.Delete(id);
            }

            return errorCode;
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
