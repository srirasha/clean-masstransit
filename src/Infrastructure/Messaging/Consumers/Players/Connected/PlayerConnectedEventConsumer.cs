using Domain.Events.Players;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Consumers.Players.Connected
{
    public class PlayerConnectedEventConsumer : IConsumer<PlayerConnected>
    {
        private readonly ILogger _logger;

        public PlayerConnectedEventConsumer(ILogger<PlayerConnectedEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<PlayerConnected> context)
        {
            _logger.LogInformation("Player connected: {connectedPlayerId}", context.Message.Id);

            return Task.CompletedTask;
        }
    }
}