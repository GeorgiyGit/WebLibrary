using Identity.Application.Customers.Commands;
using Identity.Application.Customers.Queries;
using Identity.Domain.DTOs.CustomerDTOs.Responses;
using Identity.Domain.Entities.Customers;
using Identity.Domain.Exceptions;
using Identity.Domain.Resources.Customers;
using Identity.Domain.Resources.Localization.Errors;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Customers.CommandHandlers
{
    public class SignUpHandler : IRequestHandler<SignUp, TokenDTO>
    {
        private readonly IStringLocalizer _localizer;
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMediator _mediator;
        public SignUpHandler(IStringLocalizer<ErrorMessages> localizer,
            UserManager<Customer> userManager,
            RoleManager<IdentityRole> roleManager,
            IMediator mediator)
        {
            _localizer = localizer;
            _userManager = userManager;
            _roleManager = roleManager;
            _mediator = mediator;
        }
        public async Task<TokenDTO> Handle(SignUp request, CancellationToken token)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
                throw new HttpException(_localizer[ErrorMessagesPatterns.UserAlreadyExists], HttpStatusCode.BadRequest);

            Customer user = new Customer()
            {
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = request.UserName,
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                throw new HttpException(_localizer[ErrorMessagesPatterns.UserCreationFailed], HttpStatusCode.InternalServerError);

            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
                await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

            if (await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _userManager.AddToRoleAsync(user, UserRoles.User);
            }

            return await _mediator.Send(new LogIn()
            {
                Email = request.Email,
                Password = request.Password
            });
        }
    }
}
