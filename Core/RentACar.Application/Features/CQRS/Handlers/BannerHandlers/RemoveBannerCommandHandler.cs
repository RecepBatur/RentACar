using RentACar.Application.Features.CQRS.Commands.BannerCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class RemoveBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public RemoveBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveBannerCommand removeBannerCommand)
        {
            var values = await _repository.GetByIdAsync(removeBannerCommand.Id);
            await _repository.RemoveAsync(values);
        }
    }
}
