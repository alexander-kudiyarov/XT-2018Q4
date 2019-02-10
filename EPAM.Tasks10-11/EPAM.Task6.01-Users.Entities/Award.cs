using System;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class Award
    {
        public Award(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }
    }
}