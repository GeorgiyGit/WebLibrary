using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Entities.Authors
{
    public class Author
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public MyImage? Image { get; set; }
        public string? ImageId { get; set; }

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
