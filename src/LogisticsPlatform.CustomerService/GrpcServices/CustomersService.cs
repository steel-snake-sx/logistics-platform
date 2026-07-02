using Grpc.Core;
using LogisticsPlatform.Gen;

namespace LogisticsPlatform.CustomerService.GrpcServices;

public class CustomersService : Customers.CustomersBase
{
    private static readonly IReadOnlyList<Customer> Customers = Enumerable.Range(1, 100)
        .Select(i => new Customer
        {
            Id = i,
            FirstName = $"Customer{i}",
            LastName = $"Demo{i}",
            MobileNumber = $"+7000000{i:0000}",
            Email = $"customer{i}@example.com",
            DefaultAddress = new Address
            {
                Region = "Demo Region",
                City = "Demo City",
                Street = "Demo Street",
                Building = i.ToString(),
                Apartment = (i % 50 + 1).ToString(),
                Latitude = 55.751244 + i * 0.001,
                Longitude = 37.618423 + i * 0.001
            }
        })
        .ToArray();

    // Реализация gRPC-метода для предоставления данных клиентов генератору.
    public override Task<GetCustomersForGeneratorResponse> GetCustomersForGenerator(
        GetCustomersForGeneratorRequest request, ServerCallContext context)
    {
        var customer = Customers[(request.Id - 1 + Customers.Count) % Customers.Count];
        var response = new GetCustomersForGeneratorResponse
        {
            Id = customer.Id,
            Address = customer.DefaultAddress
        };
        
        return Task.FromResult(response);
    }

    public override Task<CreateCustomerResponse> CreateCustomer(
        CreateCustomerRequest request, ServerCallContext context)
    {
        var response = new CreateCustomerResponse();
        
        return Task.FromResult(response);
    }

    public override Task<GetCustomersResponse> GetCustomers(
        GetCustomersRequest request, ServerCallContext context)
    {
        var response = new GetCustomersResponse();
        response.Customers.AddRange(Customers);
        
        return Task.FromResult(response);
    }

    public override Task<GetCustomerByIdResponse> GetCustomerById(
        GetCustomerByIdRequest request, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.NotFound, "Пользователь не найден"));
    }
}
