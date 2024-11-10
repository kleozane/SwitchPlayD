using Microsoft.EntityFrameworkCore;

namespace SwitchPlayD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Platform> Platforms { get; set; }
    }
}
