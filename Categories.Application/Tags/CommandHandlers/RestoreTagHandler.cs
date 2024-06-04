﻿using Categories.Application.Tags.Commands;
using Categories.Domain.Exceptions;
using Categories.Domain.Resources.Localization.Errors;
using Categories.Infrastructure;
using MediatR;
using Microsoft.Extensions.Localization;
using System.Net;

namespace Categories.Application.Tags.CommandHandlers
{
    public class RestoreTagHandler : IRequestHandler<RestoreTag>
    {
        private readonly CategoriesDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;

        public RestoreTagHandler(CategoriesDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer)
        {
            _dbContext = dbContext;
            _localizer = localizer;
        }
        public async Task Handle(RestoreTag request, CancellationToken cancellationToken)
        {
            var tag = await _dbContext.Tags.FindAsync(request.Id, cancellationToken);
            if (tag == null) throw new HttpException(_localizer[ErrorMessagesPatterns.TagNotFound], HttpStatusCode.NotFound);

            if (!tag.IsDeleted) return;

            tag.IsDeleted = false;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
