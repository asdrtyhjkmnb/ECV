using MediatR;

namespace Application.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
