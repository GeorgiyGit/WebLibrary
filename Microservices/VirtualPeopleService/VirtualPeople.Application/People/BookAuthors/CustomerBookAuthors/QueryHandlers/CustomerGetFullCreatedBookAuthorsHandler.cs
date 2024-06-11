using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Queries;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;
using VirtualPeople.Domain.Exceptions;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.QueryHandlers
{
    public class CustomerGetFullCreatedBookAuthorsHandler : IRequestHandler<CustomerGetFullCreatedBookAuthor, CustomerFullBookAuthorDTO>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public CustomerGetFullCreatedBookAuthorsHandler(VirtualPeopleDbContext dbContext,
            IMapper mapper,
            IStringLocalizer<ErrorMessages> localizer)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _localizer = localizer;
        }

        public async Task<CustomerFullBookAuthorDTO> Handle(CustomerGetFullCreatedBookAuthor request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _dbContext.BookAuthors.FindAsync(request.Id, cancellationToken);
            if (bookAuthor == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookAuthorNotFound], HttpStatusCode.NotFound);

            return _mapper.Map<CustomerFullBookAuthorDTO>(bookAuthor);
        }
    }
}
