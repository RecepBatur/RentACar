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
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand updateCategoryCommand)
        {
            var values = await _repository.GetByIdAsync(updateCategoryCommand.CategoryId);
            values.CategoryName = updateCategoryCommand.CategoryName;
            await _repository.UpdateAsync(values);
        }
    }
}
