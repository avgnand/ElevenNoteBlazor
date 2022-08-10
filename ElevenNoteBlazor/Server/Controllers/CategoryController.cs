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

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CategoryEdit model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            if (model.Id != id) return BadRequest();
            bool wasSuccessful = await _categoryService.UpdateCategoryAsync(model);
            return (wasSuccessful) ? Ok() : BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category is null) return NotFound();
            bool wasSuccessful = await _categoryService.DeleteCategoryAsync(id);
            return (wasSuccessful) ? Ok() : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreate model)
        {
            if (model is null || !ModelState.IsValid) return BadRequest();
            bool wasSuccessful = await _categoryService.CreateCategoryAsync(model);
            return (wasSuccessful) ? Ok() : UnprocessableEntity();
        }
    }
}
