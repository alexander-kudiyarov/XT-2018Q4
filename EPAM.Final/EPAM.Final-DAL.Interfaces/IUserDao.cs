﻿using System.Collections.Generic;
using EPAM.Final_Entities;

namespace EPAM.Final_DAL.Interfaces
{
    public interface IUserDao
    {
        bool Authentication(string username, string password);

        string GetRole(string name);

        bool TryNew(string username, string password, out int id);

        bool Edit(int id, string newUsername, string newPassword);

        bool EditRole(int userId, int newRoleId);

        bool Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();

        int GetId(string username);
    }
}