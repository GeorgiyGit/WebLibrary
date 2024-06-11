using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests;
using VirtualPeople.Domain.Validators.Shared;

namespace VirtualPeople.Domain.Validators.People.BookAuthors
{
    public class UpdateBookAuthorImageValidator : AbstractValidator<UpdateBookAuthorImageRequest>
    {
        public UpdateBookAuthorImageValidator()
        {
            this.RuleFor(e => e.Image)
                .SetValidator(new FileSizeValidator());
        }
    }
}
