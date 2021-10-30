using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.GetPersonDetais
{
    public class GetPersonDetailsQueryHandler : IRequestHandler<GetPersonDetailsQuery, PersonDetailsViewModel>
    {
        private readonly IECVContext _context;
        private readonly IMapper _mapper;
        public GetPersonDetailsQueryHandler(IECVContext context, IMapper mapper) => (_context, _mapper) = (context, mapper);
        public async Task<PersonDetailsViewModel> Handle(GetPersonDetailsQuery request, CancellationToken cancellationToken)
        {
            if (request.Guid == Guid.Empty)
            {
                throw new ArgumentException($"Ошибка запроса \"{nameof(GetPersonDetailsQuery)}\" - некорректный идентификатор поиска");
            }

            var entity = await _context.Persons.FirstOrDefaultAsync(p => p.Guid == request.Guid);

            if (entity == null)
            {
                throw new NotFoundException($"Сущность \"{nameof(Person)}\" не найдена в запросе \"{nameof(GetPersonDetailsQuery)}\"",
                    request.Guid);
            }

            return _mapper.Map<PersonDetailsViewModel>(entity);
        }
    }
}
