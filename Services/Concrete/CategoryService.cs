using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _context;

        public CategoryService(CategoryRepository context) 
        { 
            _context = context;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _context.AddAsync(category);
        } 

        public async Task UpdateCategoryAsync(Category category)
        {
            await _context.UpdateAsync(category);
        }

        public async Task DeleteCategory(int id)
        {
            await _context.RemoveAsync(id);
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _context.GetAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.GetAllAsync();
        }
    }
}
