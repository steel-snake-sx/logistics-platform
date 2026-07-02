namespace LogisticsPlatform.LogisticsSimulator.DateTimeProvider;

public interface IDateTimeProvider
{
    DateTimeOffset CurrentDateTimeOffsetUtc { get; }
}