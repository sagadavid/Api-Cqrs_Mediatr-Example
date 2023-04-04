using MediatR;
using System.Reflection.Metadata;

namespace CqrsMediatrExample.Behaviour
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
            => _logger = logger;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handl-ing {typeof(TRequest).Name}");

            var response = await next();

            _logger.LogInformation($"Handl-ed {typeof(TResponse).Name}");

            return response;
        }
    }
}
