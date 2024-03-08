using MediatR;

namespace DetailedBooks.Application.Books.Events
{
    public class BookRatingChangedEvent:INotification
    {
        public int BookId { get; set; }
    }
}
