using ElevenNoteBlazor.Server.Services.Categories;
using ElevenNoteBlazor.Shared.Models.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElevenNoteBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Category(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return (category is null) ? NotFound() : Ok(category);
        }

        // TODO
        //public void Edit()
        //{

        //}

        //public void Delete()
        //{

        //}

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);
            return (wasSuccessful) ? Ok() : UnprocessableEntity();
        }
    }
}
