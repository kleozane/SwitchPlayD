using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Identity;

namespace SwitchPlayD.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string, IdentityUserClaim<string>,
    AppUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<StudioCategory> StudioCategories { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameCategory> GameCategories { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }


		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            // any guid, but nothing is against to use the same one
            const string ROLE_ID = ADMIN_ID;
            Guid roleId = Guid.NewGuid();
            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin"
            });

            builder.Entity<AppRole>().HasData(new AppRole
            {
                Id = "moderatorId",
                Name = "moderator",
                NormalizedName = "moderator"
            });

            var hasher = new PasswordHasher<AppUser>();
            builder.Entity<AppUser>().HasData(new AppUser
            {
                Id = ADMIN_ID,
                UserName = "admin@admin.com",
                NormalizedUserName = "admin@admin.com",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "P@ssw0rd"),
                SecurityStamp = string.Empty,
                UserType = "Admini i Lojrave"
            });

            builder.Entity<AppUserRole>().HasData(new AppUserRole
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });



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

			//-- Lidhja 1-N midis Game & Studio --//

			builder.Entity<Studio>()
				.HasMany(s => s.Games)
				.WithOne(g => g.Studio)
				.HasForeignKey(g => g.StudioId)
				.OnDelete(DeleteBehavior.Restrict);

			//-- Lidhja N-N midis Game & Category --//

			builder.Entity<GameCategory>().HasKey(sc => new { sc.GameId, sc.CategoryId });

			builder.Entity<Game>()
				.HasMany(s => s.GameCategories)
				.WithOne(sc => sc.Game)
				.HasForeignKey(sc => sc.GameId);

			builder.Entity<Category>()
				.HasMany(c => c.GameCategories)
				.WithOne(sc => sc.Category)
				.HasForeignKey(sc => sc.CategoryId);

			//-- Lidhja N-N midis Game & Platform --//

			builder.Entity<GamePlatform>().HasKey(sc => new { sc.GameId, sc.PlatformId });

			builder.Entity<Game>()
				.HasMany(s => s.GamePlatforms)
				.WithOne(sc => sc.Game)
				.HasForeignKey(sc => sc.GameId);

			builder.Entity<Platform>()
				.HasMany(c => c.GamePlatforms)
				.WithOne(sc => sc.Platform)
				.HasForeignKey(sc => sc.PlatformId);
		}
	}
}
