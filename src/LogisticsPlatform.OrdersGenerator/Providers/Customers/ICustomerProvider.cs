namespace LogisticsPlatform.OrdersGenerator.Providers.Customers;

public interface ICustomerProvider
{
    Task<CustomerDto> GetRandomCustomer();
}