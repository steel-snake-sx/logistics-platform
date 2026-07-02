using LogisticsPlatform.LogisticsSimulator.Infrastructure.Repositories;
using LogisticsPlatform.LogisticsSimulator.Infrastructure.BackgroundJobs;
using LogisticsPlatform.LogisticsSimulator.Infrastructure.Grpc;
using LogisticsPlatform.LogisticsSimulator.Infrastructure.Kafka;

namespace LogisticsPlatform.LogisticsSimulator.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHostedService<UpdateOrderJob>();
        services
            .AddRepository()
            .AddKafka()
            .AddGrpcReflection()
            .AddGrpc(o => o.Interceptors.Add<ExceptionInterceptor>());

        return services;
    }
}