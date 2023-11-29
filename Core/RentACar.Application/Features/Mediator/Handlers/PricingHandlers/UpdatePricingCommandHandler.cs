using MediatR;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IRepository<Pricing> _repository;

        public UpdatePricingCommandHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.PricingId);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
