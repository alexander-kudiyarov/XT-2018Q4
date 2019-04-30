using System.Collections.Generic;
using EPAM.Final_Entities;

namespace EPAM.Final_DAL.Interfaces
{
    public interface IPostDao
    {
        bool Delete(int id);

        bool Edit(int id, string text);

        Post Get(int id);

        IEnumerable<Post> GetAllByThread(int id);

        IEnumerable<Post> GetAllByUser(int id);

        bool New(string text, int threadId, string username, out int id);
    }
}