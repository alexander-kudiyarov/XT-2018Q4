using System;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class Award
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"id: {Id} | Title: {Title}";
        }
    }
}