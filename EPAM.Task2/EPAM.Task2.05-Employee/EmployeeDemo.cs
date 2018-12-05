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

                Employee employee = new Employee(surname, name, patronymic, birthday, workExperience, position);
                employee.Show();
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
