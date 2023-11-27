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
    public class CreateContactCommandHandler
    {
        private readonly IRepository<Contact> _repository;

        public CreateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateContactCommand createContactCommand)
        {
            await _repository.CreateAsync(new Contact
            {
                Email = createContactCommand.Email,
                Message = createContactCommand.Message,
                Name = createContactCommand.Name,
                SendDate = createContactCommand.SendDate,
                Subject = createContactCommand.Subject
            });
        }
    }
}
