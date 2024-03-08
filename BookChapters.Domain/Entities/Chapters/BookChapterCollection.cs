using BookChapters.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookChapters.Domain.Entities.Chapters
{
    public class BookChapterCollection:Monitoring
    {
        public int Id { get; set; }
        public string TranslatorId { get; set; }

        //public Customer Owner { get; set; }
        public int OwnerId { get; set; }

        public int BookId { get; set; }

        public ICollection<BookChapter> Chapters { get; set; } = new HashSet<BookChapter>();
    }
}
