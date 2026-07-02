namespace LogisticsPlatform.LogisticsSimulator.Handlers.OrderCancel;

public interface IOrderCancellationHandler: IHandler<IOrderCancellationHandler.Request>
{
    public record Request(long OrderId);
}