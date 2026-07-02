namespace LogisticsPlatform.LogisticsSimulator.DateTimeProvider;

public class LocalDateTimeProvider: IDateTimeProvider
{
    public DateTimeOffset CurrentDateTimeOffsetUtc => DateTimeOffset.UtcNow;
}