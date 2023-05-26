﻿using Serilog;
using ShopOnline.IDP;
using ShopOnline.IDP.Extensions;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting up");
var builder = WebApplication.CreateBuilder(args);
try
{
    builder.Host.UseSerilog(Serilogger.Configure);
    var app = builder
        .ConfigureServices()
        .ConfigurePipeline();
    app.Run();
}
catch (Exception ex)
{
    Log.Information($"Error identity server :{ex.Message}");
    string type = ex.GetType().Name;
    if (type.Equals("StopTheHostException", StringComparison.Ordinal))
        throw;
    Log.Fatal(ex, "Unhanded exception");
}
finally
{
    Log.Information("Shut down identity server complete");
    Log.CloseAndFlush();
}