using ElevenNoteBlazor.Server.Data;
using ElevenNoteBlazor.Server.Models;
using ElevenNoteBlazor.Shared.Models.Category;
using Microsoft.EntityFrameworkCore;

namespace ElevenNoteBlazor.Server.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            if (model is null) return false;
            var entity = new Category
            {
                Name = model.Name
            };
            _context.Categories.Add(entity);
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var query = _context.Categories
                .Select(e => new CategoryListItem
                {
                    Id = e.Id,
                    Name = e.Name
                });
            return await query.ToListAsync();
        }

        public async Task<CategoryDetail?> GetCategoryByIdAsync(int categoryId)
        {
            var entity = await _context.Categories.FindAsync(categoryId);
            if (entity is null) return null;
            else return new CategoryDetail
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            var entity = await _context.Categories.FindAsync(model.Id);
            if (entity is null) return false;
            entity.Name = model.Name;
            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var entity = await _context.Categories.FindAsync(categoryId);
            if (entity is null) return false;
            _context.Categories.Remove(entity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
