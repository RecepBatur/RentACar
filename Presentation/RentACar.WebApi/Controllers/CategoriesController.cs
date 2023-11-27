using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.CQRS.Commands.CategoryCommands;
using RentACar.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACar.Application.Features.CQRS.Queries.CategoryQueries;

namespace RentACar.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CreateCategoryCommandHandler _createCategoryCommandHandler;
        private readonly GetCategoryByIdQueryHandler _getCategoryByIdQueryHandler;
        private readonly GetCategoryQueryHandler _getCategoryQueryHandler;
        private readonly UpdateCategoryCommandHandler _updateCategoryCommandHandler;
        private readonly RemoveCategoryCommandHandler _removeCategoryCommandHandler;

        public CategoriesController(CreateCategoryCommandHandler createCategoryCommandHandler, GetCategoryByIdQueryHandler getCategoryByIdQueryHandler, GetCategoryQueryHandler getCategoryQueryHandler, UpdateCategoryCommandHandler updateCategoryCommandHandler, RemoveCategoryCommandHandler removeCategoryCommandHandler)
        {
            _createCategoryCommandHandler = createCategoryCommandHandler;
            _getCategoryByIdQueryHandler = getCategoryByIdQueryHandler;
            _getCategoryQueryHandler = getCategoryQueryHandler;
            _updateCategoryCommandHandler = updateCategoryCommandHandler;
            _removeCategoryCommandHandler = removeCategoryCommandHandler;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _getCategoryQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var values = await _getCategoryByIdQueryHandler.Handle(new GetCategoryByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
            await _createCategoryCommandHandler.Handle(createCategoryCommand);
            return Ok("Kategori Bilgisi Başarılı Bir Şekilde Eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            await _removeCategoryCommandHandler.Handle(new RemoveCategoryCommand(id));
            return Ok("Kategori Bilgisi Başarılı Bir Şekilde Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCommand(UpdateCategoryCommand updateCategoryCommand)
        {
            await _updateCategoryCommandHandler.Handle(updateCategoryCommand);
            return Ok("Kategori Bilgisi Başarılı Bir Şekilde Güncellendi");
        }
    }
}
