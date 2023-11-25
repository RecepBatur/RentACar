using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAboutCommand updateAboutCommand)
        {
            var values = await _repository.GetByIdAsync(updateAboutCommand.AboutId);
            values.Description = updateAboutCommand.Description;
            values.Title = updateAboutCommand.Title;
            values.ImageUrl = updateAboutCommand.ImageUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
