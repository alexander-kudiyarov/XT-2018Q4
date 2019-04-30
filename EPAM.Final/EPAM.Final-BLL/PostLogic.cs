using System.Collections.Generic;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL.Interfaces;
using EPAM.Final_Entities;

namespace EPAM.Final_BLL
{
    public class PostLogic : ForumLogic, IPostLogic
    {
        private readonly IPostDao postDao;

        public PostLogic(IPostDao postDao)
        {
            this.postDao = postDao;
        }

        public bool New(string text, int threadId, string username)
        {
            if (threadId > 0 && !string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(username))
            {
                if (this.postDao.New(text, threadId, username, out int id))
                {
                    Log.Info($"New Message, ID: {id}");

                    return true;
                }
            }

            return false;
        }

        public bool Edit(int id, string text)
        {
            if (id > 0 && !string.IsNullOrWhiteSpace(text))
            {
                if (this.postDao.Edit(id, text))
                {
                    Log.Info($"Post with ID = {id} was edited");

                    return true;
                }
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (id > 0)
            {
                if (this.postDao.Delete(id))
                {
                    Log.Info($"Post ID: {id} was deleted");

                    return true;
                }
            }

            return false;
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