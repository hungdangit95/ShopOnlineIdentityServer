using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopOnline.IDP.Entities;

namespace ShopOnline.IDP.PersistedDb
{
    public class SeedUserData
    {
        public static void EnsureSeedData(string connectionString)
        {
           var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ShopOnlineIdentityContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });
            services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.User.RequireUniqueEmail = true;
                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                opt.Lockout.MaxFailedAccessAttempts = 3;
            });
        }
    }
}
