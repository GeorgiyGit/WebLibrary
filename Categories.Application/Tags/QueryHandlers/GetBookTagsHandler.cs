using AutoMapper;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
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
    public class GetBookTagsHandler : IRequestHandler<GetBookTags, ICollection<SimpleTagDTO>>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetBookTagsHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<ICollection<SimpleTagDTO>> Handle(GetBookTags request, CancellationToken cancellationToken)
        {
            var book = await _dbContext.Books.Where(e => e.Id == request.BookId)
                                             .Include(e => e.Tags)
                                                .ThenInclude(e => e.Names)
                                             .FirstOrDefaultAsync(cancellationToken);
            if (book == null) throw new HttpException(_localizer[ErrorMessagesPatterns.BookNotFound], HttpStatusCode.NotFound);

            var langCode = await _languageService.GetCurrentLanguageCode();

            var tags = book.Tags.Where(e => e.TypeId == request.TagTypeId && !request.IsDeletedAvailable && e.IsDeleted).ToList();
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
