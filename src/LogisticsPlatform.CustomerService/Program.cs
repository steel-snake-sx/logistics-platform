using Microsoft.AspNetCore.Server.Kestrel.Core;
using LogisticsPlatform.CustomerService;

const string LOGISTICS_GRPC_PORT = "LOGISTICS_GRPC_PORT";
const string LOGISTICS_HTTP_PORT = "LOGISTICS_HTTP_PORT";

// Создаем и запускаем веб-хост с настройками по умолчанию и кастомной конфигурацией.
await Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(
        builder => builder.UseStartup<Startup>()
            .ConfigureKestrel(
                option =>
                {
                    // Kestrel для прослушивания gRPC-порта.
                    option.ListenPortByOptions(LOGISTICS_GRPC_PORT, HttpProtocols.Http2);
                    // Kestrel для прослушивания HTTP-порта.
                    option.ListenPortByOptions(LOGISTICS_HTTP_PORT, HttpProtocols.Http1);
                }))
    .Build()
    .RunAsync();