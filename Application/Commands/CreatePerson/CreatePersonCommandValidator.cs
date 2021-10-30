using FluentValidation;

namespace Application.Commands.CreatePerson
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(createPersonCommand =>
                createPersonCommand.FirstName).NotEmpty().MaximumLength(250);
            RuleFor(createPersonCommand =>
                createPersonCommand.LastName).NotEmpty().MaximumLength(250);
        }
    }
}
