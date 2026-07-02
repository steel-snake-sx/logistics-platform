namespace LogisticsPlatform.CustomerService.ClientBalancing;

public sealed record DbEndpoint (string HostAndPort, DbReplicaType DbReplica, int[] Buckets);

public enum DbReplicaType
{
    Master = 0,
    Sync = 1,
    Async = 2
}