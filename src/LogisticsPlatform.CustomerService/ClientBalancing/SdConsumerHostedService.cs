using Grpc.Core;
using LogisticsPlatform.Gen;

namespace LogisticsPlatform.CustomerService.ClientBalancing;

public sealed class SdConsumerHostedService : BackgroundService
{
    private const int SD_TIME_TO_DELAY_MS = 1000; // Задержка перед повторной попыткой при ошибке.
    private readonly SdService.SdServiceClient _client;
    private readonly IDbStore _dbStore;
    private readonly ILogger<SdConsumerHostedService> _logger;

    public SdConsumerHostedService(SdService.SdServiceClient client, IDbStore dbStore, ILogger<SdConsumerHostedService> logger)
    {
        _client = client;
        _dbStore = dbStore;
        _logger = logger;
    }

    // Основная логика фоновой службы, работающей в бесконечном цикле до остановки.
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        // Выполняем задачу, пока приложение не получит сигнал остановки.
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Формируем запрос для получения ресурсов базы данных от SdService.
                var request = new DbResourcesRequest
                {
                    ClusterName = "cluster"
                };

                // Устанавливаем потоковое соединение с SdService для получения данных.
                using var stream = _client.DbResources(request, cancellationToken: stoppingToken);
                // Асинхронно обрабатываем все сообщения из потока.
                await foreach (var response in stream.ResponseStream.ReadAllAsync(stoppingToken))
                {
                    // Логируем полученные данные для отладки и мониторинга.
                    _logger.LogInformation(
                        "Get a new Data from SD. Timestamp {Timestamp}",
                        response.LastUpdated.ToDateTime());

                    var endpoints = GetEndpoints(response);
                    
                    await _dbStore.UpdateEndpointAsync(endpoints);
                }
            }
            catch (RpcException exc)
            {
                // Обрабатываем ошибки RPC, логируем их и делаем паузу перед новой попыткой.
                _logger.LogError(exc, "RPC exception Ошибка получения данных из SD");
                await Task.Delay(SD_TIME_TO_DELAY_MS, stoppingToken);
            }
        }
    }

    private IReadOnlyCollection<DbEndpoint> GetEndpoints(DbResourcesResponse response)
    {
        return response.Replicas.Select(
            r => new DbEndpoint(
                $"{r.Host}:{r.Port}", ToDbReplica(
                    r.Type), r.Buckets.ToArray())).ToArray();
    }

    private static DbReplicaType ToDbReplica(Replica.Types.ReplicaType replicaType)
    {
        return replicaType switch
        {
            Replica.Types.ReplicaType.Master => DbReplicaType.Master,
            Replica.Types.ReplicaType.Sync => DbReplicaType.Sync,
            Replica.Types.ReplicaType.Async => DbReplicaType.Async,
            _ => throw new ArgumentOutOfRangeException(nameof(replicaType), replicaType, null)
        };
    }
}