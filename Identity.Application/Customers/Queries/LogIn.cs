using Identity.Domain.DTOs.CustomerDTOs.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Customers.Queries
{
    public class LogIn : IRequest<TokenDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
