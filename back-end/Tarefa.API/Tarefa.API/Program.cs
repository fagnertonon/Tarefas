using NLog;
using NLog.Web;
using Tarefas.API;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    var startup = new Startup(builder.Configuration, builder.Environment);
    startup.ConfigureServices(builder.Services);

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    var app = builder.Build();

    startup.Configure(app, app.Environment);

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Stopped program because of exception");
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}