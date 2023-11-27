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
    public class UpdateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateContactCommand updateContactCommand)
        {
            var values = await _repository.GetByIdAsync(updateContactCommand.ContactId);
            values.SendDate = updateContactCommand.SendDate;
            values.Subject = updateContactCommand.Subject;
            values.Email = updateContactCommand.Email;
            values.Message = updateContactCommand.Message;
            values.Name = updateContactCommand.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
