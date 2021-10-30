using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.DeletePerson
{
    public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand>
    {
        private readonly IECVContext _context;
        public DeletePersonCommandHandler(IECVContext context) => _context = context;

        public async Task<Unit> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FindAsync(request.Id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Id);
            }
            _context.Persons.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value; // Unit - это тип, означающий пустой ответ
        }
    }
}
