using MediatR;

namespace Application.Queries.GetPersonDetais
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsViewModel>
    {
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
    }
}
