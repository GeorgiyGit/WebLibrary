using DetailedBooks.Application.Books.Commands;
using DetailedBooks.Application.Books.Events;
using DetailedBooks.Domain.Exceptions;
using DetailedBooks.Domain.Interfaces;
using DetailedBooks.Domain.Resources.Localization.Errors;
using DetailedBooks.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Application.Books.CommandHandlers
{
    public class CancelBookRatingHandler : IRequestHandler<CancelBookRating>
    {
        private readonly IMediator _mediator;
        private readonly DetailedBookDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ICustomerService _customerService;
        public CancelBookRatingHandler(IMediator mediator,
            DetailedBookDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ICustomerService customerService)
        {
            _mediator = mediator;
            _dbContext = dbContext;
            _localizer = localizer;
            _customerService = customerService;
        }
        public async Task Handle(CancelBookRating request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(e => e.Id == request.BookId && !e.IsDeleted)
                                             .FirstOrDefaultAsync();

            if (book == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookNotFound], HttpStatusCode.NotFound);

            var userId = await _customerService.GetCurrentUserId();
            if (userId == null) throw new HttpException(_localizer[ErrorMessagesPatterns.CustomerNotAuthorized], HttpStatusCode.BadRequest);

            var oldBookRating = await _dbContext.BookRatings.Where(e => e.BookId == request.BookId && e.CustomerId == userId && !e.IsDeleted)
                                                            .FirstOrDefaultAsync();

            if (oldBookRating != null)
            {
                _dbContext.BookRatings.Remove(oldBookRating);
                await _dbContext.SaveChangesAsync();

                await _mediator.Publish(new BookRatingChangedEvent()
                {
                    BookId = request.BookId
                });
            }
        }
    }
}
