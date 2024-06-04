using AutoMapper;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.Entities.Tags;
using Categories.Domain.Extensions;
using Categories.Domain.Interfaces;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Linq.Expressions;

namespace Categories.Application.Tags.QueryHandlers
{
    public class GetTagsHandler : IRequestHandler<GetTags, ICollection<SimpleTagDTO>>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetTagsHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<ICollection<SimpleTagDTO>> Handle(GetTags request, CancellationToken cancellationToken)
        {
            var langCode = await _languageService.GetCurrentLanguageCode();

            Expression<Func<Tag, bool>> filterCondition = e => e.TypeId == request.TypeId && !request.IsDeletedAvailable && e.IsDeleted;

            if (request.FilterStr != null && request.FilterStr != "")
            {
                filterCondition = filterCondition.And(e => e.Names
                                                 .Any(nt => nt.LanguageCode == langCode && nt.Value.Contains(request.FilterStr)));
            }

            var tags = await _dbContext.Tags.Where(filterCondition).ToListAsync(cancellationToken);
            var mappedTags = _mapper.Map<List<SimpleTagDTO>>(tags);

            for (int i = 0; i < tags.Count(); i++)
            {
                var name = tags[i].Names.Where(e => e.LanguageCode == langCode).FirstOrDefault();
                if (name == null) name = tags[i].Names.First();

                mappedTags[i].Name = name.Value;
            }

            mappedTags = mappedTags.OrderBy(e => e.Name).ToList();
            return mappedTags;
        }
    }
}
