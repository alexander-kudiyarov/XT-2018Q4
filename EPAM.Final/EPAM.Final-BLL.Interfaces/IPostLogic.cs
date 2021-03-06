﻿using System.Collections.Generic;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL.Interfaces
{
    public interface IPostLogic
    {
        bool New(string text, int threadId, string username);

        bool Edit(int id, string text);

        bool Delete(int id);

        Post Get(int id);

        IEnumerable<Post> GetAllByThread(int id);

        IEnumerable<Post> GetAllByUser(int id);
    }
}