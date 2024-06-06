using BookChapters.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookChapters.Domain.Entities.Chapters
{
    public class BookChapter : Monitoring
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int BookId { get; set; }

        public string Text { get; set; }

        //public Customer Owner { get; set; }
        public string OwnerId { get; set; }

        public int? ChatId { get; set; }

        public BookChapterCollection Collection { get; set; }
        public int CollectionId { get; set; }
    }
}
