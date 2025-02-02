using SwitchPlayD.Identity.IdentityRepository;

namespace SwitchPlayD.Identity.IdentityService
{
    public class RoleService : IRoleService
    {
        public readonly IRoleRepository context;
        public RoleService(IRoleRepository repository)
        {
            context = repository;
        }

        public IEnumerable<AppRole> GetRoles()
        {
            return context.FindAll();
        }

        public Task<IEnumerable<AppRole>> GetRolesAsync()
        {
            return context.FindAllAsync();
        }

        public async Task CreateRoleAsync(AppRole role)
        {
            await context.CreateRoleAsync(role);
        }
    }
}
