using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetPersonList
{
    public class GetPersonListQueryHandler : IRequestHandler<GetPersonListQuery, PersonViewModelList>
    {
        private readonly IECVContext _context;
        private readonly IMapper _mapper;
        public GetPersonListQueryHandler(IECVContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);

        public async Task<PersonViewModelList> Handle(GetPersonListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Persons
                .ProjectTo<PersonViewModel>(_mapper.ConfigurationProvider) // проецирование коллекции на конфигурацию
                .ToArrayAsync(cancellationToken);

            return new PersonViewModelList() { Persons = entities };
        }
    }
}
