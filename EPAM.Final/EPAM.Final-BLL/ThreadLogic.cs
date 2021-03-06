﻿using System.Collections.Generic;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL
{
    public class ThreadLogic : ForumLogic, IThreadLogic
    {
        private readonly IThreadDao threadDao;

        public ThreadLogic(IThreadDao threadDao)
        {
            this.threadDao = threadDao;
        }

        public bool New(string username, string subject, out int id)
        {
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(subject))
            {
                if (this.threadDao.TryNew(username, subject, out id))
                {
                    Log.Info($"New thread, ID: {id}, Subject: {subject}");

                    return true;
                }
            }

            id = ForumLogic.ErrorCode;

            return false;
        }

        public bool Edit(int id, string newSubject)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(newSubject))
            {
                if (this.threadDao.Edit(id, newSubject))
                {
                    Log.Info($"Thread {Get(id).Subject} change subject to {newSubject}");

                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                string subject = this.Get(id).Subject;

                if (this.threadDao.Delete(id))
                {
                    Log.Info($"Thread {subject} deleted");

                    return true;
                }
            }

            return false;
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

            return ForumLogic.ErrorCode;
        }
    }
}