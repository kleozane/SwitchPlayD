using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;
using SwitchPlayD.Identity;
using SwitchPlayD.Identity.IdentityRepository;
using SwitchPlayD.Identity.IdentityService;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;
using SwitchPlayD.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Db Not Found")));

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddDistributedMemoryCache();
builder.Services.AddMemoryCache();
builder.Services.AddSession(x => { x.IdleTimeout = TimeSpan.FromDays(10); x.Cookie.HttpOnly = true; x.Cookie.IsEssential = true; });
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();
builder.Services.AddCors(x => x.AddPolicy("AllowAnyOrigin", x => x.AllowAnyOrigin()));
builder.Services.Configure<FormOptions>(x => x.ValueCountLimit = 10000);
builder.Services.AddControllersWithViews();

#region Repositories

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<PlatformRepository>();
builder.Services.AddScoped<StudioRepository>();
builder.Services.AddScoped<StudioCategoryRepository>();
builder.Services.AddScoped<GameRepository>();
builder.Services.AddScoped<GameCategoryRepository>();
builder.Services.AddScoped<GamePlatformRepository>();

#endregion


#region Services

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IRoleService, RoleService>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<IStudioService, StudioService>();
builder.Services.AddTransient<IStudioCategoryService, StudioCategoryService>();
builder.Services.AddTransient<IFileHandleService, FileHandleService>();
builder.Services.AddTransient<IGameService, GameService>();
builder.Services.AddTransient<IGameCategoryService, GameCategoryService>();
builder.Services.AddTransient<IGamePlatformService, GamePlatformService>();

#endregion


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAnyOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
