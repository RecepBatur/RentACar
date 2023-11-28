using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.FooterAddressCommands;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddresesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddresesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> FooterAddressList()
        {
            var value = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand createFooterAddressCommand)
        {
            await _mediator.Send(createFooterAddressCommand);
            return Ok("Adres Bilgisi Başarılı Bir Şekilde Eklendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFooterAddress(int id)
        {
            var value = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveFooterAddress(int id)
        {
            await _mediator.Send(new RemoveFooterAddressCommand(id));
            return Ok("Adres Bilgisi Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand updateFooterAddressCommand)
        {
            await _mediator.Send(updateFooterAddressCommand);
            return Ok("Adres Bilgisi Başarılı Bir Şekilde Güncellendi");
        }
    }

}
