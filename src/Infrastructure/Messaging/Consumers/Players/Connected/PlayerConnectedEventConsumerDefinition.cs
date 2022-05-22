using Infrastructure.Messaging.Consumers.Players.Connected;
using MassTransit;

namespace Infrastructure.Messaging.Events.Players.Connected
{
    public class PlayerConnectedEventConsumerDefinition : ConsumerDefinition<PlayerConnectedEventConsumer>
    {
        public PlayerConnectedEventConsumerDefinition()
        {
            EndpointName = "player.connected";
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<PlayerConnectedEventConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}