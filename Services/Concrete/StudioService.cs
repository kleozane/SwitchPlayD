using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;

namespace SwitchPlayD.Services.Concrete
{
	public class StudioService : IStudioService
	{
		private readonly StudioRepository _context;

		public StudioService(StudioRepository context)
		{
			_context = context;
		}

		public async Task CreateStudioAsync(Studio studio)
		{
			await _context.AddAsync(studio);
		}

		public async Task UpdateStudioAsync(Studio studio)
		{
			await _context.UpdateAsync(studio);
		}

		public async Task DeleteStudio(int id)
		{
			await _context.RemoveAsync(id);
		}

		public async Task<Studio> GetStudioAsync(int id)
		{
			return await _context.GetAsync(id);
		}

		public async Task<IEnumerable<Studio>> GetStudiosAsync()
		{
			return await _context.GetAllAsync();
		}
	}
}
