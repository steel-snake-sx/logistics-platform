namespace LogisticsPlatform.LogisticsSimulator.Infrastructure.Repositories;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepository(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderRepository, OrderInMemoryRepository>();

        return collection;
    }
}