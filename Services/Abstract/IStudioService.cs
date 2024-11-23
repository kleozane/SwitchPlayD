using SwitchPlayD.Data;

namespace SwitchPlayD.Services.Abstract
{
	public interface IStudioService
	{
		Task CreateStudioAsync(Studio studio);
		Task UpdateStudioAsync(Studio studio);
		Task DeleteStudio(int id);
		Task<Studio> GetStudioAsync(int id);
		Task<IEnumerable<Studio>> GetStudiosAsync();
	}
}
