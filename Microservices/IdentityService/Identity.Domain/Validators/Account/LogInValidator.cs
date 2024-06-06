using FluentValidation;
using Identity.Domain.DTOs.AccountDTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Validators.Account
{
    public class LogInValidator : AbstractValidator<SignUpRequest>
    {
        public LogInValidator()
        {
            this.RuleFor(e => e.Email)
                .NotEmpty()
                .MaximumLength(200)
                .EmailAddress();

            this.RuleFor(e => e.Password)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
