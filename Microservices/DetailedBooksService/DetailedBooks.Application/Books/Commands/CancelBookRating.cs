using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetailedBooks.Application.Books.Commands
{
    public class CancelBookRating:IRequest
    {
        public int BookId { get; set; }
    }
}
