using MassTransit;

namespace Infrastructure.Messaging.Consumers.Trophies.Unlock
{
    public class UnlockTrophyCommandDefinition : ConsumerDefinition<UnlockTrophyCommandConsumer>
    {
        public UnlockTrophyCommandDefinition()
        {
            EndpointName = "trophy.unlock";

        }
    }
}