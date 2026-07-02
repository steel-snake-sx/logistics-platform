using Grpc.Core;
using Grpc.Core.Interceptors;

namespace LogisticsPlatform.OrdersGenerator.Infrastructure;

public class LoggingInterceptor : Interceptor
{
    private readonly ILogger<LoggingInterceptor> _logger;

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        _logger = logger;
    }
    
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request, 
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        // до return код выполнится до вызова клиента
        var result = base.AsyncUnaryCall(request, context, continuation);
        
        _logger.LogInformation("Был произведен вызов ручки {Method} к сервису {Service}", context.Method.Name, context.Method.ServiceName);
        
        return result;
    }
}