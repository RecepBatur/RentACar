using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public RemoveCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand removeCategoryCommand)
        {
            var value = await _repository.GetByIdAsync(removeCategoryCommand.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
