using Application._Common.Services;
using MassTransit;

namespace Infrastructure.Messaging.Producers
{
    public class CommandsHandler : ICommandMessagesHandler
    {
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public CommandsHandler(ISendEndpointProvider sendEndpointProvider)
        {
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Send(object message, string queueName, CancellationToken cancellationToken)
        {
            ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await endpoint.Send(message, cancellationToken);
        }
    }
}
