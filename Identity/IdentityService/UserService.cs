using SwitchPlayD.Identity.IdentityRepository;

namespace SwitchPlayD.Identity.IdentityService
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public IEnumerable<AppUser> GetUsers()
        {
            return _userRepository.FindAll();
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _userRepository.FindAllAsync();
        }

        public AppUser GetUser(string id)
        {
            return _userRepository.GetUser(id);
        }

        public async Task<AppUser> GetUserAsync(string id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public AppUser GetUserRoles(string id)
        {
            return _userRepository.GetUserRoles(id);
        }

        public async Task<AppUser> GetUserRolesAsync(string id)
        {
            return await _userRepository.GetUserRolesAsync(id);
        }

        public void UpdateUser(AppUser user)
        {
            _userRepository.UpdateUser(user);
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            await _userRepository.UpdateUserAsync(user);
        }

        public void DeleteUser(string id)
        {
            var userToDelete = _userRepository.GetUser(id);
            _userRepository.DeleteUser(userToDelete);
        }

        public async Task DeleteUserAsync(string id)
        {
            var userToDelete = await _userRepository.GetUserAsync(id);
            await _userRepository.DeleteUserAsync(userToDelete);
        }
    }
}
