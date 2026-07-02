namespace LogisticsPlatform.OrdersGenerator.Generator;

public interface IOrderGenerator
{
    Task GenerateOrder(
        CancellationToken token);
}