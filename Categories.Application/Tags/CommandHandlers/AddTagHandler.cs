using Categories.Application.Tags.Commands;
using Categories.Domain.Entities;
using Categories.Domain.Entities.Tags;
using Categories.Domain.Resources.Tags;
using Categories.Infrastructure;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;

namespace Categories.Application.Tags.CommandHandlers
{
    public class AddTagHandler : IRequestHandler<AddTag, int>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IDistributedCache _distributedCache;
        public AddTagHandler(CategoriesDbContext dbContext,
            IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }

        public async Task<int> Handle(AddTag request, CancellationToken cancellationToken)
        {
            var tag = new Tag()
            {
                TypeId = request.TypeId
            };
            foreach (var name in request.Names)
            {
                var translatedText = new TagTranslatedText()
                {
                    Value = name.Value,
                    ValueEntity = tag,
                    LanguageCode = name.LanguageCode
                };
                await _dbContext.TagTranslatedTexts.AddAsync(translatedText, cancellationToken);
            }

            await _dbContext.Tags.AddAsync(tag, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);


            var langs = Languages.GetAllLangCodes();
            foreach (var langCode in langs)
            {
                await _distributedCache.RemoveAsync("Tags_" + request.TypeId + "_" + langCode, cancellationToken);

                var type = await _dbContext.TagTypes.FindAsync(request.TypeId, cancellationToken);
                if (type != null && type.IsCompraced)
                {
                    await _distributedCache.RemoveAsync("CompracedTags_" + langCode, cancellationToken);
                }
            }

            return tag.Id;
        }
    }
}
