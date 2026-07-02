namespace LogisticsPlatform.OrdersGenerator.Providers.Customers;

public record CustomerDto(
    long Id,
    string FirstName,
    string LastName,
    AddressDto Address);