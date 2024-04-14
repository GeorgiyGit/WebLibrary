using Identity.Domain.DTOs.AccountDTOs.Responses;
using MediatR;

namespace Identity.Application.Account.Commands
{
    public class SignUp : IRequest<TokenDTO>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
