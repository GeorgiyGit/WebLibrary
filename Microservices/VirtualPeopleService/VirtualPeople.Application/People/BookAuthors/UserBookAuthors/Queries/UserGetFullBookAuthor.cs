using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;

namespace VirtualPeople.Application.People.BookAuthors.UserBookAuthors.Queries
{
    public class UserGetFullBookAuthor : IRequest<FullBookAuthorDTO>
    {
        public int Id { get; set; }
    }
}
