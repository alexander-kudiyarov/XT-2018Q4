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
        double workExperience;
        internal Employee(string surname, string name, string patronymic, string birthday, double workExperience, string position) : base(surname, name, patronymic, birthday)
        {
            this.WorkExperience = workExperience;
            this.Position = position;
        }

        internal double WorkExperience
        {
            get => this.workExperience;
            set
            {
                if (value >= 0)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new ArgumentException("Work Experience shoul be positive");
                }
            }
        }

        internal string Position { get; }

        public override void Show()
        {
            Console.WriteLine($"User:" +
                $"{Environment.NewLine}Name:\t\t{this.Surname} {this.Name} {this.Patronymic}" +
                $"{Environment.NewLine}Birth date:\t{this.Birthday:D}" +
                $"{Environment.NewLine}Age:\t\t{this.Age:#}" +
                $"{Environment.NewLine}work experience:{this.WorkExperience}" +
                $"{Environment.NewLine}Position:\t{this.Position}");
        }
    }
}
