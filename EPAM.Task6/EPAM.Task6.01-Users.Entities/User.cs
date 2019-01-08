using System;
using System.Collections.Generic;
using System.Text;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class User
    {
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

        public int Id { get; set; }

        public string Name { get; set; }

        public string ShowAwards()
        {
            StringBuilder awards = new StringBuilder();
            awards.Append("Awards:\t");
            foreach (Award award in this.AwardsList)
            {
                awards.Append($"{award.Title}, ");
            }

            awards.Remove(awards.Length - 2, 2);
            return awards.ToString();
        }

        public override string ToString()
        {
            return $"{Environment.NewLine}User:\tid: {Id} | Name: {Name} | Date of birth: {DateOfBirth:D} | Age: {Age}";
        }
    }
}