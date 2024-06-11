using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Application.People.BookAuthors.Shared.Commands;
using VirtualPeople.Domain.Exceptions;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Application.People.BookAuthors.Shared.CommandHandlers
{
    public class RestoreBookAuthorHandler : IRequestHandler<RestoreBookAuthor>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public RestoreBookAuthorHandler(VirtualPeopleDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;

        }
        public async Task Handle(RestoreBookAuthor request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _dbContext.BookAuthors.FindAsync(request.Id, cancellationToken);
            if (bookAuthor == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookAuthorNotFound], HttpStatusCode.NotFound);

            if (!bookAuthor.IsDeleted) return;

            bookAuthor.IsDeleted = false;

            await _dbContext.SaveChangesAsync();
        }
    }
}
