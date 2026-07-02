using LogisticsPlatform.LogisticsSimulator.DateTimeProvider;
using LogisticsPlatform.LogisticsSimulator.Handlers.ResultTypes;
using LogisticsPlatform.LogisticsSimulator.Infrastructure.Repositories;
using LogisticsPlatform.LogisticsSimulator.Model;

namespace LogisticsPlatform.LogisticsSimulator.Handlers.OrderRegistration;

public class OrderRegistrationHandler : IOrderRegistrationHandler
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDateTimeProvider _dateTimeProvider;

    public OrderRegistrationHandler(IOrderRepository orderRepository, IDateTimeProvider dateTimeProvider)
    {
        _orderRepository = orderRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    public async Task<HandlerResult> Handle(Order order, CancellationToken token)
    {
        var orderAlreadyRegistered = await _orderRepository.IsExists(order.OrderId, token);

        if (orderAlreadyRegistered)
            return HandlerResult.FromError(new OrderRegistrationException($"Order {order.OrderId} already registered"));

        await _orderRepository.Insert(order with { ChangedAt = _dateTimeProvider.CurrentDateTimeOffsetUtc}, token);
        return HandlerResult.Ok;
    }
}