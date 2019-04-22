using EPAM.Final_Common;
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
            var userLogic = DependencyResolver.UserLogic;
            var postLogic = DependencyResolver.PostLogic;
            var threadLogic = DependencyResolver.ThreadLogic;
            Console.WriteLine(userLogic.Delete(8));
        }
    }
}
