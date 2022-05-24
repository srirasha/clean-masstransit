using MassTransit;

namespace Infrastructure.Messaging.Consumers.Trophies.Unlock
{
    public class UnlockTrophyDefinition : ConsumerDefinition<UnlockTrophyConsumer>
    {
        public UnlockTrophyDefinition()
        {
            EndpointName = "trophy.unlock"; // if you want to overload the default name
        }
    }
}