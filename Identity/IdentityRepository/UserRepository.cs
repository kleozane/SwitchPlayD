using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;

namespace SwitchPlayD.Identity.IdentityRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext databaseContext)
        {
            context = databaseContext;
        }

        public IEnumerable<AppUser> FindAll()
        {
            return context.Users;
        }

        public async Task<IEnumerable<AppUser>> FindAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public AppUser GetUser(string id)
        {
            return context.Users.SingleOrDefault(i => i.Id == id);
        }

        public async Task<AppUser> GetUserAsync(string id)
        {
            return await context.Users.SingleOrDefaultAsync(i => i.Id == id);
        }

        public AppUser GetUserRoles(string id)
        {
            return context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).SingleOrDefault(u => u.Id == id);
        }

        public async Task<AppUser> GetUserRolesAsync(string id)
        {
            return await context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).SingleOrDefaultAsync(u => u.Id == id);
        }

        public void UpdateUser(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            context.SaveChanges();
        }

        public async Task UpdateUserAsync(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            await context.SaveChangesAsync();
        }

        public void DeleteUser(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            else
            {
                context.Remove(user);
                context.SaveChanges();
            }
        }

        public async Task DeleteUserAsync(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            else
            {
                context.Remove(user);
                await context.SaveChangesAsync();
            }
        }


        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

    }
}
