namespace LogisticsPlatform.LogisticsSimulator.Model;

public record struct Order(long OrderId, OrderState OrderState, DateTimeOffset ChangedAt);