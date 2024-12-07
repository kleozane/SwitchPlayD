using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
	public class GameCategoryRepository : BaseRepository<GameCategory>
	{
		private readonly ApplicationDbContext _context;
		public GameCategoryRepository(ApplicationDbContext context) : base(context) { _context = context; }


		public async Task CreateGameCategoryAsync(int gameId, List<int> categoryIds)
		{
			var sc = await GetByGameId(gameId);
			_context.RemoveRange(sc);

			if (categoryIds != null)
			{
				foreach (var id in categoryIds)
				{
					_context.Add(new GameCategory
					{
						GameId = gameId,
						CategoryId = id
					});

					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task<IEnumerable<GameCategory>> GetByGameId(int gameId)
		{
			return await _context.GameCategories.Where(i => i.GameId == gameId).Include(a => a.Category).ToListAsync();
		}
	}
}
