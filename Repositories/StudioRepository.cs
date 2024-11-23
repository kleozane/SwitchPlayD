using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
	public class StudioRepository : BaseRepository<Studio>
	{
		private readonly ApplicationDbContext _context;
		public StudioRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
