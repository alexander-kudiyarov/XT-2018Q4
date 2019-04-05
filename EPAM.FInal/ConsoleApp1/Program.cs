using EPAM.Final_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var forumLogic = DependencyResolver.ForumLogic;

            Console.WriteLine("users:");
            foreach(var user in forumLogic.GetUsers())
            {
                Console.WriteLine($"{user.Username}, {user.Password}, {user.IsAdmin}");
            }

            Console.WriteLine();
            Console.WriteLine("topics");
            foreach (var t in forumLogic.GetTopics("three"))
            {
                Console.WriteLine($"{t.Subject}, {t.StartedBy}, {t.LastMessage}");
            }

            Console.WriteLine("ok");
        }
    }
}
