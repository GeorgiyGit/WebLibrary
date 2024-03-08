using MediatR;

namespace DetailedBooks.Application.Books.Commands
{
    public class AddBookRating : IRequest
    {
        public int BookId { get; set; }
        public int Point { get; set; }
    }
}
