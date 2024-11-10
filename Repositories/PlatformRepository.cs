using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
    public class PlatformRepository : BaseRepository<Platform>
    {
        public readonly ApplicationDbContext _context;

        public PlatformRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
