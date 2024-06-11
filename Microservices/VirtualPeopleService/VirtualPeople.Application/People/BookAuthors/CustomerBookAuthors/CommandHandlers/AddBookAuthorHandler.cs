using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Commands;
using VirtualPeople.Domain.Entities.People;
using VirtualPeople.Domain.Exceptions;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.CommandHandlers
{
    public class AddBookAuthorHandler : IRequestHandler<AddBookAuthor, int>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        private ICustomerService _customerService;
        public AddBookAuthorHandler(VirtualPeopleDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ICustomerService customerService)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _customerService = customerService;
        }

        public async Task<int> Handle(AddBookAuthor request, CancellationToken cancellationToken)
        {
            var customerId = await _customerService.GetCurrentUserId();
            if (customerId == null) throw new HttpException(_localizer[ErrorMessagesPatterns.UserIdNotFound], HttpStatusCode.BadRequest);

            var newAuthor = new BookAuthor()
            {
                Name = request.Name,
                AddedCustomerId = customerId
            };

            //save author image

            await _dbContext.BookAuthors.AddAsync(newAuthor);
            await _dbContext.SaveChangesAsync();

            return newAuthor.Id;
        }
    }
}
