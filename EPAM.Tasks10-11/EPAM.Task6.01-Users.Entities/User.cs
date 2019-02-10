using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class User
    {
        private TextInfo textInfo = new CultureInfo("us-US", false).TextInfo;

        public int Age
        {
            get
            {
                DateTime now = DateTime.Today;
                int age = now.Year - this.DateOfBirth.Year;
                if (this.DateOfBirth > now.AddYears(-age))
                {
                    age--;
                }

                return age;
            }
        }

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public byte[] Image { get; set; } = null;

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {this.textInfo.ToTitleCase($"{FirstName} {LastName}")}, Date of birth: {DateOfBirth:D}, Age: {Age}";
        }
    }
}