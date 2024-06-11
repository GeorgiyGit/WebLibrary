using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Application.People.BookAuthors.UserBookAuthors.Queries
{
    public class UserGetBookAuthors : IRequest<ICollection<SimpleBookAuthorDTO>>
    {
        public string? FilterStr { get; set; } = "";
        public PageParameters PageParameters { get; set; }
    }
}
