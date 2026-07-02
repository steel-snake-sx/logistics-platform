namespace LogisticsPlatform.OrdersGenerator.Providers.Goods;

public record GoodDto(
    long Id,
    string Name,
    decimal Price,
    uint Weight);