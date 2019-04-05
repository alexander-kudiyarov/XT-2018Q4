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
        public string StartedBy { get; }
        public DateTime LastMessage { get; }

        public Topic(string subject, string startedBy, DateTime lastMessage)
        {
            Subject = subject;
            StartedBy = startedBy;
            LastMessage = lastMessage;
        }
    }
}
