using MediatR;

namespace Application.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
    }
}
