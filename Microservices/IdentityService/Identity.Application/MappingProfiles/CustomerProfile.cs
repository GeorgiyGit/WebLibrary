using Identity.Application.Account.Commands;
using Identity.Application.Account.Queries;
using Identity.Domain.DTOs.AccountDTOs.Requests;

namespace Identity.Application.MappingProfiles
{
    public class CustomerProfile : AutoMapper.Profile
    {
        public CustomerProfile()
        {
            CreateMap<SignUpRequest, SignUp>();
            CreateMap<LogInRequest, LogIn>();
        }
    }
}
