using Ardalis.GuardClauses;
using Microsoft.Extensions.Localization;
using Microsoft.VisualBasic.FileIO;
using System.Net;
using VirtualPeople.Domain.Exceptions;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Api.Guards
{
    public static class CustomerChangeBookAuthorGuard
    {
        public static async Task NotBookAuthorOwner(this IGuardClause guardClause, int bookAuthorId, VirtualPeopleDbContext dbContext, IStringLocalizer<ErrorMessages> localizer, ICustomerService customerService)
        {
            var author = await dbContext.BookAuthors.FindAsync(bookAuthorId);
            if (author == null) throw new HttpException(localizer[ErrorMessagesPatterns.BookAuthorNotFound], System.Net.HttpStatusCode.NotFound);

            var ownerId = await customerService.GetCurrentUserId();
            if (ownerId == null) throw new HttpException(localizer[ErrorMessagesPatterns.UserIdNotFound], HttpStatusCode.BadRequest);

            if (author.AddedCustomerId != ownerId) throw new HttpException(localizer[ErrorMessagesPatterns.UserDontHaveRules], HttpStatusCode.BadRequest);
        }
    }
}
