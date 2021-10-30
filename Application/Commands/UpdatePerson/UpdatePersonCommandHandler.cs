using Application.Common.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands.UpdatePerson
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
        private readonly IECVContext _context;
        public UpdatePersonCommandHandler(IECVContext context) => _context = context;

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Persons.FirstOrDefaultAsync(person => person.Guid == request.Guid, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Person), request.Guid);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.MiddleName = request.MiddleName;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
