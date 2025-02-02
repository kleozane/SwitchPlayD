using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;

namespace SwitchPlayD.Identity.IdentityRepository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext context;
        public RoleRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<AppRole> FindAll()
        {
            return context.Roles;
        }

        public async Task<IEnumerable<AppRole>> FindAllAsync()
        {
            return await context.Roles.ToListAsync();
        }

        public async Task CreateRoleAsync(AppRole role)
        {
            await context.Roles.AddAsync(role);
            await context.SaveChangesAsync();
        }
    }
}