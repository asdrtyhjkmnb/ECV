using MediatR;

namespace Application.Queries.GetPersonDetais
{
    public class GetPersonDetailsQuery : IRequest<PersonDetailsViewModel>
    {
        public Guid Guid { get; set; }
    }
}
