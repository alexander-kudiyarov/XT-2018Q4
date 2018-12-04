using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Task2._03_User
{
    internal class User
    {
        internal User(string surname, string name, string patronymic, string birthday)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;
            this.Birthday = DateTime.Parse(birthday);
        }

        internal string Surname { get; }

        internal string Name { get; }

        internal string Patronymic { get; }

        internal DateTime Birthday { get; }

        internal double Age
        {
            get => (DateTime.Now - this.Birthday).TotalDays / 365.25;
        }

        internal static void Check(string str)
        {
            int div = 0;
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("String can't be empty");
            }
            else
            {
                if (char.IsLetter(str[0]) && char.IsLetter(str[str.Length - 1]))
                {
                    for (int i = 1; i < str.Length - 1; i++)
                    {
                        if (str[i] == '-')
                        {
                            div++;
                        }
                        else
                        {
                            if (!char.IsLetter(str[i]) || div > 1)
                            {
                                throw new ArgumentException("Error input format");
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Error input format");
                }
            }
        }
    }
}
