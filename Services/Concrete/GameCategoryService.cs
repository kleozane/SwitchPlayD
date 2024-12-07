using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Services.Concrete
{
	public class GameCategoryService : IGameCategoryService
	{
		private readonly GameCategoryRepository _context;
		public GameCategoryService(GameCategoryRepository context)
		{
			_context = context;
		}

		public async Task CreateGameCategoryAsync(int gameId, List<int> categoryIds)
		{
			await _context.CreateGameCategoryAsync(gameId, categoryIds);
		}

		public async Task<IEnumerable<GameCategory>> GetByGameId(int gameId)
		{
			return await _context.GetByGameId(gameId);
		}
	}
}
