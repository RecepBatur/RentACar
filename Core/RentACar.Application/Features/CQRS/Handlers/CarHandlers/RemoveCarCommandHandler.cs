using RentACar.Application.Features.CQRS.Commands.CarCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CarHandlers
{
    public class RemoveCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public RemoveCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCarCommand removeCarCommand)
        {
            var value = await _repository.GetByIdAsync(removeCarCommand.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
