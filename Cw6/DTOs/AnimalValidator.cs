using FluentValidation;

namespace Cw6;

public class AnimalValidator : AbstractValidator<CreateAnimalRequest>
{
    public AnimalValidator()
    {
        RuleFor(a => a.Area).MaximumLength(200).NotEmpty();
        RuleFor(a => a.Name).MaximumLength(200).NotEmpty();
        RuleFor(a => a.Category).MaximumLength(200).NotEmpty();
        RuleFor(a => a.Description).MaximumLength(200);
    }
}