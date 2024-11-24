using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
	public interface IStudioCategoryService
	{
		Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds);
		Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId);
	}
}
