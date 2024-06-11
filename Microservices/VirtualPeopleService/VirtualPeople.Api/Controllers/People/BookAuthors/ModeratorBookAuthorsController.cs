using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Queries;
using VirtualPeople.Application.People.BookAuthors.Shared.Commands;
using VirtualPeople.Application.People.BookAuthors.UserBookAuthors.Queries;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Requests;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Users.Requests;
using VirtualPeople.Domain.Resources.Customers;

namespace VirtualPeople.Api.Controllers.People.BookAuthors
{
    [Authorize(Roles = UserRoles.Moderator)]
    public class ModeratorBookAuthorsController : ApiController
    {
        public ModeratorBookAuthorsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        [Route("get-collection")]
        [ProducesResponseType(typeof(ICollection<ModeratorSimpleBookAuthorDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModeratorGetBookAuthors([FromBody] ModeratorGetBookAuthorsRequest request)
        {
            var result = await _mediator.Send(new ModeratorGetBookAuthors()
            {
                FilterStr = request.FilterStr,
                PageParameters = request.PageParameters
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-full/{id}")]
        [ProducesResponseType(typeof(ModeratorFullBookAuthorDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ModeratorGetFullBookAuthor([FromRoute] int id)
        {
            var result = await _mediator.Send(new ModeratorGetFullBookAuthor()
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpPut]
        [Route("update-image")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBookAuthorImage([FromBody] UpdateBookAuthorImageRequest request)
        {
            await _mediator.Send(new UpdateBookAuthorImage()
            {
                Image = request.Image
            });
            return Ok();
        }

        [HttpPut]
        [Route("update-name")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBookAuthorName([FromBody] UpdateBookAuthorNameRequest request)
        {
            await _mediator.Send(new UpdateBookAuthorName()
            {
                Name = request.Name
            });
            return Ok();
        }

        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _mediator.Send(new DeleteBookAuthor()
            {
                Id = id
            });
            return Ok();
        }

        [HttpPost]
        [Route("restore/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Restore([FromRoute] int id)
        {
            await _mediator.Send(new RestoreBookAuthor()
            {
                Id = id
            });
            return Ok();
        }
    }
}
