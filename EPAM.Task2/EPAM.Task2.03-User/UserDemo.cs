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

                User user = new User(surname, name, patronymic, birthday);
                user.Show();
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