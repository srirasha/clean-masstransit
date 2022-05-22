using Application._Common.Services;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Producers
{
    public class MessagesHandler : IMessagesHandler
    {
        private readonly IBus _bus;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public MessagesHandler(IBus bus, ISendEndpointProvider sendEndpointProvider)
        {
            _bus = bus;
            _sendEndpointProvider = sendEndpointProvider;
        }

        public async Task Publish(object message, CancellationToken cancellationToken)
        {
            await _bus.Publish(message, cancellationToken);
        }

        public async Task Send(object message, string queueName, CancellationToken cancellationToken)
        {
            ISendEndpoint endpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{queueName}"));

            await endpoint.Send(message, cancellationToken);
        }
    }
}
