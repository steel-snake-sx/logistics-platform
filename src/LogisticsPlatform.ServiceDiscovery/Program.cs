using Microsoft.AspNetCore.Server.Kestrel.Core;
using LogisticsPlatform.ServiceDiscovery;

await Host
    .CreateDefaultBuilder(args)
    .ConfigureWebHostDefaults(
        builder =>
        {
            builder.UseStartup<Startup>();
            builder.ConfigureAppConfiguration(configurationBuilder => configurationBuilder.AddEnvironmentVariables(prefix: "LOGISTICS_"));
            builder.ConfigureKestrel(options => options.ConfigureEndpointDefaults(x => x.Protocols = HttpProtocols.Http2));
        })
    .Build()
    .RunAsync();