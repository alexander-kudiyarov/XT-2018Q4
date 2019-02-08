using System;

namespace EPAM.Task6._01_Users.Entities
{
    [Serializable]
    public class Award
    {
        public byte[] Image { get; set; } = null;

        public string Title { get; set; }
    }
}