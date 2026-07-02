using LogisticsPlatform.OrdersGenerator.Infrastructure.Kafka;
using LogisticsPlatform.OrdersGenerator.Infrastructure.Workers;

namespace LogisticsPlatform.OrdersGenerator.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddHostedService<OrdersGeneratorWorker>();
        services.AddScoped<IKafkaProducer, KafkaProducer>();

        return services;
    }
}