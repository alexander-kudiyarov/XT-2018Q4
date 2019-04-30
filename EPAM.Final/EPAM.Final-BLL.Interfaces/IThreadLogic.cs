using System.Collections.Generic;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL.Interfaces
{
    public interface IThreadLogic
    {
        bool New(string username, string subject, out int id);

        bool Edit(int id, string newSubject);

        bool Delete(int id);

        Thread Get(int id);

        IEnumerable<Thread> GetAll();

        IEnumerable<Thread> GetAllByUser(int id);

        int GetId(string threadName);
    }
}