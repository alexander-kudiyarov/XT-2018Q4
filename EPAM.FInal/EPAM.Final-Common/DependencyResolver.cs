using EPAM.Final_DAL.Interfaces;
using EPAM.Final_BLL.Interfaces;
using EPAM.Final_DAL;
using EPAM.Final_BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
