using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace LogisticsPlatform.CustomerService;

public static class KestrelExtensions
{ 
    // Расширение для Kestrel, упрощающее настройку портов из переменных окружения.
    public static void ListenPortByOptions(
        this KestrelServerOptions option,
        string envOption,
        HttpProtocols httpProtocols)
    {
        // Проверяем, удалось ли получить и распарсить номер порта из переменной окружения.
        var isHttpPortParsed = int.TryParse(Environment.GetEnvironmentVariable(envOption), out var httpPort);

        // Если порт определен, настраиваем прослушивание на всех доступных IP с нужным протоколом.
        if (isHttpPortParsed)
        {
            option.Listen(IPAddress.Any, httpPort, options => options.Protocols = httpProtocols); 
        }
    }
}