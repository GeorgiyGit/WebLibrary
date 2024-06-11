using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Application.People.BookAuthors.AdminBookAuthors.Commands
{
    public class RemoveBookAuthor : IRequest
    {
        public int Id { get; set; }
    }
}
