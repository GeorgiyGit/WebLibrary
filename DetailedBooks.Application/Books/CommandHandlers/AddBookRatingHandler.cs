using DetailedBooks.Application.Books.Commands;
using DetailedBooks.Domain.Resources.Localization.Errors;
using DetailedBooks.Infrastructure;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Net;
using DetailedBooks.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using DetailedBooks.Domain.Exceptions;
using DetailedBooks.Domain.Entities.Books;
using DetailedBooks.Application.Books.Events;

namespace DetailedBooks.Application.Books.CommandHandlers
{
    public class AddBookRatingHandler : IRequestHandler<AddBookRating>
    {
        private readonly DetailedBookDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ICustomerService _customerService;
        private readonly IMediator _mediator;
        public AddBookRatingHandler(DetailedBookDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ICustomerService customerService,
            IMediator mediator)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _customerService = customerService;
            _mediator = mediator;
        }

        public async Task Handle(AddBookRating request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(e => e.Id == request.BookId && !e.IsDeleted)
                                             .FirstOrDefaultAsync();

            if (book == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookNotFound], HttpStatusCode.NotFound);

            var userId = await _customerService.GetCurrentUserId();
            if (userId == null) throw new HttpException(_localizer[ErrorMessagesPatterns.CustomerNotAuthorized], HttpStatusCode.BadRequest);

            var oldBookRating = await _dbContext.BookRatings.Where(e => e.BookId == request.BookId && e.CustomerId == userId && !e.IsDeleted)
                                                            .FirstOrDefaultAsync();

            if (oldBookRating == null)
            {
                var newRating = new BookRating()
                {
                    Point = request.Point,
                    BookId = request.BookId,
                    CustomerId = userId
                };
                await _dbContext.BookRatings.AddAsync(newRating);

                oldBookRating = newRating;
                book.RatingsCount++;
                book.TotalRating = (book.TotalRating * (double)(book.RatingsCount - 1) + (double)request.Point) / (double)book.RatingsCount;
            }
            else
            {
                book.TotalRating = (book.TotalRating * (double)book.RatingsCount - oldBookRating.Point + request.Point) / (double)book.RatingsCount;
                oldBookRating.Point++;
            }

            await _dbContext.SaveChangesAsync();

            await _mediator.Publish(new BookRatingChangedEvent()
            {
                BookId = request.BookId
            });
        }
    }
}