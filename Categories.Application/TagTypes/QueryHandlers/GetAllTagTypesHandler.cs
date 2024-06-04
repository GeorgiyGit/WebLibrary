using AutoMapper;
using Categories.Application.TagTypes.Queries;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using Categories.Domain.Interfaces;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Categories.Application.TagTypes.QueryHandlers
{
    public class GetAllTagTypesHandler : IRequestHandler<GetAllTagTypes, ICollection<TagTypeDTO>>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public GetAllTagTypesHandler(CategoriesDbContext dbContext,
            ILanguageService languageService,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _languageService = languageService;
            _mapper = mapper;
        }
        public async Task<ICollection<TagTypeDTO>> Handle(GetAllTagTypes request, CancellationToken cancellationToken)
        {
            var types = await _dbContext.TagTypes.Include(e => e.Names).ToListAsync(cancellationToken);
            
            var lCode = await _languageService.GetCurrentLanguageCode();

            var mappedTypes = new List<TagTypeDTO>(types.Count);
            foreach(var type in types)
            {
                var mappedType = _mapper.Map<TagTypeDTO>(type);

                var name = type.Names.Where(e => e.LanguageCode == lCode).FirstOrDefault();
                if (name == null) name = type.Names.First();

                mappedType.Name = name.Value;

                mappedTypes.Add(mappedType);
            }

            return mappedTypes;
        }
    }
}
