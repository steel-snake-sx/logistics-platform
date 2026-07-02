using LogisticsPlatform.LogisticsSimulator.Handlers.OrderCancel;
using LogisticsPlatform.LogisticsSimulator.Handlers.OrderRegistration;
using LogisticsPlatform.LogisticsSimulator.Handlers.OrdersRandomUpdate;

namespace LogisticsPlatform.LogisticsSimulator.Handlers;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddHandlers(this IServiceCollection collection)
    {
        collection.AddScoped<IOrderCancellationHandler, OrderCancellationHandler>();
        collection.AddScoped<IOrderRegistrationHandler, OrderRegistrationHandler>();
        collection.AddScoped<IOrdersRandomUpdateHandler, OrdersRandomUpdateHandler>();
        return collection;
    }
}