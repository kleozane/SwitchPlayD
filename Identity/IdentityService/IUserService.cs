namespace SwitchPlayD.Identity.IdentityService
{
    public interface IUserService
    {
        IEnumerable<AppUser> GetUsers();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        AppUser GetUser(string id);
        Task<AppUser> GetUserAsync(string id);
        AppUser GetUserRoles(string id);
        Task<AppUser> GetUserRolesAsync(string id);
        void UpdateUser(AppUser user);
        Task UpdateUserAsync(AppUser user);
        void DeleteUser(string id);
        Task DeleteUserAsync(string id);
    }
}
