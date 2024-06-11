using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;
using VirtualPeople.Domain.DTOs.Shared;

namespace VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Queries
{
    public class CustomerGetCreatedBookAuthors : IRequest<ICollection<CustomerSimpleBookAuthorDTO>>
    {
        public string? FilterStr { get; set; } = "";
        public PageParameters PageParameters { get; set; }

        public bool IsModeratedAvailable { get; set; }
    }
}
