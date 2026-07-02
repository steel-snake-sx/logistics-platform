using LogisticsPlatform.LogisticsSimulator.Handlers.OrderCancel;
using LogisticsPlatform.LogisticsSimulator.Handlers.OrderRegistration;
using LogisticsPlatform.LogisticsSimulator.Handlers.OrdersRandomUpdate;

namespace LogisticsPlatform.LogisticsSimulator.DateTimeProvider;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddDateTimeProvider(this IServiceCollection collection)
    {
        collection.AddSingleton<IDateTimeProvider, LocalDateTimeProvider>();
        return collection;
    }
}