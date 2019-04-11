using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPAM.Final_Entities
{
    public class Post
    {
        public int Id { get; }
        public string Text { get; }
        public string Thread { get; }
        public string Author { get; }
        public int AuthorId { get; }
        public DateTime PublishDate { get; }
        public DateTime? EditDate { get; }

        public Post(int id, string text, string thread, string author, int authorId, DateTime publishDate, DateTime? editDate)
        {
            Id = id;
            Text = text;
            Thread = thread;
            Author = author;
            AuthorId = authorId;
            PublishDate = publishDate;
            EditDate = editDate;
        }
    }
}
