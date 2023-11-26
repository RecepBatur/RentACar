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
    public class UpdateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public UpdateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBrandCommand updateBrandCommand)
        {
            var values = await _repository.GetByIdAsync(updateBrandCommand.BrandId);
            values.Name = updateBrandCommand.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
