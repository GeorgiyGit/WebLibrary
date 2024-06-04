using Categories.Application.Tags.Queries;
using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.DTOs.Tags.TagDTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Categories.Api.Controllers.Tags
{
    public class UserTagsController : ApiController
    {
        public UserTagsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("get-all-from-book/{bookId}")]
        [ProducesResponseType(typeof(ICollection<TagGroupDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllBookTags([FromRoute] int bookId)
        {
            var result = await _mediator.Send(new GetAllBookTags()
            {
                BookId = bookId
            });
            return Ok(result);
        }

        [HttpPost]
        [Route("get-from-book/{bookId}")]
        [ProducesResponseType(typeof(ICollection<SimpleTagDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetBookTags([FromBody] GetBookTagsRequest request)
        {
            var result = await _mediator.Send(new GetBookTags()
            {
                BookId = request.BookId,
                TagTypeId = request.TagTypeId
            });
            return Ok(result);
        }

        [HttpGet]
        [Route("get-all-compraced")]
        [ProducesResponseType(typeof(ICollection<TagGroupDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllCompracedTags()
        {
            var result = await _mediator.Send(new GetAllCompracedTags());
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
                TypeId = request.TypeId
            });
            return Ok(result);
        }
    }
}
