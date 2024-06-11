using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Application.People.BookAuthors.Shared.Commands
{
    public class UpdateBookAuthorName : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
