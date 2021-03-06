﻿using System.Collections.Generic;
using EPAM.Task6._01_Users.Entities;

namespace EPAM.Task6._01_Users.BLL.Interfaces
{
    public interface IUserLogic
    {
        void AddAward(Award award);

        void AddAwardToUser(int id, Award award);

        void AddUser(User user);

        IEnumerable<User> GetAll();

        void LoadAwardList();

        void LoadUserList();

        void OverwriteAwardList();

        void OwerwriteUserList();

        void Remove(int id);
    }
}