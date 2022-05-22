using Domain.Events.Players;
using MassTransit;

namespace Web.Consumer.API.Consumers.Players.Connected
{
    public class PlayerConnectedEventConsumer : IConsumer<PlayerConnectedEvent>
    {
        private readonly ILogger _logger;

        public PlayerConnectedEventConsumer(ILogger<PlayerConnectedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PlayerConnectedEvent> context)
        {
            _logger.LogInformation("Player connected: {connectedPlayerId}", context.Message.Id);

            return Task.CompletedTask;
        }
    }
}