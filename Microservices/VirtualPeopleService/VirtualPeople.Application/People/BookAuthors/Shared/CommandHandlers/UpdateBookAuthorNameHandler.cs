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
    public class UpdateBookAuthorNameHandler : IRequestHandler<UpdateBookAuthorName>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        private ICustomerService _customerService;
        public UpdateBookAuthorNameHandler(VirtualPeopleDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ICustomerService customerService)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _customerService = customerService;
        }
        public async Task Handle(UpdateBookAuthorName request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _dbContext.BookAuthors.FindAsync(request.Id, cancellationToken);
            if (bookAuthor == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookAuthorNotFound], HttpStatusCode.NotFound);

            bookAuthor.Name = request.Name;
            bookAuthor.IsEdited = true;
            bookAuthor.DataLastEditTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync();
        }
    }
}
