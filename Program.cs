using Microsoft.EntityFrameworkCore;
using SwitchPlayD.Data;
using SwitchPlayD.Repositories;
using SwitchPlayD.Services.Abstract;
using SwitchPlayD.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Db Not Found")));

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Repositories

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<PlatformRepository>();
builder.Services.AddScoped<StudioRepository>();
builder.Services.AddScoped<StudioCategoryRepository>();

#endregion


#region Services

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IPlatformService, PlatformService>();
builder.Services.AddTransient<IStudioService, StudioService>();
builder.Services.AddTransient<IStudioCategoryService, StudioCategoryService>();
builder.Services.AddTransient<IFileHandleService, FileHandleService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
