using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_DAL.Interfaces
{
    public interface IPostDao
    {
        int New(string text, int threadId, string username);

        int Edit(int id, string text);

        int Delete(int id);

        Post Get(int id);

        IEnumerable<Post> GetAllByThread(int id);

        IEnumerable<Post> GetAllByUser(int id);
    }
}
