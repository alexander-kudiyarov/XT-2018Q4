using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var userLogic = EPAM.Final_Common.DependencyResolver.UserLogic;
            var postLogic = EPAM.Final_Common.DependencyResolver.PostLogic;
            var threadLogic = EPAM.Final_Common.DependencyResolver.ThreadLogic;
            Console.WriteLine(userLogic.Delete(8));
        }
    }
}
