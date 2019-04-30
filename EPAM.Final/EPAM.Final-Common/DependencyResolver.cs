using EPAM.Final_BLL;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL;
using EPAM.Final_DAL.Interfaces;

namespace EPAM.Final_Common
{
    public static class DependencyResolver
    {
        private static IUserDao userDao;
        private static IThreadDao threadDao;
        private static IPostDao postDao;
        private static IUserLogic userLogic;
        private static IThreadLogic threadLogic;
        private static IPostLogic postLogic;

        public static IUserDao UserDao => userDao ?? (userDao = new UserSQLDao());

        public static IThreadDao ThreadDao => threadDao ?? (threadDao = new ThreadSQLDao());

        public static IPostDao PostDao => postDao ?? (postDao = new PostSQLDao());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao));

        public static IThreadLogic ThreadLogic => threadLogic ?? (threadLogic = new ThreadLogic(ThreadDao));

        public static IPostLogic PostLogic => postLogic ?? (postLogic = new PostLogic(PostDao));
    }
}