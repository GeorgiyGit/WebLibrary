using Categories.Application.Tags.Commands;
using Categories.Domain.Entities;
using Categories.Domain.Entities.Tags;
using Categories.Infrastructure;
using MediatR;

namespace Categories.Application.Tags.CommandHandlers
{
    public class AddTagHandler : IRequestHandler<AddTag, int>
    {
        private readonly CategoriesDbContext _dbContext;

        public AddTagHandler(CategoriesDbContext dbContext)
        {
            _dbContext = dbContext;
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

            return tag.Id;
        }
    }
}
