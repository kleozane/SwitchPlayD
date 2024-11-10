using SwitchPlayD.Data;

namespace SwitchPlayD.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}
