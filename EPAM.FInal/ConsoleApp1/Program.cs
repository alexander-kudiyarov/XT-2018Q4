using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var forumLogic = EPAM.Final_Common.DependencyResolver.ForumLogic;

            forumLogic.DeleteUser(4);

            foreach (var u in forumLogic.GetUsers())
            {
                Console.WriteLine(u.Id);
                Console.WriteLine(u.Username);
                foreach (var r in u.Roles)
                {
                    Console.Write($"{r} ");
                }

                Console.WriteLine();
            } 
        }
    }
}
