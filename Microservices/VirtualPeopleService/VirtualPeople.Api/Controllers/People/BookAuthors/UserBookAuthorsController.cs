using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VirtualPeople.Application.People.BookAuthors.UserBookAuthors.Queries;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Users.Requests;

namespace VirtualPeople.Api.Controllers.People.BookAuthors
{
    public class UserBookAuthorsController : ApiController
    {
        public UserBookAuthorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("get-collection")]
        [ProducesResponseType(typeof(ICollection<SimpleBookAuthorDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UserGetBookAuthors([FromBody] UserGetBookAuthorsRequest request)
        {
            var result = await _mediator.Send(new UserGetBookAuthors()
            {
                FilterStr = request.FilterStr,
                PageParameters = request.PageParameters
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-full/{id}")]
        [ProducesResponseType(typeof(FullBookAuthorDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UserGetFullBookAuthor([FromRoute] int id)
        {
            var result = await _mediator.Send(new UserGetFullBookAuthor()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
