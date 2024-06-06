using DetailedBooks.Application.Books.Commands;
using DetailedBooks.Application.Books.Events;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Domain.Resources.Constants;
using DetailedBooks.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DetailedBooks.Application.Books.EventHandler
{
    public class BookRatingChangedEventHandler : INotificationHandler<BookRatingChangedEvent>
    {
        private readonly IMediator _mediator;
        public BookRatingChangedEventHandler(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task Handle(BookRatingChangedEvent notification, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CalculateBookRatingPointsStatistic()
            {
                BookId = notification.BookId
            });
        }
    }
}
