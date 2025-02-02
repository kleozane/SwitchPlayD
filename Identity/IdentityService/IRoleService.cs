namespace SwitchPlayD.Identity.IdentityService
{
    public interface IRoleService
    {
        IEnumerable<AppRole> GetRoles();
        Task<IEnumerable<AppRole>> GetRolesAsync();
        Task CreateRoleAsync(AppRole role);
    }
}
