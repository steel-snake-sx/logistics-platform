using LogisticsPlatform.LogisticsSimulator.DateTimeProvider;
using LogisticsPlatform.LogisticsSimulator.Handlers;
using LogisticsPlatform.LogisticsSimulator.Infrastructure;
using LogisticsPlatform.LogisticsSimulator.Infrastructure.Grpc;

namespace LogisticsPlatform.LogisticsSimulator;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddDateTimeProvider()
            .AddHandlers()
            .AddInfrastructure();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseEndpoints(e =>
        {
            e.MapGrpcService<LogisticsSimulatorGrpcService>();
            e.MapGrpcReflectionService();
        });
    }
}