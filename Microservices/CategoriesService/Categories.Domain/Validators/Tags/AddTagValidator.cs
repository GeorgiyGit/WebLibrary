using Categories.Domain.DTOs.Tags.TagDTOs.Requests;
using Categories.Domain.Resources.Tags;
using FluentValidation;

namespace Categories.Domain.Validators.Tags
{
    public class AddTagValidator : AbstractValidator<AddTagRequest>
    {
        private readonly List<string> validTypeIds = TagTypes.GetAllTypes();
        private readonly List<string> validLangCodes = Languages.GetAllLangCodes();
        public AddTagValidator()
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

            this.RuleFor(e => e.TypeId)
                .NotEmpty()
                .Must(typeId => validTypeIds.Contains(typeId));
        }
    }
}
