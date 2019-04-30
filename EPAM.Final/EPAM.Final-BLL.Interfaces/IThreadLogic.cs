using EPAM.Final_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
