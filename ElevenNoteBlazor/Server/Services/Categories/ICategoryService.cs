using ElevenNoteBlazor.Shared.Models.Category;

namespace ElevenNoteBlazor.Server.Services.Categories
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryDetail?> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
