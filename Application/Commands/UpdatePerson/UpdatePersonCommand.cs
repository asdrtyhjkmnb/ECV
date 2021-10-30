using MediatR;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest
    {
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
    }
}
