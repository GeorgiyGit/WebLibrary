using AutoMapper;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.Exceptions;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.Tags.QueryHandlers
{
    public class GetTagForUpdateHandler : IRequestHandler<GetTagForUpdate, TagForUpdateDTO>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly IMapper _mapper;

        public GetTagForUpdateHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _mapper = mapper;
        }
        public async Task<TagForUpdateDTO> Handle(GetTagForUpdate request, CancellationToken cancellationToken)
        {
            var tag = await _dbContext.Tags.Where(e => e.Id == request.Id && !(!request.IsDeletedAvailable && e.IsDeleted)).Include(e => e.Names).FirstOrDefaultAsync(cancellationToken);
            if (tag == null) throw new HttpException(_localizer[ErrorMessagesPatterns.TagNotFound], HttpStatusCode.NotFound);

            return _mapper.Map<TagForUpdateDTO>(tag);
        }
    }
}
