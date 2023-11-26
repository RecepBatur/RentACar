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
    public class CreateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public CreateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCarCommand createCarCommand)
        {
            await _repository.CreateAsync(new Car
            {
                BigImageUrl = createCarCommand.BigImageUrl,
                BrandId = createCarCommand.BrandId,
                Fuel = createCarCommand.Fuel,
                Km = createCarCommand.Km,
                Luggage = createCarCommand.Luggage,
                CoverImageUrl = createCarCommand.CoverImageUrl,
                Model = createCarCommand.Model,
                Seat = createCarCommand.Seat,
                Transmission = createCarCommand.Transmission
            });
        }
    }
}
