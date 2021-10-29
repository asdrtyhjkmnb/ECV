using MediatR;

namespace Application.Queries.GetPersonList
{
    public class GetPersonListQuery : IRequest<PersonViewModelList>
    {
        // набор фильтров ниже...
    }
}
