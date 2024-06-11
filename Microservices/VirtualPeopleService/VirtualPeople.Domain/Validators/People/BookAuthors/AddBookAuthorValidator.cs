using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests;
using VirtualPeople.Domain.Resources.People;
using VirtualPeople.Domain.Validators.Shared;

namespace VirtualPeople.Domain.Validators.People.BookAuthors
{
    public class AddBookAuthorValidator : AbstractValidator<AddBookAuthorRequest>
    {
        public AddBookAuthorValidator()
        {
            this.RuleFor(e => e.Name)
                .NotEmpty()
                .MinimumLength(ValidatorValues.MinBookAuthorNameLength)
                .MaximumLength(ValidatorValues.MaxBookAuthorNameLength);

            this.RuleFor(e => e.Image)
                .SetValidator(new FileSizeValidator());
        }
    }
}
