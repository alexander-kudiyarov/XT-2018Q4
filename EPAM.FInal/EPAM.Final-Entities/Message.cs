using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Message
    {
        public int Id { get; }
        public string Text { get; }
        public Topic Topic { get; }
        public User Author { get; }
        public DateTime PublishDate { get; }
        public DateTime? EditDate { get; }
    }
}
