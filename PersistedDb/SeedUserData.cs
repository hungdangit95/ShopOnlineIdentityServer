using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopOnline.IDP.Common;
using ShopOnline.IDP.Entities;
using System.Security.Claims;

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
            }).AddEntityFrameworkStores<ShopOnlineIdentityContext>()
            .AddDefaultTokenProviders();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider
                .GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    CreateUser(scope, "John", "Doe", "John Doe's Boulevard 323", "USA", "Hung@123654$",
                    "Administrator", "john@mail.com");
                    CreateUser(scope, "Jane", "Doe", "Jane Doe's Avenue 214", "USA", "Hung@123456$",
                    "Customer", "jane@mail.com");
                }
            }

        }
        private static async void CreateUser(IServiceScope scope, string name, string lastName,
                string address, string country, string password, string role, string email)
        {
            var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var user = userMgr.FindByNameAsync(email).Result;
            if (user == null)
            {
                user = new User
                {
                    UserName = email,
                    Email = email,
                    FirstName = name,
                    LastName = lastName,
                    Address = address
                };
                var result = userMgr.CreateAsync(user, password).Result;
                CheckResult(result);
                result = userMgr.AddToRoleAsync(user, role).Result;
                CheckResult(result);
                result =  userMgr.AddClaimsAsync(user, new Claim[]
                {
                    new Claim(SystemConstants.Claims.FirstName, user.FirstName),
                    new Claim(SystemConstants.Claims.LastName , user.LastName),
                    new Claim(SystemConstants.Claims.Roles, role),
                    new Claim(JwtClaimTypes.Address, user.Address),
                    new Claim(JwtClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(SystemConstants.Claims.UserName, user.UserName),
                }).Result;
                CheckResult(result);
            }
        }
        private static void CheckResult(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                throw new Exception(result.Errors.First().Description);
            }
        }


    }
}

