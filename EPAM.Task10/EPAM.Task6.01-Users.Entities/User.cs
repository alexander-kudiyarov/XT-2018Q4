using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class User
    {
        private TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

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

        public LinkedList<Award> AwardsList { get; } = new LinkedList<Award>();

        public DateTime DateOfBirth { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            StringBuilder temp = new StringBuilder();
            temp.Append($"ID: {Id} | Name: {FirstName} {LastName} | Date of birth: {DateOfBirth:D} | Age: {Age}");
            if (this.AwardsList.Count > 0)
            {
                temp.Append($" | Awards: ");
                foreach (Award award in this.AwardsList)
                {
                    temp.Append($"{award.Title}, ");
                }

                temp.Remove(temp.Length - 2, 2);
            }

            return this.textInfo.ToTitleCase(temp.ToString());
        }
    }
}