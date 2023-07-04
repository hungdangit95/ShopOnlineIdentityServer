using Serilog;
using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Common.Repositories;
using ShopOnline.IDP.Extensions;
using ShopOnline.IDP.Presentation;

namespace ShopOnline.IDP;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        // uncomment if you want to add a UI
        builder.Services.AddRazorPages();
        builder.Services.ConfigureIdentity(builder.Configuration);
        builder.Services.AddConfigurationIdentityServer(builder.Configuration);
        builder.Services.AddConfigurationCors();
        builder.Services.AddTransient(typeof(IUnitOfWork),typeof(UnitOfWork));
        builder.Services.AddTransient(typeof(IRepositoryBase<,>), typeof(RepositoryBase<,>));
        builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
        builder.Services.AddScoped<IPermissionRepositorry, PermissionRepository>();
        builder.Services.AddControllers(configure =>
        {
            configure.RespectBrowserAcceptHeader = true;
            configure.ReturnHttpNotAcceptable = true;
        }).AddApplicationPart(typeof(AssemblyReference).Assembly);
        builder.Services.ConfigureSwagger(builder.Configuration);
        return builder.Build();
    }
    
    public static WebApplication ConfigurePipeline(this WebApplication app)
    { 
        app.UseSerilogRequestLogging();
    
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // uncomment if you want to add a UI
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors("CorsPolicy");
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json","Shop Online Identity"));
        app.UseIdentityServer();

        // uncomment if you want to add a UI
        app.UseAuthorization();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
            app.MapRazorPages().RequireAuthorization();
        });

        return app;
    }

    public static void ConfigureSwagger(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.EnableAnnotations();
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Identity Server API",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Name = "ShopOnline Identity",
                    Email = "hungdangit95@gmail.com "
                }
            });
        });
    }
}
