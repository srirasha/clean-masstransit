using Domain.Commands.Trophies;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Messaging.Consumers.Trophies.Unlock
{
    public class UnlockTrophyConsumer : IConsumer<UnlockTrophy>
    {
        private readonly ILogger _logger;

        public UnlockTrophyConsumer(ILogger<UnlockTrophyConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<UnlockTrophy> context)
        {
            _logger.LogInformation("Unlocking trophy: {trophyId}", context.Message.Id);

            return Task.CompletedTask;
        }
    }
}