using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VirtualPeople.Application.People.BookAuthors.AdminBookAuthors.Commands;
using VirtualPeople.Application.People.BookAuthors.Shared.Commands;
using VirtualPeople.Domain.Resources.Customers;

namespace VirtualPeople.Api.Controllers.People.BookAuthors
{
    [Authorize(Roles = UserRoles.Admin)]
    public class AdminBookAuthorsContoller : ApiController
    {
        public AdminBookAuthorsContoller(IMediator mediator) : base(mediator)
        {
        }

        [HttpDelete]
        [Route("remove/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Remove([FromRoute] int id)
        {
            await _mediator.Send(new RemoveBookAuthor()
            {
                Id = id
            });
            return Ok();
        }
    }
}
