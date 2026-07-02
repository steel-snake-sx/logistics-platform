using Google.Protobuf.Collections;
using LogisticsPlatform.Gen;

namespace LogisticsPlatform.OrdersGenerator.Providers.Customers;

public class CustomerProvider : ICustomerProvider
{
    private readonly Gen.Customers.CustomersClient _client;

    public CustomerProvider(Gen.Customers.CustomersClient client)
    {
        _client = client;
    }

    public async Task<CustomerDto> GetRandomCustomer()
    {
        var request = new GetCustomersRequest();

        var customersResponse = await _client.GetCustomersAsync(request);

        var count = customersResponse.Customers.Count;

        var randomCustomer = customersResponse.Customers[Random.Shared.Next(count)];

        return new CustomerDto
        (
            randomCustomer.Id,
            randomCustomer.FirstName,
            randomCustomer.LastName,
            ToAddress(randomCustomer.DefaultAddress)
        );
    }

    private static AddressDto ToAddress(Address address)
    {
        return new AddressDto(
            address.Region,
            address.City,
            address.Street,
            address.Building,
            address.Apartment,
            address.Latitude,
            address.Longitude);
    }
}