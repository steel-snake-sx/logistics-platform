namespace LogisticsPlatform.CustomerService.ClientBalancing;

public interface IDbStore
{
    Task UpdateEndpointAsync(IReadOnlyCollection<DbEndpoint> endpoints);
}