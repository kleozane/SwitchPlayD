using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace SwitchPlayD.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<StudioCategory> StudioCategories { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			#region Platform Seeding

			builder.Entity<Platform>().HasData( new Platform
			{
				Id = 1,
				Name = "Playstation"
			});

			builder.Entity<Platform>().HasData(new Platform
			{
				Id = 2,
				Name = "xBox"
			});

			builder.Entity<Platform>().HasData(new Platform
			{
				Id = 3,
				Name = "PC"
			});

			builder.Entity<Platform>().HasData(new Platform
			{
				Id = 4,
				Name = "Nintendo"
			});

			builder.Entity<Platform>().HasData(new Platform
			{
				Id = 5,
				Name = "Mobile"
			});

			#endregion

			//-- Lidhja N-N midis Studio & Category --//

			builder.Entity<StudioCategory>().HasKey(sc => new {sc.StudioId, sc.CategoryId});

			builder.Entity<Studio>()
				.HasMany(s => s.StudioCategories)
				.WithOne(sc => sc.Studio)
				.HasForeignKey(sc => sc.StudioId);

			builder.Entity<Category>()
				.HasMany(c => c.StudioCategories)
				.WithOne(sc => sc.Category)
				.HasForeignKey(sc => sc.CategoryId);
		}
	}
}
