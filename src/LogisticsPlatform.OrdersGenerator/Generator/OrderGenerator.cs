using Bogus;
using Microsoft.Extensions.Options;
using LogisticsPlatform.OrdersGenerator.Configuration;
using LogisticsPlatform.OrdersGenerator.Infrastructure.Kafka;
using LogisticsPlatform.OrdersGenerator.Models;
using LogisticsPlatform.OrdersGenerator.Providers.Customers;
using LogisticsPlatform.OrdersGenerator.Providers.Goods;

namespace LogisticsPlatform.OrdersGenerator.Generator;

public class OrderGenerator: IOrderGenerator
{
    private readonly Faker _faker = new();
    
    private readonly ICustomerProvider _customerProvider;
    private readonly IGoodsProvider _goodsProvider;
    private readonly IKafkaProducer _kafkaProducer;
    private readonly OrderGeneratorSettings _settings;

    public OrderGenerator(
        ICustomerProvider customerProvider,
        IKafkaProducer kafkaProducer,
        IGoodsProvider goodsProvider,
        IOptions<OrderGeneratorSettings> options)
    {
        _customerProvider = customerProvider;
        _kafkaProducer = kafkaProducer;
        _goodsProvider = goodsProvider;
        _settings = options.Value;
    }

    public async Task GenerateOrder(
        CancellationToken token)
    {
    var orderId = Random.Shared.Next(999999, 99999999);
    var source = _settings.OrderSource;
    var customer = await _customerProvider.GetRandomCustomer();

    var address = customer.Address;
    
    var customerDto = new CustomerModel(
        customer.Id,
        new AddressModel(
            address.Region, 
            address.City, 
            address.Street, 
            address.Building, 
            address.Apartment, 
            address.Latitude,
            address.Longitude));

    var goods = Enumerable.Range(0, _faker.Random.Int(1, 3))
        .Select(_ =>
        {
            var good = _goodsProvider.GetRandomGood();
            return new GoodModel(
                Id: good.Id,
                Name: good.Name,
                Quantity: _faker.Random.Int(1, 10),
                Price: good.Price,
                Weight: good.Weight);
        });
    
         var order = new OrderModel(
             orderId,
             source,
             customerDto,
             goods);
         
         await _kafkaProducer.SendMessage(
             _settings.OrderRequestTopic,
             orderId,
             order,
             token);
    }
}