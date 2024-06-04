using Categories.Application.Tags.Commands;
using Categories.Domain.Entities;
using Categories.Domain.Exceptions;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.Tags.CommandHandlers
{
    public class UpdateTagHandler : IRequestHandler<UpdateTag>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public UpdateTagHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }
        public async Task Handle(UpdateTag request, CancellationToken cancellationToken)
        {
            var tag = await _dbContext.Tags.FindAsync(request.Id, cancellationToken);
            if (tag == null) throw new HttpException(_localizer[ErrorMessagesPatterns.TagNotFound], HttpStatusCode.NotFound);

            var oldNames = await _dbContext.TagTranslatedTexts.Where(e => e.ValueEntityId == tag.Id)
                                                              .ToListAsync(cancellationToken);

            _dbContext.TagTranslatedTexts.RemoveRange(oldNames);

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

            tag.IsEdited = true;
            tag.DataLastEditTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
