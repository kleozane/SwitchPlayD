namespace SwitchPlayD.Identity.IdentityRepository
{
    public interface IRoleRepository
    {
        IEnumerable<AppRole> FindAll();
        Task<IEnumerable<AppRole>> FindAllAsync();
        Task CreateRoleAsync(AppRole role);
    }
}
