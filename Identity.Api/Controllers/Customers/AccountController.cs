using AutoMapper;
using Identity.Application.Customers.Commands;
using Identity.Application.Customers.Queries;
using Identity.Domain.DTOs.CustomerDTOs.Requests;
using Identity.Domain.DTOs.CustomerDTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Runtime.CompilerServices;

namespace Identity.Api.Controllers.Customers
{
    public class AccountController : ApiController
    {
        public AccountController(IMediator mediator,
            IMapper mapper) : base(mediator, mapper) { }

        [HttpPost]
        [Route("sign-up")]
        [ProducesResponseType(typeof(TokenDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TokenDTO>> SignUp([FromRoute] SignUpRequest request)
        {
            var command = _mapper.Map<SignUp>(request);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("log-in")]
        [ProducesResponseType(typeof(TokenDTO), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<TokenDTO>> LogIn([FromRoute] LogInRequest request)
        {
            var query = _mapper.Map<LogIn>(request);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
