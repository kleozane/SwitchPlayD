using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
    public interface ICategoryService
    {
        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategory(int id);
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetCategoriesAsync();
    }
}
