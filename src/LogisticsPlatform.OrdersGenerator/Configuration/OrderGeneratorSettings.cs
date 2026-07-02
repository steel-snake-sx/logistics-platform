using LogisticsPlatform.OrdersGenerator.Models;

namespace LogisticsPlatform.OrdersGenerator.Configuration;

public class OrderGeneratorSettings
{
    public OrderSource OrderSource { get; set; }
    
    public string OrderRequestTopic { get; set; }
}