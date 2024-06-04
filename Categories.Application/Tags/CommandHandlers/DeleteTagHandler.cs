using Categories.Application.Tags.Commands;
using Categories.Domain.Exceptions;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Domain.Resources.Tags;
using Categories.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.Tags.CommandHandlers
{
    public class DeleteTagHandler : IRequestHandler<DeleteTag>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly IDistributedCache _distributedCache;

        public DeleteTagHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _distributedCache = distributedCache;
        }
        public async Task Handle(DeleteTag request, CancellationToken cancellationToken)
        {
            var tag = await _dbContext.Tags.Where(e => e.Id == request.Id)
                                           .Include(e => e.Type)
                                           .FirstOrDefaultAsync(cancellationToken);
            if (tag == null) throw new HttpException(_localizer[ErrorMessagesPatterns.TagNotFound], HttpStatusCode.NotFound);

            if (tag.IsDeleted) return;

            tag.IsDeleted = true;
            tag.DataLastDeleteTime = DateTime.UtcNow;

            await _dbContext.SaveChangesAsync(cancellationToken);

            var langs = Languages.GetAllLangCodes();
            foreach (var langCode in langs)
            {
                if (tag.Type.IsCompraced)
                {
                    await _distributedCache.RemoveAsync("CompracedTags_" + langCode, cancellationToken);
                }
                await _distributedCache.RemoveAsync("Tags_" + tag.TypeId + "_" + langCode, cancellationToken);
            }
        }
    }
}
