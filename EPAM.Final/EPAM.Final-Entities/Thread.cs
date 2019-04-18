using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Thread
    {
        public Thread(int id, string subject, string startedBy, int startedById, DateTime lastMessage)
        {
            this.Id = id;
            this.Subject = subject;
            this.StartedBy = startedBy;
            this.StartedById = startedById;
            this.LastMessage = lastMessage;
        }

        public int Id { get; }

        public string Subject { get; }

        public string StartedBy { get; }

        public int StartedById { get; }

        public DateTime LastMessage { get; }
    }
}
