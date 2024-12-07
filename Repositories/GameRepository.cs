using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
	public class GameRepository : BaseRepository<Game>
	{
		private readonly ApplicationDbContext _context;
		public GameRepository(ApplicationDbContext context) : base(context)
		{
			_context = context;
		}
	}
}
