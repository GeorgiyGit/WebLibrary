using AutoMapper;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Exceptions;
using Categories.Domain.Interfaces;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.Tags.QueryHandlers
{
    public class GetAllBookTagsHandler : IRequestHandler<GetAllBookTags, ICollection<TagGroupDTO>>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetAllBookTagsHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<ICollection<TagGroupDTO>> Handle(GetAllBookTags request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(e => e.Id == request.BookId)
                                             .Include(e => e.Tags)
                                                .ThenInclude(e=>e.Names)
                                             .FirstOrDefaultAsync(cancellationToken);
            if (book == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookNotFound], HttpStatusCode.NotFound);

            var langCode = await _languageService.GetCurrentLanguageCode();

            var tagTypes = await _dbContext.TagTypes.Include(e => e.Names).ToListAsync(cancellationToken);


            var tagGroups = new List<TagGroupDTO>(tagTypes.Count);
            foreach(var tagType in tagTypes)
            {
                var tags = book.Tags.Where(e => e.TypeId == tagType.Id && !(!request.IsDeletedAvailable && e.IsDeleted)).ToList();

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
