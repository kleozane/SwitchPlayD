namespace SwitchPlayD.Identity.IdentityRepository
{
    public interface IUserRepository
    {
        IEnumerable<AppUser> FindAll();
        Task<IEnumerable<AppUser>> FindAllAsync();
        AppUser GetUser(string id);
        Task<AppUser> GetUserAsync(string id);
        AppUser GetUserRoles(string id);
        Task<AppUser> GetUserRolesAsync(string id);
        void UpdateUser(AppUser user);
        Task UpdateUserAsync(AppUser user);
        void DeleteUser(AppUser user);
        Task DeleteUserAsync(AppUser user);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
