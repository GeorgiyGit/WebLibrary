using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPeople.Domain.Validators.Shared
{
    public class FileSizeValidator : AbstractValidator<IFormFile>
    {
        public FileSizeValidator()
        {
            this.RuleFor(e => e.Length)
                .GreaterThan(0)
                .LessThanOrEqualTo(10 * 1024 * 1024);
        }
    }
}
