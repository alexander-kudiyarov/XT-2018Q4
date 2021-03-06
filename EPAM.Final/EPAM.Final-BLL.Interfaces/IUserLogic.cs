﻿using System.Collections.Generic;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL.Interfaces
{
    public interface IUserLogic
    {
        bool Authentication(string username, string password);

        string GetRole(string name);

        bool New(string username, string password);

        bool Edit(int id, string newUsername, string newPassword);

        bool EditRole(int userId, int newRoleId);

        bool Delete(int id);

        User Get(int id);

        IEnumerable<User> GetAll();

        int GetId(string username);
    }
}