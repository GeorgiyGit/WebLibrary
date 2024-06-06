using Identity.Domain.DTOs.AccountDTOs.Responses;
using MediatR;

namespace Identity.Application.Account.Queries
{
    public class LogIn : IRequest<TokenDTO>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
