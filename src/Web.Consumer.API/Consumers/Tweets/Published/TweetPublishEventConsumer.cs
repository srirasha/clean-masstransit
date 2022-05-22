using Domain.Events.Tweets;
using MassTransit;

namespace Web.Consumer.API.Consumers.Tweets.Published
{
    public class TweetPublishEventConsumer : IConsumer<TweetPublishedEvent>
    {
        private readonly ILogger _logger;

        public TweetPublishEventConsumer(ILogger<TweetPublishEventConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<TweetPublishedEvent> context)
        {
            _logger.LogInformation("Message received: {Tweet}", context.Message.Text);

            return Task.CompletedTask;
        }
    }
}