using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Queries;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.Entities.People;
using VirtualPeople.Domain.Exceptions;
using VirtualPeople.Domain.Extensions;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.QueryHandlers
{
    public class CustomerGetCreatedBookAuthorsHandler : IRequestHandler<CustomerGetCreatedBookAuthors, ICollection<CustomerSimpleBookAuthorDTO>>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public CustomerGetCreatedBookAuthorsHandler(VirtualPeopleDbContext dbContext,
            IMapper mapper,
            ICustomerService customerService,
            IStringLocalizer<ErrorMessages> localizer)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _customerService = customerService;
            _localizer = localizer;
        }

        public async Task<ICollection<CustomerSimpleBookAuthorDTO>> Handle(CustomerGetCreatedBookAuthors request, CancellationToken cancellationToken)
        {
            var customerId = await _customerService.GetCurrentUserId();
            if (customerId == null) throw new HttpException(_localizer[ErrorMessages.UserIdNotFound], HttpStatusCode.BadRequest);

            Expression<Func<BookAuthor, bool>> filterCondition = e => !e.IsDeleted && e.AddedCustomerId == customerId;

            if (request.FilterStr != null && request.FilterStr != "")
            {
                filterCondition = filterCondition.And(e => e.Name.Contains(request.FilterStr));
            }

            var pageParameters = request.PageParameters;
            var authors = await _dbContext.BookAuthors.Where(filterCondition)
                                                      .OrderByDescending(e => e.BookCount)
                                                      .Skip((pageParameters.PageNumber - 1) * pageParameters.PageSize)
                                                      .Take(pageParameters.PageSize)
                                                      .ToListAsync();


            var mappedAuthors = _mapper.Map<ICollection<CustomerSimpleBookAuthorDTO>>(authors);
            return mappedAuthors;
        }
    }
}
