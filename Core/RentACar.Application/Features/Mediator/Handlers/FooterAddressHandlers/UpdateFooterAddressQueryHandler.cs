using MediatR;
using RentACar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressQueryHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FooterAddressId);
            values.Phone = request.Phone;
            values.Address = request.Address;
            values.Email = request.Email;
            values.Description = request.Description;
            await _repository.UpdateAsync(values);
        }
    }
}
