using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Post
    {
        public Post(int id, string text, string thread, string author, int authorId, DateTime publishDate, DateTime? editDate)
        {
            this.Id = id;
            this.Text = text;
            this.Thread = thread;
            this.Author = author;
            this.AuthorId = authorId;
            this.PublishDate = publishDate;
            this.EditDate = editDate;
        }

        public int Id { get; }

        public string Text { get; }

        public string Thread { get; }

        public string Author { get; }

        public int AuthorId { get; }

        public DateTime PublishDate { get; }

        public DateTime? EditDate { get; }
    }
}
