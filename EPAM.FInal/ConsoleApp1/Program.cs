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
            var postLogic = EPAM.Final_Common.DependencyResolver.PostLogic;
            var threadLogic = EPAM.Final_Common.DependencyResolver.ThreadLogic;
            Console.WriteLine();
            Console.WriteLine(threadLogic.GetId("tested"));
            Console.WriteLine(postLogic.New("hello", 40, "admin"));
        }
    }
}
