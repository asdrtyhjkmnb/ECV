﻿using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly IECVContext _context;
        public CreatePersonCommandHandler(IECVContext context) => _context = context;

        /// <summary>
        /// Содержит в себе логику обработки команды создания Person
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            var person = new Person
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                Created = DateTime.Now
            };
            await this._context.Persons.AddAsync(person, cancellationToken);
            await this._context.SaveChangesAsync(cancellationToken);
            return person.Id;
        }
    }
}
