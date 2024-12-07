using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
	public interface IGameService
	{
		Task CreateGameAsync(Game game);
		Task UpdateGameAsync(Game game);
		Task DeleteGame(int id);
		Task<Game> GetGameAsync(int id);
		Task<IEnumerable<Game>> GetGamesAsync();
	}
}
