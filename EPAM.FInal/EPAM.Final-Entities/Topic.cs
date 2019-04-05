using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Topic
    {
        public string Subject { get; }
        public User StartedBy { get; }
        public DateTime LastMessageDateTime { get; }
    }
}
