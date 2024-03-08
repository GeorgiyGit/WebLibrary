using DetailedBooks.Domain.Entities.Customers;
using DetailedBooks.Domain.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Domain.Entities.Books
{
    public class BookRating : Monitoring
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }
        public string CustomerId { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public int Point { get; set; }
    }
}
