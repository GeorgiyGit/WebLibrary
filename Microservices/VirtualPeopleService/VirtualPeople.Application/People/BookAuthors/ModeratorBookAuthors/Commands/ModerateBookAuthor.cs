using MediatR;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Commands
{
    public class ModerateBookAuthor : IRequest
    {
        public int Id { get; set; }
    }
}
