using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Services.Concrete
{
	public class GameService : IGameService
	{
		private readonly GameRepository _context;

		public GameService(GameRepository context)
		{
			_context = context;
		}

		public async Task CreateGameAsync(Game game)
		{
			await _context.AddAsync(game);
		}

		public async Task UpdateGameAsync(Game game)
		{
			await _context.UpdateAsync(game);
		}

		public async Task DeleteGame(int id)
		{
			await _context.RemoveAsync(id);
		}

		public async Task<Game> GetGameAsync(int id)
		{
			return await _context.GetAsync(id);
		}

		public async Task<IEnumerable<Game>> GetGamesAsync()
		{
			return await _context.GetAllAsync();
		}
	}
}
