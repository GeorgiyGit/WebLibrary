using AutoMapper;
using Categories.Application.TagTypes.Queries;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Exceptions;
using Categories.Domain.Interfaces;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.TagTypes.QueryHandlers
{
    public class GetTagTypeHandler : IRequestHandler<GetTagType, TagTypeDTO>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetTagTypeHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<TagTypeDTO> Handle(GetTagType request, CancellationToken cancellationToken)
        {
            var type = await _dbContext.TagTypes.Where(e => e.Id == request.Id).Include(e => e.Names).FirstOrDefaultAsync(cancellationToken);
            if (type == null) throw new HttpException(_localizer[ErrorMessagesPatterns.TagTypeNotFound], HttpStatusCode.NotFound);

            var mappedType = _mapper.Map<TagTypeDTO>(type);

            var lCode = await _languageService.GetCurrentLanguageCode();

            var name = type.Names.Where(e => e.LanguageCode == lCode).FirstOrDefault();
            if (name == null) name = type.Names.First();

            mappedType.Name = name.Value;

            return mappedType;
        }
    }
}
