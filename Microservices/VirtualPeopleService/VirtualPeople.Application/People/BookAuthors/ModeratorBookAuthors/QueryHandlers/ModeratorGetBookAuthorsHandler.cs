using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Queries;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.Entities.People;
using VirtualPeople.Domain.Extensions;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.QueryHandlers
{
    public class ModeratorGetBookAuthorsHandler : IRequestHandler<ModeratorGetBookAuthors, ICollection<ModeratorSimpleBookAuthorDTO>>
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IMapper _mapper;

        public ModeratorGetBookAuthorsHandler(VirtualPeopleDbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ICollection<ModeratorSimpleBookAuthorDTO>> Handle(ModeratorGetBookAuthors request, CancellationToken cancellationToken)
        {
            Expression<Func<BookAuthor, bool>> filterCondition = e => !(!request.IsDeletedAvailable && e.IsDeleted) && !(!request.IsModeratedAvailable && e.IsModerated);

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


            var mappedAuthors = _mapper.Map<ICollection<ModeratorSimpleBookAuthorDTO>>(authors);
            return mappedAuthors;
        }
    }
}
