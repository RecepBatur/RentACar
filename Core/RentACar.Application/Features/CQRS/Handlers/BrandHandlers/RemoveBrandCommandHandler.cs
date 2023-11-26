using RentACar.Application.Features.CQRS.Commands.BrandCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class RemoveBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public RemoveBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBrandCommand removeBrandCommand)
        {
            var value = await _repository.GetByIdAsync(removeBrandCommand.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
