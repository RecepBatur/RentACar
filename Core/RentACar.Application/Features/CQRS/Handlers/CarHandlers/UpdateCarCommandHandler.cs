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
    public class UpdateCarCommandHandler
    {
        private readonly IRepository<Car> _repository;

        public UpdateCarCommandHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCarCommand updateCarCommand)
        {
            var values = await _repository.GetByIdAsync(updateCarCommand.CarId);
            values.Fuel = updateCarCommand.Fuel;
            values.Transmission = updateCarCommand.Transmission;
            values.Luggage = updateCarCommand.Luggage;
            values.BigImageUrl = updateCarCommand.BigImageUrl;
            values.CoverImageUrl = updateCarCommand.CoverImageUrl;
            values.BrandId = updateCarCommand.BrandId;
            values.Seat = updateCarCommand.Seat;
            values.BigImageUrl = updateCarCommand.BigImageUrl;
            values.Km = updateCarCommand.Km;
            values.Model = updateCarCommand.Model;
            await _repository.UpdateAsync(values);
        }
    }
}
