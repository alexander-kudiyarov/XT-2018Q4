using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._03_User
{
    class UserDemo
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Enter surname");
                string surname = Console.ReadLine();
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter patronymic");
                string patronymic = Console.ReadLine();
                Console.WriteLine("Enter birth date");
                string birthday = Console.ReadLine();
                User ob = new User(surname, name, patronymic, birthday);
                Console.WriteLine($"User:" +
                    $"{Environment.NewLine}Name:\t{ob.Surname} {ob.Name} {ob.Patronymic}" +
                    $"{Environment.NewLine}Date:\t{ob.Birthday:D}" +
                    $"{Environment.NewLine}Age:\t{ob.Age:#}");
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}