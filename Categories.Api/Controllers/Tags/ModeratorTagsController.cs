using Categories.Application.Tags.Commands;
using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using Categories.Domain.Resources.Customers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Categories.Api.Controllers.Tags
{
    [Authorize(Roles = UserRoles.Moderator)]
    public class ModeratorTagsController : ApiController
    {
        public ModeratorTagsController(IMediator mediator) : base(mediator)
        {
        }

        #region get
        [HttpGet]
        [Route("get-all-from-book/{bookId}")]
        [ProducesResponseType(typeof(ICollection<TagGroupDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllBookTags([FromRoute] int bookId)
        {
            var result = await _mediator.Send(new GetAllBookTags()
            {
                BookId = bookId,
                IsDeletedAvailable = true
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("get-from-book")]
        [ProducesResponseType(typeof(ICollection<SimpleTagDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBookTags([FromBody] GetBookTagsRequest request)
        {
            var result = await _mediator.Send(new GetBookTags()
            {
                BookId = request.BookId,
                TagTypeId = request.TagTypeId,
                IsDeletedAvailable = true
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all-compraced")]
        [ProducesResponseType(typeof(ICollection<TagGroupDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCompracedTags()
        {
            var result = await _mediator.Send(new GetAllCompracedTags()
            {
                IsDeletedAvailable=true
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("get-tags")]
        [ProducesResponseType(typeof(ICollection<SimpleTagDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTags([FromBody] GetTagsRequest request)
        {
            var result = await _mediator.Send(new GetTags()
            {
                FilterStr = request.FilterStr,
                TypeId = request.TypeId,
                IsDeletedAvailable = true
            });
            return Ok(result);
        }
        #endregion

        #region post
        [HttpPost]
        [Route("add")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddTag([FromBody] AddTagRequest request)
        {
            var result = await _mediator.Send(new AddTag()
            {
                Names = request.Names,
                TypeId = request.TypeId
            });
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateTag([FromBody] UpdateTagRequest request)
        {
            await _mediator.Send(new UpdateTag()
            {
                Id = request.Id,
                Names = request.Names
            });
            return Ok();
        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("delete/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteTag([FromRoute] int id)
        {
            await _mediator.Send(new DeleteTag()
            {
                Id = id
            });
            return Ok();
        }

        [HttpPost]
        [Route("restore/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> RestoreTag([FromRoute] int id)
        {
            await _mediator.Send(new RestoreTag()
            {
                Id = id
            });
            return Ok();
        }
        #endregion
    }
}
