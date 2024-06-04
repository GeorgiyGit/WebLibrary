using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Domain.Validators.Tags
{
    public class GetTagsRequestValidator : AbstractValidator<GetTagsRequest>
    {
        public GetTagsRequestValidator()
        {
            this.RuleFor(e => e.FilterStr)
                .MaximumLength(300);
        }
    }
}
