namespace LogisticsPlatform.LogisticsSimulator.Handlers.OrderCancel;

public class OrderCancellationException: HandlerException
{
    public OrderCancellationException(string error): base(error)
    {
    }
}