using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;

namespace VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Queries
{
    public class ModeratorGetFullBookAuthor : IRequest<ModeratorFullBookAuthorDTO>
    {
        public int Id { get; set; }
    }
}
