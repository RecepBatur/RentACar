using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.LocationCommands
{
    public class CreateLocationCommand : IRequest
    {
        public string LocationName { get; set; }
    }
}
