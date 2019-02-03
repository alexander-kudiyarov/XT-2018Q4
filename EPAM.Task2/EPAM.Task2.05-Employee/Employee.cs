using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EPAM.Task2._03_User;

namespace EPAM.Task2._05_Employee
{
    public class Employee : User
    {
        private double workExperience;

        public Employee(string surname, string name, string patronymic, string birthday, double workExperience, string position) : base(surname, name, patronymic, birthday)
        {
            this.WorkExperience = workExperience;
            this.Position = position;
        }

        public string Position { get; }

        public double WorkExperience
        {
            get => this.workExperience;
            private set
            {
                if (value >= 0)
                {
                    this.workExperience = value;
                }
                else
                {
                    throw new ArgumentException("Work experience cannot be less than zero");
                }
            }
        }

        public override string ToString()
        {
            return $"User: Name: {this.Surname} {this.Name} {this.Patronymic} | Birth date: {this.Birthday:D} | Age: {this.Age:#} | Work experience: {this.WorkExperience} | Position: {this.Position}";
        }
    }
}
