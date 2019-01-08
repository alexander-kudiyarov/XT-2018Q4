using EPAM.Task6._01_Users.BLL;
using EPAM.Task6._01_Users.BLL.Interfaces;
using EPAM.Task6._01_Users.DAL;

namespace EPAM.Task6._01_Users.Common
{
    public static class DependencyResolver
    {
        private static IUserDao userDaoOb;

        private static IUserLogic userLogic;

        public static IUserDao UserDao => userDaoOb ?? (userDaoOb = new UserDao());

        public static IUserLogic UserLogic => userLogic ?? (userLogic = new UserLogic(UserDao));
    }
}