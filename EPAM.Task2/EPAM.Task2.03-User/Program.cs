using System;

namespace EPAM.Task2._03_User
{
    public class Program
    {
        public static void Main()
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
                Console.WriteLine(user.ToString());
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