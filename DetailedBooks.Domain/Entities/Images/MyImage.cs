using DetailedBooks.Domain.Entities.Authors;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Entities.Customers;

namespace DetailedBooks.Domain.Entities.Images
{
    public class MyImage
    {
        public string Id { get; set; }
        
        public string FullPath { get; set; }
        public string PathWithoutProvider { get; set; }

        public Book? Book { get; set; }
        public int? BookId { get; set; }

        public Customer? Customer { get; set; }
        public string? CustomerId { get; set; }

        public Author? Author { get; set; }
        public int? AuthorId { get; set; }
    }
}
