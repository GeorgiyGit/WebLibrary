using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.Resources.Tags;
using FluentValidation;

namespace Categories.Domain.Validators.Tags
{
    public class UpdateTagValidator : AbstractValidator<UpdateTagRequest>
    {
        private readonly List<string> validLangCodes = Languages.GetAllLangCodes();
        public UpdateTagValidator()
        {
            this.RuleForEach(e => e.Names)
                .NotNull()
                .ChildRules(name =>
                {
                    name.RuleFor(e => e.Value)
                        .NotEmpty()
                        .MaximumLength(300);

                    name.RuleFor(e => e.LanguageCode)
                        .NotEmpty()
                        .Must(lCode => validLangCodes.Contains(lCode));
                });
        }
    }
}
