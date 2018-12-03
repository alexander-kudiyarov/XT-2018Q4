using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._03_User
{
    class User
    {
        internal string Surname { get; }
        internal string Name { get; }
        internal string Patronymic { get; }
        internal DateTime Birthday { get; }
        internal double Age
        {
            get => (DateTime.Now - Birthday).TotalDays / 365.25;
        }
        internal User (string surname, string name, string patronymic, string birthday)
        {
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            Birthday = DateTime.Parse(birthday);
        }
    }
}
