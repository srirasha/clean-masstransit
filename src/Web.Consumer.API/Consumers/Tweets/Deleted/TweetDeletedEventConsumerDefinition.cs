using MassTransit;

namespace Web.Consumer.API.Consumers.Tweets.Deleted
{
    public class TweetDeletedEventConsumerDefinition : ConsumerDefinition<TweetDeletedEventConsumer>
    {
        public TweetDeletedEventConsumerDefinition()
        {
            //EndpointName = "tweet-deleted";
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TweetDeletedEventConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}