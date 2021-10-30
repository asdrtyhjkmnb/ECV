using FluentValidation;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(updateNoteCommand => updateNoteCommand.Guid).NotEqual(Guid.Empty);
        }
    }
}
