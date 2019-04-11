using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Thread
    {
        public int Id { get; }
        public string Subject { get; }
        public string StartedBy { get; }
        public int StartedById { get; }
        public DateTime LastMessage { get; }

        public Thread(int id, string subject, string startedBy, int startedById, DateTime lastMessage)
        {
            Id = id;
            Subject = subject;
            StartedBy = startedBy;
            StartedById = startedById;
            LastMessage = lastMessage;
        }
    }
}
