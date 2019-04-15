using EPAM.Final_BLL;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL;
using EPAM.Final_DAL.Interfaces;

namespace EPAM.Final_Common
{
    public static class DependencyResolver
    {
        private static IForumDao forumDao;
        private static IForumLogic forumLogic;

        public static IForumDao ForumDao => forumDao ?? (forumDao = new ForumDao());

        public static IForumLogic ForumLogic => forumLogic ?? (forumLogic = new ForumLogic(ForumDao));
    }
}
