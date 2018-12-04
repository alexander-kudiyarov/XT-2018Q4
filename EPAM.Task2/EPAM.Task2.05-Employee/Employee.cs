using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Task2._03_User;

namespace EPAM.Task2._05_Employee
{
    internal class Employee : User
    {
        internal Employee(string surname, string name, string patronymic, string birthday, double workExperience, string position) : base(surname, name, patronymic, birthday)
        {
            this.WorkExperience = workExperience;
            this.Position = position;
        }

        internal double WorkExperience { get; }

        internal string Position { get; }
    }
}
