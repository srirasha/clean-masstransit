using Domain.Messages.Trophies;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Consumers.Trophies.Unlock
{
    public class TrophyUnlockMessageConsumer : IConsumer<UnlockTrophyMessage>
    {
        private readonly ILogger _logger;

        public TrophyUnlockMessageConsumer(ILogger<TrophyUnlockMessageConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UnlockTrophyMessage> context)
        {
            _logger.LogInformation("Unlocking trophy: {trophyId}", context.Message.Id);

            return Task.CompletedTask;
        }
    }
}