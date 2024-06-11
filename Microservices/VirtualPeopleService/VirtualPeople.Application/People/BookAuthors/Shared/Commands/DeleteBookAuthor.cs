using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Application.People.BookAuthors.Shared.Commands
{
    public class DeleteBookAuthor : IRequest
    {
        public int Id { get; set; }
    }
}
