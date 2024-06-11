using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPeople.Domain.DTOs.People.BookAuthors.Shared.Requests;
using VirtualPeople.Domain.Resources.People;

namespace VirtualPeople.Domain.Validators.People.BookAuthors
{
    public class UpdateBookAuthorNameValidator : AbstractValidator<UpdateBookAuthorNameRequest>
    {
        public UpdateBookAuthorNameValidator()
        {
            this.RuleFor(e => e.Name)
                .NotEmpty()
                .MinimumLength(ValidatorValues.MinBookAuthorNameLength)
                .MaximumLength(ValidatorValues.MaxBookAuthorNameLength);
        }
    }
}
