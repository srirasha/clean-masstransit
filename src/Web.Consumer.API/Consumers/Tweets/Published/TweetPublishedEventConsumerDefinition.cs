using MassTransit;

namespace Web.Consumer.API.Consumers.Tweets.Published
{
    public class TweetPublishedEventConsumerDefinition : ConsumerDefinition<TweetPublishedEventConsumer>
    {
        public TweetPublishedEventConsumerDefinition()
        {
            EndpointName = "tweet-published";
        }

        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<TweetPublishedEventConsumer> consumerConfigurator)
        {
            // configure message retry with millisecond intervals
            endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));

            // use the outbox to prevent duplicate events from being published
            endpointConfigurator.UseInMemoryOutbox();
        }
    }
}