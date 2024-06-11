using Ardalis.GuardClauses;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Net;
using VirtualPeople.Api.Guards;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Commands;
using VirtualPeople.Application.People.BookAuthors.CustomerBookAuthors.Queries;
using VirtualPeople.Application.People.BookAuthors.ModeratorBookAuthors.Queries;
using VirtualPeople.Application.People.BookAuthors.Shared.Commands;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Requests;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Customers.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Requests;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Moderators.Responses;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests;
using VirtualPeople.Domain.Interfaces;
using VirtualPeople.Domain.Resources.Customers;
using VirtualPeople.Domain.Resources.Localization.Errors;
using VirtualPeople.Infrastructure;

namespace VirtualPeople.Api.Controllers.People.BookAuthors
{
    [Authorize(Roles = UserRoles.Customer)]
    public class CustomerBookAuthorsController : ApiController
    {
        private readonly VirtualPeopleDbContext _dbContext;
        private readonly IStringLocalizer<ErrorMessages> _localizer;
        private readonly ICustomerService _customerService;
        public CustomerBookAuthorsController(IMediator mediator,
            VirtualPeopleDbContext dbContext,
            IStringLocalizer<ErrorMessages> localizer,
            ICustomerService customerService) : base(mediator)
        {
            _dbContext = dbContext;
            _localizer = localizer;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("get-created-collection")]
        [ProducesResponseType(typeof(ICollection<CustomerSimpleBookAuthorDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CustomerGetCreatedBookAuthors([FromBody] CustomerGetCreatedBookAuthorsRequest request)
        {
            var result = await _mediator.Send(new CustomerGetCreatedBookAuthors()
            {
                FilterStr = request.FilterStr,
                PageParameters = request.PageParameters
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-created-full/{id}")]
        [ProducesResponseType(typeof(CustomerFullBookAuthorDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CustomerGetFullCreatedBookAuthor([FromRoute] int id)
        {
            var result = await _mediator.Send(new CustomerGetFullCreatedBookAuthor()
            {
                Id = id
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddBookAuthor([FromBody] AddBookAuthorRequest request)
        {
            var result = await _mediator.Send(new AddBookAuthor()
            {
                Image = request.Image,
                Name = request.Name
            });
            return Ok(result);
        }

        [HttpPut]
        [Route("update-image")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateBookAuthorImage([FromBody] UpdateBookAuthorImageRequest request)
        {
            await Guard.Against.NotBookAuthorOwner(request.Id, _dbContext, _localizer, _customerService);
            
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
            await Guard.Against.NotBookAuthorOwner(request.Id, _dbContext, _localizer, _customerService);

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
            await Guard.Against.NotBookAuthorOwner(id, _dbContext, _localizer, _customerService);

            await _mediator.Send(new DeleteBookAuthor()
            {
                Id = id
            });
            return Ok();
        }
    }
}
