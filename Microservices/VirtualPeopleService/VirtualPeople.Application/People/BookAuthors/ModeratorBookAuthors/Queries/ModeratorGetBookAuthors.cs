using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Queries
{
    public class ModeratorGetBookAuthors : IRequest<ICollection<ModeratorSimpleBookAuthorDTO>>
    {
        public string? FilterStr { get; set; } = "";
        public PageParameters PageParameters { get; set; }

        public bool IsDeletedAvailable { get; set; }
        public bool IsModeratedAvailable { get; set; }
    }
}
