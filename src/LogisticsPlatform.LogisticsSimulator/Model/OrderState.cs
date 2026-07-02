namespace LogisticsPlatform.LogisticsSimulator.Model;

public enum OrderState
{
    Created,
    SentToCustomer,
    Delivered,
    Lost,
    Cancelled
}