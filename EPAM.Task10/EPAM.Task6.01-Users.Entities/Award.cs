using System;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class Award
    {
        public Award(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}