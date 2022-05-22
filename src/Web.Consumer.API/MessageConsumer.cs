using Domain;
using MassTransit;

namespace Web.Consumer.API
{
    public class MessageConsumer : IConsumer<Message>
    {
        private readonly ILogger _logger;

        public MessageConsumer(ILogger<MessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<Message> context)
        {
            return Task.FromResult(() => _logger.LogInformation("Message received: {Message}", context.Message.Text));
        }
    }
}