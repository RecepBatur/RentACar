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
    public class UpdateBannerCommandHandler
    {
        private readonly IRepository<Banner> _repository;

        public UpdateBannerCommandHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateBannerCommand updateBannerCommand)
        {
            var values = await _repository.GetByIdAsync(updateBannerCommand.BannerId);
            values.Title = updateBannerCommand.Title;
            values.Description = updateBannerCommand.Description;
            values.VideoDescription = updateBannerCommand.VideoDescription;
            values.VideoUrl = updateBannerCommand.VideoUrl;
            await _repository.UpdateAsync(values);
        }
    }
}
