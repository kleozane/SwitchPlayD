using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
	public interface IGameCategoryService
	{
		Task CreateGameCategoryAsync(int gameId, List<int> categoryIds);
		Task<IEnumerable<GameCategory>> GetByGameId(int gameId);
	}
}
