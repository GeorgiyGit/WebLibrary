using AutoMapper;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Interfaces;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Categories.Application.Tags.QueryHandlers
{
    public class GetAllCompracedTagsHandler : IRequestHandler<GetAllCompracedTags, ICollection<TagGroupDTO>>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetAllCompracedTagsHandler(CategoriesDbContext dbContext,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<ICollection<TagGroupDTO>> Handle(GetAllCompracedTags request, CancellationToken cancellationToken)
        {
            var tagTypes = await _dbContext.TagTypes.Where(e => e.IsCompraced)
                                                .Include(e => e.Names)
                                                .Include(e => e.Tags)
                                                    .ThenInclude(e => e.Names)
                                                .ToListAsync(cancellationToken);

            var langCode = await _languageService.GetCurrentLanguageCode();

            var tagGroups = new List<TagGroupDTO>(tagTypes.Count);
            foreach (var tagType in tagTypes)
            {
                var tags = tagType.Tags.Where(e => !request.IsDeletedAvailable && e.IsDeleted).ToList();

                var mappedTags = _mapper.Map<List<SimpleTagDTO>>(tags);
                var mappedTagType = _mapper.Map<TagTypeDTO>(tagType);

                for (int i = 0; i < tags.Count(); i++)
                {
                    var name = tags[i].Names.Where(e => e.LanguageCode == langCode).FirstOrDefault();
                    if (name == null) name = tags[i].Names.First();

                    mappedTags[i].Name = name.Value;
                }

                var typeName = tagType.Names.Where(e => e.LanguageCode == langCode).FirstOrDefault();
                if (typeName == null) typeName = tagType.Names.First();

                mappedTagType.Name = typeName.Value;

                mappedTags = mappedTags.OrderBy(e => e.Name).ToList();

                tagGroups.Add(new TagGroupDTO()
                {
                    Tags = mappedTags,
                    Type = mappedTagType
                });
            }

            return tagGroups;
        }
    }
}
