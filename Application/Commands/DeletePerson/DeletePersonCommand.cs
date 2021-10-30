using MediatR;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
