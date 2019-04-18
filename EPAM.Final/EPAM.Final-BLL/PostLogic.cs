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
    public class PostLogic : ForumLogic, IPostLogic
    {
        private IPostDao postDao;

        public PostLogic(IPostDao postDao)
        {
            this.postDao = postDao;
        }

        public int New(string text, int threadId, string username)
        {
            if (threadId > 0 && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(username))
            {
                return this.postDao.New(text, threadId, username);
            }

            return errorCode;
        }

        public int Edit(int id, string text)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(text))
            {
                return this.postDao.Edit(id, text);
            }

            return errorCode;
        }

        public int Delete(int id)
        {
            if (id > 0)
            {
                return this.postDao.Delete(id);
            }

            return errorCode;
        }

        public Post Get(int id)
        {
            if (id > 0)
            {
                return this.postDao.Get(id);
            }

            return null;
        }

        public IEnumerable<Post> GetAllByThread(int id)
        {
            if (id > 0)
            {
                return this.postDao.GetAllByThread(id);
            }

            return null;
        }

        public IEnumerable<Post> GetAllByUser(int id)
        {
            if (id > 0)
            {
                return this.postDao.GetAllByUser(id);
            }

            return null;
        }
    }
}
