using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
	public interface IGamePlatformService
	{
		Task CreateGamePlatformAsync(int gameId, List<int> platformIds);
		Task<IEnumerable<GamePlatform>> GetByGameId(int gameId);
	}
}
