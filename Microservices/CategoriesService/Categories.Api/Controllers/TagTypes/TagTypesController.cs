using Categories.Application.TagTypes.Queries;
using Categories.Domain.DTOs.Tags.TagTypeDTOs.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Categories.Api.Controllers.TagTypes
{
    public class TagTypesController : ApiController
    {
        public TagTypesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("get-all")]
        [ProducesResponseType(typeof(ICollection<TagTypeDTO>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllTagTypes()
        {
            var result = await _mediator.Send(new GetAllTagTypes());
            return Ok(result);
        }

        [HttpGet]
        [Route("get-by-id/{id}")]
        [ProducesResponseType(typeof(TagTypeDTO), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetTagType([FromRoute] string id)
        {
            var result = await _mediator.Send(new GetTagType()
            {
                Id = id
            });
            return Ok(result);
        }
    }
}
