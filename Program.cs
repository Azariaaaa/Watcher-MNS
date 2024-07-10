using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WatchMNS.Database;
using WatchMNS.Models;
using WatchMNS.Repository.Interfaces;
using WatchMNS.Repository;
using WatchMNS.Services.Interfaces;
using WatchMNS.Services;
namespace WatchMNS
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabaseContext>()
                            .AddIdentity<Client, IdentityRole>(options =>
                            {
                                options.Password.RequiredLength = 8;
                                options.Password.RequireLowercase = true;
                                options.Password.RequireUppercase = true;

                                options.Lockout.MaxFailedAccessAttempts = 5;
                                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

                                options.User.RequireUniqueEmail = true;
                            })
                            .AddEntityFrameworkStores<DatabaseContext>();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(AbstractRepository<>));
            builder.Services.AddScoped(typeof(IService<>), typeof(Service<>));

            var roleManager = builder.Services.BuildServiceProvider().GetRequiredService<RoleManager<IdentityRole>>();

            var roles = new[] { "Admin", "Moderator", "User", "Guest" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Security/AccessDenied";
                options.AccessDeniedPath = "/Security/AccessDenied";
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=Login}/{id?}");
            app.Run();
        }
    }
}
