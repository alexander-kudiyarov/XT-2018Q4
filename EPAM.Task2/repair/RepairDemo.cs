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
                string surname = "Kudiyarov";
                Employee.Check(surname);

                string name = "Alexander";
                Employee.Check(name);

                string patronymic = "Mikhaylovich";

                string birthday = "16-03-1993";

                double workExperience = -1;

                string position = "Home";

                Employee ob = new Employee(surname, name, patronymic, birthday, workExperience, position);

                ob.Show();

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
