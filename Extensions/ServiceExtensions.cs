using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopOnline.IDP.Entities;
using ShopOnline.IDP.PersistedDb;

namespace ShopOnline.IDP.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddConfigurationIdentityServer(this IServiceCollection services, IConfiguration configuration)
        {
            var conectionString = configuration.GetConnectionString("IdentitySqlConnection");
            services.AddIdentityServer(options =>
            {
                options.EmitStaticAudienceClaim = true;
                options.Events.RaiseSuccessEvents = true;
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseFailureEvents = true;
            })
            .AddDeveloperSigningCredential()
            //.AddInMemoryIdentityResources(Config.IdentityResources)
            //.AddInMemoryApiScopes(Config.ApiScopes)
            //.AddInMemoryClients(Config.Clients)
            //.AddInMemoryApiResources(Config.ApiResource)
            //.AddTestUsers(TestUsers.Users)
            .AddConfigurationStore(cfg =>
            {
                cfg.ConfigureDbContext = c => c.UseSqlServer(conectionString, builder => builder.MigrationsAssembly("ShopOnline.IDP"));
            }).
            AddOperationalStore(cfg =>
            {
                cfg.ConfigureDbContext = c => c.UseSqlServer(conectionString, builder => builder.MigrationsAssembly("ShopOnline.IDP"));
            })
            .AddAspNetIdentity<User>();

            return services;
        }

        public static IServiceCollection AddConfigurationCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            return services;
        }

        public static void ConfigureIdentity(this IServiceCollection services, IConfiguration configuration)
        {
            var connectString = configuration.GetConnectionString("IdentitySqlConnection");
            services.AddDbContext<ShopOnlineIdentityContext>(options =>
                options.UseSqlServer(connectString)
            ).AddIdentity<User, IdentityRole>(
                opt =>
                {
                    opt.Password.RequireDigit = false;
                    opt.Password.RequiredLength = 6;
                    opt.Password.RequireUppercase = false;
                    opt.Password.RequireLowercase = false;
                    opt.User.RequireUniqueEmail = true;
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    opt.Lockout.MaxFailedAccessAttempts = 3;

                }
            )
            .AddEntityFrameworkStores<ShopOnlineIdentityContext>()
             .AddDefaultTokenProviders()
            ;
        }
    }
}
