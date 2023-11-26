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
    public class CreateBrandCommandHandler
    {
        private readonly IRepository<Brand> _repository;

        public CreateBrandCommandHandler(IRepository<Brand> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateBrandCommand createBrandCommand)
        {
            await _repository.CreateAsync(new Brand
            {
                Name = createBrandCommand.Name,
            });
        }
    }
}
