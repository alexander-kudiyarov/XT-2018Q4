using System;

namespace EPAM.Task2._03_User
{
    public class User
    {
        public User(string surname, string name, string patronymic, string birthday)
        {
            this.Surname = surname;
            this.Name = name;
            this.Patronymic = patronymic;

            if (DateTime.Parse(birthday) > DateTime.Now)
            {
                throw new ArgumentException("User birthday cannot be in the future");
            }
            else
            {
                this.Birthday = DateTime.Parse(birthday);
            }
        }

        public double Age
        {
            get
            {
                var age = DateTime.Today.Year - this.Birthday.Year;

                if (this.Birthday > DateTime.Today.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public DateTime Birthday { get; }

        public string Name { get; }

        public string Patronymic { get; }

        public string Surname { get; }

        public static void Check(string str)
        {
            int div = 0;
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("This string can't be empty");
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
                                throw new ArgumentException("Error string format");
                            }
                        }
                    }
                }
                else
                {
                    throw new ArgumentException("Error string format");
                }
            }
        }

        public override string ToString()
        {
            return $"User: Name: {this.Surname} {this.Name} {this.Patronymic} | Birth date: {this.Birthday:D} | Age: {this.Age:#}";
        }
    }
}