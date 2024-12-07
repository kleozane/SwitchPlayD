using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
	public class GamePlatformRepository : BaseRepository<GamePlatform>
	{
		private readonly ApplicationDbContext _context;
		public GamePlatformRepository(ApplicationDbContext context) : base(context) { _context = context; }

		public async Task CreateGamePlatformAsync(int gameId, List<int> platformIds)
		{
			var sc = await GetByGameId(gameId);
			_context.RemoveRange(sc);

			if (platformIds != null)
			{
				foreach (var id in platformIds)
				{
					_context.Add(new GamePlatform
					{
						GameId = gameId,
						PlatformId = id
					});

					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task<IEnumerable<GamePlatform>> GetByGameId(int gameId)
		{
			return await _context.GamePlatforms.Where(i => i.GameId == gameId).Include(a => a.Platform).ToListAsync();
		}
	}
}
