using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_DAL.Interfaces
{
    public interface IUserDao
    {
        bool Authentication(string username, string password);

        string GetRole(string name);

        int New(string username, string password);

        int Edit(int id, string newUsername, string newPassword);

        int EditRole(int userId, int newRoleId);

        int Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();

        int GetId(string username);
    }
}
