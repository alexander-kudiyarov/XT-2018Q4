using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._05_Employee
{
    internal class EmployeeDemo
    {
        internal static void Main()
        {
            try
            {
                Console.WriteLine("Enter surname");
                string surname = Console.ReadLine();
                Employee.Check(surname);
                Console.WriteLine("Enter name");
                string name = Console.ReadLine();
                Employee.Check(name);
                Console.WriteLine("Enter patronymic");
                string patronymic = Console.ReadLine();
                Console.WriteLine("Enter birth date");
                string birthday = Console.ReadLine();
                Console.WriteLine("Enter work experience");
                double workExperience = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter position");
                string position = Console.ReadLine();
                Employee ob = new Employee(surname, name, patronymic, birthday, workExperience, position);
                Console.WriteLine($"User:" +
                    $"{Environment.NewLine}Name:\t\t{ob.Surname} {ob.Name} {ob.Patronymic}" +
                    $"{Environment.NewLine}Birth date:\t{ob.Birthday:D}" +
                    $"{Environment.NewLine}Age:\t\t{ob.Age:#}" +
                    $"{Environment.NewLine}work experience:{ob.WorkExperience}" +
                    $"{Environment.NewLine}Position:\t{ob.Position}");
            }
            catch (ArgumentException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.Message);
            }
            catch (StackOverflowException exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
