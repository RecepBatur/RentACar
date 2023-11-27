using RentACar.Application.Features.CQRS.Commands.ContactCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class RemoveContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public RemoveContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveContactCommand removeContactCommand)
        {
            var value = await _repository.GetByIdAsync(removeContactCommand.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
