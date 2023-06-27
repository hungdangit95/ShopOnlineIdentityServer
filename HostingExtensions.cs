using Serilog;
using ShopOnline.IDP.Common.Domains;
using ShopOnline.IDP.Extensions;
using ShopOnline.IDP.Repositories;

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
}
