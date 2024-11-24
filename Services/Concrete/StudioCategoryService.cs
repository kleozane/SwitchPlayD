using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Services.Concrete
{
	public class StudioCategoryService : IStudioCategoryService
	{
		private readonly StudioCategoryRepository _context;
		public StudioCategoryService(StudioCategoryRepository context)
		{
			_context = context;
		}

		public async Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds)
		{
			await _context.CreateStudioCategoryAsync(studioId, categoryIds);
		}

		public async Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId)
		{
			return await _context.GetByStudioId(studioId);
		}
	}
}
