using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Queries
{
    public class CustomerGetFullCreatedBookAuthor : IRequest<CustomerFullBookAuthorDTO>
    {
        public int Id { get; set; }
    }
}
