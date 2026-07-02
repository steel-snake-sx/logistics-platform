namespace LogisticsPlatform.OrdersGenerator.Models;

public record GoodModel(
    long Id,
    string Name,
    int Quantity,
    decimal Price,
    uint Weight);