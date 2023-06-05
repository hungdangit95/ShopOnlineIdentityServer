using Microsoft.EntityFrameworkCore;

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
            });
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
    }
}
