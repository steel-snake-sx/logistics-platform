using Grpc.Core;
using LogisticsPlatform.Gen;

namespace LogisticsPlatform.CustomerService.GrpcServices;

public class CustomersService : Customers.CustomersBase
{
    // Реализация gRPC-метода для предоставления данных клиентов генератору.
    public override Task<GetCustomersForGeneratorResponse> GetCustomersForGenerator(
        GetCustomersForGeneratorRequest request, ServerCallContext context)
    {
        // Пока возвращаем пустой ответ. Будет логика получения данных клиентов, наверное.
        var response = new GetCustomersForGeneratorResponse();
        
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
        
        return Task.FromResult(response);
    }

    public override Task<GetCustomerByIdResponse> GetCustomerById(
        GetCustomerByIdRequest request, ServerCallContext context)
    {
        throw new RpcException(new Status(StatusCode.NotFound, "Пользователь не найден"));
    }
}