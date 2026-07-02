namespace LogisticsPlatform.ServiceDiscovery.Configuration;

/// <summary>
/// Хранит данные о реплике БД 
/// </summary>
public record ReplicaInfo(string Host, int Port, int[] Buckets);