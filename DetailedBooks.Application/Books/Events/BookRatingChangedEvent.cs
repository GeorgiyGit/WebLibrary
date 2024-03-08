using MediatR;

namespace DetailedBooks.Application.Books.Events
{
    public class BookRatingChangedEvent:INotification
    {
        public int BookRatingId { get; set; }
        public int BookId { get; set; }
    }
}
