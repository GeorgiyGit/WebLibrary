using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Entities.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Entities.Customers
{
    public class Customer
    {
        public string Id { get; set; }
        public string Username { get; set; }
        
        public MyImage? Avatar { get; set; }
        public string? AvatarId { get; set; }

        public ICollection<Book> CreatedBooks { get; set; } = new HashSet<Book>();
        public ICollection<BookRating> BookRatings { get; set; } = new HashSet<BookRating>(); 

        public string Email { get; set; }
    }
}
