using AutoMapper;
using Identity.Application.Account.Commands;
using Identity.Application.Account.Queries;
using Identity.Domain.DTOs.AccountDTOs.Requests;
using Identity.Domain.DTOs.AccountDTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Identity.Api.Controllers.Customers
{
    public class AccountController : ApiController
    {
        public AccountController(IMediator mediator,
            IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("sign-up")]
        [ProducesResponseType(typeof(TokenDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TokenDTO>> SignUp([FromBody] SignUpRequest request)
        {
            var command = _mapper.Map<SignUp>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("log-in")]
        [ProducesResponseType(typeof(TokenDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TokenDTO>> LogIn([FromBody] LogInRequest request)
        {
            var query = _mapper.Map<LogIn>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
