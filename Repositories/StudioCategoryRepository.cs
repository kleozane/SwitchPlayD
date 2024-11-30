using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
	public class StudioCategoryRepository : BaseRepository<StudioCategory>
	{

		private readonly ApplicationDbContext _context;
		public StudioCategoryRepository(ApplicationDbContext context) : base(context) { _context = context; }


		public async Task CreateStudioCategoryAsync(int studioId, List<int> categoryIds)
		{
			var sc = await GetByStudioId(studioId);
			_context.RemoveRange(sc);

			if (categoryIds != null)
			{
				foreach (var id in categoryIds)
				{
					_context.Add(new StudioCategory
					{
						StudioId = studioId,
						CategoryId = id
					});

					await _context.SaveChangesAsync();
				}
			}
		}

		public async Task<IEnumerable<StudioCategory>> GetByStudioId(int studioId)
		{
			return await _context.StudioCategories.Where(i => i.StudioId == studioId).Include(a => a.Category).ToListAsync();
		}
	}
}
