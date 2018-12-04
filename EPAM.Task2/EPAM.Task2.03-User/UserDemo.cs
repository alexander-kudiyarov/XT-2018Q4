using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._03_User
{
    internal class UserDemo
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine("Enter surname");
                string surname = Console.ReadLine();
                User.Check(surname);
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                User.Check(name);
                Console.WriteLine("Enter patronymic");
                string patronymic = Console.ReadLine();
                Console.WriteLine("Enter birth date");
                string birthday = Console.ReadLine();
                User ob = new User(surname, name, patronymic, birthday);
                Console.WriteLine($"User:" +
                    $"{Environment.NewLine}Name:\t\t{ob.Surname} {ob.Name} {ob.Patronymic}" +
                    $"{Environment.NewLine}Birth date:\t{ob.Birthday:D}" +
                    $"{Environment.NewLine}Age:\t\t{ob.Age:#}");
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}