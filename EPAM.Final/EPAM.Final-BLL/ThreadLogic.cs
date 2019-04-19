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
    public class ThreadLogic : ForumLogic, IThreadLogic
    {
        private IThreadDao threadDao;

        public ThreadLogic(IThreadDao threadDao)
        {
            this.threadDao = threadDao;
        }

        public int New(string username, string subject)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(subject))
            {
                return this.threadDao.New(username, subject);
            }

            return errorCode;
        }

        public int Edit(int id, string newSubject)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(newSubject))
            {
                return this.threadDao.Edit(id, newSubject);
            }

            return errorCode;
        }

        public int Delete(int id)
        {
            if (id > 0)
            {
                return this.threadDao.Delete(id);
            }

            return errorCode;
        }

        public Thread Get(int id)
        {
            if (id > 0)
            {
                return this.threadDao.Get(id);
            }

            return null;
        }

        public IEnumerable<Thread> GetAll()
        {
            return this.threadDao.GetAll();
        }

        public IEnumerable<Thread> GetAllByUser(int id)
        {
            return this.threadDao.GetAllByUser(id);
        }

        public int GetId(string threadName)
        {
            if (!string.IsNullOrWhiteSpace(threadName))
            {
                return this.threadDao.GetId(threadName);
            }

            return errorCode;
        }
    }
}
