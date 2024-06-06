using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Entities.Books
{
    public class BookVisibilityStatus
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
