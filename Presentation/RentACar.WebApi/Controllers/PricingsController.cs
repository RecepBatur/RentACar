using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand createPricingCommand)
        {
            await _mediator.Send(createPricingCommand);
            return Ok("Ödeme Türü Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommand(id));
            return Ok("Ödeme Türü Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand updatePricingCommand)
        {
            await _mediator.Send(updatePricingCommand);
            return Ok("Ödeme Türü Başarılı Bir Şekilde Güncellendi");
        }
    }
}
