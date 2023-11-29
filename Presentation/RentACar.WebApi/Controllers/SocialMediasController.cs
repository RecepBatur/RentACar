using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentACar.Application.Features.Mediator.Queries.SocialMediaQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> SocialMediaList()
        {
            var values = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialMedia(int id)
        {
            var value = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand createSocialMediaCommand)
        {
            await _mediator.Send(createSocialMediaCommand);
            return Ok("Sosyal Medya Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveSocialMedia(int id)
        {
            await _mediator.Send(new RemoveSocialMediaCommand(id));
            return Ok("Sosyal Medya Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand updateSocialMediaCommand)
        {
            await _mediator.Send(updateSocialMediaCommand);
            return Ok("Sosyal Medya Başarılı Bir Şekilde Güncellendi");
        }
    }
}
